using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework2
{
    class PlayerSouth : PlayerBase
    {
        string juehuo = "南派";
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
        public override void Prologue() { Console.WriteLine($"开场白 {this.juehuo}"); }
    }
}
