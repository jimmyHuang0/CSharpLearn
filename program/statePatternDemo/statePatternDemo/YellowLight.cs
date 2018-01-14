using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace statePatternDemo
{
    class YellowLight : BaseLight
    {
        public YellowLight()
        {
        }

        public override void show()
        {
            Console.WriteLine("黄灯亮了等一等");
        }

        public override void turn(Context context) => context.baseLight = new RedLight();
    }
}
