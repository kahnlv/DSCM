/* 
* ======================================================================== 
* 
* Author：鼎燊文化传媒 Time：2015/4/24 9:49:24 
* File name：user_info 
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
using DSCM.ds_tbl_user;
using DSCM.ds_tbl_province;
using dscm.Tools.Sql;
using DSCM.ds_tbl_user_space;

public partial class Reception_templates_default_user_info : Page
{
    public tbl_province[] province = new tbl_province[] { };
    public tbl_user user = new tbl_user();
    public tbl_user_space user_space = new tbl_user_space();
    public string provinceid = "";
    public string cityid = "";
    public override void EmpInfo(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            //获取传参
            string act = dscmSave.QueryString("ds");
            object obj = dscmSave.GetObject(act);
            user = obj as tbl_user;
            if (user == null) user = new tbl_user();
            province = SQL.ReadAll<tbl_province>("tbl_province", "");
            if (user.User_City != "")
            {
                string[] cityids = user.User_City.Split(new char[] { ',' });

                if (cityids.Length == 2)
                {
                    provinceid = cityids[0];
                    cityid = cityids[1];
                }
            }

            string user_id = Save("user_id").ToString();
            user_space = SQL.Read<tbl_user_space>("tbl_user_space", " and user_id='" + user_id + "'");
        }
    }
}
