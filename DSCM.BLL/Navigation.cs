/* 
* ======================================================================== 
* 
* Author：鼎燊文化传媒 Time：2015/4/7 11:23:16 
* File name：Navigation 
* Version：V1.0.1
* Company: 鼎燊文化传媒 
* Framework Version: 2.0
*
* ======================================================================== 
*/

using System;
using System.Collections.Generic;
using System.Text;

namespace DSCM.BLL
{
    public class Navigation
    {
        string type = "";

        public string Type
        {
            get { return type; }
            set { type = value; }
        }
        string img = "";

        public string Img
        {
            get { return img; }
            set { img = value; }
        }
        string title = "";
        public string Title
        {
            get { return title; }
            set { title = value; }
        }
        Menu[] menu;
        public Menu[] Menu
        {
            get { return menu; }
            set { menu = value; }
        }
    }

    public class Menu
    {
        string title = "";

        public string Title
        {
            get { return title; }
            set { title = value; }
        }
        string url = "";

        public string Url
        {
            get { return url; }
            set { url = value; }
        }
        Menu[] _menu;
        public Menu[] _Menu
        {
            get { return _menu; }
            set { _menu = value; }
        }
    }

    public class dscm_nav
    {
        Navigation[] navigation;

        public Navigation[] Navigation
        {
            get { return navigation; }
            set { navigation = value; }
        }
    }
}
