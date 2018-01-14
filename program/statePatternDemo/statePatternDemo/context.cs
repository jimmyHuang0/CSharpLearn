using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace statePatternDemo
{
    class Context
    {
        public BaseLight baseLight=null;

        public Context()
        {
            baseLight = new RedLight();
        }

        public void show() => baseLight.show();

        public void turn()
        {
            baseLight.turn(this);
        }
    }
}
