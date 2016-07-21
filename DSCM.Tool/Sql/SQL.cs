using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using dscm.Library;
using System.Data.SqlClient;
using System.Reflection;
using DSCM.Config;

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
            SqlCon sc = new SqlCon();
            if (sc != null)
            {
                if (colum.Count == type_length.Count && type_length.Count == doc.Count)
                {
                    sql = "select count(*) from [table] where table_name = '" + name + "'";
                    SqlDataReader sdr = sc.Read(sql);
                    bool bl = false;
                    if (sdr == null) { bl = false; }
                    else
                    {
                        while (sdr.Read())
                        {
                            if (sdr.GetValue(0).ToString().Equals("0"))
                            {
                                bl = true;
                            }
                        }
                        sdr.Close();
                        sdr.Dispose();
                    }

                    if (bl)
                    {
                        string guid = Guid.NewGuid().ToString();
                        sql = "insert into [table] (table_id,table_name,type) values ('" + guid + "','" + name + "','" + tbl_doc + "')";
                        sc.UpLoad(sql);
                        for (int i = 0; i < colum.Count; i++)
                        {
                            sql = "insert into Columns(Columns_id,Columns_name,table_id,type,type_length,doc)"
                            + "values"
                            + "(newid(),'" + colum[i] + "','" + guid + "','varchar','" + type_length[i] + "','" + doc[i] + "')";
                            sc.UpLoad(sql);
                        }


                        sql = "CREATE TABLE [dscm_" + name + "]("
                        + " [dscm_" + name + "_id] [varchar](50) COLLATE Chinese_PRC_CI_AS NOT NULL,";
                        for (int i = 0; i < colum.Count; i++)
                        {

                            sql += " [" + colum[i] + "] [varchar](" + type_length[i] + ") COLLATE Chinese_PRC_CI_AS NULL,";
                        }
                        sql += " [dscm_type] [varchar](50) COLLATE Chinese_PRC_CI_AS NULL,)";
                        sc.UpLoad(sql);
                    }
                }
            }
            sc.Close();
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
                    sql = sql + " from " + table + " where " + where;
                }
                Sql = sql;
                SqlCon sc = new SqlCon();
                SqlDataReader sdr = sc.Read(sql);
                ArrayList _al = new ArrayList();

                if (sdr != null)
                {
                    while (sdr.Read())
                    {
                        PropertyInfo[] pi = model.GetType().GetProperties();
                        for (int j = 0; j < pi.Length; j++)
                        {
                            for (int i = 0; i < sdr.FieldCount; i++)
                            {
                                if (pi[j].Name.ToLower() == sdr.GetName(i).ToLower())
                                {
                                    object obj = sdr.GetValue(i);
                                    pi[j].SetValue(model, obj.ToString(), null);
                                }
                            }
                        }
                    }
                    sdr.Close();
                    sdr.Dispose();
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
                    sql = sql + _s + " from " + table + " where " + where;
                }
                Sql = sql;
                SqlCon sc = new SqlCon();
                SqlDataReader sdr = sc.Read(sql);
                ArrayList _al = new ArrayList();

                if (sdr != null)
                {
                    while (sdr.Read())
                    {
                        PropertyInfo[] pi = model.GetType().GetProperties();
                        for (int j = 0; j < pi.Length; j++)
                        {
                            for (int i = 0; i < sdr.FieldCount; i++)
                            {
                                if (pi[j].Name.ToLower() == sdr.GetName(i).ToLower())
                                {
                                    object obj = sdr.GetValue(i);
                                    pi[j].SetValue(model, obj.ToString(), null);
                                }
                            }
                        }
                    }
                    sdr.Close();
                    sdr.Dispose();
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
                SqlCon sc = new SqlCon();
                SqlDataReader sdr = sc.Read(sql);
                ArrayList _al = new ArrayList();
                if (sdr != null)
                {
                    while (sdr.Read())
                    {
                        T model = Activator.CreateInstance<T>();
                        PropertyInfo[] pi = model.GetType().GetProperties();
                        for (int j = 0; j < pi.Length; j++)
                        {
                            for (int i = 0; i < sdr.FieldCount; i++)
                            {
                                if (pi[j].Name.ToLower() == sdr.GetName(i).ToLower())
                                {
                                    object obj = sdr.GetValue(i);
                                    pi[j].SetValue(model, obj.ToString(), null);
                                }
                            }
                        }
                        _al.Add(model);
                    }
                    sdr.Close();
                    sdr.Dispose();
                }
                sc.Close();
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
                    sql += " where " + where;
                }

                int count = 0;
                string con = "";
                SqlCon sc = new SqlCon();
                SqlDataReader sdr = sc.Read(sql);
                ArrayList _al = new ArrayList();
                if (sdr != null)
                {
                    while (sdr.Read())
                    {
                        con = sdr.GetValue(0).ToString();
                    }
                    sdr.Close();
                    sdr.Dispose();
                }
                sc.Close();
                int.TryParse(con, out count);
                return count;
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
                SqlCon sc = new SqlCon();
                SqlDataReader sdr = sc.Read(sql);
                ArrayList _al = new ArrayList();
                if (sdr != null)
                {
                    while (sdr.Read())
                    {
                        T model = Activator.CreateInstance<T>();
                        PropertyInfo[] pi = model.GetType().GetProperties();
                        for (int j = 0; j < pi.Length; j++)
                        {
                            for (int i = 0; i < sdr.FieldCount; i++)
                            {
                                if (pi[j].Name.ToLower() == sdr.GetName(i).ToLower())
                                {
                                    object obj = sdr.GetValue(i);
                                    pi[j].SetValue(model, obj.ToString(), null);
                                }
                            }
                        }
                        _al.Add(model);
                    }
                    sdr.Close();
                    sdr.Dispose();
                }
                sc.Close();
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
                SqlCon sc = new SqlCon();
                SqlDataReader sdr = sc.Read(sql);
                ArrayList _al = new ArrayList();
                if (sdr != null)
                {
                    while (sdr.Read())
                    {
                        T model = Activator.CreateInstance<T>();
                        PropertyInfo[] pi = model.GetType().GetProperties();
                        for (int j = 0; j < pi.Length; j++)
                        {
                            for (int i = 0; i < sdr.FieldCount; i++)
                            {
                                if (pi[j].Name.ToLower() == sdr.GetName(i).ToLower())
                                {
                                    object obj = sdr.GetValue(i);
                                    pi[j].SetValue(model, obj.ToString(), null);
                                }
                            }
                        }
                        _al.Add(model);
                    }
                    sdr.Close();
                    sdr.Dispose();
                }
                sc.Close();
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
                    sql = sql + _s + " from " + table + " where " + where;
                }
                Sql = sql;
                SqlCon sc = new SqlCon();
                SqlDataReader sdr = sc.Read(sql);
                ArrayList _al = new ArrayList();
                if (sdr != null)
                {
                    while (sdr.Read())
                    {
                        T model = Activator.CreateInstance<T>();
                        PropertyInfo[] pi = model.GetType().GetProperties();
                        for (int j = 0; j < pi.Length; j++)
                        {
                            for (int i = 0; i < sdr.FieldCount; i++)
                            {
                                if (pi[j].Name.ToLower() == sdr.GetName(i).ToLower())
                                {
                                    object obj = sdr.GetValue(i);
                                    pi[j].SetValue(model, obj.ToString(), null);
                                }
                            }
                        }
                        _al.Add(model);
                    }
                    sdr.Close();
                    sdr.Dispose();
                }
                sc.Close();
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
                    sql = sql + " from " + table + " where " + where;
                }

                SqlCon sc = new SqlCon();
                SqlDataReader sdr = sc.Read(sql);
                ArrayList _al = new ArrayList();
                if (sdr != null)
                {
                    while (sdr.Read())
                    {
                        T model = Activator.CreateInstance<T>();
                        PropertyInfo[] pi = model.GetType().GetProperties();
                        for (int j = 0; j < pi.Length; j++)
                        {
                            for (int i = 0; i < sdr.FieldCount; i++)
                            {
                                if (pi[j].Name.ToLower() == sdr.GetName(i).ToLower())
                                {
                                    object obj = sdr.GetValue(i);
                                    pi[j].SetValue(model, obj.ToString(), null);
                                }
                            }
                        }
                        _al.Add(model);
                    }
                    sdr.Close();
                    sdr.Dispose();
                }
                sc.Close();
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
                    sql = sql + " from " + table + " where " + where;
                }

                SqlCon sc = new SqlCon();
                SqlDataReader sdr = sc.Read(sql);
                ArrayList _al = new ArrayList();
                if (sdr != null)
                {
                    while (sdr.Read())
                    {
                        T model = Activator.CreateInstance<T>();
                        PropertyInfo[] pi = model.GetType().GetProperties();
                        for (int j = 0; j < pi.Length; j++)
                        {
                            for (int i = 0; i < sdr.FieldCount; i++)
                            {
                                if (pi[j].Name.ToLower() == sdr.GetName(i).ToLower())
                                {
                                    object obj = sdr.GetValue(i);
                                    pi[j].SetValue(model, obj.ToString(), null);
                                }
                            }
                        }
                        _al.Add(model);
                    }
                    sdr.Close();
                    sdr.Dispose();
                }
                sc.Close();
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
                    SqlCon sc = new SqlCon();
                    int ii = sc.UpLoad(sql);
                    sc.Close();
                    return ii;
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
                        sql = "update " + table + " set " + _s + " where " + where;
                    }
                    
                    Sql = sql;
                    SqlCon sc = new SqlCon();
                    int ii = sc.UpLoad(sql);
                    sc.Close();
                    return ii;
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
                    sql = "delete from " + table + " where " + where;
                }
                SqlCon sc = new SqlCon();
                int ii = sc.UpLoad(sql);
                sc.Close();
                return ii;
            }
            catch (Exception ex) { if (PageConfig.DEBUG.Equals("1")) { Extion = ex.ToString(); } }
            return 0;
        }
    }
}
