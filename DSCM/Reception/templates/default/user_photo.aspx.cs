/* 
* ======================================================================== 
* 
* Author：鼎燊文化传媒 Time：2015/4/23 16:16:09 
* File name：user_pohot 
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
using DSCM.ds_tbl_user_space;
using dscm.Tools.Sql;

public partial class Reception_templates_default_user_pohot : Page
{
    public string user_img = "";
    public tbl_user_space user_space = new tbl_user_space();
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
            user_img = Save("user_img").ToString();
        }
        string user_id = Save("user_id").ToString();
        user_space = SQL.Read<tbl_user_space>("tbl_user_space", " and user_id='" + user_id + "'");
    }
}
