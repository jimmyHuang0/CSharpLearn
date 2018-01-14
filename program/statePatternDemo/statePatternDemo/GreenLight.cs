using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace statePatternDemo
{
    class GreenLight : BaseLight
    {
        public GreenLight()
        {
        }

        public override void show()
        {
            Console.WriteLine("绿灯走");
        }

        public override void turn(Context context) => 
            context.baseLight = new YellowLight();
    }
}
