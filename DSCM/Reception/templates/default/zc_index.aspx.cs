/* 
* ======================================================================== 
* 
* Author：鼎燊文化传媒 Time：2015/4/17 10:17:01 
* File name：zc_index 
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
using DSCM.ds_tbl_object;
using System.Collections;
using DSCM.ds_tbl_object_zc_pes;

public partial class Reception_templates_default_zc_index : Page
{
    public tbl_object[] t_obj = new tbl_object[] { };
    public tbl_object[] tobj = new tbl_object[] { };
    public tbl_object_zc_pes zc_pes = new tbl_object_zc_pes();
    public int pescount = 0;
    public int objcount = 0;
    public override void EmpInfo(object sender, EventArgs e)
    {
		if (!this.IsPostBack)
        {
			//获取传参
			string act = dscmSave.QueryString("ds");
            object obj = dscmSave.GetObject(act);
            ArrayList al = new ArrayList();
            al = obj as ArrayList;
            if (al != null && al.Count == 5)
            {
                t_obj = al[0] as tbl_object[];
                tobj = al[1] as tbl_object[];
                zc_pes = al[2] as tbl_object_zc_pes;
                objcount = (int)al[3];
                pescount = (int)al[4];
                if (t_obj == null) t_obj = new tbl_object[] { };
                if (tobj == null) tobj = new tbl_object[] { };
                if (zc_pes == null) zc_pes = new tbl_object_zc_pes();
            }
            
        }
    }
}
