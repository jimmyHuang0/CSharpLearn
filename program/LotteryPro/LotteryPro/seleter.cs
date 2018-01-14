using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LotteryPro
{
    class Seleter
    {
        static int numCnt = 7;
        List<int> listTemp = new List<int>();
        public List<int> getRandomNums()
        {
            Random random = new Random();
            List<int> result = new List<int>();
            int temp;
            while (result.Count < numCnt)
            {
                temp = random.Next(0, 10);
                if (!result.Contains(temp))
                {
                    result.Add(temp);
                }
            }
            listTemp = result;
            return result;
        }

        public List<int> getListTemp()
        {
            return listTemp;
        }

        public void setListTemp(List<int> list)
        {
            listTemp = list;
        }

        public string getListTempStr()
        {
            return list2string(listTemp);
        }

        private string list2string(List<int> list)
        {
            string str=" ";
            for (int i = 0; i < list.Count; i++)
            {
                if(i!=list.Count-1)
                {
                    str = str + " " + list[i].ToString();
                }
                else
                {
                    str = str + "     " + list[i].ToString();
                }
                
            }
            return str;
        }
    }
}
