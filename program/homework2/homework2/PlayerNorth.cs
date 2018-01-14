using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework2
{
    class PlayerNorth : PlayerBase
    {
        string juehuo = "北派";
        public override void Bark()
        {
            throw new NotImplementedException();
        }

        public override void Voice()
        {
            throw new NotImplementedException();
        }

        public override void WindSound()
        {
            throw new NotImplementedException();
        }

        public void specialShow() { Console.WriteLine($"这是我的绝活 {this.juehuo}"); }
        public override void InStop() { Console.WriteLine($"表演结束 {this.juehuo}"); }
    }
}
