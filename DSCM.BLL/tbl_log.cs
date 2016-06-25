using System; 
using System.Collections.Generic; 
using System.Text;
namespace DSCM.ds_tbl_log { 
	 public class tbl_log 
	{ 
		string log_id = ""; 
		public string Log_Id 
		{  
			get{ return log_id; }  
			set{ log_id = value;}  
		}  
		string user_id = ""; 
		public string User_Id 
		{  
			get{ return user_id; }  
			set{ user_id = value;}  
		}  
		string user_name = ""; 
		public string User_Name 
		{  
			get{ return user_name; }  
			set{ user_name = value;}  
		}  
		string center = ""; 
		public string Center 
		{  
			get{ return center; }  
			set{ center = value;}  
		}  
		string time = ""; 
		public string Time 
		{  
			get{ return time; }  
			set{ time = value;}  
		}  
	}
}