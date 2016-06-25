/* 
* ======================================================================== 
* 
* Author：鼎燊文化传媒 Time：2015/4/22 15:32:19 
* File name：zc_zhichi 
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
using DSCM.ds_tbl_object_zc;
using DSCM.ds_tbl_object_pl;
using System.Collections;
using DSCM.ds_tbl_object_zc_pes;

public partial class Reception_templates_default_zc_zhichi : Page
{
    public tbl_object tbl_obj = new tbl_object();
    public tbl_object_zc[] obj_zc = new tbl_object_zc[] { };
    public tbl_object_zc_pes[] zc_pes = new tbl_object_zc_pes[] { };
    public int obj_pl = 0;
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
                if (al != null && al.Count == 7)
                {
                    tbl_obj = al[0] as tbl_object;
                    obj_zc = al[1] as tbl_object_zc[];
                    obj_pl = (int)al[2];
                    zc_pes = al[3] as tbl_object_zc_pes[];
                    if (tbl_obj == null) tbl_obj = new tbl_object();
                    if (obj_zc == null) obj_zc = new tbl_object_zc[] { };
                    if (zc_pes == null) zc_pes = new tbl_object_zc_pes[] { };

                    allcount = (int)al[4];
                    pagestr = al[5] as string;
                    count = (int)al[6];
                }
            }
            catch { }
        }
    }
}
