using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FlyWeightPattern
{
    class keyC : keyModel
    {
        private string _str;
        public keyC(string str)
        {
            System.Threading.Thread.Sleep(1000);
            Console.WriteLine($"构造了{str}");
            _str = str;
        }
        override public void show() { Console.WriteLine($"{_str}  {Thread.CurrentThread.ManagedThreadId}");}
    }
}
