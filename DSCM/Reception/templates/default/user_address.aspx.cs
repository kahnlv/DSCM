/* 
* ======================================================================== 
* 
* Author：鼎燊文化传媒 Time：2015/4/24 10:37:18 
* File name：user_address 
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
using DSCM.ds_tbl_user_delivery_address;
using System.Collections;
using DSCM.ds_tbl_province;
using dscm.Tools.Sql;
using DSCM.ds_tbl_user_space;

public partial class Reception_templates_default_user_address : Page
{
    public tbl_user_delivery_address delivery_address = new tbl_user_delivery_address();
    public tbl_user_delivery_address[] user_delivery_address = new tbl_user_delivery_address[]{};
    public string user_delivery_address_id = "";

    public tbl_user_space user_space = new tbl_user_space();
    public tbl_province[] province = new tbl_province[] { };
    public string provinceid = "";
    //public string cityid ="";
    public override void EmpInfo(object sender, EventArgs e)
    {
		if (!this.IsPostBack)
        {
            ArrayList al = new ArrayList();
			//获取传参
			string act = dscmSave.QueryString("ds");
            object obj = dscmSave.GetObject(act);
            user_delivery_address_id = dscmSave.QueryString("id");
            al = obj as ArrayList;
            if (al!= null&&al.Count == 2)
            {
                delivery_address = al[0] as tbl_user_delivery_address;
                if (delivery_address == null) delivery_address = new tbl_user_delivery_address();
                if (delivery_address.User_Delivery_Address_City != "")
                {
                    string[] cityids = delivery_address.User_Delivery_Address_City.Split(new char[] { ',' });
                    provinceid = cityids[0];
                    //cityid = cityids[1];
                }
               
                user_delivery_address = al[1] as tbl_user_delivery_address[];
                if (user_delivery_address == null) user_delivery_address = new tbl_user_delivery_address[] { };
            }
            province = SQL.ReadAll<tbl_province>("tbl_province", "");
            string user_id = Save("user_id").ToString();
            user_space = SQL.Read<tbl_user_space>("tbl_user_space", " and user_id='" + user_id + "'");
        }
    }
}
