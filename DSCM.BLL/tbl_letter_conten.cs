using System; 
using System.Collections.Generic; 
using System.Text;
using DSCM.ds_tbl_user;
namespace DSCM.ds_tbl_letter_conten { 
	 public class tbl_letter_conten 
	{
        public tbl_user user = new tbl_user();
		string letter_conten_id = ""; 
		public string Letter_Conten_Id 
		{  
			get{ return letter_conten_id; }  
			set{ letter_conten_id = value;}  
		}  
		string user_id = ""; 
		public string User_Id 
		{  
			get{ return user_id; }  
			set{ user_id = value;}  
		}  
		string letter_id = ""; 
		public string Letter_Id 
		{  
			get{ return letter_id; }  
			set{ letter_id = value;}  
		}  
		string letter_conten_doc = ""; 
		public string Letter_Conten_Doc 
		{  
			get{ return letter_conten_doc; }  
			set{ letter_conten_doc = value;}  
		}  
		string letter_conten_time = ""; 
		public string Letter_Conten_Time 
		{  
			get{ return letter_conten_time; }  
			set{ letter_conten_time = value;}  
		}  
		string if_see = ""; 
		public string If_See 
		{  
			get{ return if_see; }  
			set{ if_see = value;}  
		}  
		string user_name = ""; 
		public string User_Name 
		{  
			get{ return user_name; }  
			set{ user_name = value;}  
		}  
	}
}