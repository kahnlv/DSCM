/* 
* ======================================================================== 
* 
* Author：鼎燊文化传媒 Time：2015/6/5 14:16:49 
* File name：hongbao 
* Version：V1.0.1
* Company: 鼎燊文化传媒 
* Framework Version: 2.0
*
* ======================================================================== 
*/

using System;
using System.Collections.Generic;
using System.Text;
using dscm.Library.self;
using DSCM.ds_tbl_city;
using dscm.Tools.Sql;

namespace DSCM.Backstage
{
    public class city : DSCMSave
    {
        public void index_DSCM()
        {
            string id = QueryString("id");
            tbl_city[] city = SQL.ReadAll<tbl_city>("tbl_city", " and Provinceid='" + id + "'");
            string json = "<select name=\"object_address\" \"><option value=\"\">请选择</option>";
            foreach (tbl_city ci in city)
            {
                json += "<option value=\"" + ci.ID + "\">" + ci.Cityname + "</option>";
            }
            json += "</select>";
            PageWrite(json, "STR");
        }

    }
}
