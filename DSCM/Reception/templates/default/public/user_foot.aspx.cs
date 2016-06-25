/* 
* ======================================================================== 
* 
* Author：鼎燊文化传媒 Time：2015/4/23 15:20:29 
* File name：user_foot 
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

public partial class Reception_templates_default_public_user_foot : Page
{
    public override void EmpInfo(object sender, EventArgs e)
    {
		if (!this.IsPostBack)
        {
			//获取传参
			string act = dscmSave.QueryString("ds");
            object obj = dscmSave.GetObject(act);
            
        }
    }
}
