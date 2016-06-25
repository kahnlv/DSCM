﻿/* 
* ======================================================================== 
* 
* Author：鼎燊文化传媒 Time：2015/6/5 16:10:46 
* File name：daohang 
* Version：V1.0.1
* Company: 鼎燊文化传媒 
* Framework Version: 2.0
*
* ======================================================================== 
*/
using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI.WebControls;
using DSCM.Library;
using dscm.Tools.Sql;
using DSCM.ds_tbl_user;
using DSCM.ds_tbl_province;
using DSCM.Backstage;
public partial class Backstage_templates_default_user_insert : Page
{
    public tbl_province[] province = new tbl_province[] { };
    public tbl_user tuser = new tbl_user();

    public string provinceid = "";
    public string cityid = "";
    public override void EmpInfo(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            UserLogin ul = new UserLogin();
            if (ul.Login())
            {
                //获取传参
                string act = dscmSave.QueryString("ds");
                object obj = dscmSave.GetObject(act);
                tuser = obj as tbl_user;
                if (tuser == null) tuser = new tbl_user();
                province = SQL.ReadAll<tbl_province>("tbl_province", "");
                if (tuser.User_City != "")
                {
                    string[] cityids = tuser.User_City.Split(new char[] { ',' });
                    provinceid = cityids[0];
                    cityid = cityids[1];
                }
                string user_id = Save("user_id").ToString();
            }
        }
    }
}