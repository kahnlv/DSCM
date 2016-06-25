/* 
* ======================================================================== 
* 
* Author：鼎燊文化传媒 Time：2015/4/21 11:24:33 
* File name：zc_insert3 
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

public partial class Reception_templates_default_zc_insert3 : Page
{
    public override void EmpInfo(object sender, EventArgs e)
    {
		if (!this.IsPostBack)
        {
			//获取传参
			string act = dscmSave.QueryString("ds");
            object obj = dscmSave.GetObject(act);
            if (Save("user_phone").ToString().Equals(""))
            {
                showPage("连接超时，请重新登录。", "/Reception/index.aspx?ds=zc");
            }
        }
    }
}
