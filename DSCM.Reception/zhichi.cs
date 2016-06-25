/* 
* ======================================================================== 
* 
* Author：鼎燊文化传媒 Time：2015/4/22 16:13:17 
* File name：zhichi 
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
using DSCM.ds_tbl_object_zc;
using DSCM.ds_tbl_object_zc_pes;
using System.Collections;
using DSCM.ds_tbl_object;
using DSCM.ds_tbl_user;

namespace DSCM.Reception
{
    public class zhichi : DSCMSave
    {
        public ArrayList index_DSCM()
        {
            ArrayList al = new ArrayList();
            string id = QueryString("id");
            tbl_object obj = new tbl_object();
            tbl_object_zc[] obj_zc = new tbl_object_zc[] { };
            obj = SQL.Read<tbl_object>("tbl_object", " and object_id='" + id + "'");
            //获取支持列表
            obj_zc = SQL.ReadAll<tbl_object_zc>("tbl_object_zc", " and object_id='" + id + "'", 20);
            foreach (tbl_object_zc item in obj_zc)
            {
                //特定回报值支持人数
                item.zccount = SQL.Read("tbl_object_zc_pes", " and object_id='" + id + "' and object_zc_pes_price=" + item.Object_Zc_Price);
            }
            al.Add(obj);
            al.Add(obj_zc);
            return al;
        }

        public void dsindex_DSCM()
        {
            try
            {
                string user_id = Save("user_id").ToString();
                string object_zc_id = "";
                string[] object_zc_ids = Form("checkbox1").Split(new string[] { "," }, StringSplitOptions.None);
                if (object_zc_ids.Length > 1)
                {
                    object_zc_id = object_zc_ids[1];
                }
                else
                {
                    object_zc_id = object_zc_ids[0];
                }
                string object_id = Form("obj_id");
                string object_zc_pes_price = Form("object_zc_pes_price");
                if (user_id.Equals(""))
                {
                    showPage("请登录。", LastPage());
                }
                else
                {
                    int i = SQL.Read("tbl_object", " and object_id='" + object_id + "' and user_id='" + user_id + "'");
                    tbl_object obj = SQL.Read<tbl_object>("tbl_object", " and object_id='" + object_id + "'");
                    string guid = Guid;
                    decimal dc1 = 0;
                    decimal sum = 0;
                    if (i == 0)
                    {
                        if (object_zc_id == "")
                        {
                            sum = decimal.Parse(obj.Object_Raise_Price) - decimal.Parse(obj.Object_Raise_Ready_Manry);
                            if (decimal.Parse(object_zc_pes_price) > sum)
                            {
                                showPage("该项目目前只需支持金额￥" + sum + "就够了，谢谢!", LastPage());
                            }

                            string[] colm = new string[] { "object_zc_pes_id", "user_id", "object_zc_id", "object_zc_pes_price", "object_zc_pes_time", "object_id" };
                            string[] value = new string[] { guid, user_id, object_zc_id, object_zc_pes_price, DateTime.Now.ToString(), object_id };
                            SQL.Insert("dbo.tbl_object_zc_pes", colm, value);
                        }
                        else
                        {
                            //项目id
                            tbl_object_zc zc = SQL.Read<tbl_object_zc>("dbo.tbl_object_zc", " and object_zc_id='" + object_zc_id + "'");

                            decimal.TryParse(zc.Object_Zc_Price, out dc1);
                            sum = decimal.Parse(obj.Object_Raise_Price) - decimal.Parse(obj.Object_Raise_Ready_Manry);
                            if (dc1 > sum)
                            {
                                showPage("该项目目前只需支持金额￥" + sum + "就够了，谢谢!", LastPage());
                            }
                            string[] colm = new string[] { "object_zc_pes_id", "user_id", "object_zc_id", "object_zc_pes_price", "object_zc_pes_time", "object_id" };
                            string[] value = new string[] { guid, user_id, object_zc_id, zc.Object_Zc_Price, DateTime.Now.ToString(), object_id };
                            SQL.Insert("dbo.tbl_object_zc_pes", colm, value);

                            //showPage("支持￥" + dc1.ToString() + "成功。当前总支持金额 ￥" + sum.ToString() + "。", "/Reception/index.aspx?ds=order&cm=index&id=" + object_zc_id);

                        }
                        if (sum >=0)
                        {
                            Jump("/Reception/index.aspx?ds=order&cm=index&object_zc_pes_id=" + guid);
                        }
                        else
                        {
                            showPage("支持失败。", LastPage());
                        }

                    }
                    else
                    {
                        showPage("你不能支持自己的项目。请不要恶意刷屏。谢谢!", LastPage());
                    }
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
