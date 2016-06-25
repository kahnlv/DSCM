using System; 
using System.Collections.Generic; 
using System.Text;
using DSCM.ds_tbl_user;
using DSCM.ds_tbl_photo_img;
using DSCM.ds_tbl_user_log;
namespace DSCM.ds_tbl_user_message {
    public class tbl_user_message
    {
        public tbl_user user = new tbl_user();
        public tbl_user touser = new tbl_user();
        public tbl_user_log user_log = new tbl_user_log();
        public tbl_photo_img photo_img = new tbl_photo_img();
        public tbl_user_message[] user_mes = new tbl_user_message[] { };
        string user_message_id = "";
        public string User_Message_Id
        {
            get { return user_message_id; }
            set { user_message_id = value; }
        }
        string user_id = "";
        public string User_Id
        {
            get { return user_id; }
            set { user_id = value; }
        }
        string to_user_id = "";
        public string To_User_Id
        {
            get { return to_user_id; }
            set { to_user_id = value; }
        }
        string user_message_center = "";
        public string User_Message_Center
        {
            get { return user_message_center; }
            set { user_message_center = value; }
        }
        string user_message_time = "";
        public string User_Message_Time
        {
            get { return user_message_time; }
            set { user_message_time = value; }
        }
        string user_log_id = "";
        public string User_Log_Id
        {
            get { return user_log_id; }
            set { user_log_id = value; }
        }
        string type = "";
        public string Type
        {
            get { return type; }
            set { type = value; }
        }
        string photo_img_id = "";
        public string Photo_Img_Id
        {
            get { return photo_img_id; }
            set { photo_img_id = value; }
        }
        string user_message_parent_id = "";
        public string User_Message_Parent_Id
        {
            get { return user_message_parent_id; }
            set { user_message_parent_id = value; }
        }  
    }
}