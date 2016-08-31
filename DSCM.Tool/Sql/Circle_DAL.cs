using dscm.Library;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dscm.Tools.Sql
{
    public class Circle_DAL
    {
        public static int LikeAdd(string aid, string userid, int type, string content, out string id)
        {
            SqlParameter[] param = {
                new SqlParameter("@article_pl_id",SqlDbType.VarChar,50),
                new SqlParameter("@article_id",SqlDbType.VarChar,50),
                new SqlParameter("@user_id",SqlDbType.VarChar,50),
                new SqlParameter("@type",SqlDbType.TinyInt),
                new SqlParameter("@article_pl_content",SqlDbType.VarChar,50)
            };

            id = Guid.NewGuid().ToString();
            param[0].Value = id;
            param[1].Value = aid;
            param[2].Value = userid;
            param[3].Value = type;
            param[4].Value = content ?? "";

            return SqlCon.ExecuteSql("INSERT INTO tbl_article_pl (article_pl_id, article_id, user_id, type,article_pl_content) VALUES(@article_pl_id, @article_id,@user_id,@type,@article_pl_content); UPDATE tbl_article set article_hot = ISNULL(article_hot,0) + 1 WHERE article_id = @article_id", param);
        }

        public static int LikeUpdate(string plid, string userid, int opt, string aid)
        {
            SqlParameter[] param = {
                new SqlParameter("@article_pl_id",SqlDbType.VarChar,50),
                new SqlParameter("@user_id",SqlDbType.VarChar,50),
                new SqlParameter("@article_id",SqlDbType.VarChar,50)
            };

            param[0].Value = plid;
            param[1].Value = userid;
            param[2].Value = aid;

            string strSql = "UPDATE tbl_article_pl SET IsDelete = 1 - IsDelete WHERE article_pl_id = @article_pl_id and user_id = @user_id and type = 1;";

            strSql += "UPDATE tbl_article set article_hot = ISNULL(article_hot,0) +" + opt + "WHERE article_id = @article_id";

            return SqlCon.ExecuteSql(strSql, param);
        }

        public static int FollowAdd(string friend_user_id, string user_id)
        {
            SqlParameter[] param = {
                new SqlParameter("@friend_id",SqlDbType.VarChar,50),
                new SqlParameter("@user_id",SqlDbType.VarChar,50),
                new SqlParameter("@friend_user_id",SqlDbType.VarChar,50)
            };

            param[0].Value = Guid.NewGuid().ToString();
            param[1].Value = user_id;
            param[2].Value = friend_user_id;

            return SqlCon.ExecuteSql("INSERT INTO tbl_friend (friend_id,user_id,friend_user_id) VALUES (@friend_id,@user_id,@friend_user_id)", param);
        }

        public static int FollowUpdate(string friend_user_id, string user_id)
        {
            SqlParameter[] param = {
                new SqlParameter("@user_id",SqlDbType.VarChar,50),
                new SqlParameter("@friend_user_id",SqlDbType.VarChar,50)
            };

            param[0].Value = user_id;
            param[1].Value = friend_user_id;

            return SqlCon.ExecuteSql("UPDATE tbl_friend SET if_friend = 1 - if_friend WHERE user_id = @user_id AND friend_user_id  = @friend_user_id", param);
        }
    }
}
