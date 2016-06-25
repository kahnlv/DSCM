using DSCM.ds_tbl_admin;
using DSCM.ds_tbl_message_class;
using DSCM.ds_tbl_user;
using System;
using System.Collections.Generic;
using System.Text;
namespace DSCM.ds_tbl_message { 
	 public class tbl_message 
	{
        public tbl_admin admin = new tbl_admin(); 
        public tbl_message_class tmescla=new tbl_message_class();
        string message_id = ""; 
		public string Message_Id 
		{  
			get{ return message_id; }  
			set{ message_id = value;}  
		}  
		string message_content = ""; 
		public string Message_Content 
		{  
			get{ return message_content; }  
			set{ message_content = value;}  
		}  
		string message_time = ""; 
		public string Message_Time 
		{  
			get{ return message_time; }  
			set{ message_time = value;}
        }
        string message_class_id = "";
        public string Message_Class_Id
        {
            get { return message_class_id; }
            set { message_class_id = value; }
        }  
		string admin_id = ""; 
		public string Admin_Id 
		{
            get { return admin_id; }
            set { admin_id = value; }  
		}  
	}
}