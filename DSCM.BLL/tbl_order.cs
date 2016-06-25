using System; 
using System.Collections.Generic; 
using System.Text;
using DSCM.ds_tbl_user_delivery_address;
using DSCM.ds_tbl_object_zc_pes;
using DSCM.ds_tbl_user;
using DSCM.ds_tbl_object;
namespace DSCM.ds_tbl_order { 
	public class tbl_order 
	{
        public tbl_user_delivery_address user_delicery_address = new tbl_user_delivery_address();
        public tbl_object_zc_pes object_zc_pes = new tbl_object_zc_pes();
        public tbl_user user = new tbl_user();
        public tbl_object tbl_obj = new tbl_object();
		string order_id = ""; 
		public string Order_Id 
		{  
			get{ return order_id; }  
			set{ order_id = value;}  
		}  
		string order_time = ""; 
		public string Order_Time 
		{  
			get{ return order_time; }  
			set{ order_time = value;}  
		}
		string order_price = ""; 
		public string Order_Price 
		{  
			get{ return order_price; }  
			set{ order_price = value;}  
		}  
		string order_start = ""; 
		public string Order_Start 
		{  
			get{ return order_start; }  
			set{ order_start = value;}
        }   
		string object_title = ""; 
		public string Object_Title 
		{  
			get{ return object_title; }  
			set{ object_title = value;}
        }
        string order_doc = "";
        public string Order_Doc
        {
            get { return order_doc; }
            set { order_doc = value; }
        }   
		string user_id = ""; 
		public string User_Id 
		{  
			get{ return user_id; }  
			set{ user_id = value;}
        }
        string user_delivery_address_id = "";
        public string User_Delivery_Address_Id
        {
            get { return user_delivery_address_id; }
            set { user_delivery_address_id = value; }
        }
        string object_id = "";
        public string Object_Id
        {
            get { return object_id; }
            set { object_id = value; }
        } 
        string object_zc_pes_id = "";
        public string Object_Zc_Pes_Id
        {
            get { return object_zc_pes_id; }
            set { object_zc_pes_id = value; }
        }
        string order_company = "";
        public string Order_Company
        {
            get { return order_company; }
            set { order_company = value; }
        }
        string order_waybillno = "";
        public string Order_Waybillno
        {
            get { return order_waybillno; }
            set { order_waybillno = value; }
        }
        string order_delivery_info = "";
        public string Order_Delivery_Info
        {
            get { return order_delivery_info; }
            set { order_delivery_info = value; }
        }
        string order_receive_info = "";
        public string Order_Receive_Info
        {
            get { return order_receive_info; }
            set { order_receive_info = value; }
        }  
	}
}