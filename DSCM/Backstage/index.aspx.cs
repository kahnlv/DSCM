/* 
* ======================================================================== 
* 
* Author：鼎燊文化传媒 Time：2015/4/3 10:19:53 
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

public partial class Backstage_index : Page
{
    public override void EmpInfo(object sender, EventArgs e)
    {
		if (!this.IsPostBack)
        {
			//获取传参
			string act = dscmSave.QueryString("ds");
            object obj = dscmSave.GetObject(act);
            string str = ReadConfig("admin");
        }
    }
}
