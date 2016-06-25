using System; 
using System.Collections.Generic; 
using System.Text;
using DSCM.ds_tbl_photo_class;
namespace DSCM.ds_tbl_photo {
    public class tbl_photo
    {
        public tbl_photo_class photo_class = new tbl_photo_class();
        public int num = 0;
        string photo_id = "";
        public string Photo_Id
        {
            get { return photo_id; }
            set { photo_id = value; }
        }
        string photo_name = "";
        public string Photo_Name
        {
            get { return photo_name; }
            set { photo_name = value; }
        }
        string photo_img = "";
        public string Photo_Img
        {
            get { return photo_img; }
            set { photo_img = value; }
        }
        string photo_class_id = "";
        public string Photo_Class_Id
        {
            get { return photo_class_id; }
            set { photo_class_id = value; }
        }
        string user_id = "";
        public string User_Id
        {
            get { return user_id; }
            set { user_id = value; }
        }
        string photo_time = "";
        public string Photo_Time
        {
            get { return photo_time; }
            set { photo_time = value; }
        }
        string photo_doc = "";
        public string Photo_Doc
        {
            get { return photo_doc; }
            set { photo_doc = value; }
        }
    }
}