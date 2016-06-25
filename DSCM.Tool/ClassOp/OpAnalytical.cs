using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using DSCM.Tool.File;
using System.IO;

namespace dscm.Library.ClassOp
{
    public class OpAnalytical
    {
        FileTool fc = new FileTool();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="act">dscm.Library.FFFFF</param>
        /// <param name="op">GGGG</param>
        /// <param name="test"></param>
        /// <returns></returns>
        public object OpAnaly(string act,string op,Object[] test = null)
        {
            try
            {
                Type myType = Type.GetType(act);
                MethodInfo printMethod = myType.GetMethod(op);
                if (printMethod != null)
                {
                    Object obj = Activator.CreateInstance(myType);
                    object o = printMethod.Invoke(obj, test);
                    return o;
                }
                else
                {
                    return null;
                }
            }
            catch { return null; }
        }

        public object OpAssembly(string path,string act,string op, Object[] test)
        {
            try
            {
                string _p = fc.GetRootPath() + path;
                if (File.Exists(_p)) 
                {
                    Assembly ass = Assembly.LoadFrom(_p);
                    Type myType = ass.GetType(act);
                    if (myType != null)
                    {
                        MethodInfo printMethod = myType.GetMethod(op);
                        if (printMethod != null)
                        {
                            Object obj = Activator.CreateInstance(myType);
                            object o = printMethod.Invoke(obj, test);
                            return o;
                        }
                    }
                }
            }
            catch { }
            return null;
        }


    }
}
