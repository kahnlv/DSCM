/* 
* ======================================================================== 
* 
* Author：鼎燊文化传媒 Time：2015/4/22 16:51:42 
* File name：zhichi 
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
using DSCM.ds_tbl_object_zc;
using DSCM.ds_tbl_object;

public partial class Reception_templates_default_zhichi : Page
{
    public tbl_object_zc[] obj_zc = new tbl_object_zc[] { };
    public tbl_object obj = new tbl_object();   
    public override void EmpInfo(object sender, EventArgs e)
    {
		if (!this.IsPostBack)
        {
			//获取传参
			string act = dscmSave.QueryString("ds");
            object o = dscmSave.GetObject(act);
            ArrayList al = o as ArrayList;
            if (al != null && al.Count == 2)
            {
                obj = al[0] as tbl_object;
                obj_zc = al[1] as tbl_object_zc[];
                if (obj == null) obj = new tbl_object();
                if (obj_zc == null) obj_zc = new tbl_object_zc[] { };
            }
           
        }
    }
}
