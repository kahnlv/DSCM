using System; 
using System.Collections.Generic; 
using System.Text;
namespace DSCM.ds_tbl_user_log { 
	 public class tbl_user_log 
	{ 
		string user_log_id = ""; 
		public string User_Log_Id 
		{  
			get{ return user_log_id; }  
			set{ user_log_id = value;}  
		}  
		string user_log_title = ""; 
		public string User_Log_Title 
		{  
			get{ return user_log_title; }  
			set{ user_log_title = value;}  
		}  
		string user_log_doc = ""; 
		public string User_Log_Doc 
		{  
			get{ return user_log_doc; }  
			set{ user_log_doc = value;}  
		}  
		string user_log_time = ""; 
		public string User_Log_Time 
		{  
			get{ return user_log_time; }  
			set{ user_log_time = value;}  
		}  
		string user_log_class = ""; 
		public string User_Log_Class 
		{  
			get{ return user_log_class; }  
			set{ user_log_class = value;}  
		}  
	}
}