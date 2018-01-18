using System;
using System.Collections.Generic;
using System.Reflection;
//using CommonItf.RWItf;
using CommonItf.RWItf;

namespace ConsoleApp5
{
    class Program
    {
        static void Main(string[] args)
        {
            Driver.AddDriver(1, "DriverA", "DriverA.DriverA");
            Driver.AddDriver(2, "DriverB", "DriverB.DriverB");

            Console.WriteLine("Hello World!");
            Console.ReadLine();
        }
    }
    class Driver
    {
        static SortedList<int, ISingleRW> _drivers=new SortedList<int, ISingleRW>();

        static public ISingleRW AddDriver(int id,string dllName,string className)
        {
            //_drivers.TryGetValue

            if (_drivers.ContainsKey(id))
                return _drivers[id];

            ITag tag = new ITag();

            ISingleRW dv = null;
            try
            {
                Assembly ass = Assembly.Load(dllName);//加载 dll
                //使用load需要在"xxx.deps.json"文件加上注册信息
                //使用LoadFrom，绝对位置

                // Assembly ass = Assembly.LoadFrom(@"C:\Users\IA203373\source\repos\ConsoleApp5\ConsoleApp5\bin\Debug\netcoreapp2.0\DriverA.dll");
                var dvType = ass.GetType(className);//获取 命名空间下的某类
                if (dvType != null)
                {
                    dv = Activator.CreateInstance(dvType) as ISingleRW;
                    if (dv != null)
                    {
                        Console.WriteLine(dv.readSingle(tag).name.NameInMaster);
                    }
                }
                _drivers.Add(id, dv);
            }
            catch (Exception)
            {
                Console.WriteLine($"获取dll失败：{dllName}");
                //throw;
            }
            return dv;
        }
    }
}
