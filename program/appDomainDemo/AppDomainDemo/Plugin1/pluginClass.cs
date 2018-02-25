using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plugin1
{
    [Serializable]
    public class pluginClass
    {
        public pluginClass()
        {
            Console.WriteLine("我是plugin CC");
        }

        public void fun()
        {
            Console.WriteLine("我是fun");
        }
    }
}
