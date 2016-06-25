using System; 
using System.Collections.Generic; 
using System.Text;
using DSCM.ds_tbl_user;
namespace DSCM.ds_tbl_friend { 
	 public class tbl_friend 
	{
        public tbl_user user = new tbl_user();
		string friend_id = ""; 
		public string Friend_Id 
		{  
			get{ return friend_id; }  
			set{ friend_id = value;}  
		}  
		string user_id = ""; 
		public string User_Id 
		{  
			get{ return user_id; }  
			set{ user_id = value;}  
		}  
		string friend_user_id = ""; 
		public string Friend_User_Id 
		{  
			get{ return friend_user_id; }  
			set{ friend_user_id = value;}  
		}  
		string if_friend = ""; 
		public string If_Friend 
		{  
			get{ return if_friend; }  
			set{ if_friend = value;}  
		}  
		string friend_time = ""; 
		public string Friend_Time 
		{  
			get{ return friend_time; }  
			set{ friend_time = value;}  
		}  
	}
}