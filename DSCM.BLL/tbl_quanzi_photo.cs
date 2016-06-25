using DSCM.ds_tbl_user;
using System;
using System.Collections.Generic;
using System.Text;

namespace DSCM.BLL
{
   public class tbl_quanzi_photo
    {
       public tbl_user user = new tbl_user();
        string photo_id = "";
        public string Photo_Id
        {
            get { return photo_id; }
            set { photo_id = value; }
        }
       string photo_path = "";
        public string Photo_Path
        {
            get { return photo_path; }
            set { photo_path = value; }
        }
        string photo_time = "";
        public string Photo_Time
        {
            get { return photo_time; }
            set { photo_time = value; }
        }
        string user_id = "";
        public string User_Id
        {
            get { return user_id; }
            set { user_id = value; }
        }

    }
}
