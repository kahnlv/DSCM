/* 
* ======================================================================== 
* 
* Author：鼎燊文化传媒 Time：2015/4/23 10:30:25 
* File name：order 
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
using DSCM.ds_tbl_object;
using dscm.Tools.Sql;
using System.Collections;
using DSCM.ds_tbl_object_zc;
using DSCM.ds_tbl_order;
using DSCM.ds_tbl_object_zc_pes;
using DSCM.ds_tbl_user_delivery_address;
using DSCM.ds_tbl_user;
using DSCM.ds_tbl_province;
using DSCM.ds_tbl_city;

namespace DSCM.Reception
{
    public class order : DSCMSave
    {
        public ArrayList trade_DSCM()
        {
            string user_id = Save("user_id").ToString();
            if (user_id.ToString().Equals(""))
            {
                showPage("连接超时，请重新登录。", LastPage());
            }

            string[] colm = new string[] { "order_id", "object_title", "order_time", "object_id", "order_price", "order_start", "user_delivery_address_id", "object_zc_pes_id" };
            ArrayList al = new ArrayList();
            string order = "order_time,order_start";
            string page = QueryString("page");
            int p = 0;
            int.TryParse(page, out p);
            if (p == 0) p = 1;

            tbl_order[] user_log = SQL.ReadAll<tbl_order>("tbl_order", colm, " and user_id='" + user_id + "'", p, 20, order, false);
            DSCM.Page.PageList pl = new DSCM.Page.PageList();
            string pagestr = pl.WabPage(SQL.AllPageCount, 800, 2);
            al.Add(user_log);
            al.Add(SQL.AllCount);
            al.Add(pagestr);
            al.Add(pl.Count);
            return al;
        }

        public ArrayList index_DSCM()
        {
            ArrayList al = new ArrayList();
            tbl_object obj = new tbl_object();
            tbl_object_zc obj_zc = new tbl_object_zc();
            string id = QueryString("obj_zc_id");//obj_zc_id
            string object_zc_pes_id = QueryString("object_zc_pes_id");
            tbl_object_zc_pes obj_zc_pes = new tbl_object_zc_pes();
            if (object_zc_pes_id != "") {
                obj_zc_pes = SQL.Read<tbl_object_zc_pes>("tbl_object_zc_pes", " and object_zc_pes_id='" + object_zc_pes_id + "'");
                id = obj_zc_pes.Object_Zc_Id;
            }
            decimal raisemoney = 0;         
            obj_zc = SQL.Read<tbl_object_zc>("tbl_object_zc", " and object_zc_id='" + id + "'");
            if (id == "")
            {
                obj = SQL.Read<tbl_object>("tbl_object", " and object_id='" + obj_zc_pes.Object_Id + "'");
                raisemoney = decimal.Parse(obj_zc_pes.Object_Zc_Pes_Price);
            }
            else
            {
                obj = SQL.Read<tbl_object>("tbl_object", " and object_id='" + obj_zc.Object_Id + "'");
                raisemoney = decimal.Parse(obj_zc.Object_Zc_Price);
            }

            Save("object_zc_pes_id", object_zc_pes_id);
            al.Add(obj);
            al.Add(obj_zc);
            al.Add(raisemoney);
            return al;
        }

        public void dsinsert_DSCM()
        {
            try
            {
                string user_delivery_address_user_relname = Form("user_delivery_address_user_relname");
                string user_delivery_address_city = Form("user_delivery_address_city");
                string user_delivery_address_user_address = Form("user_delivery_address_user_address");
                string user_delivery_address_city_code = Form("user_delivery_address_city_code");
                string user_delivery_address_user_email = Form("user_delivery_address_user_email");
                string user_delivery_address_user_phone = Form("user_delivery_address_user_phone");
                string order_doc = Form("order_doc");

                string object_zc_pes_id = Save("object_zc_pes_id").ToString();
                string object_zc_id = Form("object_zc_id");
                string object_id = Form("object_id");
                string user_id = Save("user_id").ToString();

                if (user_id.ToString().Equals(""))
                {
                    showPage("连接超时，请重新登录。", LastPage());
                    return;
                }
                int i = 0;
                //保存支持信息
                tbl_object obj = SQL.Read<tbl_object>("tbl_object", " and object_id='" + object_id + "'");
                if (object_zc_pes_id == "")
                {
                    tbl_object_zc obj_zc = SQL.Read<tbl_object_zc>("tbl_object_zc", " and object_zc_id='" + object_zc_id + "'");
                    object_zc_pes_id = Guid;
                    decimal sum = decimal.Parse(obj.Object_Raise_Price) - decimal.Parse(obj.Object_Raise_Ready_Manry);
                    if (decimal.Parse(obj_zc.Object_Zc_Price) > sum)
                    {
                        showPage("该项目目前只需支持金额￥" + sum + "就够了，谢谢!", "/Reception/index.aspx?ds=zc&cm=item&id=" + object_id);
                    }

                    string[] colm = new string[] { "object_zc_pes_id", "user_id", "object_zc_id", "object_zc_pes_price", "object_zc_pes_time", "object_id" };
                    string[] value = new string[] { object_zc_pes_id, user_id, object_zc_id, obj_zc.Object_Zc_Price, DateTime.Now.ToString(), object_id };
                    i = SQL.Insert("dbo.tbl_object_zc_pes", colm, value);
                }

                //保存收货地址
                string user_delivery_address_id = Guid;
                string[] colm1 = new string[] { "user_delivery_address_id", "user_delivery_address_user_relname", "user_delivery_address_city","user_delivery_address_user_address",
                 "user_delivery_address_city_code","user_delivery_address_user_email", "user_delivery_address_user_phone", "user_delivery_address_user_tel", "user_id" };
                string[] value1 = new string[] { user_delivery_address_id, user_delivery_address_user_relname,user_delivery_address_city, user_delivery_address_user_address,
                user_delivery_address_city_code, user_delivery_address_user_email, user_delivery_address_user_phone, "",user_id };
                i = SQL.Insert("tbl_user_delivery_address", colm1, value1);

                tbl_object_zc_pes obj_zc_pes = SQL.Read<tbl_object_zc_pes>("tbl_object_zc_pes", " and object_zc_pes_id='" + object_zc_pes_id + "'");
                if (i == 1)
                {
                    //保存订单信息
                    string order_id = Guid;
                    string[] colm2 = new string[] { "order_id", "object_title", "order_price", "order_time", "order_doc", 
                    "order_start", "user_id", "object_id", "user_delivery_address_id", "object_zc_pes_id" ,"order_company",
                "order_waybillno","order_delivery_info","order_receive_info"};
                    string[] value2 = new string[] { order_id, obj.Object_Title, obj_zc_pes.Object_Zc_Pes_Price, DateTime.Now.ToString(),order_doc, 
                    "0", user_id, object_id ,user_delivery_address_id,object_zc_pes_id ,"","","",""};
                    SQL.Insert("tbl_order", colm2, value2);
                    Jump("/Reception/index.aspx?ds=order&cm=index2&order_id=" + order_id);
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

        public ArrayList index2_DSCM()
        {
            ArrayList al = new ArrayList();
            tbl_object obj = new tbl_object();
            tbl_object_zc obj_zc = new tbl_object_zc();
            string order_id = QueryString("order_id");
            tbl_order order = SQL.Read<tbl_order>("tbl_order", " and order_id='" + order_id + "'");
            tbl_object_zc_pes obj_zc_pes = SQL.Read<tbl_object_zc_pes>("tbl_object_zc_pes", " and object_zc_pes_id='" + order.Object_Zc_Pes_Id + "'");
            obj_zc = SQL.Read<tbl_object_zc>("tbl_object_zc", " and object_zc_id='" + obj_zc_pes.Object_Zc_Id + "'");
            obj = SQL.Read<tbl_object>("tbl_object", " and object_id='" + obj_zc_pes.Object_Id + "'");
            al.Add(obj);
            al.Add(obj_zc);
            al.Add(order_id);
            return al;
        }

        public void dsinsert2_DSCM() 
        {
            try
            {
                string object_zc_id = Form("object_zc_id");
                string object_id = Form("object_id");
                string order_id = Form("order_id");
                decimal sum = 0;
                //更新order表支付状态为已付款
                string[] colm = new string[] { "order_time", "order_start" };
                string[] value = new string[] { DateTime.Now.ToString(), "1" };
                int i= SQL.Update("tbl_order", colm, value, " and order_id='" + order_id + "'");

                tbl_order order = SQL.Read<tbl_order>("tbl_order", " and order_id='" + order_id + "'");

                //更新object_zc_pes表支付状态为已付款
                string[] colm1 = new string[] { "order_start" };
                string[] value1 = new string[] { "1" };
                i = SQL.Update("tbl_object_zc_pes", colm1, value1, " and object_zc_pes_id='" + order.Object_Zc_Pes_Id + "'");

                tbl_object_zc_pes obj_zc_pes = SQL.Read<tbl_object_zc_pes>("tbl_object_zc_pes", " and object_zc_pes_id='" + order.Object_Zc_Pes_Id + "'");
                tbl_object obj = SQL.Read<tbl_object>("tbl_object", " and object_id='" + obj_zc_pes.Object_Id + "'");
                int zccount = SQL.Read("tbl_object_zc_pes", " and object_id='" + object_id + "'");
                //更新object表已支持金额及支持人数
                sum = decimal.Parse(obj_zc_pes.Object_Zc_Pes_Price) + decimal.Parse(obj.Object_Raise_Ready_Manry);
                string[] obj_raise_ready_manry = new string[] { "object_raise_ready_manry", "object_zc" };
                string[] values = new string[] { sum.ToString(),zccount.ToString() };
                i = SQL.Update("tbl_object", obj_raise_ready_manry, values, " and object_id='" + object_id + "'");

                if (i == 1)
                {
                    Jump("/Reception/index.aspx?ds=order&cm=index3&order_id=" + order_id);
                }
                
            }
            catch (Exception e)
            {
                Response.Write(e.Message);
                throw;
            }
        }

        public tbl_order details_DSCM()
        {
            try
            {
                string id = Save("user_id").ToString();
                if (Save("user_phone").ToString().Equals(""))
                {
                    showPage("请登录。", "/Reception/index.aspx?ds=zc");
                }
                string order_id = QueryString("order_id");//order_id
                tbl_order order = SQL.Read<tbl_order>("tbl_order", " and order_id='" + order_id + "'");
                order.user_delicery_address = SQL.Read<tbl_user_delivery_address>("tbl_user_delivery_address", " and user_delivery_address_id='" + order.User_Delivery_Address_Id + "'");
                order.object_zc_pes = SQL.Read<tbl_object_zc_pes>("tbl_object_zc_pes", " and object_zc_pes_id='" + order.Object_Zc_Pes_Id + "'");
                order.user = SQL.Read<tbl_user>("tbl_user", "and user_id='" + order.User_Id + "'");
                order.tbl_obj = SQL.Read<tbl_object>("tbl_object", " and object_id='" + order.Object_Id + "'");
                if (order.user_delicery_address.User_Delivery_Address_City != "")
                {
                    string[] citys = order.user_delicery_address.User_Delivery_Address_City.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
                    order.user_delicery_address.proname = SQL.Read<tbl_province>("tbl_province", " and di='" + citys[0] + "'").Provincename;
                    order.user_delicery_address.cityname = SQL.Read<tbl_city>("tbl_city", " and id='" + citys[1] + "'").Cityname;                
                }
                
                return order;
            }
            catch (Exception e)
            {
                Response.Write(e.Message);
                throw;
            }
        }

        public ArrayList index3_DSCM()
        {
            ArrayList al = new ArrayList();
            tbl_object obj = new tbl_object();
            tbl_object_zc obj_zc = new tbl_object_zc();
            string order_id = QueryString("order_id");
            tbl_order order = SQL.Read<tbl_order>("tbl_order", " and order_id='" + order_id + "'");           
            al.Add(order_id);
            return al;
        }
    }
}
