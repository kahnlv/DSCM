/* 
* ======================================================================== 
* 
* Author：鼎燊文化传媒 Time：2015/4/23 10:11:37 
* File name：new_index 
* Version：V1.0.1
* Company: 鼎燊文化传媒 
* Framework Version: 2.0
*
* ======================================================================== 
*/

using System;
using System.Collections.Generic;
using System.Web;
using DSCM.Library;
using System.Web.UI.WebControls;
using System.Collections;
using DSCM.ds_tbl_new;

public partial class Reception_templates_default_new_index : Page
{
    public tbl_new[] tbl_news = new tbl_new[] { };
    public tbl_new[] tbl_news1 = new tbl_new[] { };
    public override void EmpInfo(object sender, EventArgs e)
    {
		if (!this.IsPostBack)
        {
			//获取传参
			string act = dscmSave.QueryString("ds");
            object obj = dscmSave.GetObject(act);
            ArrayList al = obj as ArrayList;
            if (al != null && al.Count == 5)
            {
                tbl_news = al[0] as tbl_new[];
                tbl_news1 = al[1] as tbl_new[];
                allcount = (int)al[2];
                pagestr = al[3] as string;
                count = (int)al[4];
            }
        }
    }
}
