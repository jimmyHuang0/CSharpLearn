using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LotteryBall
{
    class RandomHelper
    {
        static private object obj = new object();
        static public int getRandomNum(int startNum=1,int endNum=51)
        {
            Guid guid;
            lock (obj){
                guid = Guid.NewGuid();
            }
            
            int t = System.DateTime.Now.Millisecond;
            char[] chars= guid.ToString().ToArray<char>();
            foreach (var item in chars)
            {
                switch (item)
                {
                    case 'a':
                    case 'b':
                    case 'c':
                    case 'd':
                    case 'e':
                    case 'f':
                    case 'g':
                        t++;
                        break;
                    case 'h':
                    case 'i':
                    case 'j':
                    case 'k':
                        t=t+2;
                        break;
                    case 'l':
                    case 'm':
                    case 'n':
                    case 'o':
                    case 'p':
                    case 'q':
                    case 'r':
                    case 's':
                        t = t + 3;
                        break;
                    case 't':
                    case 'u':
                    case 'v':
                    case 'w':
                    case 'x':
                    case 'y':
                    case 'z':
                        t = t + 5;
                        break;
                    default:
                        t = t - 1;
                        break;
                }
            }

            Random random = new Random(t);
            int ret = random.Next(startNum, endNum);//取1~50的随机值
            //Console.WriteLine(ret);
            return ret;
        }
    }
}