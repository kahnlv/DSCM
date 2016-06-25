/* 
* ======================================================================== 
* 
* Author：鼎燊文化传媒 Time：2015/4/17 10:39:05 
* File name：zc 
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
using DSCM.ds_tbl_object;
using System.Web;
using System.IO;
using DSCM.ds_tbl_object_zc;
using System.Collections;
using DSCM.ds_tbl_object_pl;
using DSCM.ds_tbl_object_zc_pes;
using DSCM.ds_tbl_city;
using DSCM.ds_tbl_user;
using DSCM.ds_tbl_object_xh;
using DSCM.ds_tbl_province;

namespace DSCM.Reception
{
    public class zc : DSCMSave
    {
        public void dscominsert_DSCM()
        {
            try
            {
                string object_id = Form("object_id");
                string content = Form("content");
                string user_id = Save("user_id").ToString();
                string object_pl_id = Form("object_pl_id");

                if (user_id.Equals(""))
                {
                    showPage("登录超时或未登录，请重新登录", LastPage());
                }
                else
                {
                    if (object_pl_id.Equals(""))
                    {
                        int i = SQL.Read("tbl_object", " and object_id='" + object_id + "' and user_id='" + user_id + "'");
                        if (i == 1)
                        {
                            showPage("您不能评论自己的项目。", LastPage());
                        }
                        else
                        {
                            string[] colm = new string[] { "object_pl_id", "object_pl_content", "user_id", "object_pl_time", "object_id", "object_pl_parent_id" };
                            string[] value = new string[] { Guid, content, user_id, DateTime.Now.ToString(), object_id, "0" };
                            i = SQL.Insert("tbl_object_pl", colm, value);
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
                    else
                    {
                        string[] colm = new string[] { "object_pl_id", "object_pl_content", "user_id", "object_pl_time", "object_id", "object_pl_parent_id" };
                        string[] value = new string[] { Guid, content, user_id, DateTime.Now.ToString(), object_id, object_pl_id };
                        int i = SQL.Insert("tbl_object_pl", colm, value);
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

        public ArrayList zhichi_DSCM()
        {
            ArrayList al = new ArrayList();
            tbl_object obj = new tbl_object();
            tbl_object_zc[] obj_zc = new tbl_object_zc[] { };
            tbl_object_zc_pes[] zc_pes = new tbl_object_zc_pes[] { };
            try
            {
                string id = QueryString("id");
                obj = SQL.Read<tbl_object>("tbl_object", " and object_id='" + id + "'");
                obj_zc = SQL.ReadAll<tbl_object_zc>("tbl_object_zc", " and object_id='" + id + "'", 20);
                int con = SQL.Read("tbl_object_pl", " and object_id='" + id + "' and object_pl_parent_id='0'");

                string page = QueryString("page");
                int p = 0;
                int.TryParse(page, out p);
                if (p == 0) p = 1;
                string[] colm = new string[] { "object_zc_pes_id", "object_zc_id", "object_zc_pes_price", "object_zc_pes_time", "object_id", "(select user_name from tbl_user where a.user_id=tbl_user.user_id) as user_name", "user_id", "(select user_img from tbl_user where a.user_id=tbl_user.user_id) as user_img" };
                zc_pes = SQL.ReadAll<tbl_object_zc_pes>("tbl_object_zc_pes", colm, " and object_id='" + id + "'", p, 20, "object_zc_pes_time", false);

                al.Add(obj);
                al.Add(obj_zc);
                al.Add(con);
                al.Add(zc_pes);

                al.Add(SQL.AllCount);

                foreach (tbl_object_zc item in obj_zc)
                {
                    //特定回报值支持人数
                    item.zccount = SQL.Read("tbl_object_zc_pes", " and object_id='" + id + "' and object_zc_pes_price=" + item.Object_Zc_Price);
                }
                string[] citys = obj.Object_Address.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
                obj.proname = SQL.Read<tbl_province>("tbl_province", " and di='" + citys[0] + "'").Provincename;
                obj.cityname = SQL.Read<tbl_city>("tbl_city", " and id='" + citys[1] + "'").Cityname;
                //喜欢人数
                obj.xhcount = SQL.Read("tbl_object_xh", " and object_id='" + id + "'");
                DSCM.Page.PageList pl = new DSCM.Page.PageList();
                string pagestr = pl.WabPage(SQL.AllPageCount, 800, 2);
               
                al.Add(pagestr);
                al.Add(pl.Count);
            }
            catch { }
            return al;
        }

        public ArrayList com_DSCM()
        {
            ArrayList al = new ArrayList();
            tbl_object obj = new tbl_object();
            tbl_object_zc[] obj_zc = new tbl_object_zc[] { };
            tbl_object_pl[] obj_pl = new tbl_object_pl[] { };
            try
            {
                string id = QueryString("id");
                obj = SQL.Read<tbl_object>("tbl_object", " and object_id='" + id + "'");
                obj_zc = SQL.ReadAll<tbl_object_zc>("tbl_object_zc", " and object_id='" + id + "'", 20);

                //带分页评论
                string page = QueryString("page");
                int p = 0;
                int.TryParse(page, out p);
                if (p == 0) p = 1;
                obj_pl = SQL.ReadAll<tbl_object_pl>("tbl_object_pl", " and object_id='" + id + "' and object_pl_parent_id='0'", p, 20, "object_pl_time", false);
                DSCM.Page.PageList pl = new DSCM.Page.PageList();
                string pagestr = pl.WabPage(SQL.AllPageCount, 800, 2);

                al.Add(SQL.AllCount);
                al.Add(pagestr);
                al.Add(pl.Count);

                foreach (tbl_object_pl opl in obj_pl)
                {
                    tbl_object_pl[] obj_p = SQL.ReadAll<tbl_object_pl>("tbl_object_pl", " and object_pl_parent_id='" + opl.Object_Pl_Id + "'", 10);
                    opl.object_pl = obj_p;
                    string[] colm = new string[] { "user_name", "user_img" };
                    tbl_user user1 = SQL.Read<tbl_user>("tbl_user", colm, "and user_id='" + opl.User_Id + "'");
                    opl.tbl_us = user1;
                    foreach (tbl_object_pl par_pl in opl.object_pl)
                    {
                        tbl_user user2 = SQL.Read<tbl_user>("tbl_user", colm, "and user_id='" + par_pl.User_Id + "'");
                        par_pl.tbl_us = user2;
                    }
                }

                //支持人数
                int count = SQL.Read("tbl_object_zc_pes", " and object_id='" + id + "'");

                foreach (tbl_object_zc item in obj_zc)
                {
                    //特定回报值支持人数
                    item.zccount = SQL.Read("tbl_object_zc_pes", " and object_id='" + id + "' and object_zc_pes_price=" + item.Object_Zc_Price);
                }
                //喜欢人数
                obj.xhcount = SQL.Read("tbl_object_xh", " and object_id='" + id + "'");
                string[] citys = obj.Object_Address.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
                obj.proname = SQL.Read<tbl_province>("tbl_province", " and di='" + citys[0] + "'").Provincename;
                obj.cityname = SQL.Read<tbl_city>("tbl_city", " and id='" + citys[1] + "'").Cityname;
              
                al.Add(obj);
                al.Add(obj_zc);
                al.Add(obj_pl);
                al.Add(count);
            }
            catch { }
            return al;
        }

        public ArrayList item_DSCM()
        {
            ArrayList al = new ArrayList();
            tbl_object obj = new tbl_object();
            tbl_object_zc[] obj_zc = new tbl_object_zc[] { };
            try
            {
                string id = QueryString("id");
                obj = SQL.Read<tbl_object>("tbl_object", " and object_id='" + id + "'");
                obj_zc = SQL.ReadAll<tbl_object_zc>("tbl_object_zc", " and object_id='" + id + "'", 20);
                int con = SQL.Read("tbl_object_pl", " and object_id='" + id + "' and object_pl_parent_id='0'");
                //支持人数
                int count = SQL.Read("tbl_object_zc_pes", " and object_id='" + id + "'");

                foreach (tbl_object_zc item in obj_zc)
                {
                    //特定回报值支持人数
                    item.zccount = SQL.Read("tbl_object_zc_pes", " and object_id='" + id + "' and object_zc_pes_price=" + item.Object_Zc_Price);
                }
                string[] citys = obj.Object_Address.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
                obj.proname = SQL.Read<tbl_province>("tbl_province", " and di='" + citys[0] + "'").Provincename;
                obj.cityname = SQL.Read<tbl_city>("tbl_city", " and id='" + citys[1] + "'").Cityname;
                //喜欢人数
                obj.xhcount = SQL.Read("tbl_object_xh", " and object_id='" + id + "'");
                al.Add(obj);
                al.Add(obj_zc);
                al.Add(con);
                al.Add(count);
            }
            catch { }
            return al;
        }

        public ArrayList list_DSCM()
        {
            string xm = QueryString("xm");
            string px = QueryString("px");
            string order = "object_time";
            string str = "";
            switch (xm)
            {
                case "1": str += " and (object_stop_time<'" + DateTime.Now.ToString() + "' and object_start_time<'" + DateTime.Now.ToString() + "')"; break;
                case "2": str += " and (object_stop_time>'" + DateTime.Now.ToString() + "')"; break;
                case "3": str += " and (object_start_time>'" + DateTime.Now.ToString() + "')"; break;
            }
            switch (px)
            {
                case "1": str += " and (object_start_time>'" + DateTime.Now.AddDays(-1).ToString() + "' and object_start_time<'" + DateTime.Now.ToString() + "')"; break;
                case "2": order = " object_raise_price"; break;
                case "3": order = " object_zc"; break;
                case "4": order = " object_raise_ready_manry"; break;
            }

            string type = QueryString("type");
            if (!type.Equals(""))
            {
                type = " and object_class like '%" + type + "%' ";
            }
            ArrayList al = new ArrayList();
            string page = QueryString("page");
            int p = 0;
            int.TryParse(page, out p);
            if (p == 0) p = 1;
            tbl_object[] obj = SQL.ReadAll<tbl_object>("tbl_object", " and object_state='1' " + str + type, p, 20, order, false);
           
            DSCM.Page.PageList pl = new DSCM.Page.PageList();
            string pagestr = pl.WabPage(SQL.AllPageCount, 800, 2);
            al.Add(obj);
            al.Add(SQL.AllCount);
            al.Add(pagestr);
            al.Add(pl.Count);
            return al;
        }

        public ArrayList index_DSCM()
        {
            ArrayList al = new ArrayList();
            int i = SQL.Read("tbl_object", " and object_state='1' ");
            int j = SQL.Read("tbl_object_zc_pes", "");
            string[] colm = new string[] { "sum(object_zc_pes_price) as object_zc_pes_price" };
            tbl_object_zc_pes pes = SQL.Read<tbl_object_zc_pes>("tbl_object_zc_pes", colm, "");

            tbl_object[] tobj = SQL.ReadAll<tbl_object>("tbl_object", " and object_raise_price<=object_raise_ready_manry order by object_time desc", 4);

            tbl_object[] obj = SQL.ReadAll<tbl_object>("tbl_object", " and object_state='1' order by object_time desc", 5);

            al.Add(obj);
            al.Add(tobj);
            al.Add(pes);
            al.Add(i);
            al.Add(j);
            return al;
        }

        public void dsinsert_DSCM()
        {
            try
            {
                string object_title = Form("object_title");
                string object_class = Form("object_class");
                string object_label = Form("object_label");
                string object_address = Form("object_address");
                string object_doc = Form("editorValue");
                string object_pingtai = Form("object_pingtai");
                string object_qixian = Form("object_qixian");
                string object_start_time = Form("object_start_time");
                string object_raise_price = Form("object_raise_price");
                string object_game_name = Form("object_game_name");
                Save("object_id", Guid);
                Save("object_title", object_title);
                Save("object_class", object_class);
                Save("object_label", object_label);
                Save("object_address", object_address);
                Save("object_doc", object_doc);
                Save("object_pingtai", object_pingtai);
                Save("object_qixian", object_qixian);
                Save("object_start_time", object_start_time);
                Save("object_raise_price", object_raise_price);
                Save("object_game_name", object_game_name);
                Jump("/Reception/index.aspx?ds=zc&cm=insert2");
            }
            catch (Exception e)
            {
                Response.Write(e.Message);
                throw;
            }
        }

        public void dsinsert2_DSCM()
        {
            try
            {
                string object_img = Form("object_img");
                HttpPostedFile postedfile = Request.Files["object_img"];
                object_img = upload("/data/upload/", postedfile);

                string object_video = Form("object_video");
                postedfile = Request.Files["object_video"];
                object_video = upload("/data/upload/", postedfile);

                string object_content = Form("editorValue");
                string object_raise_start_time = Form("object_raise_start_time");
                string object_game_zhouqi = Form("object_game_zhouqi");
                string object_kaifashang = Form("object_kaifashang");
                string object_VC = Form("object_VC");

                Save("object_img", object_img);
                Save("object_video", object_video);
                Save("object_content", object_content);
                Save("object_raise_start_time", object_raise_start_time);
                Save("object_game_zhouqi", object_game_zhouqi);
                Save("object_kaifashang", object_kaifashang);
                Save("object_VC", object_VC);   
                Jump("/Reception/index.aspx?ds=zc&cm=insert3");
            }
            catch (Exception e)
            {
                Response.Write(e.Message);
                throw;
            }
         
        }

        public void dsinsert3_DSCM()
        {
            try
            {
                string object_zc_price = Form("object_zc_price");
                string object_zc_img1 = Form("object_zc_img1");
                HttpPostedFile postedfile = Request.Files["object_zc_img1"];
                object_zc_img1 = upload("/data/upload/", postedfile);


                string object_zc_img2 = Form("object_zc_img2");
                postedfile = Request.Files["object_zc_img2"];
                object_zc_img2 = upload("/data/upload/", postedfile);


                string object_zc_img3 = Form("object_zc_img3");
                postedfile = Request.Files["object_zc_img3"];
                object_zc_img3 = upload("/data/upload/", postedfile);

                string object_zc_doc = Form("editorValue");
                string object_zc_time = Form("object_zc_time");
                string object_zc_xianzhi = Form("object_zc_xianzhi");
                string object_zc_fangshi = Form("object_zc_fangshi");
                string object_raise_price = Save("object_raise_price").ToString();

                string object_id = Save("object_id").ToString();
                string[] colm = new string[] { "object_zc_id", "object_zc_price","object_zc_raise_price",
                                            "object_zc_img1","object_zc_img2", "object_zc_img3", "object_zc_doc", 
                                            "object_zc_time", "object_zc_xianzhi", "object_zc_fangshi","object_id" };
                string[] value = new string[] {Guid, object_zc_price, object_raise_price,object_zc_img1,
                                            object_zc_img2, object_zc_img3, object_zc_doc, 
                                            object_zc_time, object_zc_xianzhi, object_zc_fangshi,object_id};
                SQL.Insert("tbl_object_zc", colm, value);
                Jump("/Reception/index.aspx?ds=zc&cm=insert3");
            }
            catch (Exception e)
            {
                Response.Write(e.Message);
                throw;
            }
        }

        public void dsinsert4_DSCM()
        {
            try
            {
                string object_id = Save("object_id").ToString();
                string object_title = Save("object_title").ToString();
                string object_class = Save("object_class").ToString();
                string object_label = Save("object_label").ToString();
                string object_address = Save("object_address").ToString();
                //string object_doc = Save("editorValue").ToString();错误
                string object_doc = Save("object_doc").ToString();
                string object_pingtai = Save("object_pingtai").ToString();
                string object_qixian = Save("object_qixian").ToString();
                string object_start_time = Save("object_start_time").ToString();
                string object_raise_price = Save("object_raise_price").ToString();
                string object_game_name = Save("object_game_name").ToString();
                string object_img = Save("object_img").ToString();
                string object_video = Save("object_video").ToString();
                string object_content = Save("object_content").ToString();
                string object_raise_start_time = Save("object_raise_start_time").ToString();
                string object_game_zhouqi = Save("object_game_zhouqi").ToString();
                string object_kaifashang = Save("object_kaifashang").ToString();
                string object_VC = Save("object_VC").ToString();
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

                string[] colm = new string[] { "object_id","object_title", "object_class", "object_label",
                                            "object_address", "object_doc", "object_pingtai", 
                                            "object_qixian", "object_start_time", "object_raise_price",
                                            "object_game_name", "object_img", "object_video", 
                                            "object_content", "object_raise_start_time", "object_game_zhouqi", "object_kaifashang", "object_VC" ,"object_time","object_stop_time"};
                string[] value = new string[] { object_id,object_title, object_class, object_label,
                                            object_address, object_doc, object_pingtai, 
                                            object_qixian, object_start_time, object_raise_price,
                                            object_game_name, object_img, object_video, 
                                            object_content, object_raise_start_time, object_game_zhouqi, object_kaifashang, object_VC,DateTime.Now.ToString(),dt.ToString()};

                SQL.Insert("tbl_object", colm, value);
                string sql1 = SQL.Sql;
                //支持
                string object_zc_price = Form("object_zc_price");
                string object_zc_img1 = Form("object_zc_img1");
                HttpPostedFile postedfile = Request.Files["object_zc_img1"];
                object_zc_img1 = upload("/data/upload/", postedfile);


                string object_zc_img2 = Form("object_zc_img2");
                postedfile = Request.Files["object_zc_img2"];
                object_zc_img2 = upload("/data/upload/", postedfile);


                string object_zc_img3 = Form("object_zc_img3");
                postedfile = Request.Files["object_zc_img3"];
                object_zc_img3 = upload("/data/upload/", postedfile);

                //string object_zc_doc = Form("object_zc_doc");//错误
                string object_zc_doc = Form("editorValue");
                string object_zc_time = Form("object_zc_time");
                string object_zc_xianzhi = Form("object_zc_xianzhi");
                string object_zc_fangshi = Form("object_zc_fangshi");

                colm = new string[] { "object_zc_id", "object_zc_price","object_zc_raise_price", "object_zc_img1",
                                            "object_zc_img2", "object_zc_img3", "object_zc_doc", 
                                            "object_zc_time", "object_zc_xianzhi", "object_zc_fangshi","object_id" };
                value = new string[] {Guid, object_zc_price,object_raise_price, object_zc_img1,
                                            object_zc_img2, object_zc_img3, object_zc_doc, 
                                            object_zc_time, object_zc_xianzhi, object_zc_fangshi,object_id};
                SQL.Insert("tbl_object_zc", colm, value);
                string sql2 = SQL.Sql;
                Jump("/Reception/index.aspx?ds=zc&cm=insert4");
            }
            catch (Exception e)
            {
                Response.Write(e.Message);
                throw;
            }
        }

        public void dsinsert5_DSCM()
        {
            try
            {
                string object_id = Save("object_id").ToString();
                string user_name = Form("user_name");
                string user_code = Form("user_code");
                string user_code_img = Form("user_code_img");
                string user_sex = Form("user_sex");
                string user_phone = Form("user_phone");
                string user_email = Form("user_email");
                string user_id = Save("user_id").ToString();

                HttpPostedFile postedfile = Request.Files["user_code_img"];
                user_code_img = upload("/data/upload/", postedfile);

                string[] colm = new string[] { "user_name", "user_code", "user_code_img", "user_sex", "user_phone", "user_email", "user_id" };
                string[] value = new string[] { user_name, user_code, user_code_img, user_sex, user_phone, user_email, user_id };
                int i = SQL.Update("tbl_object", colm, value, " and object_id='" + object_id + "'");
                if (i == 1)
                {
                    showPage("提交成功，等待审核。", "/Reception/index.aspx?ds=zc");
                }
                else
                {
                    showPage("提交失败。", "/Reception/index.aspx?ds=zc&cm=insert");
                }
            }
            catch (Exception e)
            {
                Response.Write(e.Message);
                throw;
            }
        }

        public void city_DSCM()
        {
            string id = QueryString("id");
            tbl_city[] city = SQL.ReadAll<tbl_city>("tbl_city", " and ProvinceID='" + id + "'");
            string json = "";
            foreach (tbl_city c in city)
            {
                json += "<p val=\"" + c.ID + "\" class=\"smgIthems\">" + c.Cityname + "</p>";
            }
            PageWrite(json, "STR");
        }

        public void dsxhinsert_DSCM()
        {
            try
            {
                string user_id = Save("user_id").ToString();
                string object_id = QueryString("id");
                //int result = 0;
                if (user_id.Equals(""))
                {
                    showPage("登录超时或未登录，请重新登录", LastPage());
                    //result= 0;
                }
                else
                {
                    int i = SQL.Read("tbl_object", " and object_id='" + object_id + "' and user_id='" + user_id + "'");
                    if (i == 0)
                    {
                        int k = SQL.Read("tbl_object_xh", " and object_id='" + object_id + "' and user_id='" + user_id + "'");
                        if (k > 0)
                        {
                            showPage("该项目已在您的喜欢列表内了!", LastPage());
                            //result = 1;
                        }
                        else
                        {
                            string[] colm = new string[] { "object_xh_id", "object_xh_time", "user_id", "object_id" };
                            string[] value = new string[] { Guid, DateTime.Now.ToString(), user_id, object_id };

                            i = SQL.Insert("tbl_object_xh", colm, value);
                            if (i == 1)
                            {
                                Jump(LastPage());
                                //result= 2;
                            }
                            else
                            {
                                showPage("添加喜欢失败!", LastPage());
                                //result= 3;
                            }
                        }
                    }
                    else
                    {
                        showPage("你不能喜欢自己的项目。请不要恶意刷屏。谢谢!", LastPage());
                        //result= 4;
                    }
                }
            }
            catch (Exception e)
            {
                Response.Write(e.Message);
                throw;
            }

            //return result;
        }

    }
}
