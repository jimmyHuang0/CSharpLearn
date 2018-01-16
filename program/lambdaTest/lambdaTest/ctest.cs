using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace lambdaTest
{
    class ctest
    {
        static public void fun()
        {

            Object
            int num=1;
            while(num<99999)
            {
                try
                {
                    Console.WriteLine("输入num：");
                    num = int.Parse(Console.ReadLine());
                    Console.WriteLine("-----------------------");
                    for (int i = 0; i < 5; i++)
                    {

                        new Action(() =>
                        {
                            Console.WriteLine(i);
                        }).BeginInvoke(null, null);
                        Thread.Sleep(num);
                    }
                }
                catch (Exception)
                {

                    //throw;
                }
                
            }
            
 
        }

     
    }
}