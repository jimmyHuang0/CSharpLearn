using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlyWeightPattern
{
    class FlyWeightModle
    {
        private static Dictionary<E_key, keyModel> dictionary = new Dictionary<E_key, keyModel>();

        private static object o = new object();

        static public keyModel GetKey(E_key str)
        {
            keyModel keyModel = null;
            if (dictionary.ContainsKey(str))
            {
                return dictionary[str];
            }
            else
            {
                lock (o)
                {
                    if (dictionary.ContainsKey(str))
                    {
                        return dictionary[str];
                    }
                    else
                    {
                        switch (str)
                        {
                            case E_key.A:
                                keyModel = new keyA("A");
                                dictionary[E_key.A] = keyModel;
                                break;
                            case E_key.B:
                                keyModel = new keyA("B");
                                dictionary[E_key.B] = keyModel;
                                break;
                            case E_key.C:
                                keyModel = new keyA("C");
                                dictionary[E_key.C] = keyModel;
                                break;
                            default:
                                throw new Exception();
                        }
                        return keyModel;
                     }        
                }
            }
        }
    }
    enum E_key
    {
        A,
        B,
        C
    }
}
