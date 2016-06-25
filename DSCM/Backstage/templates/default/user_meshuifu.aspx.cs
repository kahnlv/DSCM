/* 
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
using System.Collections;
using DSCM.Library;
using DSCM.Backstage;
using DSCM.ds_tbl_user_message;

public partial class Backstage_templates_default_user_meshuifu : Page
{
    public tbl_user_message[] user_mes = new tbl_user_message[] { };
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
                ArrayList al = obj as ArrayList;
                if (al != null && al.Count == 4)
                {
                    user_mes = al[0] as tbl_user_message[];
                    allcount = (int)al[1];
                    pagestr = al[2] as string;
                    count = (int)al[3];
                }
            }
        }
    }
}