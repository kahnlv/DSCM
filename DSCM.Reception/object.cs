/* 
* ======================================================================== 
* 
* Author：鼎燊文化传媒 Time：2015/4/24 13:43:47 
* File name：@object 
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
using DSCM.ds_tbl_object;
using DSCM.ds_tbl_object_zc_pes;
using System.Collections;
using DSCM.ds_tbl_order;
using DSCM.ds_tbl_user_delivery_address;
using DSCM.ds_tbl_user;

namespace DSCM.Reception
{
   class @object : DSCMSave
    {
       
        public ArrayList sendout_DSCM()
        {
            string user_id = Save("user_id").ToString();
            if (Save("user_phone").ToString().Equals(""))
            {
                showPage("请登录。", "/Reception/index.aspx?ds=zc");
            }
            ArrayList al = new ArrayList();
            string order = "order_time";
            string page = QueryString("page");
            string start = QueryString("start");
            if (start.Equals("0")) { start = " and order_start in(0,1)"; }
            if (start.Equals("1")) { start = " and order_start in(2,3)"; }
            int p = 0;
            int.TryParse(page, out p);
            if (p == 0) p = 1;
            string[] colm = new string[] { "order_id","user_id","object_id","object_zc_pes_id","order_price","object_title","order_time","order_start","user_delivery_address_id",
                "(select user_name from dbo.tbl_user where user_id=a.user_id)as user_name", 
                "(select user_img from dbo.tbl_user where user_id=a.user_id)as user_img" };
            tbl_order[] user_log = SQL.ReadAll<tbl_order>("tbl_order", colm, " and object_id in (select object_id from dbo.tbl_object where user_id='" + user_id + "') " + start , p, 20, order, false);
            foreach (tbl_order tbl_order in user_log)
            {
               tbl_order.user_delicery_address = SQL.Read<tbl_user_delivery_address>("tbl_user_delivery_address", " and user_delivery_address_id='" + tbl_order.User_Delivery_Address_Id + "'");
               tbl_order.object_zc_pes = SQL.Read<tbl_object_zc_pes>("tbl_object_zc_pes", " and object_zc_pes_id='" + tbl_order.Object_Zc_Pes_Id + "'");
               tbl_order.user = SQL.Read<tbl_user>("tbl_user", "and user_id='" + tbl_order.User_Id + "'");
               tbl_order.tbl_obj = SQL.Read<tbl_object>("tbl_object", " and object_id='" + tbl_order.Object_Id + "'");  
            }
            
            DSCM.Page.PageList pl = new DSCM.Page.PageList();
            string pagestr = pl.WabPage(SQL.AllPageCount, 800, 2);
            al.Add(user_log);
            al.Add(SQL.AllCount);
            al.Add(pagestr);
            al.Add(pl.Count);
            return al;
        }

        public void orderwuliu_DSCM()
        {
            try
            {
                string user_id = Save("user_id").ToString();
                if (Save("user_phone").ToString().Equals(""))
                {
                    showPage("请登录。", "/Reception/index.aspx?ds=zc");
                }
                string order_id = Form("order_id");
                string order_company = Form("order_company");
                string order_waybillno = Form("order_waybillno");
                string order_delivery_info = Form("order_delivery_info");
                string order_receive_info = Form("order_receive_info");

                //更新order表状态为已付款
                string[] colm = new string[] { "order_start", "order_company", "order_waybillno", "order_delivery_info", "order_receive_info" };
                string[] value = new string[] { "2", order_company, order_waybillno, order_delivery_info, order_receive_info };
                int i = SQL.Update("tbl_order", colm, value, " and order_id='" + order_id + "'");
                if (i == 1)
                {
                    Jump("/Reception/index.aspx?ds=object&cm=sendout");
                }
                else
                {
                    showPage("提交失败。", LastPage());
                }
            }
            catch (Exception e)
            {
                Response.Write(e.Message);
                throw;
            }
        }
    }
}
