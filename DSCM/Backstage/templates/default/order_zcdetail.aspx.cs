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
using DSCM.Library;
using DSCM.Backstage;
using dscm.Tools.Sql;
using DSCM.ds_tbl_order;
using DSCM.ds_tbl_user;
using DSCM.ds_tbl_object_zc;
using DSCM.ds_tbl_object_zc_pes;
using DSCM.ds_tbl_user_delivery_address;

public partial class Backstage_templates_default_order_zcdetail : Page
{
    public DSCMtools dtools = new DSCMtools();
    public tbl_order order = new tbl_order();
    public string content = "";
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

                string order_id = dscmSave.QueryString("id");//order_id
                order = SQL.Read<tbl_order>("tbl_order", " and order_id='" + order_id + "'");
                order.user_delicery_address = SQL.Read<tbl_user_delivery_address>("tbl_user_delivery_address", " and user_delivery_address_id='" + order.User_Delivery_Address_Id + "'");
                order.object_zc_pes = SQL.Read<tbl_object_zc_pes>("tbl_object_zc_pes", " and object_zc_pes_id='" + order.Object_Zc_Pes_Id + "'");
                order.user = SQL.Read<tbl_user>("tbl_user", "and user_id='" + order.User_Id + "'");

                if (order == null) order = new tbl_order();
                if (order.object_zc_pes.Object_Zc_Id != "")
                {
                    tbl_object_zc obj_zc = SQL.Read<tbl_object_zc>("tbl_object_zc", " and object_zc_id='" + order.object_zc_pes.Object_Zc_Id + "'");
                    content = obj_zc.Object_Zc_Doc;
                }
            }
        }
    }
}