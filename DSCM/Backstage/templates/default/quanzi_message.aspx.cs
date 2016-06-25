using DSCM.Backstage;
using DSCM.ds_tbl_message;
using DSCM.Library;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Web;
using System.Web.UI.WebControls;

public partial class Backstage_templates_default_quanzi_message : Page
{
    public tbl_message[] tbl_messages = new tbl_message[] { };
    public string message_content = "";
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
                 message_content = dscmSave.Form("message_content");
                 ArrayList al = obj as ArrayList;
                 if (al != null && al.Count == 4)
                 {
                     tbl_messages = al[0] as tbl_message[];
                     allcount = (int)al[1];
                     pagestr = al[2] as string;
                     count = (int)al[3];
                 }
             }
         }


    }
}