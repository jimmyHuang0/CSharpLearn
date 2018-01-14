using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace attributeDemo
{
    [AttributeUsage(AttributeTargets.Field| AttributeTargets.Property)]
    abstract class abstractValidDataAttribute:Attribute
    {
       public abstract bool validData(object obj);
    }

    class LongValidDataAttribute : abstractValidDataAttribute
    {
        private long _min = 0;
        private long _max = 0;
        public LongValidDataAttribute(long min,long max)
        {
            this._min = min;
            this._max = max;
        }

        public override bool validData(object obj)
        {
            if(obj is long)
            {
                long l =(long)obj;

                return _min< l && l<_max;
            }
            else
            {
                return false;
            }
        }
    }

    class RequirdValidDataAttribute : abstractValidDataAttribute
    {
        public override bool validData(object obj)
        {
            if (obj==null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }


    public static class DataValidData
    {
        public static bool validData<T>(T obj)
        {
            ///这里传一个类型过来
            Type type = obj.GetType();
            bool ret=true;
            ///这里获取的都是属性，没有获取字段
            foreach (var item in type.GetProperties())
            {
                if (item.IsDefined(typeof(abstractValidDataAttribute), true))
                {
                    abstractValidDataAttribute attribute = item.GetCustomAttributes(true)[0] as abstractValidDataAttribute;
                    if(!attribute.validData(item.GetValue(obj)))//有任意一个属性不符合要求，返回false
                    {
                        ret=false;
                        break;
                    }
                        
                }
            }
            Console.WriteLine(ret);
            return ret;
        }
    }
}
