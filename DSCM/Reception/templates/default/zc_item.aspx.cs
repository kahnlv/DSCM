/* 
* ======================================================================== 
* 
* Author：鼎燊文化传媒 Time：2015/4/17 12:12:05 
* File name：zc_item 
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
using DSCM.ds_tbl_object_zc;
using DSCM.ds_tbl_object_pl;

public partial class Reception_templates_default_zc_item : Page
{
    public tbl_object tbl_obj = new tbl_object();
    public tbl_object_zc[] obj_zc = new tbl_object_zc[] { };
    public int obj_pl=0;
    public int zhichi = 0;
    public string object_id = "";
    public override void EmpInfo(object sender, EventArgs e)
    {
		if (!this.IsPostBack)
        {
            try
            {
                ArrayList al = new ArrayList();
                //获取传参
                string act = dscmSave.QueryString("ds");
                object obj = dscmSave.GetObject(act);
                object_id = dscmSave.QueryString("id");
                al = obj as ArrayList;
                if (object_id.Equals("")) Jump("/Reception/index.aspx?ds=zc");
                if (al != null && al.Count == 4)
                {
                    tbl_obj = al[0] as tbl_object;
                    obj_zc = al[1] as tbl_object_zc[];
                    obj_pl = (int)al[2];
                    if (tbl_obj == null) tbl_obj = new tbl_object();
                    if (obj_zc == null) obj_zc = new tbl_object_zc[] { };
                    zhichi = (int)al[3];
                }
            }
            catch { }
        }
    }
}
