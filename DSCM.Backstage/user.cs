/* 
* ======================================================================== 
* 
* Author：鼎燊文化传媒 Time：2015/6/5 14:16:49 
* File name：hongbao 
* Version：V1.0.1
* Company: 鼎燊文化传媒 
* Framework Version: 2.0
*
* ======================================================================== 
*/

using System;
using System.Collections.Generic;
using System.Text;
using dscm.Library.self;
using System.Collections;
using dscm.Tools.Sql;
using DSCM.ds_tbl_user;
using DSCM.ds_tbl_object;
using DSCM.ds_tbl_user_message;
using DSCM.ds_tbl_user_log;
using DSCM.ds_tbl_photo_img;

namespace DSCM.Backstage
{
    public class user : DSCMSave
    {
        UserLogin ul = new UserLogin();
        string admin_id = "";
        string admin_name = "";
        string[] colm = new string[] { };
        string[] value = new string[] { };
        public user()
        {
            admin_id = Save("admin_id") != null ? Save("admin_id").ToString() : "";
            admin_name = Save("admin_name") != null ? Save("admin_name").ToString() : "";
            if (admin_id.Equals(""))
            {
                ul.Login();
            }
        }
        public ArrayList index_DSCM()
        {
            string user_sex = Form("user_sex");
            string citysql = Form("object_address");
            string user_name = Form("user_name");
            string user_relname = Form("user_relname");

            if (citysql != "")
            {
                citysql = " and user_city  like '%" + citysql + "%'";
            }

            if (user_sex != "")
            {
                user_sex = " and user_sex ='" + user_sex + "'";
            }

            if (!user_name.Equals(""))
            {
                user_name = " and user_name like '%" + user_name + "%'";
            }
            if (!user_relname.Equals(""))
            {
                user_relname = " and user_relname like '%" + user_relname + "%'";
            }
            ArrayList al = new ArrayList();
            string page = QueryString("page");
            int p = 0;
            int.TryParse(page, out p);
            if (p == 0) p = 1;
            tbl_user[] users = SQL.ReadAll<tbl_user>("tbl_user", citysql + user_sex + user_name + user_relname, p, 20, "user_name", false);
            DSCM.Page.PageList pl = new DSCM.Page.PageList();
            string pagestr = pl.WabPage(SQL.AllPageCount, 800, 2);
            al.Add(users);
            al.Add(SQL.AllCount);
            al.Add(pagestr);
            al.Add(pl.Count);
            return al;
        }

        public void dsinsert_DSCM()
        {

            string user_phone = Form("user_phone");
            string user_pwd = Form("user_pwd");
            string user_pwd1 = Form("user_pwd1");
            if (user_pwd.Equals(user_pwd1))
            {
                int i = SQL.Read("tbl_user", " and user_name='" + user_phone + "'");
                if (i > 0)
                {
                    showPage("该手机号已经注册", LastPage());
                }
                else
                {
                    string user_relname = Form("user_relname");
                    string user_city = Form("object_address");
                    string user_address = Form("user_address");
                    string user_birthday = Form("user_birthday");
                    string user_sex = Form("user_sex");
                    string user_tel = Form("user_tel");
                    string city_code = Form("city_code");
                    string user_email = Form("user_email");
                    string user_img = Form("user_img");
                    string user_recommend = Form("user_recommend");

                    colm = new string[] {"user_id","user_name", "user_relname", "user_city","user_address","user_birthday","user_sex", 
                                         "user_phone", "user_tel", "city_code", "user_email", "user_img","user_recommend","user_pwd" };

                    value = new string[] {Guid,user_phone, user_relname,user_city,user_address, user_birthday,user_sex,
                                          user_phone, user_tel, city_code, user_email, user_img,user_recommend == "" ? "0" : "1",Md5(user_pwd) };
                    i = SQL.Insert("tbl_user", colm, value);
                    if (i == 1)
                    {
                        ul.Loglog(admin_id, admin_name, "添加前台用户");
                        Jump("/backstage/index.aspx?ds=user&cm=index");
                    }
                    else
                    {
                        showPage("添加用户失败", LastPage());
                    }
                }
            }
            else
            {
                showPage("两次密码不一致", LastPage());
            }
        }

        public void dspwdupdate_DSCM()
        {
            string user_id = Form("user_id").ToString();
            string oldpwd = Form("oldpwd").ToString();
            string newpwd = Form("newpwd").ToString();
            tbl_user tuser = SQL.Read<tbl_user>("tbl_user", " and user_id='" + user_id + "'");
            if (tuser.User_Pwd.Equals(Md5(oldpwd)))
            {
                colm = new string[] { "user_pwd" };
                value = new string[] { Md5(newpwd) };
                int i = SQL.Update("tbl_user", colm, value, " and user_id='" + user_id + "'");
                if (i == 1)
                {
                    ul.Loglog(admin_id, admin_name, "修改用户密码");
                    Jump("/backstage/index.aspx?ds=user&cm=index");
                }
                else
                {
                    showPage("修改密码失败", LastPage());
                }
            }
            else
            {
                showPage("原始密码错误", LastPage());
            }
        }

        public void dsupdate_DSCM()
        {
            string user_id = Form("user_id");
            string user_relname = Form("user_relname");
            string user_city = Form("object_address");
            string user_address = Form("user_address");
            string user_birthday = Form("user_birthday");
            string user_sex = Form("user_sex");
            string user_phone = Form("user_phone");
            string user_tel = Form("user_tel");
            string city_code = Form("city_code");
            string user_email = Form("user_email");
            string user_img = Form("user_img");
            string user_recommend = Form("user_recommend");

            colm = new string[] { "user_relname", "user_city", "user_address", "user_birthday", "user_sex", "user_phone", "user_tel", "city_code", "user_email", "user_img", "user_recommend" };
            value = new string[] { user_relname, user_city, user_address, user_birthday, user_sex, user_phone, user_tel, city_code, user_email, user_img, user_recommend == "" ? "0" : "1" };

            int i = SQL.Update("tbl_user", colm, value, " and user_id='" + user_id + "'");
            if (i == 1)
            {
                ul.Loglog(admin_id, admin_name, "修改用户信息");
                Jump("/backstage/index.aspx?ds=user&cm=index");
            }
            else
            {
                showPage("修改失败。", LastPage());
            }
        }

        public void delete_DSCM()
        {
            string id = QueryString("id");
            colm = new string[] { "user_delstate" };
            value = new string[] { "1" };
            int i = SQL.Update("tbl_user", colm, value, " and user_id='" + id + "'");
            if (i == 1)
            {
                ul.Loglog(admin_id, admin_name, "删除用户");
                Jump(LastPage());
            }
            else
            {
                showPage("删除用户失败！", LastPage());
            }
        }

        public ArrayList logcom_DSCM()
        {
            string user_log_class = Form("user_log_class");
            string logtitle = Form("logtitle");
            string username = Form("username");
            string plcontent = Form("plcontent");

            string order = "user_message_time";

            if (user_log_class != "")
            {
                user_log_class = " and user_log_id in(select user_log_id from tbl_user_log where user_log_class ='" + user_log_class + "')";
            }
            if (logtitle != "")
            {
                logtitle = " and user_log_id in(select user_log_id from tbl_user_log where user_log_title like '%" + logtitle + "%')";
            }

            if (!username.Equals(""))
            {
                username = " and user_id in(select user_id from tbl_user where user_name like '%" + username + "%')";
            }
            if (!plcontent.Equals(""))
            {
                plcontent = " and user_message_center like '%" + plcontent + "%'";
            }
            string sql = user_log_class + logtitle + username + plcontent;
            ArrayList al = new ArrayList();
            string page = QueryString("page");
            int p = 0;
            int.TryParse(page, out p);
            if (p == 0) p = 1;
            tbl_user_message[] usermes = SQL.ReadAll<tbl_user_message>("tbl_user_message", sql + " and user_message_parent_id ='0' and type='1' ", p, 20, order, false);
            foreach (tbl_user_message tusermes in usermes)
            {
                tusermes.user_log = SQL.Read<tbl_user_log>("tbl_user_log", " and user_log_id='" + tusermes.User_Log_Id + "'");
                tusermes.user = SQL.Read<tbl_user>("tbl_user", " and user_id='" + tusermes.User_Id + "'");
            }
            DSCM.Page.PageList pl = new DSCM.Page.PageList();
            string pagestr = pl.WabPage(SQL.AllPageCount, 800, 2);
            al.Add(usermes);
            al.Add(SQL.AllCount);
            al.Add(pagestr);
            al.Add(pl.Count);
            return al;

        }

        public ArrayList loghuifu_DSCM()
        {
            string id = QueryString("id");
            string order = "user_message_time";

            ArrayList al = new ArrayList();
            string page = QueryString("page");
            int p = 0;
            int.TryParse(page, out p);
            if (p == 0) p = 1;
            tbl_user_message[] usermes = SQL.ReadAll<tbl_user_message>("tbl_user_message", " and type='1' and user_message_parent_id ='" + id + "'", p, 20, order, false);
            foreach (tbl_user_message tusermes in usermes)
            {
                tusermes.user_log = SQL.Read<tbl_user_log>("tbl_user_log", " and user_log_id='" + tusermes.User_Log_Id + "'");
                tusermes.user = SQL.Read<tbl_user>("tbl_user", " and user_id='" + tusermes.User_Id + "'");
            }
            DSCM.Page.PageList pl = new DSCM.Page.PageList();
            string pagestr = pl.WabPage(SQL.AllPageCount, 800, 2);
            al.Add(usermes);
            al.Add(SQL.AllCount);
            al.Add(pagestr);
            al.Add(pl.Count);
            return al;

        }

        public void dslogcomupdate_DSCM()
        {
            try
            {
                string user_message_id = Form("user_message_id");
                string user_message_center = Form("user_message_center");

                colm = new string[] { "user_message_center" };
                value = new string[] { user_message_center };
                int i = SQL.Update("tbl_user_message", colm, value, " and user_message_id='" + user_message_id + "'");
                if (i == 1)
                {
                    ul.Loglog(admin_id, admin_name, "修改日志评论");
                    showPage("修改成功！", LastPage());
                }
                else
                {
                    showPage("修改日志评论失败！", LastPage());
                }
            }
            catch { }
        }

        public ArrayList photocom_DSCM()
        {
            string imgtitle = Form("imgtitle");
            string imgdoc = Form("imgdoc");
            string username = Form("username");
            string plcontent = Form("plcontent");

            string order = "user_message_time";

            if (imgtitle != "")
            {
                imgtitle = " and photo_img_id in(select photo_img_id from tbl_photo_img where photo_img_title like '%" + imgtitle + "%')";
            }
            if (imgdoc != "")
            {
                imgdoc = " and photo_img_id in(select photo_img_id from tbl_photo_img where photo_img_doc like '%" + imgdoc + "%')";
            }

            if (!username.Equals(""))
            {
                username = " and user_id in(select user_id from tbl_user where user_name like '%" + username + "%')";
            }
            if (!plcontent.Equals(""))
            {
                plcontent = " and user_message_center like '%" + plcontent + "%'";
            }
            string sql = imgtitle + imgdoc + username + plcontent;
            ArrayList al = new ArrayList();
            string page = QueryString("page");
            int p = 0;
            int.TryParse(page, out p);
            if (p == 0) p = 1;
            tbl_user_message[] usermes = SQL.ReadAll<tbl_user_message>("tbl_user_message", sql + " and user_message_parent_id ='0' and type='2'", p, 20, order, false);
            foreach (tbl_user_message tusermes in usermes)
            {
                tusermes.photo_img = SQL.Read<tbl_photo_img>("tbl_photo_img", " and photo_img_id='" + tusermes.Photo_Img_Id + "'");
                tusermes.user = SQL.Read<tbl_user>("tbl_user", " and user_id='" + tusermes.User_Id + "'");
            }
            DSCM.Page.PageList pl = new DSCM.Page.PageList();
            string pagestr = pl.WabPage(SQL.AllPageCount, 800, 2);
            al.Add(usermes);
            al.Add(SQL.AllCount);
            al.Add(pagestr);
            al.Add(pl.Count);
            return al;
        }

        public ArrayList photocomhuifu_DSCM()
        {
            string id = QueryString("id");
            string order = "user_message_time";

            ArrayList al = new ArrayList();
            string page = QueryString("page");
            int p = 0;
            int.TryParse(page, out p);
            if (p == 0) p = 1;
            tbl_user_message[] usermes = SQL.ReadAll<tbl_user_message>("tbl_user_message", " and type='2' and user_message_parent_id ='" + id + "'", p, 20, order, false);
            foreach (tbl_user_message tusermes in usermes)
            {
                tusermes.photo_img = SQL.Read<tbl_photo_img>("tbl_photo_img", " and photo_img_id='" + tusermes.Photo_Img_Id + "'");
                tusermes.user = SQL.Read<tbl_user>("tbl_user", " and user_id='" + tusermes.User_Id + "'");
            }
            DSCM.Page.PageList pl = new DSCM.Page.PageList();
            string pagestr = pl.WabPage(SQL.AllPageCount, 800, 2);
            al.Add(usermes);
            al.Add(SQL.AllCount);
            al.Add(pagestr);
            al.Add(pl.Count);
            return al;

        }

        public void dsphotocomupdate_DSCM()
        {
            try
            {
                string user_message_id = Form("user_message_id");
                string user_message_center = Form("user_message_center");

                colm = new string[] { "user_message_center" };
                value = new string[] { user_message_center };
                int i = SQL.Update("tbl_user_message", colm, value, " and user_message_id='" + user_message_id + "'");
                if (i == 1)
                {
                    ul.Loglog(admin_id, admin_name, "修改相册评论");
                    showPage("修改成功！", LastPage());
                }
                else
                {
                    showPage("修改相册评论失败！", LastPage());
                }
            }
            catch { }
        }

        public ArrayList mes_DSCM()
        {
            string tousername = Form("tousername");
            string username = Form("username");
            string plcontent = Form("plcontent");

            string order = "user_message_time";

            if (tousername != "")
            {
                tousername = " and to_user_id in(select user_id from tbl_user where user_name like '%" + tousername + "%')";
            }

            if (!username.Equals(""))
            {
                username = " and user_id in(select user_id from tbl_user where user_name like '%" + username + "%')";
            }
            if (!plcontent.Equals(""))
            {
                plcontent = " and user_message_center like '%" + plcontent + "%'";
            }
            string sql = tousername + username + plcontent;
            ArrayList al = new ArrayList();
            string page = QueryString("page");
            int p = 0;
            int.TryParse(page, out p);
            if (p == 0) p = 1;
            tbl_user_message[] usermes = SQL.ReadAll<tbl_user_message>("tbl_user_message", sql + " and user_message_parent_id ='0' and type='0' ", p, 20, order, false);
            foreach (tbl_user_message tusermes in usermes)
            {
                tusermes.touser = SQL.Read<tbl_user>("tbl_user", " and user_id='" + tusermes.To_User_Id + "'");
                tusermes.user = SQL.Read<tbl_user>("tbl_user", " and user_id='" + tusermes.User_Id + "'");
            }
            DSCM.Page.PageList pl = new DSCM.Page.PageList();
            string pagestr = pl.WabPage(SQL.AllPageCount, 800, 2);
            al.Add(usermes);
            al.Add(SQL.AllCount);
            al.Add(pagestr);
            al.Add(pl.Count);
            return al;
        }

        public ArrayList meshuifu_DSCM()
        {
            string id = QueryString("id");
            string order = "user_message_time";

            ArrayList al = new ArrayList();
            string page = QueryString("page");
            int p = 0;
            int.TryParse(page, out p);
            if (p == 0) p = 1;
            tbl_user_message[] usermes = SQL.ReadAll<tbl_user_message>("tbl_user_message", " and type='0' and user_message_parent_id ='" + id + "'", p, 20, order, false);
            foreach (tbl_user_message tusermes in usermes)
            {
                tusermes.touser = SQL.Read<tbl_user>("tbl_user", " and user_id='" + tusermes.To_User_Id + "'");
                tusermes.user = SQL.Read<tbl_user>("tbl_user", " and user_id='" + tusermes.User_Id + "'");
            }
            DSCM.Page.PageList pl = new DSCM.Page.PageList();
            string pagestr = pl.WabPage(SQL.AllPageCount, 800, 2);
            al.Add(usermes);
            al.Add(SQL.AllCount);
            al.Add(pagestr);
            al.Add(pl.Count);
            return al;

        }

        public void dsmesupdate_DSCM()
        {
            try
            {
                string user_message_id = Form("user_message_id");
                string user_message_center = Form("user_message_center");

                colm = new string[] { "user_message_center" };
                value = new string[] { user_message_center };
                int i = SQL.Update("tbl_user_message", colm, value, " and user_message_id='" + user_message_id + "'");
                if (i == 1)
                {
                    ul.Loglog(admin_id, admin_name, "修改留言");
                    showPage("修改成功！", LastPage());
                }
                else
                {
                    showPage("修改留言失败！", LastPage());
                }
            }
            catch { }
        }

        public void dscomdelete_DSCM()
        {
            string id = QueryString("id");
            int i = SQL.Delete("tbl_user_message", " and user_message_id='" + id + "' or user_message_parent_id='" + id + "'");
            if (i >= 1)
            {
                ul.Loglog(admin_id, admin_name, "删除评论");
                Jump(LastPage());
            }
            else
            {
                showPage("删除评论失败！", LastPage());
            }
        }

        public void dsmesdelete_DSCM()
        {
            string id = QueryString("id");
            int i = SQL.Delete("tbl_user_message", " and user_message_id='" + id + "' or user_message_parent_id='" + id + "'");
            if (i >= 1)
            {
                ul.Loglog(admin_id, admin_name, "删除留言");
                Jump(LastPage());
            }
            else
            {
                showPage("删除留言失败！", LastPage());
            }
        }

    }
}
