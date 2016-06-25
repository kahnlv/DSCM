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
using DSCM.ds_tbl_new;

public partial class Backstage_templates_default_new_index : Page
{
     public tbl_new[] tbl_news = new tbl_new[] { };
     public string new_title="";
     public string new_inc = "";
     public string new_key = "";
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
                 new_title = dscmSave.Form("new_title");
                 new_inc = dscmSave.Form("new_inc");
                 new_key = dscmSave.Form("new_key");
                 ArrayList al = obj as ArrayList;
                 if (al != null && al.Count == 4)
                 {
                     tbl_news = al[0] as tbl_new[];
                     allcount = (int)al[1];
                     pagestr = al[2] as string;
                     count = (int)al[3];
                 }
             }
         }
    }
}