using DSCM.ds_tbl_user;
using System;
using System.Collections.Generic;
using System.Text;
namespace DSCM.ds_tbl_article_pl { 
	 public class tbl_article_pl 
	{
         public tbl_user user = new tbl_user();
		string article_pl_id = ""; 
		public string Article_Pl_Id 
		{  
			get{ return article_pl_id; }  
			set{ article_pl_id = value;}  
		}  
		string article_pl_content = ""; 
		public string Article_Pl_Content 
		{  
			get{ return article_pl_content; }  
			set{ article_pl_content = value;}  
		}  
		string article_pl_time = ""; 
		public string Article_Pl_Time 
		{  
			get{ return article_pl_time; }  
			set{ article_pl_time = value;}  
		}  
		string article_id = ""; 
		public string Article_Id 
		{  
			get{ return article_id; }  
			set{ article_id = value;}  
		}  
		string user_id = ""; 
		public string User_Id 
		{  
			get{ return user_id; }  
			set{ user_id = value;}  
		}

        int type = 0;
        public int Type
        {
            get { return type; }
            set { type = value; }
        }

        bool isDelete = false;
        public bool IsDelete
        {
            get { return isDelete; }
            set { isDelete = value; }
        }
	}
}