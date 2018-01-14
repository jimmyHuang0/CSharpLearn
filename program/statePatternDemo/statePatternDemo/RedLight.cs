using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace statePatternDemo
{
    class RedLight : BaseLight
    {
        public RedLight()
        {
        }

        public override void show() => Console.WriteLine("红灯停");

        public override void turn(Context context)
        {
            context.baseLight = new GreenLight();
        }
    }
}
