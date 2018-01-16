using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lambdaTest
{
    class classTest
    {
        public Func<int> T1()
        {
            var n = 10;
            return () =>
            {
                return n;
            };
        }

        public Func<int> T4()
        {

            return () =>
            {
                var n = 10;
                return n;
            };
        }
    }
}
