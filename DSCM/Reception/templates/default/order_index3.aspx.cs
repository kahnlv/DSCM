/* 
* ======================================================================== 
* 
* Author：鼎燊文化传媒 Time：2015/4/23 11:39:51 
* File name：order_index3 
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

public partial class Reception_templates_default_order_index3 : Page
{
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
            if (al != null && al.Count == 1)
            {
                order_id = al[0].ToString();
            }
        }
    }
}
