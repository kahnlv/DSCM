/* 
* ======================================================================== 
* 
* Author：鼎燊文化传媒 Time：2015/4/22 9:52:02 
* File name：zc_list 
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
using DSCM.ds_tbl_object;
using dscm.Tools.Sql;

public partial class Reception_templates_default_zc_list : Page
{
    public tbl_object[] tbl_obj = new tbl_object[] { };
    public string XM = "";
    public string PX = "";
    public string type = "";
    public int objcount = 0;
    public override void EmpInfo(object sender, EventArgs e)
    {
		if (!this.IsPostBack)
        {
			//获取传参
			string act = dscmSave.QueryString("ds");
            object obj = dscmSave.GetObject(act);

            XM = dscmSave.QueryString("xm");
            PX = dscmSave.QueryString("px");
            type = dscmSave.QueryString("type");
            ArrayList al = obj as ArrayList;
            if (al != null && al.Count == 4)
            {
                tbl_obj = al[0] as tbl_object[];
                allcount = (int)al[1];
                pagestr = al[2] as string;
                count = (int)al[3];
            }
            objcount = SQL.Read("tbl_object", "  and object_state='1' ");
        }
    }
}
