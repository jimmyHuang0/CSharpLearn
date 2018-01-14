using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlyWeightPattern
{
    class Test
    {
        public void showA()
        {
            Console.WriteLine("--------- 开始showA ----------");
            keyModel a = FlyWeightModle.GetKey(E_key.A);
            keyModel b = FlyWeightModle.GetKey(E_key.B);
            keyModel c = FlyWeightModle.GetKey(E_key.C);
            a.show();
            b.show();
            c.show();
        }
        public void showB()
        {
            Console.WriteLine("--------- 开始showB ----------");
            keyModel a = FlyWeightModle.GetKey(E_key.A);
            keyModel b = FlyWeightModle.GetKey(E_key.B);
            keyModel c = FlyWeightModle.GetKey(E_key.C);
            a.show();
            b.show();
            c.show();
        }
    }
}
