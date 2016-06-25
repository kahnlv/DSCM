using System; 
using System.Collections.Generic; 
using System.Text;
using DSCM.ds_tbl_object;
namespace DSCM.ds_tbl_object_zc_pes { 
	 public class tbl_object_zc_pes 
	{

         public tbl_object tbl_obj = new tbl_object();        
         string order_start = "";

         public string Order_Start
         {
             get { return order_start; }
             set { order_start = value; }
         }
         string user_img = "";

         public string User_Img
         {
             get { return user_img; }
             set { user_img = value; }
         }
         string object_title = "";

         public string Object_Title
         {
             get { return object_title; }
             set { object_title = value; }
         }

        string user_name = "";

        public string User_Name
        {
            get { return user_name; }
            set { user_name = value; }
        }
		string object_zc_pes_id = ""; 
		public string Object_Zc_Pes_Id 
		{  
			get{ return object_zc_pes_id; }  
			set{ object_zc_pes_id = value;}  
		}  
		string user_id = ""; 
		public string User_Id 
		{  
			get{ return user_id; }  
			set{ user_id = value;}  
		}  
		string object_zc_id = ""; 
		public string Object_Zc_Id 
		{  
			get{ return object_zc_id; }  
			set{ object_zc_id = value;}  
		}  
		string object_zc_pes_price = ""; 
		public string Object_Zc_Pes_Price 
		{  
			get{ return object_zc_pes_price; }  
			set{ object_zc_pes_price = value;}  
		}  
		string object_zc_pes_time = ""; 
		public string Object_Zc_Pes_Time 
		{  
			get{ return object_zc_pes_time; }  
			set{ object_zc_pes_time = value;}  
		}  
		string object_id = ""; 
		public string Object_Id 
		{  
			get{ return object_id; }  
			set{ object_id = value;}  
		}  
	}
}