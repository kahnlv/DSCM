/* 
* ======================================================================== 
* 
* Author：鼎燊文化传媒 Time：2015/4/21 9:43:50 
* File name：zc_insert 
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
using DSCM.ds_tbl_province;
using dscm.Tools.Sql;

public partial class Reception_templates_default_zc_insert : Page
{
    public tbl_province[] province = new tbl_province[] { };
    public override void EmpInfo(object sender, EventArgs e)
    {
		if (!this.IsPostBack)
        {
			//获取传参
			string act = dscmSave.QueryString("ds");
            object obj = dscmSave.GetObject(act);
            if (Save("user_phone").ToString().Equals(""))
            {
                showPage("请登录。", "/Reception/index.aspx?ds=zc");
            }
            province = SQL.ReadAll<tbl_province>("tbl_province", "");
        }
    }
}
