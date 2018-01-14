using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace luckyGuyDemo
{
    class studentList
    {
        List<student> stdList = new List<student>();
        public void add(student std)
        {
            stdList.Add(std);
        }
        public student getRanStd()
        {
            Random num = new Random();
            if(stdList.Count==0)
            {
                return new student() { name="null",id="null"};
            }
            else
                return stdList[num.Next(stdList.Count)];
        }

    }

    struct student
    {
       public string name;
       public string id;
    }

}
