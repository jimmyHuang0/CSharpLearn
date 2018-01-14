using IDBHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace classDll
{
    class simpleFactory
    {
        static private IHelper _helper;
        

        public static IHelper creatInstance()
        {
            if(_helper==null)
            {
                Assembly assembly = Assembly.Load("ClassDll");
                Type type = assembly.GetType("classDll.ClassDll");
                _helper = Activator.CreateInstance(type) as IHelper;
            }
            return _helper;
        }


    }
}
