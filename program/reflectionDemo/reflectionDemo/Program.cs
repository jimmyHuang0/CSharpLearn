using IDBHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;


namespace reflectionDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            #region 通过反射获取一个程序集
            {
                /// <summary>
                /// 目标一、
                ///     通过反射获取一个程序集
                /// </summary>
                //try
                //{
                //    Assembly assembly = Assembly.Load("ClassDll");

                //    foreach (var item in assembly.GetTypes())
                //    {
                //        Console.WriteLine($"{item.Name}");
                //    }

                //    Type type = assembly.GetType("classDll.ClassDll");
                //    object obj = Activator.CreateInstance(type);
                //    IHelper helper = (IHelper)obj;
                //    helper.fun();


                //    Type typeTest = assembly.GetType("classDll.ClassTest");
                //    IHelper helper1 = (IHelper)Activator.CreateInstance(typeTest);
                //    helper1.fun();


                //    Console.WriteLine("--- end ---");
                //}
                //catch (Exception e)
                //{
                //    Console.WriteLine($"error={e.Message}");
                //}
                

            }
            #endregion

            #region 通过反射调用泛型方法和获取属性
            //{
            //    try
            //    {
            //        Assembly assembly = Assembly.Load("ClassDll");
            //        Type type = assembly.GetType("classDll.ClassDll");
            //        object obj = Activator.CreateInstance(type);

            //        //获取普通方法
            //        Console.WriteLine("---------------- 获取普通方法 -----------------");
            //        MethodInfo methodInfo = type.GetMethod("fun");
            //        methodInfo.Invoke(obj, null);

            //        //泛型方法的调用要获取MethodInfo后，在调用MakeGenericMethod
            //        Console.WriteLine("---------------- 获取泛型方法 -----------------");
            //        MethodInfo methodInfoT = type.GetMethod("funT");
            //        MethodInfo methodInfoT2 = methodInfoT.MakeGenericMethod(new Type[] { typeof(int) });
            //        methodInfoT2.Invoke(obj, new object[] { 123 });

            //        //获取属性
            //        Console.WriteLine("---------------- 获取属性 -----------------");
            //        PropertyInfo p1 = type.GetProperty("p1");
            //        Console.WriteLine("p1="+p1.GetValue(obj));
            //        p1.SetValue(obj, 999);
            //        Console.WriteLine("p1=" + p1.GetValue(obj)); ;

            //        FieldInfo b1 = type.GetField("b1"); //type.GetField
            //        Console.WriteLine("b1=" + b1.GetValue(obj));
            //        b1.SetValue(obj, false);
            //        Console.WriteLine("b1=" + b1.GetValue(obj));


            //    }
            //    catch (Exception)
            //    {

            //        throw;
            //    }


            //}
            #endregion

            #region 简单工厂+单例模式
            {
                IHelper helper = classDll.simpleFactory.creatInstance();
                helper.funT("hello world");
            }
            #endregion



            Console.WriteLine("--- end ---");
            Console.ReadLine();
        }
    }
}
