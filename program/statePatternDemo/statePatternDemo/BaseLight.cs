using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace statePatternDemo
{
    abstract class BaseLight
    {
        abstract public void show();
        abstract public void turn(Context context);
    }
}
