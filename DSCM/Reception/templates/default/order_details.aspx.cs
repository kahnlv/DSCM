/* 
* ======================================================================== 
* 
* Author：鼎燊文化传媒 Time：2015/6/5 16:10:46 
* File name：order_details 
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
using DSCM.Library;
using DSCM.ds_tbl_order;
using DSCM.ds_tbl_object_zc;
using dscm.Tools.Sql;
using DSCM.ds_tbl_user_space;

public partial class Reception_templates_default_order_details :Page
{
    public tbl_order order = new tbl_order();
    public string content = "";
    public string username = "";
    public tbl_user_space user_space = new tbl_user_space();
    public override void EmpInfo(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            //获取传参
            string act = dscmSave.QueryString("ds");
            object obj = dscmSave.GetObject(act);
            order = obj as tbl_order;
            if (order == null) order = new tbl_order();
            if (order.object_zc_pes.Object_Zc_Id != "")
            {
                tbl_object_zc obj_zc = SQL.Read<tbl_object_zc>("tbl_object_zc", " and object_zc_id='" + order.object_zc_pes.Object_Zc_Id + "'");
                content = obj_zc.Object_Zc_Doc;
            }
            string user_id = Save("user_id").ToString();
            user_space = SQL.Read<tbl_user_space>("tbl_user_space", " and user_id='" + user_id + "'");
       
        }
    }
}