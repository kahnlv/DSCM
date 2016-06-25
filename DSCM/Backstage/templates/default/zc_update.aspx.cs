/* 
* ======================================================================== 
* 
* Author：鼎燊文化传媒 Time：2015/6/5 16:10:46 
* File name：daohang 
* Version：V1.0.1
* Company: 鼎燊文化传媒 
* Framework Version: 2.0
*
* ======================================================================== 
*/
using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI.WebControls;
using DSCM.Library;
using DSCM.Backstage;
using dscm.Tools.Sql;
using DSCM.ds_tbl_object;
using DSCM.ds_tbl_province;

public partial class Backstage_templates_default_zc_update : Page
{
    public tbl_object tobj = new tbl_object();
    public tbl_province[] province = new tbl_province[] { };
    public string provinceid = "";
    public string object_id = "";
    public override void EmpInfo(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            UserLogin ul = new UserLogin();
            if (ul.Login())
            {
                //获取传参
                string act = dscmSave.QueryString("ds");
                object obj = dscmSave.GetObject(act);
                object_id = dscmSave.QueryString("id");
                tobj = SQL.Read<tbl_object>("tbl_object", " and object_id='" + object_id + "'");
                province = SQL.ReadAll<tbl_province>("tbl_province", "");
                if (!tobj.Object_Address.Equals(""))
                {
                    string[] cityids = tobj.Object_Address.Split(new char[] { ',' });
                    provinceid = cityids[0];
                }
            }
        }
    }
}