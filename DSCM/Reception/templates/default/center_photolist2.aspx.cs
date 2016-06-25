/* 
* ======================================================================== 
* 
* Author：鼎燊文化传媒 Time：2015/4/24 17:23:23 
* File name：center_photolist2 
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
using DSCM.ds_tbl_photo_img;
using DSCM.ds_tbl_user_message;
using System.Collections;
using dscm.Tools.Sql;

public partial class Reception_templates_default_center_photolist2 : Page
{
    public tbl_photo_img photo_img = new tbl_photo_img();
    public string JsonStr = ""; 

    public override void EmpInfo(object sender, EventArgs e)
    {
		if (!this.IsPostBack)
        {
			//获取传参          
            string user_id = Save("user_id").ToString();
            if (Save("user_phone").ToString().Equals(""))
            {
                showPage("请登录。", "/Reception/index.aspx?ds=zc");
            }
            string id = dscmSave.QueryString("id");
            photo_img = SQL.Read<tbl_photo_img>("tbl_photo_img", " and photo_img_id='" + id + "'");
            tbl_photo_img[] images = SQL.ReadAll<tbl_photo_img>("tbl_photo_img", " and photo_id='" + photo_img.Photo_Id + "' order by photo_img_time desc");
            String json = "{\"total\":" + images.Length + ",\"rows\":[";
            foreach (tbl_photo_img img in images)
            {

                img.plnum = SQL.Read("tbl_user_message", " and photo_img_id='" + img.Photo_Img_Id + "' and user_message_parent_id='0'");
                img.zannum = SQL.Read("tbl_user_zan", " and photo_img_id='" + img.Photo_Img_Id + "' and if_zan=1 ");
                json += "{\"photo_img_id\":\"" + img.Photo_Img_Id
                        + "\",\"photo_img_path\":\"" + img.Photo_Img_Path
                        + "\",\"photo_img_time\":\"" + img.Photo_Img_Time
                        + "\",\"photo_img_doc\":\"" + img.Photo_Img_Doc
                        + "\",\"photo_id\":\"" + img.Photo_Id
                        + "\",\"photo_img_title\":\"" + img.Photo_Img_Title
                        + "\",\"plnum\":\"" + img.plnum
                        + "\",\"zannum\":\"" + img.zannum + "\"},";
            } 

           JsonStr = json.Substring(0, json.Length - 1) + "]}"; 
        }
    }
}
