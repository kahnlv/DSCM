/* 
* ======================================================================== 
* 
* Author：鼎燊文化传媒 Time：2015/6/5 16:10:46 
* File name：daohang 
* Version：V1.0.1
* Company: 鼎燊文化传媒 
* Framework Version: 2.0
*
* ======================================================================== 
*/
using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI.WebControls;
using System.Collections;
using DSCM.Library;
using DSCM.Backstage;
using DSCM.ds_tbl_object_zc;
using DSCM.ds_tbl_object;

public partial class Backstage_templates_default_zc_zclist :Page
{
    public tbl_object_zc[] tbl_obj_zc = new tbl_object_zc[] { };
    public tbl_object tobj = new tbl_object();
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

                ArrayList al = obj as ArrayList;
                if (al != null && al.Count == 5)
                {
                    tbl_obj_zc = al[0] as tbl_object_zc[];
                    tobj = al[1] as tbl_object;
                    allcount = (int)al[2];
                    pagestr = al[3] as string;
                    count = (int)al[4];
                }
            }
        }
    }
}