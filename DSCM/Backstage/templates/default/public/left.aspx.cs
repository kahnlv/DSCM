/* 
* ======================================================================== 
* 
* Author：鼎燊文化传媒 Time：2015/4/1 14:44:01 
* File name：left 
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
using dscm.Tools.Sql;
using DSCM.Backstage;
using DSCM.Tool.Tools;
using DSCM.BLL;

public partial class Backstage_templates_default_public_left : Page
{
    public dscm_nav DSCM_NAV = new dscm_nav();
    public string type = "";
    public override void EmpInfo(object sender, EventArgs e)
    {
		if (!this.IsPostBack)
        {
            //获取传参
            string act = dscmSave.QueryString("ds");
            object obj = dscmSave.GetObject(act);
            type = dscmSave.QueryString("type");
            string admin_type = Session["admin_type"] != null ? Session["admin_type"].ToString() : "0";
            //读取json
            string str = "";
            if (Save("admin_type").ToString().Equals("2"))
            {
                str = Config.Admin_Agent;
            }
            else
            {
                str = Config.Admin_Navigation;
            }
            DSCM_NAV = Json.Read<dscm_nav>(str);
        }
    }

    public string TypeToStr(string type)
    {
        switch (type)
        {
            case "0":
                return "项目管理";
            case "1":
                return "用户管理";
            case "2":
                return "评论管理";
            case "3":
                return "订单管理";
            case "4":
                return "新闻管理";
            case "5":
                return "标签通知管理";
            case "6":
                return "系统设置";
            default :
                return "";
        }
    }
}
