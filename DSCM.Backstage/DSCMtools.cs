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
using dscm.Tools.Sql;
using DSCM.ds_tbl_user;
using DSCM.ds_tbl_province;
using DSCM.ds_tbl_city;

namespace DSCM.Backstage
{
    public class DSCMtools : DSCMSave
    {
        public tbl_user user(string id)
        {
            tbl_user user = SQL.Read<tbl_user>("tbl_user", " and user_id='" + id + "'");
            return user;
        }

        public string City(string id)
        {
            string c = "";
            string[] idstr = id.Split(',');
            int m = 0;
            if (idstr.Length > 0)
            {
                if (int.TryParse(idstr[0], out m))
                {
                    tbl_province p = SQL.Read<tbl_province>("tbl_province", " and di='" + idstr[0] + "'");
                    c += p.Provincename + " ";
                }
            }
            if (idstr.Length > 1)
            {
                if (int.TryParse(idstr[1], out m))
                {
                    tbl_city p = SQL.Read<tbl_city>("tbl_city", " and id='" + idstr[1] + "'");
                    c += p.Cityname + " ";
                }
            }
            return c;
        }
    }
}
