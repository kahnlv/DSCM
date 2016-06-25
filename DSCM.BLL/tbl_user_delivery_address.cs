using System; 
using System.Collections.Generic; 
using System.Text;
namespace DSCM.ds_tbl_user_delivery_address { 
	 public class tbl_user_delivery_address 
	{
        public string proname = "";
        public string cityname = "";
		string user_delivery_address_id = ""; 
		public string User_Delivery_Address_Id 
		{  
			get{ return user_delivery_address_id; }  
			set{ user_delivery_address_id = value;}  
		}  
		string user_delivery_address_user_relname = ""; 
		public string User_Delivery_Address_User_Relname 
		{  
			get{ return user_delivery_address_user_relname; }  
			set{ user_delivery_address_user_relname = value;}  
		}  
		string user_delivery_address_city = ""; 
		public string User_Delivery_Address_City 
		{  
			get{ return user_delivery_address_city; }  
			set{ user_delivery_address_city = value;}  
		}    
		string user_delivery_address_user_address = ""; 
		public string User_Delivery_Address_User_Address 
		{  
			get{ return user_delivery_address_user_address; }  
			set{ user_delivery_address_user_address = value;}  
		}
		string user_delivery_address_city_code = ""; 
		public string User_Delivery_Address_City_Code 
		{  
			get{ return user_delivery_address_city_code; }  
			set{ user_delivery_address_city_code = value;}
        }
        string user_delivery_address_user_email = "";
        public string User_Delivery_Address_User_Email
        {
            get { return user_delivery_address_user_email; }
            set { user_delivery_address_user_email = value; }
        }    
		string user_delivery_address_user_phone = ""; 
		public string User_Delivery_Address_User_Phone 
		{  
			get{ return user_delivery_address_user_phone; }  
			set{ user_delivery_address_user_phone = value;}  
		}  
		string user_delivery_address_user_tel = ""; 
		public string User_Delivery_Address_User_Tel 
		{  
			get{ return user_delivery_address_user_tel; }  
			set{ user_delivery_address_user_tel = value;}
        }
        string user_delivery_address_delstate = "";
        public string User_Delivery_Address_Delstate
        {
            get { return user_delivery_address_delstate; }
            set { user_delivery_address_delstate = value; }
        }  
		string user_id = ""; 
		public string User_Id 
		{  
			get{ return user_id; }  
			set{ user_id = value;}  
		}  
	}
}