﻿using System; 
using System.Collections.Generic; 
using System.Text;
using DSCM.ds_tbl_letter_conten;
using DSCM.ds_tbl_user;
namespace DSCM.ds_tbl_letter {
    public class tbl_letter
    {
        public tbl_user user = new tbl_user();
        public tbl_user letter_user = new tbl_user();
        public tbl_letter_conten[] letter_contenList = new tbl_letter_conten[] { };
        public tbl_letter_conten letter_conten = new tbl_letter_conten();
        string if_see = "";

        public string If_See
        {
            get { return if_see; }
            set { if_see = value; }
        }
        string letter_id = "";
        public string Letter_Id
        {
            get { return letter_id; }
            set { letter_id = value; }
        }
        string user_id = "";
        public string User_Id
        {
            get { return user_id; }
            set { user_id = value; }
        }
        string letter_user_id = "";
        public string Letter_User_Id
        {
            get { return letter_user_id; }
            set { letter_user_id = value; }
        }
        string letter_time = "";
        public string Letter_Time
        {
            get { return letter_time; }
            set { letter_time = value; }
        }
        string user_name = "";
        public string User_Name
        {
            get { return user_name; }
            set { user_name = value; }
        }
        string letter_user_name = "";
        public string Letter_User_Name
        {
            get { return letter_user_name; }
            set { letter_user_name = value; }
        }
    }
}