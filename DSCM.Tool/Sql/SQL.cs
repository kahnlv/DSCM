using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using dscm.Library;
using System.Data.SqlClient;
using System.Reflection;
using DSCM.Config;
using System.Data;

namespace dscm.Tools.Sql
{
    public class SQL
    {
        public static string Extion = "";
        /// <summary>
        /// 总条数
        /// </summary>
        public static int AllCount = 0;
        /// <summary>
        /// 总页数
        /// </summary>
        public static int AllPageCount = 0;
        public static string Sql = "";
        public static void CreadSql(string name, string tbl_doc, ArrayList colum, ArrayList type_length, ArrayList doc)
        {
            string sql = "";
            if (colum.Count == type_length.Count && type_length.Count == doc.Count)
            {
                sql = "select count(*) from [table] where table_name = '" + name + "'";
                object count = SqlCon.GetScalar(sql);
                bool bl = false;
                if (null == count) { bl = false; }
                else
                {
                    bl = true;
                }

                if (bl)
                {
                    string guid = Guid.NewGuid().ToString();
                    sql = "insert into [table] (table_id,table_name,type) values ('" + guid + "','" + name + "','" + tbl_doc + "')";
                    SqlCon.UpLoad(sql);
                    for (int i = 0; i < colum.Count; i++)
                    {
                        sql = "insert into Columns(Columns_id,Columns_name,table_id,type,type_length,doc)"
                        + "values"
                        + "(newid(),'" + colum[i] + "','" + guid + "','varchar','" + type_length[i] + "','" + doc[i] + "')";
                        SqlCon.UpLoad(sql);
                    }


                    sql = "CREATE TABLE [dscm_" + name + "]("
                    + " [dscm_" + name + "_id] [varchar](50) COLLATE Chinese_PRC_CI_AS NOT NULL,";
                    for (int i = 0; i < colum.Count; i++)
                    {

                        sql += " [" + colum[i] + "] [varchar](" + type_length[i] + ") COLLATE Chinese_PRC_CI_AS NULL,";
                    }
                    sql += " [dscm_type] [varchar](50) COLLATE Chinese_PRC_CI_AS NULL,)";
                    SqlCon.UpLoad(sql);
                }
            }
        }

        /// <summary>
        /// 读取单条数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="table">表</param>
        /// <returns></returns>
        public static T Read<T>(string table, string where)
        {
            T model = Activator.CreateInstance<T>();
            try
            {
                string sql = "select top 1 * ";
                if (where.ToLower().Trim().IndexOf("and") == 0)
                {
                    sql = sql + " from " + table + " where 1=1 " + where;
                }
                else
                {
                    if (where.Length > 0)
                    {
                        sql = sql + " from " + table + " where " + where;
                    }
                    else
                    {
                        sql = sql + " from " + table;
                    }
                }
                Sql = sql;
                DataSet ds = SqlCon.Read(sql);
                if (0 < ds.Tables[0].Rows.Count)
                {
                    string columName = "";
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        PropertyInfo[] proInfo = model.GetType().GetProperties();

                        foreach (DataColumn col in dr.Table.Columns)
                        {
                            columName = col.ColumnName;
                            foreach (var p in proInfo)
                            {
                                if (columName.ToLower().Equals(p.Name.ToLower()))
                                {
                                    object value = dr[columName];
                                    p.SetValue(model, HConvertByType(value, p.PropertyType), null);
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex) { if (PageConfig.DEBUG.Equals("1")) { Extion = ex.ToString(); } }
            return model;
        }

        /// <summary>
        /// 读取单条数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="table">表</param>
        /// <returns></returns>
        public static T Read<T>(string table, string[] colm, string where)
        {
            T model = Activator.CreateInstance<T>();
            try
            {
                string sql = "select top 1 ";
                string _s = "";
                for (int i = 0; i < colm.Length; i++)
                {
                    if ((i + 1) == colm.Length)
                    {
                        _s += colm[i];
                    }
                    else
                    {
                        _s += colm[i] + ",";
                    }
                }
                if (where.ToLower().Trim().IndexOf("and") == 0)
                {
                    sql = sql + _s + " from " + table + " where 1=1 " + where;
                }
                else
                {
                    if (where.Length > 0)
                    {
                        sql = sql + _s + " from " + table + " where " + where;
                    }
                    else
                    {
                        sql = sql + _s + " from " + table;
                    }
                }
                Sql = sql;
                DataSet ds = SqlCon.Read(sql);
                if (0 < ds.Tables[0].Rows.Count)
                {
                    string columName = "";
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        PropertyInfo[] proInfo = model.GetType().GetProperties();

                        foreach (DataColumn col in dr.Table.Columns)
                        {
                            columName = col.ColumnName;
                            foreach (var p in proInfo)
                            {
                                if (columName.ToLower().Equals(p.Name.ToLower()))
                                {
                                    object value = dr[columName];
                                    p.SetValue(model, HConvertByType(value, p.PropertyType), null);
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex) { if (PageConfig.DEBUG.Equals("1")) { Extion = ex.ToString(); } }
            return model;
        }

        /// <summary>
        /// 读取多条数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql">sql语句</param>
        /// <returns></returns>
        public static T[] ReadAll<T>(string sql)
        {
            try
            {
                DataSet ds = SqlCon.Read(sql);
                ArrayList _al = new ArrayList();
                if (0 < ds.Tables[0].Rows.Count)
                {
                    string columName = "";
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        T model = Activator.CreateInstance<T>();
                        PropertyInfo[] proInfo = model.GetType().GetProperties();

                        foreach (DataColumn col in dr.Table.Columns)
                        {
                            columName = col.ColumnName;
                            foreach (var p in proInfo)
                            {
                                if (columName.ToLower().Equals(p.Name.ToLower()))
                                {
                                    object value = dr[columName];
                                    p.SetValue(model, HConvertByType(value, p.PropertyType), null);
                                }
                            }
                        }
                        _al.Add(model);
                    }
                }
                T[] t = new T[_al.Count];
                for (int i = 0; i < _al.Count; i++)
                {
                    t[i] = (T)_al[i];
                }
                return t;
            }
            catch (Exception ex) { if (PageConfig.DEBUG.Equals("1")) { Extion = ex.ToString(); } }
            return null;
        }
        /// <summary>
        /// 获取总条数
        /// </summary>
        /// <param name="table">表</param>
        /// <returns></returns>
        public static int Read(string table, string where)
        {
            try
            {
                string sql = "select count(0) from " + table;
                if (where.ToLower().Trim().IndexOf("and") == 0)
                {
                    sql += " where 1=1 " + where;
                }
                else
                {
                    if (where.Length > 0)
                    {
                        sql += " where " + where;
                    }
                }

                object count;
                count = SqlCon.GetScalar(sql);

                if (null != count)
                {
                    return Convert.ToInt32(count);
                }
                else
                {
                    return 0;
                }
            }
            catch (Exception ex) { if (PageConfig.DEBUG.Equals("1")) { Extion = ex.ToString(); } }
            return 0;
        }

        /// <summary>
        /// 分页
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="table"></param>
        /// <param name="colm"></param>
        /// <param name="where"></param>
        /// <param name="pcount">当前页数</param>
        /// <param name="fcount">每页最大条数</param>
        /// <param name="orderColm">排序字段 </param>
        /// <param name="order">排序（正序，倒序）</param>
        /// <returns></returns>
        public static T[] ReadAll<T>(string table, string[] colm, string where, int pcount, int fcount, string orderColm, bool order)
        {
            try
            {
                AllCount = Read(table, where);
                if (AllCount % fcount == 0)
                {
                    AllPageCount = AllCount / fcount;
                }
                else
                {
                    AllPageCount = (AllCount / fcount) + 1;
                }

                string px = "";
                if (order) px = " order by " + orderColm + " asc "; else px = " order by " + orderColm + " desc ";

                string sql = "select ";
                string _s = "";
                if (colm != null)
                {
                    for (int i = 0; i < colm.Length; i++)
                    {
                        if ((i + 1) == colm.Length)
                        {
                            _s += colm[i];
                        }
                        else
                        {
                            _s += colm[i] + ",";
                        }
                    }
                    if (colm.Length == 0) _s = " * ";
                }
                else
                {
                    _s = " * ";
                }
                sql = sql + _s + " from " + " (select row_number()over(order by " + orderColm + ")rownumber,* from " + table + ")a " + " where 1=1 " + where + " and rownumber between " + ((pcount - 1) * fcount + 1) + " and " + pcount * fcount + px;
                Sql = sql;
                DataSet ds = SqlCon.Read(sql);
                ArrayList _al = new ArrayList();
                if (0 < ds.Tables[0].Rows.Count)
                {
                    string columName = "";
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        T model = Activator.CreateInstance<T>();
                        PropertyInfo[] proInfo = model.GetType().GetProperties();

                        foreach (DataColumn col in dr.Table.Columns)
                        {
                            columName = col.ColumnName;
                            foreach (var p in proInfo)
                            {
                                if (columName.ToLower().Equals(p.Name.ToLower()))
                                {
                                    object value = dr[columName];
                                    p.SetValue(model, HConvertByType(value, p.PropertyType), null);
                                }
                            }
                        }
                        _al.Add(model);
                    }
                }
                T[] t = new T[_al.Count];
                for (int i = 0; i < _al.Count; i++)
                {
                    t[i] = (T)_al[i];
                }
                return t;
            }
            catch (Exception ex) { if (PageConfig.DEBUG.Equals("1")) { Extion = ex.ToString(); } }
            return null;
        }

        /// <summary>
        /// 分页
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="table"></param>
        /// <param name="where"></param>
        /// <param name="pcount">当前页数</param>
        /// <param name="fcount">每页最大条数</param>
        /// <param name="orderColm">排序字段 </param>
        /// <param name="order">排序（正序，倒序）</param>
        /// <returns></returns>
        public static T[] ReadAll<T>(string table, string where, int pcount, int fcount, string orderColm, bool order)
        {
            try
            {
                AllCount = Read(table, where);
                if (AllCount % fcount == 0)
                {
                    AllPageCount = AllCount / fcount;
                }
                else
                {
                    AllPageCount = (AllCount / fcount) + 1;
                }

                string px = "";
                if (order) px = " asc "; else px = "  desc ";

                string sql = "select ";
                string _s = " * ";
                sql = sql + _s + " from " + " (select row_number()over(order by " + orderColm + " " + px + ")rownumber,* from " + table + " where 1=1 " + where + ")a " + " where 1=1  and rownumber between " + ((pcount - 1) * fcount + 1) + " and " + pcount * fcount + where;
                Sql = sql;
                DataSet ds = SqlCon.Read(sql);
                ArrayList _al = new ArrayList();
                if (0 < ds.Tables[0].Rows.Count)
                {
                    string columName = "";
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        T model = Activator.CreateInstance<T>();
                        PropertyInfo[] proInfo = model.GetType().GetProperties();

                        foreach (DataColumn col in dr.Table.Columns)
                        {
                            columName = col.ColumnName;
                            foreach (var p in proInfo)
                            {
                                if (columName.ToLower().Equals(p.Name.ToLower()))
                                {
                                    object value = dr[columName];
                                    p.SetValue(model, HConvertByType(value, p.PropertyType), null);
                                }
                            }
                        }
                        _al.Add(model);
                    }
                }
                T[] t = new T[_al.Count];
                for (int i = 0; i < _al.Count; i++)
                {
                    t[i] = (T)_al[i];
                }
                return t;
            }
            catch (Exception ex) { if (PageConfig.DEBUG.Equals("1")) { Extion = ex.ToString(); } }
            return null;
        }

        /// <summary>
        /// 读取多条数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="table">表</param>
        /// <param name="colm">字段</param>
        /// <param name="where">条件</param>
        /// <returns></returns>
        public static T[] ReadAll<T>(string table, string[] colm, string where)
        {
            try
            {
                string sql = "select ";
                string _s = "";
                for (int i = 0; i < colm.Length; i++)
                {
                    if ((i + 1) == colm.Length)
                    {
                        _s += colm[i];
                    }
                    else
                    {
                        _s += colm[i] + ",";
                    }
                }
                if (where.ToLower().Trim().IndexOf("and") == 0 || where.ToLower().Trim().IndexOf("order") == 0)
                {
                    sql = sql + _s + " from " + table + " where 1=1 " + where;
                }
                else
                {
                    if (where.Length > 0)
                    {
                        sql = sql + _s + " from " + table + " where " + where;
                    }
                    else
                    {
                        sql = sql + _s + " from " + table;
                    }
                }
                Sql = sql;
                DataSet ds = SqlCon.Read(sql);
                ArrayList _al = new ArrayList();
                if (0 < ds.Tables[0].Rows.Count)
                {
                    string columName = "";
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        T model = Activator.CreateInstance<T>();
                        PropertyInfo[] proInfo = model.GetType().GetProperties();

                        foreach (DataColumn col in dr.Table.Columns)
                        {
                            columName = col.ColumnName;
                            foreach (var p in proInfo)
                            {
                                if (columName.ToLower().Equals(p.Name.ToLower()))
                                {
                                    object value = dr[columName];
                                    p.SetValue(model, HConvertByType(value, p.PropertyType), null);
                                }
                            }
                        }
                        _al.Add(model);
                    }
                }
                T[] t = new T[_al.Count];
                for (int i = 0; i < _al.Count; i++)
                {
                    t[i] = (T)_al[i];
                }
                return t;
            }
            catch (Exception ex) { if (PageConfig.DEBUG.Equals("1")) { Extion = ex.ToString(); } }
            return null;
        }
        /// <summary>
        /// 读取多条数据
        /// </summary>
        /// <typeparam name="T">对象</typeparam>
        /// <param name="table">表名</param>
        /// <param name="where">条件</param>
        /// <param name="count">读取条数</param>
        /// <returns></returns>
        public static T[] ReadAll<T>(string table, string where, int count)
        {
            try
            {
                string sql = "select top " + count + " * ";
                if (where.ToLower().Trim().IndexOf("and") == 0 || where.ToLower().Trim().IndexOf("order") == 0)
                {
                    sql = sql + " from " + table + " where 1=1 " + where;
                }
                else
                {
                    if (where.Length > 0)
                    {
                        sql = sql + " from " + table + " where " + where;
                    }
                    else
                    {
                        sql = sql + " from " + table;
                    }
                }

                DataSet ds = SqlCon.Read(sql);
                ArrayList _al = new ArrayList();
                if (0 < ds.Tables[0].Rows.Count)
                {
                    string columName = "";
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        T model = Activator.CreateInstance<T>();
                        PropertyInfo[] proInfo = model.GetType().GetProperties();

                        foreach (DataColumn col in dr.Table.Columns)
                        {
                            columName = col.ColumnName;
                            foreach (var p in proInfo)
                            {
                                if (columName.ToLower().Equals(p.Name.ToLower()))
                                {
                                    object value = dr[columName];
                                    p.SetValue(model, HConvertByType(value, p.PropertyType), null);
                                }
                            }
                        }
                        _al.Add(model);
                    }
                }
                T[] t = new T[_al.Count];
                for (int i = 0; i < _al.Count; i++)
                {
                    t[i] = (T)_al[i];
                }
                return t;
            }
            catch (Exception ex) { if (PageConfig.DEBUG.Equals("1")) { Extion = ex.ToString(); } }
            return null;
        }

        /// <summary>
        /// 读取多条数据
        /// </summary>
        /// <typeparam name="T">对象</typeparam>
        /// <param name="table">表名</param>
        /// <param name="where">条件</param>
        /// <param name="count">读取条数</param>
        /// <returns></returns>
        public static T[] ReadAll<T>(string table, string where)
        {
            try
            {
                string sql = "select * ";
                if (where.ToLower().Trim().IndexOf("and") == 0 || where.ToLower().Trim().IndexOf("order") == 0)
                {
                    sql = sql + " from " + table + " where 1=1 " + where;
                }
                else
                {
                    if (where.Length > 0)
                    {
                        sql = sql + " from " + table + " where " + where;
                    }
                    else
                    {
                        sql = sql + " from " + table;
                    }
                }
                DataSet ds = SqlCon.Read(sql);
                ArrayList _al = new ArrayList();
                if (0 < ds.Tables[0].Rows.Count)
                {
                    string columName = "";
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        T model = Activator.CreateInstance<T>();
                        PropertyInfo[] proInfo = model.GetType().GetProperties();

                        foreach (DataColumn col in dr.Table.Columns)
                        {
                            columName = col.ColumnName;
                            foreach (var p in proInfo)
                            {
                                if (columName.ToLower().Equals(p.Name.ToLower()))
                                {
                                    object value = dr[columName];
                                    p.SetValue(model, HConvertByType(value, p.PropertyType), null);
                                }
                            }
                        }
                        _al.Add(model);
                    }
                }
                T[] t = new T[_al.Count];
                for (int i = 0; i < _al.Count; i++)
                {
                    t[i] = (T)_al[i];
                }
                return t;
            }
            catch (Exception ex)
            {
                if (PageConfig.DEBUG.Equals("1")) { Extion = ex.ToString(); }
            }
            return null;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="table">表名</param>
        /// <param name="colm">字段数组</param>
        /// <param name="where">条件 要 and 1=1</param>
        /// <returns></returns>
        public static int Insert(string table, string[] colm, string[] value)
        {
            try
            {
                if (colm.Length == value.Length)
                {
                    string _s = string.Join(",", colm);
                    string _v = "";

                    for (int i = 0; i < value.Length; i++)
                    {
                        if ((i + 1) == value.Length)
                        {
                            _v += "'" + value[i] + "'";
                        }
                        else
                        {
                            _v += "'" + value[i] + "',";
                        }
                    }
                    string sql = "insert into " + table + "(" + _s + ") values (" + _v + ")";
                    Sql = sql;
                    return SqlCon.UpLoad(sql);
                }
            }
            catch (Exception ex) { if (PageConfig.DEBUG.Equals("1")) { Extion = ex.ToString(); } }
            return -1;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="table">表名</param>
        /// <param name="colm">字段数组</param>
        /// <param name="value">字段对应数据数组</param>
        /// <param name="where">条件 要 and 1=1</param>
        /// <returns></returns>
        public static int Update(string table, string[] colm, string[] value, string where)
        {
            try
            {
                if (colm.Length == value.Length)
                {
                    string _s = "";
                    if (colm.Length == value.Length)
                    {
                        for (int i = 0; i < colm.Length; i++)
                        {
                            if ((i + 1) == colm.Length)
                            {
                                _s += colm[i] + "='" + value[i] + "'";
                            }
                            else
                            {
                                _s += colm[i] + "='" + value[i] + "',";
                            }
                        }
                    }

                    string sql = "";
                    if (where.ToLower().Trim().IndexOf("and") == 0)
                    {
                        sql = "update " + table + " set " + _s + " where 1=1 " + where;
                    }
                    else
                    {
                        if (where.Length > 0)
                        {
                            sql = "update " + table + " set " + _s + " where " + where;
                        }
                        else
                        {
                            sql = "update " + table + " set " + _s;
                        }
                    }

                    Sql = sql;
                    return SqlCon.UpLoad(sql);
                }
            }
            catch (Exception ex) { if (PageConfig.DEBUG.Equals("1")) { Extion = ex.ToString(); } }
            return -1;
        }
        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="table">表名</param>
        /// <param name="where">条件 要 and 1=1</param>
        /// <returns></returns>
        public static int Delete(string table, string where)
        {
            try
            {
                string sql = "";
                if (where.ToLower().Trim().IndexOf("and") == 0)
                {
                    sql = "delete from " + table + " where 1=1 " + where;
                }
                else
                {
                    if (where.Length > 0)
                    {
                        sql = "delete from " + table + " where " + where;
                    }
                    else
                    {
                        sql = "delete from " + table;
                    }
                }
                return SqlCon.UpLoad(sql);
            }
            catch (Exception ex) { if (PageConfig.DEBUG.Equals("1")) { Extion = ex.ToString(); } }
            return 0;
        }

        /// <summary>
        /// 根据TYPE进行转换
        /// </summary>
        /// <param name="o"></param>
        /// <param name="pptypeName"></param>
        /// <returns></returns>
        public static object HConvertByType(object val, Type type)
        {
            Type valtype = type;
            string pptypeName = valtype.Name,
                   pptypeFullName = valtype.FullName;

            if (pptypeName.LastIndexOf("int") != -1)
            {
                return Convert.ToInt32(val);
            }
            else if (pptypeName == "DateTime")
            {
                return Convert.ToDateTime(val);
            }
            else if (pptypeName == "String")
            {
                return Convert.ToString(val);
            }
            else if (pptypeName == "Decimal")
            {
                return Convert.ToDecimal(val);
            }
            else if (pptypeName == "Nullable`1")
            {

                if (pptypeFullName.LastIndexOf("Int") != -1)
                {
                    if ((val + "").Length > 0)
                    {
                        int tempInt = 0;
                        int.TryParse(val.ToString(), out tempInt);
                        return tempInt;
                    }
                    else
                        return null;
                }
                else if (pptypeFullName.LastIndexOf("DateTime") != -1)
                {
                    if ((val + "").Length > 0)
                    {
                        DateTime tempDate = DateTime.Now;
                        DateTime.TryParse(val.ToString(), out tempDate);
                        return tempDate;
                    }
                    else
                        return null;
                }
                else if (pptypeFullName.LastIndexOf("String") != -1)
                {
                    return Convert.ToString(val);
                }
                else if (pptypeFullName.LastIndexOf("Decimal") != -1)
                {
                    if ((val + "").Length > 0)
                    {
                        Decimal tempDecimal = 0;
                        Decimal.TryParse(val.ToString(), out tempDecimal);
                        return tempDecimal;
                    }
                    else
                        return null;
                }
            }
            return val;
        }
    }
}
