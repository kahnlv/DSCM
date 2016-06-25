/* 
* ======================================================================== 
* 
* Author：鼎燊文化传媒 Time：2015/3/31 15:37:03 
* File name：Default 
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
using DSCM.BLL;
using DSCM.Backstage;
using DSCM.Tool.Tools;
using dscm.Library;

public partial class Backstage_Default : Page
{
    public override void EmpInfo(object sender, EventArgs e)
    {
		if (!this.IsPostBack)
        {
            UserLogin ul = new UserLogin();
            ul.Login();
            //获取传参
            string act = dscmSave.QueryString("ds");
            object obj = dscmSave.GetObject(act);                 
        }
    }
}
