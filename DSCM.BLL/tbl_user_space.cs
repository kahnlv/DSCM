using System; 
using System.Collections.Generic; 
using System.Text;
namespace DSCM.ds_tbl_user_space { 
	 public class tbl_user_space 
	{ 
		string user_space_id = ""; 
		public string User_Space_Id 
		{  
			get{ return user_space_id; }  
			set{ user_space_id = value;}  
		}  
		string user_id = ""; 
		public string User_Id 
		{  
			get{ return user_id; }  
			set{ user_id = value;}  
		}  
		string user_space_name = ""; 
		public string User_Space_Name 
		{  
			get{ return user_space_name; }  
			set{ user_space_name = value;}  
		}  
		string user_space_signature = ""; 
		public string User_Space_Signature 
		{  
			get{ return user_space_signature; }  
			set{ user_space_signature = value;}  
		}  
	}
}