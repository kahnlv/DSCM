/* 
* ======================================================================== 
* 
* Author：鼎燊文化传媒 Time：2015/4/23 10:11:45 
* File name：@new 
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
using System.Collections;
using dscm.Tools.Sql;
using DSCM.ds_tbl_new;

namespace DSCM.Reception
{
    public class @new : DSCMSave
    {
        public ArrayList index_DSCM()
        {
            string order = "new_time";
            ArrayList al = new ArrayList();
            string page = QueryString("page");
            int p = 0;
            int.TryParse(page, out p);
            if (p == 0) p = 1;
            tbl_new[] news = SQL.ReadAll<tbl_new>("tbl_new", "", p, 20, order, false);
            tbl_new[] news1 = SQL.ReadAll<tbl_new>("tbl_new", " and new_tuijian='1'");
            DSCM.Page.PageList pl = new DSCM.Page.PageList();
            string pagestr = pl.WabPage(SQL.AllPageCount, 800, 2);
            al.Add(news); 
            al.Add(news1);
            al.Add(SQL.AllCount);
            al.Add(pagestr);
            al.Add(pl.Count);
            return al;
        }
    }
}
