/* 
* ======================================================================== 
* 
* Author：鼎燊文化传媒 Time：2015/7/27 10:16:49 
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
using dscm.Tools.Sql;
using DSCM.ds_tbl_admin;

namespace DSCM.Backstage
{
    public class admin : DSCMSave
    {
        UserLogin ul = new UserLogin();
        string admin_id = "";
        string admin_name = "";
        string[] colm = new string[] { };
        string[] value = new string[] { };
        public admin()
        {
            admin_id = Save("admin_id") != null ? Save("admin_id").ToString() : "";
            admin_name = Save("admin_name") != null ? Save("admin_name").ToString() : "";
        }

        public void login_DSCM()
        {
            string username = Form("username");
            string password = Form("password");
            tbl_admin admin = SQL.Read<tbl_admin>("tbl_admin", " and admin_name='" + username + "'");

            if (admin != null && !admin.Admin_Name.Equals(""))
            {
                if (admin.Admin_Pwd.Equals(Md5(password)))
                {
                    Save("admin_id", admin.Admin_Id);
                    Save("admin_name", admin.Admin_Name);
                    Save("admin_type", admin.Admin_Type);
                    Jump("/Backstage/default.aspx");
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

        public void out_DSCM()
        {
            Save("clear");
            Jump("/Backstage/templates/default/login.aspx");
        }

        public void dsinsert_DSCM()
        {
            string user_name = Form("admin_name");
            string admin_pwd = Form("admin_pwd");
            int i = SQL.Read("tbl_admin", " and admin_name='" + user_name + "'");
            if (i > 0)
            {
                PageWrite("用户名重复！", "JS", "/backstage/index.aspx?ds=admin&cm=insert");
            }
            else
            {
                colm = new string[] { "admin_id", "admin_name", "admin_pwd", "admin_type", "parent_admin_id" };
                value = new string[] { Guid, user_name, Md5(admin_pwd), "2", admin_id };
                SQL.Insert("tbl_admin", colm, value);
                ul.Loglog(admin_id, admin_name, "添加管理员");
                Jump("/Backstage/templates/default/admin_index.aspx");
            }
        }

        public void dsupdate_DSCM()
        {
            string id = Form("adminid").ToString();
            string oldpwd = Form("oldpwd").ToString();
            string newpwd = Form("newpwd").ToString();
            tbl_admin admin = SQL.Read<tbl_admin>("tbl_admin", " and admin_id='" + id + "'");
            if (!admin.Admin_Id.Equals(""))
            {
                if (admin.Admin_Pwd.Equals(Md5(oldpwd)))
                {                   
                    colm = new string[] { "admin_pwd" };
                    value = new string[] { Md5(newpwd) };
                    int i = SQL.Update("tbl_admin", colm, value, " and admin_id='" + id + "'");
                    if (i == 1)
                    {                           
                        ul.Loglog(admin_id, admin_name, "修改管理员密码");
                        Jump("/Backstage/templates/default/admin_index.aspx");
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
            else
            {
                Jump("/Backstage/templates/default/login.aspx");
            }
        }

        public void delete_DSCM()
        {
            string id = QueryString("id");
            SQL.Delete("tbl_admin", " and admin_id='" + id + "'");
            ul.Loglog(admin_id, admin_name, "删除管理员");
            Jump("/Backstage/templates/default/admin_index.aspx");
        }
    }
}
