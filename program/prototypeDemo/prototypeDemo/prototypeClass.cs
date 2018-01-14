using PrototypePattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace prototypeDemo
{
    [Serializable]
    class PrototypeClass
    {
        private PrototypeClass()
        {
            ID = 1;
            inside = new ClassInside();
            Thread.Sleep(1000);
            Console.WriteLine("PrototypeClass 构造函数");
        }

  

        /// <summary>
        /// 单例模式一 : 静态构造函数：由CLR保证，在第一次使用这个类之前，调用而且只调用一次
        /// </summary>
        static PrototypeClass()
        {
            _prototypeClass = new PrototypeClass();
        }
        /// <summary>
        /// 单例模式二 : 使用new，简写了上面的静态构造函数
        /// </summary>
        static private PrototypeClass _prototypeClass = null;// new PrototypeClass();



        public int ID { get; set; }
        public ClassInside inside { get; set; }

        static public PrototypeClass getInstance()
        {
            ///浅克隆，值对象克隆新的地址，引用对象克隆引用地址，不会克隆引用对象本身
            PrototypeClass prototypeClass = (PrototypeClass)_prototypeClass.MemberwiseClone();
            return prototypeClass;
        }
        static public PrototypeClass getInsDeep()
        {
            ///浅克隆，值对象克隆新的地址，引用对象克隆引用地址，不会克隆引用对象本身
            PrototypeClass prototypeClass = (PrototypeClass)_prototypeClass.MemberwiseClone();
            ///手动深克隆，class是引用，克隆只克隆了地址
            prototypeClass.inside = new ClassInside();
            return prototypeClass;
        }
        static public PrototypeClass getInsSerial()
        {
            ///通过序列化来深克隆
            return SerializeHelper.DeepClone<PrototypeClass>(_prototypeClass); 
        }


    }

    [Serializable]
    class ClassInside
    {
        public int CID = 0;
        public string name = "empty";
    }


}
