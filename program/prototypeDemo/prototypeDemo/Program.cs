using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prototypeDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            {
                Console.WriteLine("-------------- 浅克隆 ---------------");
                PrototypeClass prototypeClass1 = PrototypeClass.getInstance();
                PrototypeClass prototypeClass2 = PrototypeClass.getInstance();

                prototypeClass1.ID = 5;
                prototypeClass1.inside.CID = 10;
                prototypeClass1.inside.name = "jimmy";
                Console.WriteLine($"{prototypeClass1.ID}, {prototypeClass1.inside.CID}, {prototypeClass1.inside.name}");
                Console.WriteLine($"{prototypeClass2.ID}, {prototypeClass2.inside.CID}, {prototypeClass2.inside.name}");
            }
            {
                Console.WriteLine("-------------- 手动深克隆 ---------------");
                PrototypeClass prototypeClass1 = PrototypeClass.getInsDeep();
                PrototypeClass prototypeClass2 = PrototypeClass.getInsDeep();

                prototypeClass1.ID = 5;
                prototypeClass1.inside.CID = 10;
                prototypeClass1.inside.name = "jimmy";
                Console.WriteLine($"{prototypeClass1.ID}, {prototypeClass1.inside.CID}, {prototypeClass1.inside.name}");
                Console.WriteLine($"{prototypeClass2.ID}, {prototypeClass2.inside.CID}, {prototypeClass2.inside.name}");
            }

            {
                Console.WriteLine("-------------- 序列化深克隆 ---------------");
                PrototypeClass prototypeClass1 = PrototypeClass.getInsSerial();
                PrototypeClass prototypeClass2 = PrototypeClass.getInsSerial();

                prototypeClass1.ID = 5;
                prototypeClass1.inside.CID = 10;
                prototypeClass1.inside.name = "jimmy";
                Console.WriteLine($"{prototypeClass1.ID}, {prototypeClass1.inside.CID}, {prototypeClass1.inside.name}");
                Console.WriteLine($"{prototypeClass2.ID}, {prototypeClass2.inside.CID}, {prototypeClass2.inside.name}");
            }



            Console.ReadLine();


        }
    }
}
