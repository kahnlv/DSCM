/* 
* ======================================================================== 
* 
* Author：鼎燊文化传媒 Time：2015/4/23 10:11:45 
* File name：@new 
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
using DSCM.ds_tbl_new;

namespace DSCM.Backstage
{
    public class @new : DSCMSave
    {
        UserLogin ul = new UserLogin();
        string admin_id = "";
        string admin_name = "";
        string[] colm = new string[] { };
        string[] value = new string[] { };
        public @new()
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
            string new_title = Form("new_title");
            string new_inc = Form("new_inc");
            string new_key = Form("new_key");

            string order = "new_time";
            if (!new_title.Equals(""))
            {
                new_title = " and new_title like '%" + new_title + "%'";
            }
            if (!new_inc.Equals(""))
            {
                new_inc = " and new_inc like '%" + new_inc + "%'";
            }
            if (!new_key.Equals(""))
            {
                new_key = " and new_key like '%" + new_key + "%'";
            }
            string sql = new_title + new_inc + new_key ;
            ArrayList al = new ArrayList();
            string page = QueryString("page");
            int p = 0;
            int.TryParse(page, out p);
            if (p == 0) p = 1;
            tbl_new[] news = SQL.ReadAll<tbl_new>("tbl_new", sql, p, 20, order, false);
            DSCM.Page.PageList pl = new DSCM.Page.PageList();
            string pagestr = pl.WabPage(SQL.AllPageCount, 800, 2);
            al.Add(news);
            al.Add(SQL.AllCount);
            al.Add(pagestr);
            al.Add(pl.Count);
            return al;
        }

        public void dsinsert_DSCM()
        {
            string new_key = Form("new_key");
            string new_title = Form("new_title");
            string new_time = Form("new_time");
            string new_label = Form("new_label");
            string new_inc = Form("new_inc");
            string new_doc = Form("new_doc");
            string new_tuijian = Form("new_tuijian");

            colm = new string[] { "new_id", "new_key", "new_title", "new_time", "new_label", "new_inc", "new_doc", "new_tuijian" };
            value = new string[] { Guid, new_key, new_title, new_time, new_label, new_inc, new_doc, new_tuijian };
            int i = SQL.Insert("tbl_new", colm, value);
            if (i == 1)
            {
                ul.Loglog(admin_id, admin_name, "添加新闻");
                Jump("/backstage/index.aspx?ds=new&cm=index");
            }
            else
            {
                showPage("修改新闻失败", LastPage());
            }
        }

        public void dsupdate_DSCM()
        {
            string new_id = Form("new_id");
            string new_key = Form("new_key");
            string new_title = Form("new_title");
            string new_time = Form("new_time");
            string new_label = Form("new_label");
            string new_inc = Form("new_inc");
            string new_doc = Form("new_doc");
            string new_tuijian = Form("new_tuijian");
            colm = new string[] { "new_key", "new_title", "new_time", "new_label", "new_inc", "new_doc", "new_tuijian" };
            value = new string[] { new_key, new_title, new_time, new_label, new_inc, new_doc, new_tuijian };
            int i = SQL.Update("tbl_new", colm, value, " and new_id='" + new_id + "'");
            if (i == 1)
            {
                ul.Loglog(admin_id, admin_name, "修改新闻");
                Jump("/backstage/index.aspx?ds=new&cm=index");
            }
            else
            {
                showPage("修改新闻失败", LastPage());
            }
        
        }

        public void delete_DSCM()
        {
            string id = QueryString("id");
            SQL.Delete("tbl_new", " and new_id='" + id + "'");
            ul.Loglog(admin_id, admin_name, "删除新闻");
            Jump(LastPage());
        }
    }
}
