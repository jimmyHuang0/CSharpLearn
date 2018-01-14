using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace attributeDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            #region remarkAttribute
            Console.WriteLine(eState.normal.getStateName());//直接使用扩展方法
            Console.WriteLine(eState.delete.getStateName());
            Console.WriteLine(eState.suspend.getStateName());
            #endregion

            #region validData
            {
                DataValidData.validData(new testClass() { i = 20, j = 50, m = "hello", n = "world" });
                DataValidData.validData(new testClass() { i = 1, j = 50, m = null, n = "hello" });
                DataValidData.validData(new testClass() { i = 1, j = 50, m = "hello", n = "world" });
                DataValidData.validData(new testClass() { i = 20, j = 50, m = null, n = "hello" });
            }
            #endregion

            Console.ReadLine();
        }
    }


    class testClass
    {
        [LongValidDataAttribute(10, 100)]
        public long i { get; set; }
        [LongValidDataAttribute(10, 100)]
        public long j { get; set; }
        [RequirdValidDataAttribute]
        public string m { get; set; }
        [RequirdValidDataAttribute]
        public string n { get; set; }
    }
}
