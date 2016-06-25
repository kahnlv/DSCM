using System;
using System.Collections.Generic;
using System.Text;
using System.CodeDom.Compiler;
using System.Reflection;
using Microsoft.CSharp;
using System.Collections;
using DSCM.Tool.File;

namespace dscm.Library.self
{
    public class SAssembly
    {
        static FileTool fc = new FileTool();
        static CSharpCodeProvider provider;
        static CompilerParameters cp;
        /// <summary>
        /// 动态创建dll
        /// </summary>
        /// <param name="classSource">程序代码</param>
        /// <param name="al">附加的dll</param>
        /// <param name="path">dll存储位置</param>
        /// <param name="name">dll名称</param>
        /// <returns></returns>
        public static Assembly NewAssembly(StringBuilder classSource,ArrayList al, string path,string name)
        {
            try
            {
                //创建编译器实例。   
                provider = new CSharpCodeProvider();
                //设置编译参数。   
                cp = new CompilerParameters();
                cp.GenerateExecutable = false;
                cp.GenerateInMemory = true;
                cp.OutputAssembly = fc.GetRootPath() + path + "\\" + name + ".dll";
                cp.IncludeDebugInformation = true;
                cp.GenerateInMemory = false;
                cp.WarningLevel = 3;
                cp.TreatWarningsAsErrors = false;
                cp.CompilerOptions = "/optimize";

                cp.ReferencedAssemblies.Add("System.dll");
                cp.ReferencedAssemblies.Add("System.Data.dll");
                cp.ReferencedAssemblies.Add("System.Deployment.dll");
                cp.ReferencedAssemblies.Add("System.Design.dll");
                cp.ReferencedAssemblies.Add("System.Drawing.dll");
                cp.ReferencedAssemblies.Add("System.Windows.Forms.dll");
                if (al != null)
                {
                    for (int i = 0; i < al.Count; i++)
                    {
                        cp.ReferencedAssemblies.Add(al[i].ToString());
                    }
                }
                //创建动态代码。
                if (classSource != null)
                {
                    System.Diagnostics.Debug.WriteLine(classSource.ToString());

                    //编译代码。   
                    CompilerResults result = provider.CompileAssemblyFromSource(cp, classSource.ToString());
                    if (result.Errors.Count > 0)
                    {
                        string error = "";
                        for (int i = 0; i < result.Errors.Count; i++)
                        {
                            error += result.Errors[i];
                        }
                        fc.Write("Log/dt" + DateTime.Now.Ticks, error);
                        return null;
                    }

                    provider.Dispose();
                    //获取编译后的程序集。
                    Assembly assembly = result.CompiledAssembly;
                    return assembly;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex) { fc.Write("Log/dt" + DateTime.Now.Ticks, ex.ToString()); }
            return null;
        }
        
        public static void assembly(string path)
        {
            Assembly ass = Assembly.LoadFrom(path); 
        }
    }
}
