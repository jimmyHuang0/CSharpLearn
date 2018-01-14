using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LinqDemo
{
    class Test
    {
        public void fun()
        {
            var vObj = new
            {
                name = "nihaoma"
            };

            object obj = new
            {
                name = "helloworld"
            };

            dynamic dObj = new
            {
                name = "dynamicObj"
            };
           // dObj.name = "gaile"; //不能使用赋值


        }


        public IEnumerable<int> yeildFun()//返回结果必须是IEnumerable<>接口
        {
            int i = 0;
            while (i<10)
            {
                i++;
                Thread.Sleep(1000);
                yield return i;
            }
        }


    }


    static class ExtentMethod
    {
        static public void funnn(this Test t)
        {

        }

    }

}
