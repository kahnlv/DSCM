/* 
* ======================================================================== 
* 
* Author：鼎燊文化传媒 Time：2015/4/23 9:41:26 
* File name：remen 
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
using DSCM.ds_tbl_object;

public partial class Reception_templates_default_public_remen : Page
{
    public tbl_object[] tbl_obj = new tbl_object[] { };
    public string type = "";
    public override void EmpInfo(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            //获取传参
            string act = dscmSave.QueryString("ds");
            object obj = dscmSave.GetObject(act);
            //string c = dscmSave.QueryString("c");
            // dscmSave.QueryString("type");
            string c = Request.Params["c"];
            type = Request.Params["type"];
            int ic = 0;
            if (!int.TryParse(c, out ic)) ic = 3;
            int count = SQL.Read("tbl_object", "");
            if (count > 0)
            {
                Random r = new Random();
                int k = r.Next(1, count);
                if (k < 4) k = 4;
                tbl_obj = SQL.ReadAll<tbl_object>("(select row_number()over(order by object_id)rownumber,* from dbo.tbl_object) a", " and object_stop_time>getdate() and rownumber between " + (k - 3) + " and " + k, ic);
            }
        }
    }
}
