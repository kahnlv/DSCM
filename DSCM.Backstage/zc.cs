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
using DSCM.ds_tbl_object;
using DSCM.ds_tbl_province;
using DSCM.ds_tbl_city;
using DSCM.ds_tbl_object_zc;
using System.Web;
using DSCM.ds_tbl_object_pl;
using DSCM.ds_tbl_user;

namespace DSCM.Backstage
{
    public class zc : DSCMSave
    {
        UserLogin ul = new UserLogin();
        string admin_id = "";
        string admin_name = "";
        string[] colm = new string[] { };
        string[] value = new string[] { };
        public zc()
        {
            admin_id = Save("admin_id") != null ? Save("admin_id").ToString() : "";
            admin_name = Save("admin_name") != null ? Save("admin_name").ToString() : "";
            if (admin_id.Equals(""))
            {
                ul.Login();
                //showPage("登录超时，请重新登录。", "/Backstage/templates/default/login.aspx");
            }
        }
        public ArrayList index_DSCM()
        {
            string obj_class = Form("obj_class");
            string citysql = Form("object_address");
            string obj_title = Form("obj_title");
            string obj_username = Form("obj_username");

            string order = "object_time";

            if (citysql != "")
            {
                citysql = " and object_address  like '%" + citysql + "%'";
            }

            if (obj_class != "")
            {
                obj_class = " and object_class ='" + obj_class + "'";
            }

            if (!obj_title.Equals(""))
            {
                obj_title = " and object_title like '%" + obj_title + "%'";
            }
            if (!obj_username.Equals(""))
            {
                obj_username = " and user_name like '%" + obj_username + "%'";
            }
            ArrayList al = new ArrayList();
            string page = QueryString("page");
            int p = 0;
            int.TryParse(page, out p);
            if (p == 0) p = 1;
            tbl_object[] obj = SQL.ReadAll<tbl_object>("tbl_object", citysql + obj_class + obj_title + obj_username, p, 20, order, false);
            DSCM.Page.PageList pl = new DSCM.Page.PageList();
            string pagestr = pl.WabPage(SQL.AllPageCount, 800, 2);
            al.Add(obj);
            al.Add(SQL.AllCount);
            al.Add(pagestr);
            al.Add(pl.Count);
            return al;
        }

        public void dsupdate_DSCM()
        {
            try
            {
                string object_id = Form("object_id");
                string object_title = Form("object_title");
                string object_class = Form("object_class");
                string object_label = Form("object_label");
                string object_address = Form("object_address");
                //string object_doc = Form("editorValue");
                string object_pingtai = Form("object_pingtai");
                string object_qixian = Form("object_qixian");
                string object_start_time = Form("object_start_time");
                string object_raise_price = Form("object_raise_price");
                string object_game_name = Form("object_game_name");
                string object_img = Form("object_img");
                string object_video = Form("object_video");
                //string object_content = Form("editorValue");
                string object_raise_start_time = Form("object_raise_start_time");
                string object_game_zhouqi = Form("object_game_zhouqi");
                string object_kaifashang = Form("object_kaifashang");
                string object_VC = Form("object_VC"); 
                string user_name = Form("user_name");
                string user_code = Form("user_code");
                string user_code_img = Form("user_code_img");
                string user_sex = Form("user_sex");
                string user_phone = Form("user_phone");
                string user_email = Form("user_email");
                int tian = 0;
                int.TryParse(object_qixian, out tian);
                DateTime dt = new DateTime();
                if (DateTime.TryParse(object_start_time, out dt))
                {
                    dt = dt.AddDays(tian);
                }
                else
                {
                    dt = DateTime.Now.AddDays(tian);
                }
                colm = new string[] {"object_title", "object_class", "object_label","object_address", "object_pingtai", 
                                   "object_qixian", "object_start_time", "object_raise_price","object_game_name", "object_img", "object_video", 
                                   "object_raise_start_time", "object_game_zhouqi", "object_kaifashang", "object_VC" ,"object_stop_time",
                                   "user_name", "user_code", "user_code_img", "user_sex", "user_phone", "user_email","object_state"};
                value = new string[] {object_title, object_class, object_label,object_address,  object_pingtai, 
                                   object_qixian, object_start_time, object_raise_price,object_game_name, object_img, object_video, 
                                   object_raise_start_time, object_game_zhouqi, object_kaifashang, object_VC,dt.ToString(),
                                   user_name, user_code, user_code_img, user_sex, user_phone, user_email,"1"};
                int i = SQL.Update("tbl_object", colm, value, " and object_id='" + object_id + "'");
                if (i == 1)
                {
                    ul.Loglog(admin_id, admin_name, "修改项目");
                    Jump("/backstage/index.aspx?ds=zc&cm=index");
                }
                else
                {
                    showPage("修改项目失败。", LastPage());
                }
                Jump(LastPage());
            }
            catch { }

        }

        public void dsshenhe_DSCM()
        {
            string object_id = Form("object_id");
            string object_state = Form("object_state");
            colm=new string[]{"object_state"};
            value = new string[] { object_state };
            SQL.Update("tbl_object", colm, value, " and object_id='" + object_id + "'");
            ul.Loglog(admin_id, admin_name, "审核项目");
            Jump("/backstage/index.aspx?ds=zc&cm=index");
        }

        public void delete_DSCM()
        {
            string id = QueryString("id");
            colm = new string[] { "object_state" };
            value = new string[] { "3" };
            int i = SQL.Update("tbl_object", colm, value, " and object_id='" + id + "'");
            if (i == 1)
            {
                ul.Loglog(admin_id, admin_name, "删除项目");
                Jump(LastPage());
            }
            else
            {
                showPage("删除项目失败！", LastPage());
            }
        }

        public ArrayList zclist_DSCM()
        {
            string id = QueryString("id");
            string order = "object_zc_time";

            ArrayList al = new ArrayList();
            string page = QueryString("page");
            int p = 0;
            int.TryParse(page, out p);
            if (p == 0) p = 1;
            tbl_object obj = SQL.Read<tbl_object>("tbl_object", " and object_id='" + id + "'");
            tbl_object_zc[] obj_zc = SQL.ReadAll<tbl_object_zc>("tbl_object_zc", " and object_id='" + id + "'", p, 20, order, false);
            DSCM.Page.PageList pl = new DSCM.Page.PageList();
            string pagestr = pl.WabPage(SQL.AllPageCount, 800, 2);
            al.Add(obj_zc);
            al.Add(obj);
            al.Add(SQL.AllCount);
            al.Add(pagestr);
            al.Add(pl.Count);
            return al;
        }

        public void dszcupdate_DSCM()
        {
            try
            {
                string obj_id = Form("obj_id");
                string obj_zc_id = Form("obj_zc_id");
                string object_zc_price = Form("object_zc_price");
                string object_zc_img1 = Form("object_zc_img1");
                string object_zc_img2 = Form("object_zc_img2");
                string object_zc_img3 = Form("object_zc_img3");
                //string object_zc_doc = Form("editorValue");
                string object_zc_time = Form("object_zc_time");
                string object_zc_xianzhi = Form("object_zc_xianzhi");
                string object_zc_fangshi = Form("object_zc_fangshi");

                colm = new string[] {"object_zc_price","object_zc_img1","object_zc_img2", "object_zc_img3",
                               "object_zc_time", "object_zc_xianzhi", "object_zc_fangshi"};
                value = new string[] { object_zc_price, object_zc_img1,object_zc_img2, object_zc_img3,
                               object_zc_time, object_zc_xianzhi, object_zc_fangshi};
                int i = SQL.Update("tbl_object_zc", colm, value, " and object_zc_id='" + obj_zc_id + "'");
                if (i == 1)
                {
                    ul.Loglog(admin_id, admin_name, "修改回报");
                    Jump("/backstage/index.aspx?ds=zc&cm=zclist&id=" + obj_id);
                }
                else
                {
                    showPage("修改回报失败！", LastPage());
                }
            }
            catch { }
        }

        public void zcdelete_DSCM()
        {
            string id = QueryString("id");
            colm = new string[] { "object_zc_delstate" };
            value = new string[] { "1"};
            int i = SQL.Update("tbl_object_zc",colm,value, " and object_zc_id='" + id + "'");
            if (i == 1)
            {
                ul.Loglog(admin_id, admin_name, "删除项目回报");
                Jump(LastPage());
            }
            else
            {
                showPage("删除项目回报失败！", LastPage());
            }
        }

        public ArrayList com_DSCM()
        {
            string objname = Form("objname");
            string username = Form("username");
            string plcontent = Form("plcontent");

            string order = "object_pl_time";
            if (objname != "")
            {
                objname = " and object_id in(select object_id from tbl_object where object_title like '%" + objname + "%')";
            }

            if (!username.Equals(""))
            {
                username = " and user_id in(select user_id from tbl_user where user_name like '%" + username + "%')";
            }
            if (!plcontent.Equals(""))
            {
                plcontent = " and object_pl_content like '%" + plcontent + "%'";
            }

            ArrayList al = new ArrayList();
            string page = QueryString("page");
            int p = 0;
            int.TryParse(page, out p);
            if (p == 0) p = 1;
            tbl_object_pl[] obj_pl = SQL.ReadAll<tbl_object_pl>("tbl_object_pl", objname + username + plcontent + " and object_pl_parent_id ='0'", p, 20, order, false);
            foreach (tbl_object_pl tobjpl in obj_pl)
            {
                tobjpl.tbl_object = SQL.Read<tbl_object>("tbl_object", " and object_id='" + tobjpl.Object_Id + "'");
                tobjpl.tbl_us = SQL.Read<tbl_user>("tbl_user", " and user_id='" + tobjpl.User_Id + "'");
            }
            DSCM.Page.PageList pl = new DSCM.Page.PageList();
            string pagestr = pl.WabPage(SQL.AllPageCount, 800, 2);
            al.Add(obj_pl);
            al.Add(SQL.AllCount);
            al.Add(pagestr);
            al.Add(pl.Count);
            return al;

        }

        public void dscomupdate_DSCM()
        {
            try
            {
                string obj_pl_id = Form("obj_pl_id");
                string object_pl_content = Form("object_pl_content");

                colm = new string[] {"object_pl_content"};
                value = new string[] { object_pl_content };
                int i = SQL.Update("tbl_object_pl", colm, value, " and object_pl_id='" + obj_pl_id + "'");
                if (i == 1)
                {
                    ul.Loglog(admin_id, admin_name, "修改评论");
                    showPage("修改成功！", LastPage());
                }
                else
                {
                    showPage("修改评论失败！", LastPage());
                }
            }
            catch { }
        }

        public void dscomdelete_DSCM()
        {
            string id = QueryString("id");
            int i = SQL.Delete("tbl_object_pl", " and object_pl_id='" + id + "' or object_pl_parent_id='" + id + "'");
            if (i >= 1)
            {
                ul.Loglog(admin_id, admin_name, "删除项目评论");
                Jump(LastPage());
            }
            else
            {
                showPage("删除项目评论失败！", LastPage());
            }
        }

        public ArrayList comhuifu_DSCM()
        {
            string id = QueryString("id");
            string order = "object_pl_time";
            ArrayList al = new ArrayList();
            string page = QueryString("page");
            int p = 0;
            int.TryParse(page, out p);
            if (p == 0) p = 1;
            tbl_object_pl[] obj_pl = SQL.ReadAll<tbl_object_pl>("tbl_object_pl", " and object_pl_parent_id ='"+id+"'", p, 20, order, false);
            foreach (tbl_object_pl tobjpl in obj_pl)
            {
                tobjpl.tbl_object = SQL.Read<tbl_object>("tbl_object", " and object_id='" + tobjpl.Object_Id + "'");
                tobjpl.tbl_us = SQL.Read<tbl_user>("tbl_user", " and user_id='" + tobjpl.User_Id + "'");
            }
            DSCM.Page.PageList pl = new DSCM.Page.PageList();
            string pagestr = pl.WabPage(SQL.AllPageCount, 800, 2);
            al.Add(obj_pl);
            al.Add(SQL.AllCount);
            al.Add(pagestr);
            al.Add(pl.Count);
            return al;

        }

    }
}
