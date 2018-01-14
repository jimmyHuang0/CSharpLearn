using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace statePatternDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Context context = new Context();

            for (int i = 0; i < 9; i++)
            {
                context.show();
                context.turn();
            }

            Console.ReadLine();

        }
    }
}
