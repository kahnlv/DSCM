using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using DSCM.Config;

namespace dscm.Library
{
    public class SqlCon
    {
        SqlConnection MyCon;
        SqlTransaction SqlTra;
        public SqlCon()
        {
            try
            {
                string con = PageConfig.SqlCon;
                MyCon = new SqlConnection(con);  //Linestr为连接路径
                MyCon.Open();
                SqlTra = MyCon.BeginTransaction();//开始事务
            }
            catch
            {
            }
        }

        public void Close()
        {
            try
            {
                MyCon.Close();
            }
            catch
            {
                SqlTra.Rollback();
            }
            finally
            {
                
            }
        }

        public SqlDataReader Read(string sql)
        {
            try
            {
                SqlCommand myCom = new SqlCommand(sql, MyCon, SqlTra);
                myCom.CommandTimeout = 0;
                SqlDataReader sdr = myCom.ExecuteReader();
                return sdr;
            }
            catch(Exception ex)
            {
                return null;
            }
        }

        public int UpLoad(string sql)
        {
            try
            {
                SqlCommand myCom = new SqlCommand(sql, MyCon, SqlTra);
                myCom.CommandTimeout = 0;
                int i = myCom.ExecuteNonQuery();
                myCom.Dispose();
                SqlTra.Commit();
                return i;
            }
            catch { return 0; }
        }

        /// <summary>
        /// 执行SQL语句，返回影响的记录数
        /// </summary>
        /// <param name="sqlStr">SQL语句(用在增 删 改)</param>
        /// <returns>影响的记录数</returns>
        public static int ExecuteSql(string sqlStr, SqlParameter[] paras) {
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
