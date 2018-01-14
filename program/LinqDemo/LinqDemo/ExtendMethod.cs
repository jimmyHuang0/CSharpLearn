using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqDemo
{
    static class ExtendMethod
    {
        public static List<T> findWhere<T>(this List<T> list,Func<T,bool> predicate)
        {
            List<T> _list = new List<T>();
            foreach (var item in list)
            {
                if (predicate.Invoke(item))
                {
                    _list.Add(item);
                }
            }
            return _list;
        }
    }
}
