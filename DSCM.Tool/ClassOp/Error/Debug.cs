using System;
using System.Collections.Generic;
using System.Text;

namespace DSCM.Tool.Error
{
    public class Debug
    {
        static StringBuilder errorStr = new StringBuilder();
        public static string Read(string bug)
        {
            return errorStr.ToString();
        }

        public static void Write(string bug)
        {
            errorStr.AppendLine(bug);
        }

        public static void Clear()
        {
            errorStr = new StringBuilder();
            GC.Collect();
        }
    }
}
