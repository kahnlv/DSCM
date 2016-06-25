using DSCM.ds_tbl_article_pl;
using DSCM.ds_tbl_user;
using System;
using System.Collections.Generic;
using System.Text;
namespace DSCM.ds_tbl_article
{
    public class tbl_article
    {
        public int plnum = 0;
        public tbl_user user = new tbl_user();
        public tbl_article_pl[] pl = new tbl_article_pl[] { };
        public string[] bqs = new string[] { };
        public int hot { get; set; }
        public bool isLike { get; set; }
        string article_id = "";
        public string Article_Id
        {
            get { return article_id; }
            set { article_id = value; }
        }
        string article_pic = "";
        public string Article_Pic
        {
            get { return article_pic; }
            set { article_pic = value; }
        }
        string article_title = "";
        public string Article_Title
        {
            get { return article_title; }
            set { article_title = value; }
        }
        string article_contents = "";
        public string Article_Contents
        {
            get { return article_contents; }
            set { article_contents = value; }
        }
        string article_times = "";
        public string Article_Times
        {
            get { return article_times; }
            set { article_times = value; }
        }
        string article_hot = "";
        public string Article_Hot
        {
            get { return article_hot; }
            set { article_hot = value; }
        }
        string article_recommend = "";
        public string Article_Recommend
        {
            get { return article_recommend; }
            set { article_recommend = value; }
        }
        string article_biaoqian = "";
        public string Article_Biaoqian
        {
            get { return article_biaoqian; }
            set { article_biaoqian = value; }
        }
        string user_id = "";
        public string User_Id
        {
            get { return user_id; }
            set { user_id = value; }
        }

        public string Article_type { get; set; }
    }
}