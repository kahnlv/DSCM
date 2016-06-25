/* 
* ======================================================================== 
* 
* Author：鼎燊文化传媒 Time：2015/6/5 14:16:49 
* File name：hongbao 
* Version：V1.0.1
* Company: 鼎燊文化传媒 
* Framework Version: 2.0
*
* ======================================================================== 
*/

using System;
using System.Collections.Generic;
using System.Text;

namespace DSCM.ds_tbl_admin {
    public class tbl_admin
    {
        string admin_id = "";
        public string Admin_Id
        {
            get { return admin_id; }
            set { admin_id = value; }
        }
        string admin_name = "";
        public string Admin_Name
        {
            get { return admin_name; }
            set { admin_name = value; }
        }
        string admin_pwd = "";
        public string Admin_Pwd
        {
            get { return admin_pwd; }
            set { admin_pwd = value; }
        }
        string admin_type = "";
        public string Admin_Type
        {
            get { return admin_type; }
            set { admin_type = value; }
        }
        string parent_admin_id = "";
        public string Parent_Admin_Id
        {
            get { return parent_admin_id; }
            set { parent_admin_id = value; }
        } 
    }
}
