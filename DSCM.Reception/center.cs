/* 
* ======================================================================== 
* 
* Author：鼎燊文化传媒 Time：2015/4/24 17:11:18 
* File name：center 
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
using dscm.Tools.Sql;
using DSCM.ds_tbl_photo;
using DSCM.ds_tbl_user_log;
using System.Collections;
using DSCM.ds_tbl_user_message;
using DSCM.ds_tbl_object;
using DSCM.ds_tbl_user;
using DSCM.ds_tbl_photo_class;
using DSCM.ds_tbl_photo_img;
using DSCM.ds_tbl_city;
using DSCM.ds_tbl_user_zan;
using System.Data;

namespace DSCM.Reception
{
    class center : DSCMSave
    {
        public ArrayList phlistcom_DSCM()
        {
            ArrayList al = new ArrayList();
            string user_id = Save("user_id").ToString();
            if (Save("user_phone").ToString().Equals(""))
            {
                showPage("请登录。", "/Reception/index.aspx?ds=zc");
            }
            try
            {
                string id = QueryString("id");
                string order = "user_message_time";
                string page = QueryString("page");
                int p = 0;
                int.TryParse(page, out p);
                if (p == 0) p = 1;
                tbl_user_message[] mes = SQL.ReadAll<tbl_user_message>("tbl_user_message", " and photo_img_id='" + id + "' and user_message_parent_id='0'", p, 20, order, false);
                DSCM.Page.PageList pl = new DSCM.Page.PageList();
                string pagestr = pl.WabPage(SQL.AllPageCount, 800, 2);
                foreach (tbl_user_message m in mes)
                {
                    tbl_user_message[] user_m = SQL.ReadAll<tbl_user_message>("tbl_user_message", " and user_message_parent_id='" + m.User_Message_Id + "'", 10);
                    m.user_mes = user_m;
                    string[] colm = new string[] { "user_name", "user_img" };
                    tbl_user user = SQL.Read<tbl_user>("tbl_user", colm, " and user_id='" + m.User_Id + "'");
                    m.user = user;
                    foreach (tbl_user_message par_mes in m.user_mes)
                    {
                        tbl_user user2 = SQL.Read<tbl_user>("tbl_user", colm, "and user_id='" + par_mes.User_Id + "'");
                        par_mes.user = user2;
                    }
                }
                al.Add(mes);
                al.Add(SQL.AllCount);
                al.Add(pagestr);
                al.Add(pl.Count);
            }
            catch { }
            return al;
        }

        public ArrayList photolist_DSCM()
        {
            ArrayList al = new ArrayList();
            string user_id = Save("user_id").ToString();
            if (Save("user_phone").ToString().Equals(""))
            {
                showPage("请登录。", "/Reception/index.aspx?ds=zc");
            }
            try
            {
                string id = QueryString("id");

                string order = "photo_img_time";
                string page = QueryString("page");
                //if (start.Equals("2")) { start = "and letter_user_id='" + user_id + "'"; } else { start = "and user_id='" + user_id + "'"; }
                int p = 0;
                int.TryParse(page, out p);
                if (p == 0) p = 1;
                tbl_photo_img[] mes = SQL.ReadAll<tbl_photo_img>("tbl_photo_img", " and photo_id='" + id + "'", p, 20, order, false);
                foreach (tbl_photo_img img in mes)
                {
                    img.zannum = SQL.Read("tbl_user_zan", " and photo_img_id='" + img.Photo_Img_Id + "' and if_zan=1 ");
                    img.plnum = SQL.Read("tbl_user_message", "and photo_img_id='" + img.Photo_Img_Id + "'  and user_message_parent_id='0'");
                }

                DSCM.Page.PageList pl = new DSCM.Page.PageList();
                string pagestr = pl.WabPage(SQL.AllPageCount, 800, 2);
                al.Add(mes);
                al.Add(SQL.AllCount);
                al.Add(pagestr);
                al.Add(pl.Count);
            }
            catch { }
            return al;
        }

        public ArrayList photo_DSCM()
        {
            ArrayList al = new ArrayList();
            string user_id = Save("user_id").ToString();
            if (Save("user_phone").ToString().Equals(""))
            {
                showPage("请登录。", "/Reception/index.aspx?ds=zc");
            }
            try
            {
                string order = "photo_time";
                string page = QueryString("page");
                string type = QueryString("type");
                if (type.Equals("")) type = "";
                else type = " and photo_class_id = '" + type + "'";
                //if (start.Equals("2")) { start = "and letter_user_id='" + user_id + "'"; } else { start = "and user_id='" + user_id + "'"; }
                int p = 0;
                int.TryParse(page, out p);
                if (p == 0) p = 1;
                tbl_photo[] mes = SQL.ReadAll<tbl_photo>("tbl_photo", " and user_id='" + user_id + "'" + type, p, 20, order, false);
                DSCM.Page.PageList pl = new DSCM.Page.PageList();
                string pagestr = pl.WabPage(SQL.AllPageCount, 800, 2);
                foreach (tbl_photo tp in mes)
                {
                    tbl_photo_class pc = SQL.Read<tbl_photo_class>("tbl_photo_class", " and photo_class_id='" + tp.Photo_Class_Id + "'");
                    tp.photo_class = pc;
                    tp.num = SQL.Read("tbl_photo_img", " and photo_id='" + tp.Photo_Id + "'");
                }

                tbl_photo_class[] pclass = SQL.ReadAll<tbl_photo_class>("tbl_photo_class", " and user_id='" + user_id + "'");
                al.Add(mes);
                al.Add(SQL.AllCount);
                al.Add(pagestr);
                al.Add(pl.Count);
                al.Add(pclass);
            }
            catch { }
            return al;
        }

        public ArrayList logview_DSCM()
        {
            ArrayList al = new ArrayList();
            string user_id = Save("user_id").ToString();
            if (Save("user_phone").ToString().Equals(""))
            {
                showPage("请登录。", "/Reception/index.aspx?ds=zc");
            }
            try
            {

                string id = QueryString("id");
                tbl_user_log log = SQL.Read<tbl_user_log>("tbl_user_log", " and user_log_id='" + id + "'");
                al.Add(log);

                string order = "user_message_time";
                string page = QueryString("page");
                //if (start.Equals("2")) { start = "and letter_user_id='" + user_id + "'"; } else { start = "and user_id='" + user_id + "'"; }
                int p = 0;
                int.TryParse(page, out p);
                if (p == 0) p = 1;
                tbl_user_message[] mes = SQL.ReadAll<tbl_user_message>("tbl_user_message", " and user_log_id='" + log.User_Log_Id + "' and user_message_parent_id='0'", p, 20, order, false);
                DSCM.Page.PageList pl = new DSCM.Page.PageList();
                string pagestr = pl.WabPage(SQL.AllPageCount, 800, 2);
                foreach (tbl_user_message m in mes)
                {
                    tbl_user_message[] user_m = SQL.ReadAll<tbl_user_message>("tbl_user_message", " and user_message_parent_id='" + m.User_Message_Id + "'", 10);
                    m.user_mes = user_m;
                    string[] colm = new string[] { "user_name", "user_img" };
                    tbl_user user = SQL.Read<tbl_user>("tbl_user", colm, " and user_id='" + m.User_Id + "'");
                    m.user = user;
                    foreach (tbl_user_message par_mes in m.user_mes)
                    {
                        tbl_user user2 = SQL.Read<tbl_user>("tbl_user", colm, "and user_id='" + m.User_Id + "'");
                        par_mes.user = user2;
                    }
                }

                al.Add(mes);
                al.Add(SQL.AllCount);
                al.Add(pagestr);
                al.Add(pl.Count);
            }
            catch { }
            return al;
        }

        public ArrayList log_DSCM()
        {
            ArrayList al = new ArrayList();
            string user_id = Save("user_id").ToString();
            if (Save("user_phone").ToString().Equals(""))
            {
                showPage("请登录。", "/Reception/index.aspx?ds=zc");
            }
            string id = QueryString("id");
            string order = "user_log_time";
            string page = QueryString("page");
            string start = QueryString("type");
            if (!start.Equals(""))  { start = " and user_log_class='" + log_class(start) + "'"; }          
            //if (start.Equals("2")) { start = "and letter_user_id='" + user_id + "'"; } else { start = "and user_id='" + user_id + "'"; }
            int p = 0;
            int.TryParse(page, out p);
            if (p == 0) p = 1;
            tbl_user_log[] user_log = SQL.ReadAll<tbl_user_log>("tbl_user_log", " and user_id='" + user_id + "'" + start, p, 20, order, false);
            DSCM.Page.PageList pl = new DSCM.Page.PageList();
            string pagestr = pl.WabPage(SQL.AllPageCount, 800, 2);
            al.Add(user_log);
            al.Add(SQL.AllCount);
            al.Add(pagestr);
            al.Add(pl.Count);

            return al;
        }

        public ArrayList index_DSCM()
        {
            ArrayList al = new ArrayList();
            string user_id = Save("user_id").ToString();
            if (Save("user_phone").ToString().Equals(""))
            {
                showPage("请登录。", "/Reception/index.aspx?ds=zc");
            }

            //相册
            tbl_photo[] photo = SQL.ReadAll<tbl_photo>("tbl_photo", " and user_id='" + user_id + "' order by photo_time desc", 6);
            foreach (tbl_photo pho in photo)
            {
                pho.num = SQL.Read("tbl_photo_img", " and photo_id='" + pho.Photo_Id + "'");
            }
            //日志
            tbl_user_log log = SQL.Read<tbl_user_log>("tbl_user_log", " and user_id='" + user_id + "' order by user_log_time desc");
            //留言
            tbl_user_message[] message = SQL.ReadAll<tbl_user_message>("tbl_user_message", " and to_user_id='" + user_id + "'", 5);
            foreach (tbl_user_message m in message)
            {
                tbl_user user = SQL.Read<tbl_user>("tbl_user", " and user_id='" + m.User_Id + "'");
                m.user = user;
            }
            //发起的项目
            tbl_object[] obj = SQL.ReadAll<tbl_object>("tbl_object", " and user_id='" + user_id + "' order by object_time desc", 4);
            al.Add(photo);
            al.Add(log);
            al.Add(message);
            al.Add(obj);
            return al;
        }

        public ArrayList leaveWord_DSCM()
        {
            ArrayList al = new ArrayList();
            string user_id = Save("user_id").ToString();
            if (Save("user_phone").ToString().Equals(""))
            {
                showPage("请登录。", "/Reception/index.aspx?ds=zc");
            }

            try
            {
                string order = "user_message_time";
                string page = QueryString("page");
                int p = 0;
                int.TryParse(page, out p);
                if (p == 0) p = 1;
                tbl_user_message[] mes = SQL.ReadAll<tbl_user_message>("tbl_user_message", " and to_user_id='" + user_id + "' and user_message_parent_id='0'", p, 20, order, false);
                DSCM.Page.PageList pl = new DSCM.Page.PageList();
                string pagestr = pl.WabPage(SQL.AllPageCount, 800, 2);

                foreach (tbl_user_message m in mes)
                {
                    tbl_user_message[] user_m = SQL.ReadAll<tbl_user_message>("tbl_user_message", " and user_message_parent_id='" + m.User_Message_Id + "'", 10);
                    m.user_mes = user_m;
                    string[] colm = new string[] { "user_name", "user_img" };
                    tbl_user user = SQL.Read<tbl_user>("tbl_user", colm, " and user_id='" + m.User_Id + "'");
                    m.user = user;
                    foreach (tbl_user_message par_mes in m.user_mes)
                    {
                        tbl_user user2 = SQL.Read<tbl_user>("tbl_user", colm, "and user_id='" + par_mes.User_Id + "'");
                        par_mes.user = user2;
                    }
                }

                al.Add(mes);
                al.Add(SQL.AllCount);
                al.Add(pagestr);
                al.Add(pl.Count);
            }
            catch { }
            return al;
        }

        string log_class(string str)
        {
            switch (str)
            {
                case "0":
                    str = "个人日志";
                    break;
                case "1":
                    str = "视频日志";
                    break;
                case "2":
                    str = "我的收藏";
                    break;
                case "3":
                    str = "情感天地";
                    break;
                case "4":
                    str = "情感收藏";
                    break;
                case "5":
                    str = "人生道理";
                    break;
                case "6":
                    str = "人生感悟";
                    break;
            }
            return str;
        }

        public void dslogmesinsert_DSCM()
        {
            try
            {
                string user_id = Save("user_id").ToString();
                string log_id = Form("user_log_id");
                string user_message_id = Form("user_message_id");
                string content = Form("content");
                if (user_id.Equals(""))
                {
                    showPage("登录超时或未登录，请重新登录", LastPage());
                }
                else
                {
                    if (user_message_id.Equals(""))
                    {
                        string[] colm = new string[] { "user_message_id", "user_id", "to_user_id", "user_message_center", "user_message_time", "user_log_id", "type", "photo_img_id", "user_message_parent_id" };
                        string[] value = new string[] { Guid, user_id, "", content, DateTime.Now.ToString(), log_id, "1", "", "0" };
                        int i = SQL.Insert("tbl_user_message", colm, value);
                        if (i == 1)
                        {
                            Jump(LastPage());
                        }
                        else
                        {
                            showPage("提交失败", LastPage());
                        }
                    }
                    else
                    {
                        string[] colm = new string[] { "user_message_id", "user_id", "to_user_id", "user_message_center", "user_message_time", "user_log_id", "type", "photo_img_id", "user_message_parent_id" };
                        string[] value = new string[] { Guid, user_id, "", content, DateTime.Now.ToString(), log_id, "1", "", user_message_id };
                        int i = SQL.Insert("tbl_user_message", colm, value);
                        if (i == 1)
                        {
                            Jump(LastPage());
                        }
                        else
                        {
                            showPage("提交失败", LastPage());
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Response.Write(e.Message);
                throw;
            }
        }

        public void dsimgmesinsert_DSCM()
        {
            try
            {
                string user_id = Save("user_id").ToString();
                string photo_img_id = Form("photo_img_id");
                string user_message_id = QueryString("megid");
                string content = Form("content");
                if (user_id.Equals(""))
                {
                    showPage("登录超时或未登录，请重新登录", LastPage());
                }
                else
                {
                    if (user_message_id.Equals(""))
                    {
                        string[] colm = new string[] { "user_message_id", "user_id", "to_user_id", "user_message_center", "user_message_time", "user_log_id", "type", "photo_img_id", "user_message_parent_id" };
                        string[] value = new string[] { Guid, user_id, "", content, DateTime.Now.ToString(), "", "2", photo_img_id, "0" };
                        int i = SQL.Insert("tbl_user_message", colm, value);
                        if (i == 1)
                        {
                            Jump("/Reception/index.aspx?ds=center&cm=photolist2&id=" + photo_img_id);
                        }
                        else
                        {
                            showPage("提交失败", LastPage());
                        }
                    }
                    else
                    {
                        string[] colm = new string[] { "user_message_id", "user_id", "to_user_id", "user_message_center", "user_message_time", "user_log_id", "type", "photo_img_id", "user_message_parent_id" };
                        string[] value = new string[] { Guid, user_id, "", content, DateTime.Now.ToString(), "", "2", photo_img_id, user_message_id };
                        int i = SQL.Insert("tbl_user_message", colm, value);
                        if (i == 1)
                        {
                            Jump("/Reception/index.aspx?ds=center&cm=photolist2&id=" + photo_img_id);
                        }
                        else
                        {
                            showPage("提交失败", LastPage());
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Response.Write(e.Message);
                throw;
            }
        }

        public void dsmesinsert_DSCM()
        {
            try
            {
                string user_id = Save("user_id").ToString();
                string user_message_id = Form("user_message_id");
                string content = Form("content");
                if (user_id.Equals(""))
                {
                    showPage("登录超时或未登录，请重新登录", LastPage());
                }
                else
                {
                    if (user_message_id.Equals(""))
                    {
                        string[] colm = new string[] { "user_message_id", "user_id", "to_user_id", "user_message_center", "user_message_time", "user_log_id", "type", "photo_img_id", "user_message_parent_id" };
                        string[] value = new string[] { Guid, user_id, user_id, content, DateTime.Now.ToString(), "", "0", "", "0" };
                        int i = SQL.Insert("tbl_user_message", colm, value);
                        if (i == 1)
                        {
                            Jump("/Reception/index.aspx?ds=center&cm=leaveWord");
                        }
                        else
                        {
                            showPage("提交失败", LastPage());
                        }
                    }
                    else
                    {
                        string[] colm = new string[] { "user_message_id", "user_id", "to_user_id", "user_message_center", "user_message_time", "user_log_id", "type", "photo_img_id", "user_message_parent_id" };
                        string[] value = new string[] { Guid, user_id, user_id, content, DateTime.Now.ToString(), "", "0", "", user_message_id };
                        int i = SQL.Insert("tbl_user_message", colm, value);
                        if (i == 1)
                        {
                            Jump(LastPage());
                        }
                        else
                        {
                            showPage("提交失败", LastPage());
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Response.Write(e.Message);
                throw;
            }
        }

        public void citys_DSCM()
        {
            string id = QueryString("id");
            tbl_city[] city = SQL.ReadAll<tbl_city>("tbl_city", " and Provinceid='" + id + "'");
            string json = "<select name=\"user_delivery_address_city\"><option value=\"\">请选择</option>";
            foreach (tbl_city ci in city)
            {
                json += "<option value=\"" + ci.ID + "\">" + ci.Cityname + "</option>";
            }
            json += "</select>";
            PageWrite(json, "STR");
        }

        public void zanimg_DSCM()
        {
            string user_id = Save("user_id").ToString();
            string result = "";           
            if (user_id.Equals(""))
            {
                result = "0";
            }
            try
            {
                string id = Request.Params["id"].ToString(); 
                int i = 0;
                tbl_user_zan zanimg = SQL.Read<tbl_user_zan>("tbl_user_zan", " and user_id='" + user_id + "' and photo_img_id='" + id + "'");
                if (zanimg.User_Zan_Id.Equals(""))
                {
                    string[] colm = new string[] { "user_zan_id", "user_id", "photo_img_id", "if_zan", "zan_time" };
                    string[] value = new string[] { Guid, user_id, id, "1", DateTime.Now.ToString() };
                    i = SQL.Insert("tbl_user_zan", colm, value);
                }
                else
                {
                    if (zanimg.If_Zan.Equals("1"))
                    {
                        i = SQL.Update("tbl_user_zan", new string[] { "if_zan" }, new string[] { "0" }, " and user_zan_id='" + zanimg.User_Zan_Id + "'");
                    }
                    else
                    {
                        i = SQL.Update("tbl_user_zan", new string[] { "if_zan" }, new string[] { "1" }, " and user_zan_id='" + zanimg.User_Zan_Id + "'");
                    }
                }
                if (i == 1)
                {
                    result = SQL.Read("tbl_user_zan", " and photo_img_id='" + id + "' and if_zan=1 ").ToString();
                }
                                
                Response.Write(result);
            }
            catch (Exception e)
            {
                Response.Write(e.Message);
                throw;
            }
        }

        public void lists_DSCM()
        {
            string user_id = Save("user_id").ToString();
            string id = Request.Params["id"].ToString();
            tbl_photo_img[] images = SQL.ReadAll<tbl_photo_img>("tbl_photo_img", " and photo_id='" + id + "' order by photo_img_time");

            String json = "{\"total\":" + images.Length + ",\"rows\":[";
            foreach (tbl_photo_img obj in images)
            {

                //obj.plnum = SQL.Read("tbl_user_message", " and photo_img_id='" + id + "'");
                //obj.zannum = SQL.Read("tbl_user_zan", " and photo_img_id='" + id + "' and if_zan=1 ");
                json += "{\"photo_img_id\":\"" + obj.Photo_Img_Id
                        + "\",\"photo_img_path\":\"" + obj.Photo_Img_Path
                        + "\",\"photo_img_time\":\"" + obj.Photo_Img_Time
                        + "\",\"photo_img_doc\":\"" + obj.Photo_Img_Doc
                        + "\",\"photo_id\":\"" + obj.Photo_Id
                        + "\",\"photo_img_title\":\"" + obj.Photo_Img_Title
                        + "\",\"plnum\":\"" + obj.plnum
                        + "\",\"zannum\":\"" + obj.zannum + "\"},";
            }
            String finalJson = json.Substring(0, json.Length - 1) + "]}";

            Response.Write(finalJson);
        }      
    }
}
