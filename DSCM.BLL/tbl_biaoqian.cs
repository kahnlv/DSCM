using DSCM.ds_tbl_admin;
using System;
using System.Collections.Generic;
using System.Text;
namespace DSCM.ds_tbl_biaoqian { 
	 public class tbl_biaoqian
     {
        public tbl_admin admin = new tbl_admin();
		string biaoqian_id = ""; 
		public string Biaoqian_Id 
		{  
			get{ return biaoqian_id; }  
			set{ biaoqian_id = value;}  
		}  
		string biaoqian_name = ""; 
		public string Biaoqian_Name 
		{  
			get{ return biaoqian_name; }  
			set{ biaoqian_name = value;}  
		}  
		string biaoqian_time = ""; 
		public string Biaoqian_Time 
		{  
			get{ return biaoqian_time; }  
			set{ biaoqian_time = value;}  
		}  
		string biaoqian_type = ""; 
		public string Biaoqian_Type 
		{  
			get{ return biaoqian_type; }  
			set{ biaoqian_type = value;}  
		}  
		string admin_id = ""; 
		public string Admin_Id 
		{  
			get{ return admin_id; }  
			set{ admin_id = value;}  
		}  
	}
}