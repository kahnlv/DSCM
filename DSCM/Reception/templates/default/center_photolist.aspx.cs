/* 
* ======================================================================== 
* 
* Author：鼎燊文化传媒 Time：2015/4/24 17:22:13 
* File name：center_photolist 
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
using DSCM.ds_tbl_photo_img;
using System.Collections;

public partial class Reception_templates_default_center_photolist : Page
{
    public tbl_photo_img[] photo_img = new tbl_photo_img[] { };
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
                photo_img = al[0] as tbl_photo_img[];
                if (photo_img == null) photo_img = new tbl_photo_img[] { };
                pagestr = al[2] as string;

            }
        }
    }
}
