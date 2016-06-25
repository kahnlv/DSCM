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
using System.Collections;
using dscm.Tools.Sql;
using DSCM.ds_tbl_order;
using DSCM.ds_tbl_user;
using DSCM.ds_tbl_object;
using DSCM.ds_tbl_user_delivery_address;
using DSCM.ds_tbl_object_zc_pes;

namespace DSCM.Backstage
{
    public class order : DSCMSave
    { 
        UserLogin ul = new UserLogin();
        string admin_id = "";
        string admin_name = "";

        string[] colm = new string[] { };
        string[] value = new string[] { };
        public order()
        {
            admin_id = Save("admin_id") != null ? Save("admin_id").ToString() : "";
            admin_name = Save("admin_name") != null ? Save("admin_name").ToString() : "";
            if (admin_id.Equals(""))
            {
                ul.Login();
            }
        }
        public ArrayList index_DSCM()
        {
            string obj_class = Form("obj_class");
            string obj_title = Form("obj_title");
            string username = Form("username");
            string ordertime = Form("ordertime");
            string endordertime = Form("endordertime");

            if (obj_class != "")
            {
                obj_class = " and object_id in(select object_id from tbl_object where object_class='" + obj_class + "')";
            }
            if (!obj_title.Equals(""))
            {
                obj_title = " and object_title like '%" + obj_title + "%'";
            }
            if (!username.Equals(""))
            {
                username = " and user_id in(select user_id from tbl_user where user_name like '%" + username + "%')";
            }
            if (!ordertime.Equals(""))
            {
                ordertime = " and order_time > '" + ordertime + "'"; 
            }
            if (!endordertime.Equals(""))
            {
                endordertime = " and order_time < '" + endordertime + "'";
            }

            string sql = obj_class + obj_title + username + ordertime + endordertime;
            ArrayList al = new ArrayList();
            string order = "order_time";
            string page = QueryString("page");
            int p = 0;
            int.TryParse(page, out p);
            if (p == 0) p = 1;

            tbl_order[] tbl_order = SQL.ReadAll<tbl_order>("tbl_order", sql, p, 20, order, false);
            foreach (tbl_order torder in tbl_order)
            {
                torder.user = SQL.Read<tbl_user>("tbl_user", "and user_id='" + torder.User_Id + "'");
                torder.tbl_obj = SQL.Read<tbl_object>("tbl_object", " and object_id='" + torder.Object_Id + "'");
            }
            DSCM.Page.PageList pl = new DSCM.Page.PageList();
            string pagestr = pl.WabPage(SQL.AllPageCount, 800, 2);
            al.Add(tbl_order);
            al.Add(SQL.AllCount);
            al.Add(pagestr);
            al.Add(pl.Count);
            return al;

        }

        public void dsupdate_DSCM()
        {
            string user_delivery_address_id = Form("user_delivery_address_id");

            string user_delivery_address_user_relname = Form("user_delivery_address_user_relname");
            string user_delivery_address_city = Form("object_address");
            string user_delivery_address_user_address = Form("user_delivery_address_user_address");
            string user_delivery_address_city_code = Form("user_delivery_address_city_code");
            string user_delivery_address_user_phone = Form("user_delivery_address_user_phone");
            string user_delivery_address_user_tel = Form("user_delivery_address_user_tel");
            string user_delivery_address_user_email = Form("user_delivery_address_user_email");

            colm = new string[] { "user_delivery_address_user_relname", "user_delivery_address_city","user_delivery_address_user_address",
                 "user_delivery_address_city_code", "user_delivery_address_user_phone", "user_delivery_address_user_tel","user_delivery_address_user_email", "user_id" };
            value = new string[] { user_delivery_address_user_relname, user_delivery_address_user_address,
                user_delivery_address_city,user_delivery_address_city_code, user_delivery_address_user_phone, user_delivery_address_user_tel,user_delivery_address_user_email };
            int i = SQL.Update("tbl_user_delivery_address", colm, value, " and user_delivery_address_id='" + user_delivery_address_id + "'");
            if (i == 1)
            {
                ul.Loglog(admin_id, admin_name, "修改订单收货地址");
                Jump("/backstage/index.aspx?ds=order&cm=index");
            }
            else
            {
                showPage("修改订单收货地址失败。", LastPage());
            }
        }

        public void delete_DSCM()
        {
            string id = QueryString("id");
            colm = new string[] { "order_start" };
            value = new string[] { "4" };
            int i = SQL.Update("tbl_order", colm, value, " and order_id='" + id + "'");
            if (i == 1)
            {
                ul.Loglog(admin_id, admin_name, "删除订单");
                Jump(LastPage());
            }
            else
            {
                showPage("删除订单失败！", LastPage());
            }
        }
    }
}
