using System; 
using System.Collections.Generic; 
using System.Text;
using DSCM.ds_tbl_user;
using DSCM.ds_tbl_object;
namespace DSCM.ds_tbl_object_pl { 
	 public class tbl_object_pl 
	{
         public tbl_object_pl[] object_pl = new tbl_object_pl[] { };
         public tbl_user tbl_us = new tbl_user();
         public tbl_object tbl_object = new tbl_object();
		string object_pl_id = ""; 
		public string Object_Pl_Id 
		{  
			get{ return object_pl_id; }  
			set{ object_pl_id = value;}  
		}  
		string object_pl_content = ""; 
		public string Object_Pl_Content 
		{  
			get{ return object_pl_content; }  
			set{ object_pl_content = value;}  
		}  
		string user_id = ""; 
		public string User_Id 
		{  
			get{ return user_id; }  
			set{ user_id = value;}  
		}  
		string object_pl_time = ""; 
		public string Object_Pl_Time 
		{  
			get{ return object_pl_time; }  
			set{ object_pl_time = value;}  
		}  
		string object_id = ""; 
		public string Object_Id 
		{  
			get{ return object_id; }  
			set{ object_id = value;}  
		}  
		string object_pl_parent_id = ""; 
		public string Object_Pl_Parent_Id 
		{  
			get{ return object_pl_parent_id; }  
			set{ object_pl_parent_id = value;}  
		}  
	}
}