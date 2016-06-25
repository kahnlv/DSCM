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
using DSCM.ds_tbl_province;
using DSCM.ds_tbl_order;
using DSCM.ds_tbl_user_delivery_address;

public partial class Backstage_templates_default_order_update :Page
{
    public tbl_order order = new tbl_order();
    public tbl_user_delivery_address tuser = new tbl_user_delivery_address();
    public tbl_province[] province = new tbl_province[] { };
    public string order_id = "";
    public string provinceid = "";
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
                order_id = dscmSave.QueryString("id");
                order = SQL.Read<tbl_order>("tbl_order", " and order_id='" + order_id + "'");
                tuser = SQL.Read<tbl_user_delivery_address>("tbl_user_delivery_address", " and user_delivery_address_id='" + order.User_Delivery_Address_Id + "'");
                province = SQL.ReadAll<tbl_province>("tbl_province", "");
                if (!tuser.User_Delivery_Address_City.Equals(""))
                {
                    string[] cityids = tuser.User_Delivery_Address_City.Split(new char[] { ',' });
                    provinceid = cityids[0];
                }
            }
        }

    }
}