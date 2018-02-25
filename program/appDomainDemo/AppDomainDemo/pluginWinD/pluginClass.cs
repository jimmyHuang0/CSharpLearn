using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pluginWinD
{
    [Serializable]
    public class pluginClass
    {
        public pluginClass()
        {
            //int i =  0;
            //int j = 1 / i;


            Console.WriteLine($"我是plugin HH; DomainID= {Thread.GetDomainID()}");


            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }

        public void fun()
        {
            Console.WriteLine("我是fun");
        }
    }
}
