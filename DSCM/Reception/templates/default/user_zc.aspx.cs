/* 
* ======================================================================== 
* 
* Author：鼎燊文化传媒 Time：2015/4/23 15:42:23 
* File name：user_zc 
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
using DSCM.ds_tbl_object_zc_pes;

public partial class Reception_templates_default_user_zc : Page
{
    public tbl_object_zc_pes[] zc_pes = new tbl_object_zc_pes[] { };
    public override void EmpInfo(object sender, EventArgs e)
    {
		if (!this.IsPostBack)
        {
			//获取传参
			string act = dscmSave.QueryString("ds");
            object obj = dscmSave.GetObject(act);
            ArrayList al = obj as ArrayList;
            if (al != null && al.Count == 4)
            {
                zc_pes = al[0] as tbl_object_zc_pes[];
                allcount = (int)al[1];
                pagestr = al[2].ToString();
                count = (int)al[3];
                if (zc_pes == null) zc_pes = new tbl_object_zc_pes[] { };
            }
        }
    }
}
