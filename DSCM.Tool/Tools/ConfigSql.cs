using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;

namespace dscm.Library.self
{
    public class ConfigSql
    {
        List<Tbl_Act> tbl_act = new List<Tbl_Act>();
        List<Tbl_Page> tbl_apage = new List<Tbl_Page>();

        public void ReadConfig()
        {
            SqlCon sc = new SqlCon();
            SqlDataReader sdr = sc.Read("SELECT [act_id],[act_name],[act_namespace],[act_path],op_name,page FROM [DS_CMS].[dbo].[tbl_act] ");
            if (sdr != null)
            {
                while (sdr.Read())
                {
                    Tbl_Act ta = new Tbl_Act();
                    ta.act_id = sdr.GetValue(0).ToString();
                    ta.act_name = sdr.GetValue(1).ToString();
                    ta.act_namespace = sdr.GetValue(2).ToString();
                    ta.act_path = sdr.GetValue(3).ToString();
                    ta.op_name = sdr.GetValue(4).ToString();
                    ta.page = sdr.GetValue(5).ToString();
                    tbl_act.Add(ta);
                }
                sdr.Close();
                sdr.Dispose();
            }
            sc.Close();
        }

        public void ReadPageConfig(string act)
        {
            string page_id = "";
            SqlCon sc = new SqlCon();
            SqlDataReader sdr = sc.Read("SELECT [page_id],[page_name] FROM [tbl_page] where [page_name]='" + act + "'");
            if (sdr != null)
            {
                if (sdr.Read())
                {
                    page_id = sdr.GetValue(0).ToString();
                }
                sdr.Close();
                sdr.Dispose();

                if (!page_id.Equals(""))
                {
                    string sql = "SELECT [page_model_id]"
                      + ",[page_name]"
                      + ",[page_id]"
                      + ",[model_id]"
                      + ",model_doc"
                      + ",model_type"
                      + ",model_def"
                      + ",model_lcount"
                      + ",model_json"
                      + ",[Sorting]"
                      + "FROM [tbl_page_model] where page_id='" + page_id + "'";
                    sdr = sc.Read(sql);
                    while (sdr.Read())
                    {
                        Tbl_Page tp = new Tbl_Page();
                        tp.page_model_id = sdr.GetValue(0).ToString();
                        tp.page_name = sdr.GetValue(0).ToString();
                        tp.page_id = sdr.GetValue(0).ToString();
                        tp.model_id = sdr.GetValue(0).ToString();
                        tp.model_doc = sdr.GetValue(0).ToString();
                        tp.model_type = sdr.GetValue(0).ToString();
                        tp.model_def = sdr.GetValue(0).ToString();
                        tp.model_lcount = sdr.GetValue(0).ToString();
                        tp.model_json = sdr.GetValue(0).ToString();
                        tp.Sorting = sdr.GetValue(0).ToString();
                        tbl_apage.Add(tp);
                    }
                    sdr.Close();
                    sdr.Dispose();
                }
            }
            sc.Close();
            
        }

        public List<Tbl_Page> ReadPage()
        {
            return tbl_apage;
        }

        public Tbl_Act ReadAct(string act,string op)
        {
            Tbl_Act t = new Tbl_Act();
            foreach (Tbl_Act ta in tbl_act)
            {
                if (ta.act_name.ToLower().Equals(act)&& ta.op_name.ToLower().Equals(op))
                {
                    t = ta;
                }
            }
            return t;
        }
    }

    public class Tbl_Page
    {
        public string page_model_id = "";
        public string page_name = "";
        public string page_id = "";
        public string model_id = "";
        public string model_doc = "";
        public string model_type = "";
        public string model_def = "";
        public string model_lcount = "";
        public string model_json = "";
        public string Sorting = "";
    }

    public class Tbl_Act
    {
        public string act_id = "";
        public string act_name = "";
        public string act_namespace = "";
        public string act_path = "";
        public string op_name = "";
        public string page = "";
    }
}
