/* 
* ======================================================================== 
* 
* Author：鼎燊文化传媒 Time：2015/4/25 10:15:22 
* File name：photo 
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
using System.Collections;
using DSCM.ds_tbl_photo_class;
using DSCM.ds_tbl_photo_img;

namespace DSCM.Reception
{
    class photo : DSCMSave
    {
        public void imginsert_DSCM()
        {
            string user_id = Save("user_id").ToString();
            if (Save("user_phone").ToString().Equals(""))
            {
                showPage("请登录。", "/Reception/index.aspx?ds=zc");
            }
            string id = Form("photo_id");
            string photo_img_title = Form("photo_img_title");
            string photo_img_path = Form("photo_img_title");
            string photo_img_doc = Form("photo_img_doc");
            photo_img_path = upload("/data/upload/", "photo_img_path");
            string[] colm = new string[] { "photo_img_id", "photo_img_path", "photo_img_time", "photo_img_doc", "photo_id", "photo_img_title", "user_id" };
            string[] value = new string[] { Guid, photo_img_path, DateTime.Now.ToString(), photo_img_doc, id, photo_img_title, user_id };
            int i = SQL.Insert("dbo.tbl_photo_img", colm, value);
            if (i == 1)
            {
               Jump(LastPage());
            }
            else
            {
                showPage("添加照片失败。", LastPage());
            }
        }

        public ArrayList img_DSCM()
        {
            string user_id = Save("user_id").ToString();
            if (Save("user_phone").ToString().Equals(""))
            {
                showPage("请登录。", "/Reception/index.aspx?ds=zc");
            }
            string id = QueryString("id");
            ArrayList al = new ArrayList();
            string order = "photo_img_time";
            string page = QueryString("page");
            string start = QueryString("start");
            //if (start.Equals("2")) { start = "and letter_user_id='" + user_id + "'"; } else { start = "and user_id='" + user_id + "'"; }
            int p = 0;
            int.TryParse(page, out p);
            if (p == 0) p = 1;
            tbl_photo_img[] user_log = SQL.ReadAll<tbl_photo_img>("tbl_photo_img", " and photo_id='" + id + "'" + start, p, 20, order, false);
            DSCM.Page.PageList pl = new DSCM.Page.PageList();
            string pagestr = pl.WabPage(SQL.AllPageCount, 800, 2);
            al.Add(user_log);
            al.Add(SQL.AllCount);
            al.Add(pagestr);
            al.Add(pl.Count);
            return al;
        }

        public void insert_DSCM()
        {
            string user_id = Save("user_id").ToString();
            if (Save("user_phone").ToString().Equals(""))
            {
                showPage("请登录。", "/Reception/index.aspx?ds=zc");
            }

            string photo_name = Form("photo_name");
            string photo_class_id = Form("photo_class_id");
            string photo_doc = Form("photo_doc");
            string photo_img = Form("photo_img");
            photo_img = upload("/data/upload/", "photo_img");
            string guid = Guid;
            string[] colm = new string[] { };
            string[] value = new string[] { };
            tbl_photo_class cl = SQL.Read<tbl_photo_class>("dbo.tbl_photo_class", " and photo_class_name='" + photo_class_id + "'");
            if (cl.Photo_Class_Id.Equals(""))
            {
                colm = new string[] { "photo_class_id", "photo_class_name", "photo_class_time", "user_id" };
                value = new string[] { guid, photo_class_id, DateTime.Now.ToString(), user_id };
                SQL.Insert("tbl_photo_class", colm, value);
                cl.Photo_Class_Id = guid;
            }
            colm = new string[] { "photo_id", "photo_name", "photo_class_id", "photo_doc", "photo_img", "photo_time", "user_id", };
            value = new string[] { Guid, photo_name, cl.Photo_Class_Id, photo_doc, photo_img, DateTime.Now.ToString(), user_id };
            int i = SQL.Insert("dbo.tbl_photo", colm, value);
            if (i == 1)
            {
              Jump(LastPage());
            }
            else
            {
                showPage("创建相册失败。", LastPage());
            }
        }

        public ArrayList index_DSCM()
        {
            string user_id = Save("user_id").ToString();
            if (Save("user_phone").ToString().Equals(""))
            {
                showPage("请登录。", "/Reception/index.aspx?ds=zc");
            }
            ArrayList al = new ArrayList();
            string order = "photo_time";
            string page = QueryString("page");
            string start = QueryString("start");
            //if (start.Equals("2")) { start = "and letter_user_id='" + user_id + "'"; } else { start = "and user_id='" + user_id + "'"; }
            int p = 0;
            int.TryParse(page, out p);
            if (p == 0) p = 1;
            tbl_photo[] user_log = SQL.ReadAll<tbl_photo>("tbl_photo", " and user_id='" + user_id + "'" + start, p, 20, order, false);
            DSCM.Page.PageList pl = new DSCM.Page.PageList();
            string pagestr = pl.WabPage(SQL.AllPageCount, 800, 2);
            al.Add(user_log);
            al.Add(SQL.AllCount);
            al.Add(pagestr);
            al.Add(pl.Count);

            foreach (tbl_photo photo in user_log)
            {
                photo.num = SQL.Read("tbl_photo_img", " and photo_id='" + photo.Photo_Id + "'");
            }
            tbl_photo_class[] pclass = SQL.ReadAll<tbl_photo_class>("tbl_photo_class", " and user_id='" + user_id + "'");
            al.Add(pclass);
            return al;
        }

        public void imgdel_DSCM()
        {
            try
            {
                string user_id = Save("user_id").ToString();
                if (Save("user_phone").ToString().Equals(""))
                {
                    showPage("请登录。", "/Reception/index.aspx?ds=zc");
                }
                string id = QueryString("id").ToString();
                int i = SQL.Delete("tbl_user_message", " and photo_img_id='" + id + "'");//删除该图片的所有评论
                i = SQL.Delete("tbl_user_zan", " and photo_img_id='" + id + "'");//删除该图片的赞信息
                i = SQL.Delete("tbl_photo_img", " and photo_img_id='" + id + "'");//删除该图片
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

        public void photodel_DSCM()
        {
            try
            {
                string user_id = QueryString("user_id").ToString();
                if (Save("user_phone").ToString().Equals(""))
                {
                    showPage("请登录。", "/Reception/index.aspx?ds=zc");
                }
                string id = QueryString("id").ToString();
                tbl_photo_img[] images = SQL.ReadAll<tbl_photo_img>("tbl_photo_img", " and photo_id='" + id + "'");
                int i = 0;
                foreach (tbl_photo_img img in images)
                {
                    i = SQL.Delete("tbl_photo_img", " and photo_img_id='" + img.Photo_Img_Id + "'");//删除该相册内的图片
                    i = SQL.Delete("tbl_user_message", " and photo_img_id='" + img.Photo_Img_Id + "'");//删除相册内的图片的所有评论
                    i = SQL.Delete("tbl_user_zan", " and photo_img_id='" + img.Photo_Img_Id + "'");//删除相册内的图片的赞信息
                }
                i = SQL.Delete("tbl_photo", " and photo_id='" + id + "'");//删除该相册
                if (i == 1)
                {
                    Jump("/Reception/index.aspx?ds=photo");
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

        public void photoUpdate_DSCM()
        {
            try
            {
                string user_id = Save("user_id").ToString();
                if (Save("user_phone").ToString().Equals(""))
                {
                    showPage("请登录。", "/Reception/index.aspx?ds=zc");
                }
                string id = QueryString("id").ToString();
                tbl_photo_img img = SQL.Read<tbl_photo_img>("tbl_photo_img", " and photo_img_id='" + id + "'");
                string[] colm = new string[] { "photo_img" };
                string[] value = new string[] { img.Photo_Img_Path };
                int i = SQL.Update("tbl_photo", colm, value, " and photo_id='" + img.Photo_Id + "'");
                if (i == 1)
                {
                    Jump("/Reception/index.aspx?ds=photo");
                }
                else
                {
                    showPage("设置失败。", LastPage());
                }

            }
            catch (Exception e)
            {
                Response.Write(e.Message);
                throw;
            }
        }
    }
}
