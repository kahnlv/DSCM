/* 
* ======================================================================== 
* 
* Author：鼎燊文化传媒 Time：2015/4/22 11:16:25 
* File name：user 
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
using DSCM.ds_tbl_user;
using DSCM.ds_tbl_object;
using System.Collections;
using DSCM.ds_tbl_object_zc_pes;
using System.Web;
using DSCM.ds_tbl_user_delivery_address;
using DSCM.ds_tbl_user_log;
using DSCM.ds_tbl_friend;
using DSCM.ds_tbl_letter;
using DSCM.ds_tbl_letter_conten;
using DSCM.ds_tbl_city;
using DSCM.ds_tbl_order;
using DSCM.ds_tbl_province;
using DSCM.ds_tbl_object_xh;
using System.Net.Mail;
using System.Net;
using DSCM.ds_tbl_user_space;
using DSCM.ds_tbl_user_message;

namespace DSCM.Reception
{
    public class user : DSCMSave
    {
        public void lettersend_DSCM()
        {
            try
            {
                string user_id = Save("user_id").ToString();
                if (Save("user_phone").ToString().Equals(""))
                {
                    showPage("请登录。", "/Reception/index.aspx?ds=zc");
                }
                string guid = Guid;
                string letter_user_id = Form("letter_user_id");
                string letter_conten_doc = Form("letter_conten_doc");

                if (user_id.Equals(letter_user_id))
                {
                    showPage("您不能给自己发送私信。", LastPage());
                }

                string[] colm = new string[] { "letter_id", "user_id", "letter_user_id", "letter_time" };
                string[] value = new string[] { guid, user_id, letter_user_id, DateTime.Now.ToString() };
                int i = SQL.Insert("tbl_letter", colm, value);
                if (i == 1)
                {
                    colm = new string[] { "letter_conten_id", "user_id", "letter_id", "letter_conten_doc", "letter_conten_time" };
                    value = new string[] { Guid, user_id, guid, letter_conten_doc, DateTime.Now.ToString() };
                    i = SQL.Insert("tbl_letter_conten", colm, value);
                    if (i == 1)
                    {
                        showPage("私信发送成功。", LastPage());
                    }
                    else
                    {
                        showPage("私信发送失败。", LastPage());
                    }
                }
                else
                {
                    showPage("私信发送失败。", LastPage());
                }
            }
            catch (Exception e)
            {
                Response.Write(e.Message);
                throw;
            }
        }

        public ArrayList letter_DSCM()
        {
            string user_id = Save("user_id").ToString();
            if (Save("user_phone").ToString().Equals(""))
            {
                showPage("请登录。", "/Reception/index.aspx?ds=zc");
            }
            ArrayList al = new ArrayList();
            string order = "letter_time";
            string page = QueryString("page");
            string start = QueryString("start");
            if (start.Equals("2")) { start = "and user_id='" + user_id + "'"; } else { start = "and letter_user_id='" + user_id + "'"; }
            int p = 0;
            int.TryParse(page, out p);
            if (p == 0) p = 1;
            tbl_letter[] user_log = SQL.ReadAll<tbl_letter>("tbl_letter", " " + start, p, 20, order, false);
            DSCM.Page.PageList pl = new DSCM.Page.PageList();
            string pagestr = pl.WabPage(SQL.AllPageCount, 800, 2);
            al.Add(user_log);
            al.Add(SQL.AllCount);
            al.Add(pagestr);
            al.Add(pl.Count);


            foreach (tbl_letter letter in user_log)
            {
                tbl_user user = SQL.Read<tbl_user>("tbl_user", " and user_id='"+letter.User_Id+"'");
                letter.user = user;
                user = SQL.Read<tbl_user>("tbl_user", " and user_id='" + letter.Letter_User_Id + "'");
                letter.letter_user = user;
                tbl_letter_conten[] letter_conten = SQL.ReadAll<tbl_letter_conten>("tbl_letter_conten", " and letter_id='" + letter.Letter_Id + "' order by letter_conten_time asc", 10);
                letter.letter_contenList = letter_conten;
                foreach (tbl_letter_conten conten in letter_conten)
                {
                    user = SQL.Read<tbl_user>("tbl_user", " and user_id='" + conten.User_Id + "'");
                    conten.user = user;
                }
            }
            return al;
        }

        public ArrayList zcobject_DSCM()
        {
            string user_id = Save("user_id").ToString();
            if (Save("user_phone").ToString().Equals(""))
            {
                showPage("请登录。", "/Reception/index.aspx?ds=zc");
            }
            ArrayList al = new ArrayList();
            string order = "order_time,order_start";
            string page = QueryString("page");
            string start = QueryString("start");
           //if (!start.Equals("")) { start = " and order_start='" + start + "'"; } else { start = " and (order_start='0' or order_start='1')"; }
            if (start.Equals("0")) { start = " and order_start='" + start + "'"; }
            if (start.Equals("1")) { start = " and order_start in(1,2,3)"; }
            int p = 0;
            int.TryParse(page, out p);
            if (p == 0) p = 1;
            string[] colm = new string[] { "order_id", "object_title", "order_time", "object_id", "order_price", "order_start", "user_delivery_address_id", "object_zc_pes_id" };
            tbl_order[] user_log = SQL.ReadAll<tbl_order>("tbl_order", colm, " and user_id='" + user_id + "' " + start, p, 20, order, false);
            foreach (tbl_order tbl_order in user_log)
            {
               tbl_order.user_delicery_address = SQL.Read<tbl_user_delivery_address>("tbl_user_delivery_address", " and user_delivery_address_id='" + tbl_order.User_Delivery_Address_Id + "'");
               tbl_order.object_zc_pes = SQL.Read<tbl_object_zc_pes>("tbl_object_zc_pes", " and object_zc_pes_id='" + tbl_order.Object_Zc_Pes_Id + "'");
               tbl_order.user = SQL.Read<tbl_user>("tbl_user", "and user_id='" + tbl_order.User_Id + "'");
               tbl_order.tbl_obj = SQL.Read<tbl_object>("tbl_object", " and object_id='" + tbl_order.Object_Id + "'");            
            }
           
            DSCM.Page.PageList pl = new DSCM.Page.PageList();
            string pagestr = pl.WabPage(SQL.AllPageCount, 800, 2);
            al.Add(user_log);
            al.Add(SQL.AllCount);
            al.Add(pagestr);
            al.Add(pl.Count);
            return al;
        }

        public ArrayList friends_DSCM()
        {
            string user_id = Save("user_id").ToString();
            if (Save("user_phone").ToString().Equals(""))
            {
                showPage("请登录。", "/Reception/index.aspx?ds=zc");
            }
            ArrayList al = new ArrayList();
            string order = "user_id";
            string page = QueryString("page");
            int p = 0;
            int.TryParse(page, out p);
            if (p == 0) p = 1;
            tbl_friend[] friends = SQL.ReadAll<tbl_friend>("tbl_friend", " and user_id='" + user_id + "'", p, 20, order, false);           
            foreach (tbl_friend friend in friends)
            {
                tbl_user user1 = SQL.Read<tbl_user>("tbl_user", " and user_id='" + friend.Friend_User_Id + "'");

                int m = SQL.Read("tbl_friend", " and user_id='" + user1.User_Id + "'");
                user1.Guanzhu = m;
                m = SQL.Read("tbl_friend", " and friend_user_id='" + user1.User_Id + "'");
                user1._Guanzhu = m;
                string[] cityids = user1.User_City.Split(new string[]{ "," }, StringSplitOptions.RemoveEmptyEntries);
                user1.proname = SQL.Read<tbl_province>("tbl_province", " and di='" + cityids[0] + "'").Provincename;
                user1.cityname = SQL.Read<tbl_city>("tbl_city", " and id='" + cityids[1] + "'").Cityname;
                friend.user = user1;
            }
            DSCM.Page.PageList pl = new DSCM.Page.PageList();
            string pagestr = pl.WabPage(SQL.AllPageCount, 800, 2);
            al.Add(friends);
            al.Add(SQL.AllCount);
            al.Add(pagestr);
            al.Add(pl.Count);

           
            return al;
        }

        public void friendinsert_DSCM()
        {
            try
            {
                string user_id = Save("user_id").ToString();
                if (Save("user_phone").ToString().Equals(""))
                {
                    showPage("请登录。", "/Reception/index.aspx?ds=zc");
                }
                string friendid = QueryString("friendid");
                string userid = QueryString("userid");

                tbl_friend friend = SQL.Read<tbl_friend>("tbl_friend", " and friend_id='" + friendid + "'");
                if (friend.Friend_Id != "" && userid == "")
                {
                    //string[] colm = new string[] { "friend_id", "user_id", "friend_user_id", "if_friend", "friend_time" };
                    //string[] value = new string[] { friendid, user_id, friend.Friend_User_Id, "0", DateTime.Now.ToString() };
                    //int i = SQL.Update("dbo.tbl_friend", colm, value, " and friend_id='" + friendid + "'");
                    int i = SQL.Delete("dbo.tbl_friend", "and friend_id='" + friendid + "'");
                    if (i == 1)
                    {
                        showPage("您已取消关注该用户。", "/Reception/index.aspx?ds=user&cm=friends");
                    }
                    else
                    {
                        showPage("取消关注失败。", LastPage());
                    }
                }
                else
                {
                    string[] colm = new string[] { "friend_id", "user_id", "friend_user_id", "if_friend", "friend_time" };
                    string[] value = new string[] { Guid, user_id, userid, "1", DateTime.Now.ToString() };
                    int i = SQL.Insert("dbo.tbl_friend", colm, value);
                    if (i == 1)
                    {
                        showPage("收听成功。", "/Reception/index.aspx?ds=user&cm=friends");
                    }
                    else
                    {
                        showPage("收听失败。", LastPage());
                    }
                }
            }
            catch (Exception e)
            {
                Response.Write(e.Message);
                throw;
            }
        }

        public void loginsert_DSCM()
        {
            try
            {
                string user_id = Save("user_id").ToString();
                if (Save("user_phone").ToString().Equals(""))
                {
                    showPage("请登录。", "/Reception/index.aspx?ds=zc");
                }

                string user_log_title = Form("user_log_title");
                string user_log_class = Form("user_log_class");
                string user_log_doc = Form("user_log_doc");
                string user_log_id = Form("user_log_id");

                int i = SQL.Read("tbl_user_log", " and user_log_id='" + user_log_id + "'");
                if (i == 1)
                {

                    string[] colm = new string[] { "user_log_title", "user_log_doc", "user_log_time", "user_log_class" };
                    string[] value = new string[] { user_log_title, user_log_doc, DateTime.Now.ToString(), user_log_class };
                    i = SQL.Update("dbo.tbl_user_log", colm, value, " and user_log_id='" + user_log_id + "'");
                    if (i == 1)
                    {
                        showPage("修改成功。", "/Reception/index.aspx?ds=user&cm=log");
                    }
                    else
                    {
                        showPage("修改失败。", LastPage());
                    }
                }
                else
                {
                    string[] colm = new string[] { "user_log_id", "user_log_title", "user_log_doc", "user_log_time", "user_log_class", "user_id" };
                    string[] value = new string[] { Guid, user_log_title, user_log_doc, DateTime.Now.ToString(), user_log_class, user_id };
                    i = SQL.Insert("dbo.tbl_user_log", colm, value);
                    if (i == 1)
                    {
                        showPage("添加成功。", "/Reception/index.aspx?ds=user&cm=log");
                    }
                    else
                    {
                        showPage("添加失败。", LastPage());
                    }
                }
            }
            catch (Exception e)
            {
                Response.Write(e.Message);
                throw;
            }
        }

        public tbl_user_log logcreat_DSCM()
        {
            string user_id = Save("user_id").ToString();
            if (Save("user_phone").ToString().Equals(""))
            {
                showPage("请登录。", "/Reception/index.aspx?ds=zc");
            }
            string id = QueryString("id");
            tbl_user_log log = SQL.Read<tbl_user_log>("tbl_user_log", " and user_log_id='" + id + "'");
            return log;
        }

        public void logdel_DSCM()
        {
            try
            {
                string user_id = Save("user_id").ToString();
                if (Save("user_phone").ToString().Equals(""))
                {
                    showPage("请登录。", "/Reception/index.aspx?ds=zc");
                }
                string id =QueryString("id").ToString();
                int i = SQL.Delete("tbl_user_message", " and user_log_id='" + id + "'");//删除该日志的所有评论
                i = SQL.Delete("tbl_user_log", " and user_log_id='" + id + "'");//删除该日志
         
                if (i ==1)
                {
                    showPage("删除成功。", LastPage());
                }
                else
                {
                    showPage("删除失败。", LastPage()); 
                }
            }
            catch (Exception e)
            {
                Response.Write(e.Message);
                throw;
            }
        }

        public ArrayList log_DSCM()
        {
            string user_id = Save("user_id").ToString();
            if (Save("user_phone").ToString().Equals(""))
            {
                showPage("请登录。", "/Reception/index.aspx?ds=zc");
            }

            string order = "user_log_time";
            ArrayList al = new ArrayList();
            string page = QueryString("page");
            int p = 0;
            int.TryParse(page, out p);
            if (p == 0) p = 1;
            tbl_user_log[] user_log = SQL.ReadAll<tbl_user_log>("tbl_user_log", " and user_id='" + user_id + "'", p, 20, order, false);
            DSCM.Page.PageList pl = new DSCM.Page.PageList();
            string pagestr = pl.WabPage(SQL.AllPageCount, 800,2);
            al.Add(user_log);
            al.Add(SQL.AllCount);
            al.Add(pagestr);
            al.Add(pl.Count);
            return al;
        }

        public void addressdel_DSCM()
        {
            try
            {
                if (Save("user_phone").ToString().Equals(""))
                {
                    showPage("请登录。", "/Reception/index.aspx?ds=zc");
                }
                string id = QueryString("id");
                string[] colm = new string[] { "user_delivery_address_delstate" };
                string[] value = new string[] { "1"};
                //int n = SQL.Read("tbl_order", " and user_delivery_address_id='" + id + "'");
                //if (n != 0)
                //{
                //    showPage("您支持的项目以此地址为收货地址，暂时不能删除。", LastPage());
                //}
                //else
                //{
                //    int i = SQL.Delete("tbl_user_delivery_address", " and user_delivery_address_id='" + id + "'");
                //    if (i == 1)
                //    {
                //        showPage("删除成功。", LastPage());
                //    }
                //    else
                //    {
                //        showPage("删除失败。", LastPage());
                //    }
                //}

                int i = SQL.Update("tbl_user_delivery_address",colm ,value," and user_delivery_address_id='" + id + "'");
                if (i == 1)
                {
                    Jump(LastPage());
                }
                else
                {
                    showPage("删除失败。", LastPage());
                }
            }
            catch (Exception e)
            {
                Response.Write(e.Message);
                throw;
            }
        }

        public void addressinsert_DSCM()
        {
            string user_id = Save("user_id").ToString();
            if (Save("user_phone").ToString().Equals(""))
            {
                showPage("请登录。", "/Reception/index.aspx?ds=zc");
            }

            string user_delivery_address_user_relname = Form("user_delivery_address_user_relname");
            string user_delivery_address_user_address = Form("user_delivery_address_user_address");
            string user_delivery_address_city = Form("user_delivery_address_city");
            string user_delivery_address_city_code = Form("user_delivery_address_city_code");
            string user_delivery_address_user_phone = Form("user_delivery_address_user_phone");
            string user_delivery_address_user_tel = Form("user_delivery_address_user_tel");
            string user_delivery_address_id = Form("user_delivery_address_id");

            int i = SQL.Read("tbl_user_delivery_address", " and user_delivery_address_id='" + user_delivery_address_id + "'");

            if (i == 1)
            {
                string[] colm = new string[] { "user_delivery_address_user_relname", "user_delivery_address_user_address",
                "user_delivery_address_city", "user_delivery_address_city_code", "user_delivery_address_user_phone", "user_delivery_address_user_tel", "user_id" };
                string[] value = new string[] { user_delivery_address_user_relname, user_delivery_address_user_address,
                user_delivery_address_city,user_delivery_address_city_code, user_delivery_address_user_phone, user_delivery_address_user_tel,user_id };
                i = SQL.Update("tbl_user_delivery_address", colm, value, " and user_delivery_address_id='" + user_delivery_address_id + "'");
                if (i == 1)
                {
                    showPage("修改成功。", LastPage());
                }
                else
                {
                    showPage("修改失败。", LastPage());
                }
            }
            else
            {
                string[] colm = new string[] { "user_delivery_address_id", "user_delivery_address_user_relname", "user_delivery_address_city","user_delivery_address_user_address",
                 "user_delivery_address_city_code","user_delivery_address_user_email", "user_delivery_address_user_phone", "user_delivery_address_user_tel", "user_id" };
                string[] value = new string[] { Guid, user_delivery_address_user_relname, user_delivery_address_city, user_delivery_address_user_address,
                user_delivery_address_city_code, "", user_delivery_address_user_phone, user_delivery_address_user_tel,user_id };
                i = SQL.Insert("tbl_user_delivery_address", colm, value);
                if (i == 1)
                {
                    showPage("添加成功。", LastPage());
                }
                else
                {
                    showPage("添加失败。", LastPage());
                }
            }
        }

        public ArrayList address_DSCM()
        {
            ArrayList al = new ArrayList();
            string user_id = Save("user_id").ToString();
            if (Save("user_phone").ToString().Equals(""))
            {
                showPage("请登录。", "/Reception/index.aspx?ds=zc");
            }
            string id = QueryString("id");
            tbl_user_delivery_address address = SQL.Read<tbl_user_delivery_address>("tbl_user_delivery_address", " and user_delivery_address_id='" + id + "'");
            tbl_user_delivery_address[] uadd = SQL.ReadAll<tbl_user_delivery_address>("tbl_user_delivery_address", " and user_delivery_address_delstate='0' and user_id='" + user_id + "'", 10);
            foreach (tbl_user_delivery_address item in uadd)
            {
                string[] cityids = item.User_Delivery_Address_City.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
                item.proname = SQL.Read<tbl_province>("tbl_province", " and di='" + cityids[0] + "'").Provincename;
                item.cityname = SQL.Read<tbl_city>("tbl_city", " and id='" + cityids[1] + "'").Cityname;
            }

            al.Add(address);
            al.Add(uadd);
            return al;
        }

        public void update_DSCM()
        {
            try
            {
                string id = Save("user_id").ToString();
                if (Save("user_phone").ToString().Equals(""))
                {
                    showPage("请登录。", "/Reception/index.aspx?ds=zc");
                }
                string user_relname = Form("user_relname");
                string user_address = Form("user_address");
                string user_phone = Form("user_phone");
                string user_sex = Form("user_sex");
                string user_tel = Form("user_tel");
                string user_city = Form("user_city");
                string city_code = Form("city_code");
                string user_email = Form("user_email");
                string user_birthday = Form("user_birthday");

                user_birthday = user_birthday.Replace(",", "/") + " 00:00:00";

                string[] colm = new string[] { "user_relname", "user_address", "user_phone", 
                "user_sex", "user_tel", "user_city", "city_code", "user_email", "user_birthday", };


                string[] value = new string[] { user_relname, user_address, user_phone, 
                user_sex, user_tel, user_city, city_code, user_email, user_birthday, };
                int i = SQL.Update("tbl_user", colm, value, " and user_id='" + id + "'");
                if (i == 1)
                {
                    showPage("修改成功。", LastPage());
                }
                else
                {
                    showPage("修改失败。", LastPage());
                }
            }
            catch (Exception e)
            {
                Response.Write(e.Message);
                throw;
            }
        }

        public tbl_user info_DSCM()
        {
            string id = Save("user_id").ToString();
            if (Save("user_phone").ToString().Equals(""))
            {
                showPage("请登录。", "/Reception/index.aspx?ds=zc");
            }
            tbl_user user = SQL.Read<tbl_user>("tbl_user", " and user_id='" + id + "'");
            return user;
        }

        public void upimg_DSCM()
        {
            try
            {
                string user_photo = Form("user_photo");
                HttpPostedFile postedfile = Request.Files["user_photo"];
                user_photo = upload("/data/upload/", postedfile);

                if (Save("user_phone").ToString().Equals(""))
                {
                    showPage("请登录。", "/Reception/index.aspx?ds=zc");
                }
                string id = Save("user_id").ToString();
                string[] colm = new string[] { "user_img" };
                string[] value = new string[] { user_photo };
                int i = SQL.Update("tbl_user", colm, value, " and user_id='" + id + "'");
                if (i == 1)
                {
                    Save("user_img", user_photo);
                }
                Jump("/Reception/index.aspx?ds=user&cm=photo");
            }
            catch (Exception e)
            {
                Response.Write(e.Message);
                throw;
            }
        }

        public ArrayList zc_DSCM()
        {
            if (Save("user_phone").ToString().Equals(""))
            {
                showPage("请登录。", "/Reception/index.aspx?ds=zc");
            }
            string id = Save("user_id").ToString();//user_id
            string order = "object_zc_pes_time";
            ArrayList al = new ArrayList();
            string page = QueryString("page");
            int p = 0;
            int.TryParse(page, out p);
            if (p == 0) p = 1;
            tbl_object_zc_pes[] zc_pes = SQL.ReadAll<tbl_object_zc_pes>("tbl_object_zc_pes", " and user_id='" + id + "'", p, 5, order, false);
            DSCM.Page.PageList pl = new DSCM.Page.PageList();
            string pagestr = pl.WabPage(SQL.AllPageCount, 800,2);
            al.Add(zc_pes);
            al.Add(SQL.AllCount);
            al.Add(pagestr);
            al.Add(pl.Count);

            foreach (tbl_object_zc_pes pes in zc_pes)
            {
                tbl_object obj = SQL.Read<tbl_object>("tbl_object", " and object_id='" + pes.Object_Id + "'");
                pes.tbl_obj = obj;
            }
            return al;
        }

        public ArrayList object_DSCM()
        {
            if (Save("user_phone").ToString().Equals(""))
            {
                showPage("请登录。", "/Reception/index.aspx?ds=zc");
            }
            string id = Save("user_id").ToString();//user_id
            ArrayList al = new ArrayList();
            string order = "object_start_time";
            string page = QueryString("page");
            int p = 0;
            int.TryParse(page, out p);
            if (p == 0) p = 1;
            tbl_object[] obj = SQL.ReadAll<tbl_object>("tbl_object", " and user_id='" + id + "'", p, 5, order, false);
            DSCM.Page.PageList pl = new DSCM.Page.PageList();
            string pagestr = pl.WabPage(SQL.AllPageCount, 800,2);
            al.Add(obj);
            al.Add(SQL.AllCount);
            al.Add(pagestr);
            al.Add(pl.Count);
            return al;
        }

        public ArrayList xhobject_DSCM()
        {
            if (Save("user_phone").ToString().Equals(""))
            {
                showPage("请登录。", "/Reception/index.aspx?ds=zc");
            }
            string id = Save("user_id").ToString();//user_id
            ArrayList al = new ArrayList();
            string order = "object_start_time";
            string page = QueryString("page");
            int p = 0;
            int.TryParse(page, out p);
            if (p == 0) p = 1;
            tbl_object[] obj = SQL.ReadAll<tbl_object>("tbl_object", " and object_id in(select object_id from tbl_object_xh where user_id='" + id + "')", p, 5, order, false);
            DSCM.Page.PageList pl = new DSCM.Page.PageList();
            string pagestr = pl.WabPage(SQL.AllPageCount, 800, 2);
            al.Add(obj);
            al.Add(SQL.AllCount);
            al.Add(pagestr);
            al.Add(pl.Count);
            return al;
        }

        public void out_DSCM()
        {
            Save("clear");
            Jump(LastPage());
        }

        public void login_DSCM()
        {

            string user_phone = Form("user_phone");
            string user_pwd = Form("user_pwd");
            tbl_user user = SQL.Read < tbl_user>("tbl_user", " and user_phone='" + user_phone + "' and user_delstate='0'");
            if (user.User_Phone.Equals(user_phone))
            {
                if (user.User_Pwd.Equals(Md5(user_pwd)))
                {
                    Save("user_id", user.User_Id);
                    Save("user_phone", user_phone);
                    Save("user_name", user.User_Name);
                    Save("user_img", user.User_Img);
                    Save("user_email", user.User_Email);
                    Save("user_relname", user.User_Relname);
                    Jump(LastPage());
                }
                else
                {
                    showPage("密码错误", LastPage());
                }
            }
            else
            {
                showPage("用户名不存在", LastPage());
            }
        }

        public void regedit_DSCM()
        {
            string user_phone = Form("user_phone");
            string user_pwd = Form("user_pwd");
            string user_pwd1 = Form("user_pwd1");
            string user_code = Form("user_code");
            if (user_code.Equals(Save("CODE").ToString()))
            {
                if (user_pwd.Equals(user_pwd1))
                {
                    int i = SQL.Read("tbl_user", " and user_name='" + user_phone + "'");
                    if (i > 0)
                    {
                        showPage("手机号已经注册", LastPage());
                    }
                    else
                    {
                        string[] colm = new string[] { "user_id", "user_name", "user_pwd", "user_phone" };
                        string[] value = new string[] { Guid, user_phone, Md5(user_pwd), user_phone };
                        i = SQL.Insert("tbl_user", colm, value);
                        if (i == 1)
                        {
                            showPage("注册成功", LastPage());
                        }
                        else
                        {
                            showPage("用户注册失败", LastPage());
                        }
                    }
                }
                else
                {
                    showPage("两次密码不一致", LastPage());
                }
            }
            else
            {
                showPage("验证码错误", LastPage());
            }
        }
              
        public void citys_DSCM()
        {
            string id = QueryString("id");
            tbl_city[] city = SQL.ReadAll<tbl_city>("tbl_city", " and Provinceid='" + id + "'");
            string json = "<select name=\"user_city\"><option value=\"\">请选择</option>";
            foreach (tbl_city ci in city)
            {
                json += "<option value=\"" + ci.ID + "\">" + ci.Cityname + "</option>";
            }
            json += "</select>";
            PageWrite(json, "STR");
        }

        public tbl_user_space spacedesign_DSCM()
        {
            string user_id = Save("user_id").ToString();
            if (Save("user_phone").ToString().Equals(""))
            {
                showPage("请登录。", "/Reception/index.aspx?ds=zc");
            }
            tbl_user_space space = SQL.Read<tbl_user_space>("tbl_user_space", " and user_id='" + user_id + "'");
            return space;
        }

        public void spaceinsert_DSCM()
        {
            try
            {
                string user_id = Save("user_id").ToString();
                if (Save("user_phone").ToString().Equals(""))
                {
                    showPage("请登录。", "/Reception/index.aspx?ds=zc");
                }

                string user_space_name = Form("user_space_name");
                string user_space_signature = Form("user_space_signature");

                int i = SQL.Read("tbl_user_space", " and user_id='" + user_id + "'");
                if (i == 1)
                {

                    string[] colm = new string[] { "user_space_name", "user_space_signature" };
                    string[] value = new string[] { user_space_name, user_space_signature };
                    i = SQL.Update("dbo.tbl_user_space", colm, value, " and user_id='" + user_id + "'");
                    if (i == 1)
                    {
                        Jump("/Reception/index.aspx?ds=user&cm=info");
                    }
                    else
                    {
                        showPage("修改失败。", LastPage());
                    }

                }
                else
                {
                    string[] colm = new string[] { "user_space_id", "user_id", "user_space_name", "user_space_signature" };
                    string[] value = new string[] { Guid, user_id, user_space_name, user_space_signature };
                    i = SQL.Insert("dbo.tbl_user_space", colm, value);
                    if (i == 1)
                    {
                        Jump("/Reception/index.aspx?ds=user&cm=info");
                    }
                    else
                    {
                        showPage("添加失败。", LastPage());
                    }
                }
            }
            catch (Exception e)
            {
                Response.Write(e.Message);
                throw;
            }
        }

        //public string sendEmail(string UserName, string strEmail, string checkNum)
        //{
        //    try
        //    {
        //        //发送参数用户邮箱地址  用户名
        //        //确定smtp服务器地址。实例化一个Smtp客户端
        //        //System.Net.Mail.SmtpClient client = new System.Net.Mail.SmtpClient("smtp.qq.com");
        //        System.Net.Mail.SmtpClient client = new System.Net.Mail.SmtpClient(PubConstant.SmtpClientUrl);
        //        //生成一个发送地址
        //        string strFrom = string.Empty;
        //        //strFrom = "616701261@qq.com";
        //        strFrom = "B000017@naton.cn";


        //        //构造一个发件人地址对象
        //        MailAddress from = new MailAddress(strFrom, "纳通医疗", Encoding.UTF8);
        //        //构造一个收件人地址对象
        //        MailAddress to = new MailAddress(strEmail, UserName, Encoding.UTF8);

        //        //构造一个Email的Message对象
        //        MailMessage message = new MailMessage(from, to);
        //        #region
        //        //为 message 添加附件
        //        //foreach (TreeNode treeNode in treeViewFileList.Nodes)
        //        //{
        //        //    //得到文件名
        //        //    string fileName = treeNode.Text;
        //        //    //判断文件是否存在
        //        //    if (File.Exists(fileName))
        //        //    {
        //        //        //构造一个附件对象
        //        //        Attachment attach = new Attachment(fileName);
        //        //        //得到文件的信息
        //        //        ContentDisposition disposition = attach.ContentDisposition;
        //        //        disposition.CreationDate = System.IO.File.GetCreationTime(fileName);
        //        //        disposition.ModificationDate = System.IO.File.GetLastWriteTime(fileName);
        //        //        disposition.ReadDate = System.IO.File.GetLastAccessTime(fileName);
        //        //        //向邮件添加附件
        //        //        message.Attachments.Add(attach);
        //        //    }
        //        //    else
        //        //    {
        //        //        MessageBox.Show("文件" + fileName + "未找到！");
        //        //    }
        //        //}
        //        #endregion
        //        //添加邮件主题和内容
        //        //添加找回邮件地址再次将邮件地址加密传出
        //        string URL = "https://health.naton.cn/ResetPWD.html?Id=" + ClsMD5Encrypt.GetMD5HashHex(strEmail);
        //        message.Subject = "健康云端密码找回";
        //        message.SubjectEncoding = Encoding.UTF8;
        //        string bodytext = "<!DOCTYPE html><html xmlns='http://www.w3.org/1999/xhtml'><head><meta http-equiv='Content-Type' content='text/html; charset=utf-8'/><title></title></head>";
        //        bodytext += "<body><div style='min-width:400px;min-height:400px;margin:0px auto'><h2  style='background-color:#2790B0;color:#fff;text-align:center;'>健康云端</h2>";
        //        bodytext += "<h3>&nbsp;亲爱的&nbsp;" + UserName + "：</h3>";
        //        bodytext += " <h5>&nbsp;&nbsp;&nbsp;欢迎使用健康云端密码找回功能.</h5>";
        //        bodytext += "  <p style='font-weight:400;font-size:small;'>&nbsp;&nbsp;&nbsp;您此次找回密码的验证码是：<font style='font-weight:800;font-size:large;text-align:center;'>" + checkNum + "</font>，请在30分钟内在找回密码页填入此验证码。</p>";
        //        bodytext += " <p style='font-weight:400;font-size:small;'>&nbsp;&nbsp;&nbsp;密码找回地址:&nbsp;&nbsp;<font style='font-weight:800;font-size:medium;text-align:center;'>" + URL + "</font></p><br />";
        //        bodytext += " <p style='font-weight:400;font-size:small;'>&nbsp;&nbsp;&nbsp;如果您并未发过此请求，则可能是因为其他用户在尝试重设密码时误输入了您的电子邮件地址而</p>";
        //        bodytext += " <p style='font-weight:400;font-size:small;'>&nbsp;使您收到这封邮件，那么您可以放心的忽略此邮件，无需进一步采取任何操作。</p>";
        //        bodytext += " <br /><br /><h6>此致</h6>";
        //        bodytext += " <h6>健康云端项目组</h6><br />";
        //        bodytext += "<p style='font-weight:400;font-size:small;text-align:center;'>（请注意，该电子邮件地址不接受回复邮件，纳通医疗集团。）</p>";
        //        bodytext += "</div></body></html>";




        //        message.Body = bodytext;
        //        message.BodyEncoding = Encoding.UTF8;

        //        //设置邮件的信息
        //        client.DeliveryMethod = SmtpDeliveryMethod.Network;
        //        message.BodyEncoding = System.Text.Encoding.UTF8;
        //        message.IsBodyHtml = true;//设置为html

        //        //如果服务器支持安全连接，则将安全连接设为true。
        //        //gmail支持，163不支持，如果是gmail则一定要将其设为true
        //        //if (cmbBoxSMTP.SelectedText == "smpt.163.com")
        //        client.EnableSsl = false;
        //        //else
        //        //    client.EnableSsl = true;

        //        //设置用户名和密码。
        //        //string userState = message.Subject;
        //        client.UseDefaultCredentials = false;

        //        string username = "B000017";
        //        string passwd = "Naton123456";
        //        //用户登陆信息
        //        NetworkCredential myCredentials = new NetworkCredential(username, passwd);
        //        client.Credentials = myCredentials;
        //        //发送邮件
        //        client.Send(message);
        //        //异步发送
        //        //client.SendAsync(message, "ojb");//异步发送不会阻塞线程
        //        //提示发送成功
        //        return "true";

        //    }
        //    catch (Exception ex)
        //    {
        //        return ex.Message;
        //    }
        //}
    }
}
