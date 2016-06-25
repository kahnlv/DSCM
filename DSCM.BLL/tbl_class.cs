using System; 
using System.Collections.Generic; 
using System.Text;
namespace DSCM.ds_tbl_class { 
	 public class tbl_class 
	{ 
		string class_id = ""; 
		public string Class_Id 
		{  
			get{ return class_id; }  
			set{ class_id = value;}  
		}  
		string class_name = ""; 
		public string Class_Name 
		{  
			get{ return class_name; }  
			set{ class_name = value;}  
		}  
		string class_parent_id = ""; 
		public string Class_Parent_Id 
		{  
			get{ return class_parent_id; }  
			set{ class_parent_id = value;}  
		}  
	}
}