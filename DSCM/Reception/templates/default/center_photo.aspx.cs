/* 
* ======================================================================== 
* 
* Author：鼎燊文化传媒 Time：2015/4/24 17:20:55 
* File name：center_photo 
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
using DSCM.ds_tbl_photo;
using DSCM.ds_tbl_photo_class;

public partial class Reception_templates_default_center_photo : Page
{
    public tbl_photo[] photo = new tbl_photo[] { };
    public tbl_photo_class[] pclass = new tbl_photo_class[] { };
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
                photo = al[0] as tbl_photo[];
                pagestr = al[2] as string;
                pclass = al[4] as tbl_photo_class[];
            }
        }
    }
}
