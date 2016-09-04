using System;
using System.Collections.Generic;
using System.Text;
using DSCM.ds_tbl_friend;
using DSCM.ds_tbl_user_biaoqian;
using DSCM.ds_tbl_article;
namespace DSCM.ds_tbl_user
{
    public class tbl_user
    {
        public tbl_friend[] tbl_friend = new tbl_friend[] { };
        public int Guanzhu = 0;
        public int _Guanzhu = 0;
        public string proname = "";
        public string cityname = "";
        public int artnum = 0;
        string user_id = "";
        public int biaoqianNum = 0;
        public int xihuanNum = 0;
        public int guanzhuNum = 0;
        public bool guanzhu = false;

        public tbl_user_biaoqian[] tbl_user_biaoqian = new tbl_user_biaoqian[] { };
        public tbl_article[] tbl_article = new tbl_article[] { };

        public string User_Id
        {
            get { return user_id; }
            set { user_id = value; }
        }
        string user_name = "";
        public string User_Name
        {
            get { return user_name; }
            set { user_name = value; }
        }
        string user_relname = "";
        public string User_Relname
        {
            get { return user_relname; }
            set { user_relname = value; }
        }
        string user_address = "";
        public string User_Address
        {
            get { return user_address; }
            set { user_address = value; }
        }
        string user_phone = "";
        public string User_Phone
        {
            get { return user_phone; }
            set { user_phone = value; }
        }
        string user_pwd = "";
        public string User_Pwd
        {
            get { return user_pwd; }
            set { user_pwd = value; }
        }
        string user_img = "";
        public string User_Img
        {
            get { return user_img; }
            set { user_img = value; }
        }
        string user_manry = "";
        public string User_Manry
        {
            get { return user_manry; }
            set { user_manry = value; }
        }
        string user_sex = "";
        public string User_Sex
        {
            get { return user_sex; }
            set { user_sex = value; }
        }
        string user_tel = "";
        public string User_Tel
        {
            get { return user_tel; }
            set { user_tel = value; }
        }
        string user_city = "";
        public string User_City
        {
            get { return user_city; }
            set { user_city = value; }
        }
        string city_code = "";
        public string City_Code
        {
            get { return city_code; }
            set { city_code = value; }
        }
        string user_email = "";
        public string User_Email
        {
            get { return user_email; }
            set { user_email = value; }
        }
        string user_age = "";
        public string User_Age
        {
            get { return user_age; }
            set { user_age = value; }
        }
        string user_birthday = "";
        public string User_Birthday
        {
            get { return user_birthday; }
            set { user_birthday = value; }
        }
        string user_delstate = "";
        public string User_Delstate
        {
            get { return user_delstate; }
            set { user_delstate = value; }
        }

        public string User_recommend { get; set; }

        public DateTime? Update_Time { get; set; }
    }
}