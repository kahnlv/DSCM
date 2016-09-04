using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using DSCM.Config;
using System.Data;

namespace dscm.Library
{
    public class SqlCon
    {
        public static SqlConnection Connection
        {
            get
            {
                SqlConnection conn = new SqlConnection(PageConfig.SqlCon);

                if (conn.State == System.Data.ConnectionState.Closed)
                {
                    conn.Open();
                }
                else if (conn.State == System.Data.ConnectionState.Broken)
                {
                    conn.Close();
                    conn.Open();
                }

                return conn;
            }
        }

        public void Close(SqlConnection conn)
        {
            if (null != conn)
            {
                if (System.Data.ConnectionState.Open == conn.State)
                {
                    conn.Close();
                }
            }
        }

        public void Dispose(SqlConnection conn)
        {
            if (null != conn)
            {
                conn.Dispose();
                conn = null;
            }
        }

        public static DataSet Read(string sqlStr)
        {
            using (SqlConnection conn = new SqlConnection(PageConfig.SqlCon))
            {
                SqlCommand cmd = new SqlCommand();
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    DataSet ds = new DataSet();
                    GetParameters(conn, cmd, sqlStr, null, null);
                    try
                    {
                        da.Fill(ds);

                    }
                    catch (SqlException e)
                    {
                        throw new Exception(e.Message);
                    }

                    return ds;
                }
            }
        }

        public static int UpLoad(string sql)
        {
            int ret = 0;
            using (SqlConnection conn = new SqlConnection(PageConfig.SqlCon))
            {
                using (SqlTransaction trans = conn.BeginTransaction())
                {
                    SqlCommand cmd = new SqlCommand();
                    try
                    {
                        GetParameters(conn, cmd, sql, trans, null);
                        ret = cmd.ExecuteNonQuery();
                        trans.Commit();
                    }
                    catch (SqlException e)
                    {
                        trans.Rollback();
                        throw new Exception(e.Message);
                    }
                    return ret;
                }
            }
        }

        /// <summary>
        /// 执行SQL语句，返回影响的记录数
        /// </summary>
        /// <param name="sqlStr">SQL语句(用在增 删 改)</param>
        /// <returns>影响的记录数</returns>
        public static int ExecuteSql(string sqlStr, SqlParameter[] paras)
        {
            using (SqlConnection conn = new SqlConnection(PageConfig.SqlCon))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    try
                    {
                        GetParameters(conn, cmd, sqlStr, null, paras);
                        int rows = cmd.ExecuteNonQuery();
                        cmd.Parameters.Clear();
                        return rows;
                    }
                    catch (SqlException e)
                    {
                        throw new Exception(e.Message);
                        //return 0;
                    }
                }
            }
        }
        /// <summary>
        /// 执行一条计算查询结果语句，返回查询结果
        /// </summary>
        /// <param name="sqlStr"></param>
        /// <returns></returns>
        public static object GetScalar(string sqlStr)
        {
            using (SqlConnection conn = new SqlConnection(PageConfig.SqlCon))
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = sqlStr;
                    object ret = cmd.ExecuteScalar();
                    if (ret == null)
                    {
                        return null;
                    }
                    else
                    {
                        return ret;
                    }
                }
            }
        }


        public static void GetParameters(SqlConnection conn, SqlCommand cmd, string sqlStr, SqlTransaction trans, SqlParameter[] cmdParams)
        {
            if (conn.State == System.Data.ConnectionState.Closed)
            {
                conn.Open();
            }
            cmd.Connection = conn;
            cmd.CommandText = sqlStr;
            if (cmdParams != null)
            {
                foreach (SqlParameter param in cmdParams)
                {
                    cmd.Parameters.Add(param);
                }
            }
        }

    }
}
