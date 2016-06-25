using System; 
using System.Collections.Generic; 
using System.Text;
using DSCM.ds_tbl_photo;
namespace DSCM.ds_tbl_photo_img { 
	 public class tbl_photo_img 
	{
         public int plnum = 0;
         public int zannum = 0;
         public tbl_photo photo = new tbl_photo();
		string photo_img_id = ""; 
		public string Photo_Img_Id 
		{  
			get{ return photo_img_id; }  
			set{ photo_img_id = value;}  
		}  
		string photo_img_path = ""; 
		public string Photo_Img_Path 
		{  
			get{ return photo_img_path; }  
			set{ photo_img_path = value;}  
		}  
		string photo_img_time = ""; 
		public string Photo_Img_Time 
		{  
			get{ return photo_img_time; }  
			set{ photo_img_time = value;}  
		}  
		string photo_img_doc = ""; 
		public string Photo_Img_Doc 
		{  
			get{ return photo_img_doc; }  
			set{ photo_img_doc = value;}  
		}  
		string photo_id = ""; 
		public string Photo_Id 
		{  
			get{ return photo_id; }  
			set{ photo_id = value;}  
		}  
		string photo_img_title = ""; 
		public string Photo_Img_Title 
		{  
			get{ return photo_img_title; }  
			set{ photo_img_title = value;}  
		}
	}
}