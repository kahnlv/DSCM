/* 
* ======================================================================== 
* 
* Author：鼎燊文化传媒 Time：2015/4/23 11:34:51 
* File name：order_index2 
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
using DSCM.ds_tbl_object_zc;

public partial class Reception_templates_default_order_index2 : Page
{
    public tbl_object tbl_obj = new tbl_object();
    public tbl_object_zc obj_zc = new tbl_object_zc();
    public string object_zc_id = "";
    public string object_id = "";
    public string order_id = "";
    public override void EmpInfo(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            //获取传参
            string act = dscmSave.QueryString("ds");
            object obj = dscmSave.GetObject(act);
            if (Save("user_phone").ToString().Equals(""))
            {
                showPage("连接超时，请重新登录。", LastPage());
            } 
            ArrayList al = obj as ArrayList;
            if (al != null && al.Count == 3)
            {
                tbl_obj = al[0] as tbl_object;
                obj_zc = al[1] as tbl_object_zc;
                if (tbl_obj == null) tbl_obj = new tbl_object();
                if (obj_zc == null) obj_zc = new tbl_object_zc();
                order_id = al[2].ToString();
                object_zc_id = obj_zc.Object_Zc_Id;
                object_id = tbl_obj.Object_Id;
            }
        }
    }
}
