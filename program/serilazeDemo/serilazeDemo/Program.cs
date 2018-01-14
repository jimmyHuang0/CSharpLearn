using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace serilazeDemo
{
    class Program
    {
        static void Main(string[] args)
        {


            {//序列化对象
                Serilaze seObj = new Serilaze();
                seObj.name = "aaaaa";

                FileStream fs = new FileStream("obj.ooo", FileMode.Create);
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(fs, seObj);
                fs.Close();
            }
            {//反序列化对象
                FileStream fs = new FileStream("obj.ooo", FileMode.Open);
                BinaryFormatter formatter = new BinaryFormatter();
                Serilaze seObj = (Serilaze)formatter.Deserialize(fs);
                Console.WriteLine(seObj.name.ToString() + " " + seObj.id.ToString());
            }

            Console.ReadLine();


        }
    }

    [Serializable]///设置序列化属性
    class Serilaze
    {
        public string name = "hello";
        public int id = 10;
    }


}
