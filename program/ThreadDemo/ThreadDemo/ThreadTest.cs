using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadDemo
{
    class ThreadTest
    {

        public void test()
        {
            Console.WriteLine("---------- 无参数多线程 -----------");
            ThreadStart threadStart = DFun;
            Thread thread1 = new Thread(threadStart);
            thread1.Start();
      
            Thread thread2 = new Thread(DFun);
            thread2.Start();
        }
        public void test1()
        {
            Console.WriteLine("---------- 带参数多线程 -----------");

            ///这里是类型不安全的，调用的函数的参数是object
            ParameterizedThreadStart start = PFun;
            Thread thread = new Thread(start);
            thread.Start(10);

            Thread thread1 = new Thread(PFun);
            thread1.Start(20);

            ///这里是类型安全的，在开始的时候已经定义了变量
            ThreadFun<string> fun = new ThreadFun<string>("你好");
            Thread thread2 = new Thread(fun.ChildThread);
            thread2.Start();
        }

        public void test2()
        {
            Console.WriteLine("---------- 带返回值多线程，模拟异步调用 -----------");

            //定义一个Func委托
            Func<string> SFun = () =>
            {
                Console.WriteLine($"ThreadID={Thread.CurrentThread.ManagedThreadId} doSomeThing...start {DateTime.Now.Ticks}");
                Thread.Sleep(5000);
                Console.WriteLine($"ThreadID={Thread.CurrentThread.ManagedThreadId} doSomeThing...end   {DateTime.Now.Ticks}");
                return "Go";
            };
        
            ///定义了一个泛型函数A，A内部启动一个线程，同时返回一个带有同类型的一个泛型函数B
            ///B是等待A线程完成后才返回一个值
            ///通过invoke B，来激活返回的泛型函数B，并最后得到返回值
            ///因此，在调用A的时候，可以做另外的东西C。但是，把 B.Invoke放在做另外的
            Func<string> B = AFun<string>(SFun);          
            CFun();//可以做点别的
            var b = B.Invoke();//最后再来拿结果
            Console.WriteLine(b);

        }

        void CFun()
        {
            Console.WriteLine("Else1............................");
            Thread.Sleep(1000);
            Console.WriteLine("Else2............................");
            Thread.Sleep(1000);
            Console.WriteLine("Else3............................");
        }

        void DFun()
        {
            Thread.Sleep(1000);
            Console.WriteLine($"ThreadID={Thread.CurrentThread.ManagedThreadId} doSomeThing...{DateTime.Now.Ticks}");
        }

        void PFun(object obj)
        {
            int o = (int)obj;
            Console.WriteLine($"ThreadID={Thread.CurrentThread.ManagedThreadId} doSomeThing...{DateTime.Now.Ticks}  obj={o}");
        }

        Func<T> AFun<T>(Func<T> func)
        {

            T t = default(T);
            ThreadStart start = () =>
              {
                  t=func.Invoke();
              };
            Thread thread = new Thread(start);
            thread.Start();

            return new Func<T>(() =>
            {
                thread.Join();
                return t;
            });
        }
    }


    class ThreadFun<T>
    {
        T _t = default(T);
        public ThreadFun(T t)
        {
            _t = t;
        }

        public void ChildThread()
        {
            Console.WriteLine($"ThreadID={Thread.CurrentThread.ManagedThreadId} doSomeThing...{DateTime.Now.Ticks}  obj={_t}");
        }

    }

}
