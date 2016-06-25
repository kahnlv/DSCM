using DSCM.ds_tbl_admin;
using System;
using System.Collections.Generic;
using System.Text;
namespace DSCM.ds_tbl_message_class { 
	 public class tbl_message_class
     {
        public tbl_admin admin = new tbl_admin();
        public tbl_message_class[] mescla = new tbl_message_class[] { };
        public string mesparclaname = "";
		string message_class_id = ""; 
		public string Message_Class_Id 
		{  
			get{ return message_class_id; }  
			set{ message_class_id = value;}  
		}  
		string message_class_name = ""; 
		public string Message_Class_Name 
		{  
			get{ return message_class_name; }  
			set{ message_class_name = value;}  
		}  
		string message_class_time = ""; 
		public string Message_Class_Time 
		{  
			get{ return message_class_time; }  
			set{ message_class_time = value;}  
		}  
		string message_class_parentid = ""; 
		public string Message_Class_Parentid 
		{  
			get{ return message_class_parentid; }  
			set{ message_class_parentid = value;}  
		}  
		string message_class_type = ""; 
		public string Message_Class_Type 
		{  
			get{ return message_class_type; }  
			set{ message_class_type = value;}  
		}  
		string admin_id = ""; 
		public string Admin_Id 
		{  
			get{ return admin_id; }  
			set{ admin_id = value;}  
		}  
	}
}