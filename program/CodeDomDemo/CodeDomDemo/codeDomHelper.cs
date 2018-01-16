using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CodeDomDemo
{
    /// <summary>
    /// 动态的生成代码：
    ///     使用codeDom类可以动态的生成代码，并且可以编译代码，获取程序集。
    /// 动态调用代码：
    ///     反射
    /// </summary>
    class codeDomHelper
    {
        /// <summary>
        /// 方式一，使用string生成代码。
        /// </summary>
        static public void fun1()
        {
            CodeDomProvider provider = CodeDomProvider.CreateProvider("cs");
            CompilerParameters p = new CompilerParameters();
            p.OutputAssembly = "DemoLib.dll";  
            CompilerResults res = provider.CompileAssemblyFromSource(p,
                "using System;" +
               @"namespace ConsoleApp2
                    {
                        public class a
                        {
                            int i;
                            public void fun() { Console.WriteLine(" + '"' + "aaaaaaa" + '"' + @"); }

                        }
                    }");


            if (res.Errors.Count == 0)
            {
                // 没有出错
                Console.WriteLine("编译成功。");
                // 获取刚刚编译的程序集信息
                Assembly outputAss = res.CompiledAssembly;
                // 全名
                Console.WriteLine($"程序集全名：{outputAss.FullName}");
                // 位置
                Console.WriteLine($"程序集位置：{outputAss.Location}");
                // 程序集中的类型
                Type[] types = outputAss.GetTypes();
                Console.WriteLine("----------------------\n类型列表：");
                foreach (Type t in types)
                {
                    Console.WriteLine(t.FullName);
                }


                Assembly assembly = res.CompiledAssembly;
                Type type = assembly.GetType("ConsoleApp2.a");
                var v = type.GetMethod("fun");
                Object obj = Activator.CreateInstance(type);
                v.Invoke(obj, null);

            }
            else
            {
                // 如果编译出错
                Console.WriteLine("发生错误，详见以下内容：");
                foreach (CompilerError er in res.Errors)
                {
                    Console.WriteLine($"行{er.Line}，列{er.Column}，错误号{er.ErrorNumber}，错误信息：{er.ErrorText}");
                }
            }
        }

        static public void fun2()
        {
            // 文件路径
            string srccodePath = @"demo.cs";

            CodeDomProvider provider = CodeDomProvider.CreateProvider("cs");
            // 编译参数
            CompilerParameters p = new CompilerParameters();
            // 输出文件
            p.OutputAssembly = "DemoLib2.dll";
            // 添加引用的程序集
            // 其实我们这里用不上，只是作为演示
            // mscorLib.dll是不用添加的，它是默认库
            p.ReferencedAssemblies.Add("System.dll");
            // 编译
            CompilerResults res = provider.CompileAssemblyFromFile(p, srccodePath);
            // 检查编译结果
            if (res.Errors.Count == 0)
            {
                // 没有出错
                Console.WriteLine("编译成功。");
                // 获取刚刚编译的程序集信息
                Assembly outputAss = res.CompiledAssembly;
                // 全名
                Console.WriteLine($"程序集全名：{outputAss.FullName}");
                // 位置
                Console.WriteLine($"程序集位置：{outputAss.Location}");
                // 程序集中的类型
                Type[] types = outputAss.GetTypes();
                Console.WriteLine("----------------------\n类型列表：");
                foreach (Type t in types)
                {
                    Console.WriteLine(t.FullName);
                }


                Assembly assembly = res.CompiledAssembly;
                Type type = assembly.GetType("ConsoleApp2.a");
                var v = type.GetMethod("fun");
                Object obj = Activator.CreateInstance(type);
                v.Invoke(obj, null);

            }
            else
            {
                // 如果编译出错
                Console.WriteLine("发生错误，详见以下内容：");
                foreach (CompilerError er in res.Errors)
                {
                    Console.WriteLine($"行{er.Line}，列{er.Column}，错误号{er.ErrorNumber}，错误信息：{er.ErrorText}");
                }
            }
        }

    }
}
