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
using DSCM.Backstage;
using dscm.Tools.Sql;
using DSCM.ds_tbl_user_message;

public partial class Backstage_templates_default_user_logcomupdate : Page
{
    public tbl_user_message tuser_mes = new tbl_user_message();
    public string user_message_id = "";
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
                user_message_id = dscmSave.QueryString("id");
                tuser_mes = SQL.Read<tbl_user_message>("tbl_user_message", " and user_message_id='" + user_message_id + "'");
            }
        }

    }
}