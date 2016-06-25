/* 
* ======================================================================== 
* 
* Author：鼎燊文化传媒 Time：2015/3/21 10:39:55 
* File name：index 
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

public partial class index : Page
{
    public override void EmpInfo(object sender, EventArgs e)
    {
		if (!this.IsPostBack)
        {
            //tbl_user u = new tbl_user();
            //u.User_Id = "1";
            //u.User_Img = "2";
            //u.User_Name = "3";
            //u.User_Phone = "4";
            //dscmSave.SelfObject<tbl_user>("user", u);
            //tbl_user _u = dscmSave.SelfObject<tbl_user>("user");
        }
    }
}
