using dscm.Library.self;
using dscm.Tools.Sql;
using DSCM.ds_tbl_admin;
using DSCM.ds_tbl_biaoqian;
using DSCM.ds_tbl_message;
using DSCM.ds_tbl_message_class;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace DSCM.Backstage
{
    public class quanzi : DSCMSave
    {
        UserLogin ul = new UserLogin();
        string admin_id = "";
        string admin_name = "";
        string[] colm = new string[] { };
        string[] value = new string[] { };
        public quanzi()
        {
            admin_id = Save("admin_id") != null ? Save("admin_id").ToString() : "";
            admin_name = Save("admin_name") != null ? Save("admin_name").ToString() : "";
            if (admin_id.Equals(""))
            {
                ul.Login();
            }
        }

        public ArrayList message_DSCM()
        {
            string mescon =Form("message_content");
            string order = "message_time";

            if (!mescon.Equals(""))
            {
                mescon = " and message_content like '%" + mescon + "%'";
            }

            ArrayList al = new ArrayList();
            string page = QueryString("page");
            int p = 0;
            int.TryParse(page, out p);
            if (p == 0) p = 1;
            tbl_message[] messages = SQL.ReadAll<tbl_message>("tbl_message", mescon, p, 20, order, false);
            foreach (tbl_message tmes in messages)
            {
                tmes.admin = SQL.Read<tbl_admin>("tbl_admin", " and admin_id='" + tmes.Admin_Id + "'");
                tmes.tmescla = SQL.Read<tbl_message_class>("tbl_message_class", " and message_class_id='" + tmes.Message_Class_Id + "'");
            }

            DSCM.Page.PageList pl = new DSCM.Page.PageList();
            string pagestr = pl.WabPage(SQL.AllPageCount, 800, 2);
            al.Add(messages);
            al.Add(SQL.AllCount);
            al.Add(pagestr);
            al.Add(pl.Count);
            return al;
        }

        public ArrayList mesclass_DSCM()
        {
            string mesparcla = Form("mescla_parentid");
            string mescla_type = Form("mescla_type");
            string order = "message_class_time";
            if (!mesparcla.Equals(""))
            {
                mesparcla = " and message_class_parentid='" + mesparcla + "'";
            }
            if (!mescla_type.Equals(""))
            {
                mescla_type = " and message_class_type='" + mescla_type + "'";
            }
            ArrayList al = new ArrayList();
            string page = QueryString("page");
            int p = 0;
            int.TryParse(page, out p);
            if (p == 0) p = 1;
            tbl_message_class[] mesclas = SQL.ReadAll<tbl_message_class>("tbl_message_class", mesparcla + mescla_type, p, 20, order, false);
            foreach (tbl_message_class tmescla in mesclas)
            {
                tmescla.admin = SQL.Read<tbl_admin>("tbl_admin", " and admin_id='" + tmescla.Admin_Id + "'");
                if (tmescla.Message_Class_Parentid == "0")
                {
                    tmescla.mesparclaname = "无";
                }
                else
                {
                    tmescla.mesparclaname = SQL.Read<tbl_message_class>("tbl_message_class", "and message_class_id='" + tmescla.Message_Class_Parentid + "'").Message_Class_Name;
                }
            }
            tbl_message_class[] mespraclas = SQL.ReadAll<tbl_message_class>("tbl_message_class", " and message_class_parentid='0'");
            DSCM.Page.PageList pl = new DSCM.Page.PageList();
            string pagestr = pl.WabPage(SQL.AllPageCount, 800, 2);
            al.Add(mesclas);
            al.Add(mespraclas);
            al.Add(SQL.AllCount);
            al.Add(pagestr);
            al.Add(pl.Count);
            return al;
        }

        public ArrayList biaoqian_DSCM()
        {
            string type = Form("biaoqian_type");
            string order = "biaoqian_time";
            if (!type.Equals(""))
            {
                type = " and biaoqian_type='" + type + "'";
            }
            ArrayList al = new ArrayList();
            string page = QueryString("page");
            int p = 0;
            int.TryParse(page, out p);
            if (p == 0) p = 1;
            tbl_biaoqian[] biaoqians = SQL.ReadAll<tbl_biaoqian>("tbl_biaoqian", type, p, 20, order, false);
            foreach (tbl_biaoqian tbq in biaoqians)
            {
                tbq.admin = SQL.Read<tbl_admin>("tbl_admin", " and admin_id='" + tbq.Admin_Id + "'");
            }
            DSCM.Page.PageList pl = new DSCM.Page.PageList();
            string pagestr = pl.WabPage(SQL.AllPageCount, 800, 2);

            al.Add(biaoqians);
            al.Add(SQL.AllCount);
            al.Add(pagestr);
            al.Add(pl.Count);
            return al;
        }

        public void dsmesinsert_DSCM()
        {
            string message_content = Form("message_content");
            string message_class_id = Form("mescla_id");
            colm = new string[] { "message_id", "message_content", "message_time", "admin_id" ,"message_class_id"};
            value = new string[] { Guid, message_content, DateTime.Now.ToString(), admin_id, message_class_id };
            int i = SQL.Insert("tbl_message", colm, value);
            if (i == 1)
            {
                ul.Loglog(admin_id, admin_name, "添加通知");
                Jump("/backstage/index.aspx?ds=quanzi&cm=message");
            }
            else
            {
                showPage("添加通知失败", LastPage());
            }
        }

        public void dsmesupdate_DSCM()
        {
            try
            {
                string message_id = Form("mes_id");
                string message_content = Form("message_content");
                string message_class_id = Form("mescla_id");

                colm = new string[] { "message_content", "message_class_id" };
                value = new string[] { message_content, message_class_id };
                int i = SQL.Update("tbl_message", colm, value, " and message_id='" + message_id + "'");
                if (i == 1)
                {
                    ul.Loglog(admin_id, admin_name, "修改通知");
                    showPage("修改成功！", LastPage());
                }
                else
                {
                    showPage("修改通知失败！", LastPage());
                }
            }
            catch { }
        }

        public void dsmesdelete_DSCM()
        {
            string id = QueryString("id").ToString();

            int i = SQL.Delete("tbl_message", " and message_id='" + id + "'");
            if (i >= 1)
            {
                ul.Loglog(admin_id, admin_name, "删除通知");
                Jump(LastPage());
            }
            else
            {
                showPage("删除通知失败！", LastPage());
            }
        }

        public void dsmesclainsert_DSCM()
        {
            try
            {
                string mescla_name = Form("mescla_name");
                string mesclatype = Form("mescla_type");
                string mesclaparid = Form("mescla_parentid");
                colm = new string[] { "message_class_id", "message_class_name", "message_class_time", "message_class_type", "message_class_parentid", "admin_id" };
                value = new string[] { Guid, mescla_name, DateTime.Now.ToString(), mesclatype, mesclaparid,admin_id };
                int i = SQL.Insert("tbl_message_class", colm, value);
                if (i == 1)
                {
                    ul.Loglog(admin_id, admin_name, "添加通知类别");
                    Jump("/backstage/index.aspx?ds=quanzi&cm=mesclass");
                }
                else
                {
                    showPage("添加通知类别失败", LastPage());
                }

            }
            catch (Exception e) { Response.Write(e); }
        }

        public void dsmesclaupdate_DSCM()
        {
            try
            {
                string message_class_id = Form("mescla_id");
                string mescla_name = Form("mescla_name");
                string mesclatype = Form("mescla_type");
                string mesclaparid = Form("mescla_parentid");
                colm = new string[] { "message_class_name", "message_class_time", "message_class_type", "message_class_parentid", "admin_id" };
                value = new string[] { mescla_name, DateTime.Now.ToString(), mesclatype, mesclaparid, admin_id };
                int i = SQL.Update("tbl_message_class", colm, value, " and message_class_id='" + message_class_id + "'");
                if (i == 1)
                {
                    ul.Loglog(admin_id, admin_name, "修改通知类别");
                    Jump("/backstage/index.aspx?ds=quanzi&cm=mesclass");
                }
                else
                {
                    showPage("修改通知类别失败", LastPage());
                }

            }
            catch (Exception e) { Response.Write(e); }

        }

        public void dsmescladelete_DSCM()
        {
            string id = QueryString("id").ToString();

            int i = SQL.Delete("tbl_message_class", " and message_class_id='" + id + "' or message_class_parentid='" + id + "'");
            if (i >= 1)
            {
                ul.Loglog(admin_id, admin_name, "删除通知类别");
                Jump(LastPage());
            }
            else
            {
                showPage("删除通知类别失败！", LastPage());
            }
        }

        public void dsbqinsert_DSCM()
        {
            try
            {
                string biaoqian_name = Form("biaoqian_name");
                string biaoqian_type = Form("biaoqian_type");
                int i = SQL.Read("tbl_biaoqian", " and biaoqian_name='" + biaoqian_name + "'");
                if (i > 0)
                {
                    PageWrite("标签名重复！", "JS", LastPage());
                }
                else
                {
                    colm = new string[] { "biaoqian_id", "biaoqian_name", "biaoqian_time", "biaoqian_type", "admin_id" };
                    value = new string[] { Guid, biaoqian_name, DateTime.Now.ToString(), biaoqian_type, admin_id };
                    i = SQL.Insert("tbl_biaoqian", colm, value);
                    if (i == 1)
                    {
                        ul.Loglog(admin_id, admin_name, "添加标签");
                        Jump("/backstage/index.aspx?ds=quanzi&cm=biaoqian");
                    }
                    else
                    {
                        showPage("添加标签失败", LastPage());
                    }
                }
            }
            catch (Exception e) { Response.Write(e); }
        }

        public void dsbqupdate_DSCM()
        {
            try
            {
                string biaoqian_id = Form("biaoqian_id");
                string biaoqian_name = Form("biaoqian_name");
                string biaoqian_type = Form("biaoqian_type");
                tbl_biaoqian bq = SQL.Read<tbl_biaoqian>("tbl_biaoqian", " and biaoqian_name='" + biaoqian_name + "'");
                if (bq.Biaoqian_Id != biaoqian_id)
                {
                    PageWrite("该标签名已存在！", "JS", LastPage());
                }
                else
                {
                    colm = new string[] { "biaoqian_name", "biaoqian_time", "biaoqian_type", "admin_id" };
                    value = new string[] { biaoqian_name, DateTime.Now.ToString(), biaoqian_type, admin_id };
                    int i = SQL.Update("tbl_biaoqian", colm, value, " and biaoqian_id='" + biaoqian_id + "'");
                    if (i == 1)
                    {
                        ul.Loglog(admin_id, admin_name, "修改标签");
                        Jump("/backstage/index.aspx?ds=quanzi&cm=biaoqian");
                    }
                    else
                    {
                        showPage("修改标签失败", LastPage());
                    }
                }
            }
            catch (Exception e) { Response.Write(e); }
        }

        public void dsbqdelete_DSCM()
        {
            string id = QueryString("id").ToString();

            int i = SQL.Delete("tbl_biaoqian", " and biaoqian_id='" + id + "'");
            if (i >= 1)
            {
                ul.Loglog(admin_id, admin_name, "删除标签");
                Jump(LastPage());
            }
            else
            {
                showPage("删除标签失败！", LastPage());
            }
        }

        public void mesparcla_DSCM()
        {
            string type = QueryString("type");
            tbl_message_class[] mesclas = SQL.ReadAll<tbl_message_class>("tbl_message_class", " and message_class_parentid='0' and message_class_type='" + type + "'");
            string json = "<select name=\"mescla_parentid\" ><option value=\"0\">无</option>";
            foreach (tbl_message_class mescla in mesclas)
            {
                json += "<option value=\"" + mescla.Message_Class_Id + "\">" + mescla.Message_Class_Name + "</option>";
            }
            json += "</select>";
            PageWrite(json, "STR");
        }
    }
}
