using System; 
using System.Collections.Generic; 
using System.Text;
namespace DSCM.ds_tbl_city { 
	 public class tbl_city 
	{ 
		string id = ""; 
		public string ID 
		{  
			get{ return id; }  
			set{ id = value;}  
		}  
		string cityname = ""; 
		public string Cityname 
		{  
			get{ return cityname; }  
			set{ cityname = value;}  
		}  
		string zipcode = ""; 
		public string Zipcode 
		{  
			get{ return zipcode; }  
			set{ zipcode = value;}  
		}  
		string provinceid = ""; 
		public string Provinceid 
		{  
			get{ return provinceid; }  
			set{ provinceid = value;}  
		}  
	}
}