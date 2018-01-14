using IDBHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace classDll
{
    public class ClassDll: IHelper
    {
        public void fun()
        {
            //Console.WriteLine("this is fun");
            Console.WriteLine($"{this.GetType().ToString()}");
        }

        public void funT<T>(T t)
        {
            Console.WriteLine($"funT : {this.GetType().ToString()} : {t}");
        }

        public int p1 { get; set; }

        public bool b1=true;
    }

    public class ClassTest: IHelper
    {
        public void fun()
        {
            Console.WriteLine($"{this.GetType().ToString()}");
        }

        public void funT<T>(T t)
        {
            Console.WriteLine($"funT : {this.GetType().ToString()} : {t}");
        }
    }
}
