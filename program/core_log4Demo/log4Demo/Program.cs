using log4net;
using log4net.Config;
using log4net.Repository;
using System;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;

namespace log4Demo
{
    class Program
    {
        static void Main(string[] args)
        {
           //ILoggerRepository repository = LogManager.CreateRepository("NETCoreRepository");
           //// 默认简单配置，输出至控制台
           //BasicConfigurator.Configure(repository);
           //ILog log = LogManager.GetLogger(repository.Name, "NETCorelog4net");
           //
           //log.Info("NETCorelog4net log");
           //log.Info("test log");
           //Console.ReadKey();
           //
           //log.Error("error");
           //log.Info("linezero");
           //Console.ReadKey();

            ILoggerRepository repository = LogManager.CreateRepository("NETCoreRepository");
            XmlConfigurator.Configure(repository, new FileInfo("log4net.config"));
            //ILog log = LogManager.GetLogger(repository.Name, "NETCorelog4net");
           
            ///这里获取的logger就是config文件里定义，如果里面没有定义的就是获取root节点的
            ILog log = LogManager.GetLogger(repository.Name,"root");
            log.Error("error");
            //TaskFactory taskFactory = new TaskFactory();
            //for (int i = 0; i < 10; i++)
            //{
            //    int j = i;
            //    taskFactory.StartNew(new Action(() => { log.Info($"NETCorelog4net log {j}"); }));
            //}

            var total = 200000;
            var sw = new Stopwatch();
            sw.Start();
            //Parallel.For(0, total, (int i) => { log.Info("log4 bigdata test: " + i); });

            for (int i = 0; i < total; i++)
            {
                log.Info("log4 bigdata test: " + i);
            }
            sw.Stop();
            log.Info($"total: {total}, Elapsed:{sw.ElapsedMilliseconds}");
            Console.WriteLine($"Log4net测试 total: {total}, Elapsed:{sw.ElapsedMilliseconds}");

            Console.ReadKey();
        }
    }
}
