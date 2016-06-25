using DSCM.Backstage;
using DSCM.ds_tbl_message_class;
using DSCM.Library;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Web;
using System.Web.UI.WebControls;

public partial class Backstage_templates_default_quanzi_mesclass : Page
{
    public tbl_message_class[] tbl_mesclas = new tbl_message_class[] { };
    public tbl_message_class[] tbl_mespraclas = new tbl_message_class[] { };
    public string mescla_parentid = "";
    public string mescla_type = "";
    public override void EmpInfo(object sender, EventArgs e)
    {
        if (!IsPostBack)
        { 
          UserLogin ul = new UserLogin();
          if (ul.Login())
          {
              //获取传参
              string act = dscmSave.QueryString("ds");
              object obj = dscmSave.GetObject(act);
              mescla_parentid = dscmSave.Form("mescla_parentid");
              mescla_type = dscmSave.Form("mescla_type");
              ArrayList al = obj as ArrayList;
              if (al != null && al.Count == 5)
              {
                  tbl_mesclas = al[0] as tbl_message_class[];
                  tbl_mespraclas = al[1] as tbl_message_class[];
                  allcount = (int)al[2];
                  pagestr = al[3] as string;
                  count = (int)al[4];
              }
          }
        }
    }
}