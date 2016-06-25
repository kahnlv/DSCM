using System; 
using System.Collections.Generic; 
using System.Text;
namespace DSCM.ds_tbl_user_zan { 
	 public class tbl_user_zan 
	{ 
		string user_zan_id = ""; 
		public string User_Zan_Id 
		{  
			get{ return user_zan_id; }  
			set{ user_zan_id = value;}  
		}  
		string user_id = ""; 
		public string User_Id 
		{  
			get{ return user_id; }  
			set{ user_id = value;}  
		}  
		string photo_img_id = ""; 
		public string Photo_Img_Id 
		{  
			get{ return photo_img_id; }  
			set{ photo_img_id = value;}  
		}  
		string if_zan = ""; 
		public string If_Zan 
		{  
			get{ return if_zan; }  
			set{ if_zan = value;}  
		}  
		string zan_time = ""; 
		public string Zan_Time 
		{  
			get{ return zan_time; }  
			set{ zan_time = value;}  
		}  
	}
}