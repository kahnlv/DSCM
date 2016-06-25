using System;
using System.Collections.Generic;
using System.Text;

namespace dscm.Library.self
{
    public class YzConfig
    {
        bool success = false;

        public bool Success
        {
            get { return success; }
            set { success = value; }
        }
        string jQM = "";

        public string JQM
        {
            get { return jQM; }
            set { jQM = value; }
        }
        static string softReg = "";

        public static string SoftReg
        {
            get { return softReg; }
            set { softReg = value; }
        }
        string nAME = "";

        public string NAME
        {
            get { return nAME; }
            set { nAME = value; }
        }
        string pWD = "";

        public string PWD
        {
            get { return pWD; }
            set { pWD = value; }
        }
        string uRL = "";

        public string URL
        {
            get { return uRL; }
            set { uRL = value; }
        }
        string sqlConfig = "";

        public string SqlConfig
        {
            get { return sqlConfig; }
            set { sqlConfig = value; }
        }
        string yZ = "";

        public string YZ
        {
            get { return yZ; }
            set { yZ = value; }
        }
        string mD5KEY = "";

        public string MD5KEY
        {
            get { return mD5KEY; }
            set { mD5KEY = value; }
        }
        string dCKEY = "";

        public string DCKEY
        {
            get { return dCKEY; }
            set { dCKEY = value; }
        }
        string _dCKEY = "";

        public string _DCKEY
        {
            get { return _dCKEY; }
            set { _dCKEY = value; }
        }
        string uSER_NAME = "";

        public string USER_NAME
        {
            get { return uSER_NAME; }
            set { uSER_NAME = value; }
        }
        string uSER_PWD = "";

        public string USER_PWD
        {
            get { return uSER_PWD; }
            set { uSER_PWD = value; }
        }
        DateTime tIME = DateTime.Now;

        public DateTime TIME
        {
            get { return tIME; }
            set { tIME = value; }
        }
    }
}
