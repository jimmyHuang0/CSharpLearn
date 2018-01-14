using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace attributeDemo
{
    enum eState
    {
        [remarkAttribute("正常")]
        normal = 0,
        [remarkAttribute("删除")]
        delete = 1,
        [remarkAttribute("暂停")]
        suspend = 2
    }

    class remarkAttribute : Attribute
    {
        private string _name=null;
        public remarkAttribute(string name)
        {
            this._name = name;
        }

        public string getName()
        {
            return this._name;
        }
    }

    /// <summary>
    /// 这是一个扩展方法，只要类型属于Enum，就都可以使用getStateName方法
    /// </summary>
    public static class GetStateName
    {
        public static string getStateName(this Enum enu)
        {
            ///enu.GetType获取的是Enum的类型，需要通过GetField来获取枚举类型的字段
            Type type = enu.GetType();
            FieldInfo fieldInfo = type.GetField(enu.ToString());
            if (fieldInfo.IsDefined(typeof(remarkAttribute), true))
            {
                ///GetCustomAttributes返回的时一个object[]，可以直接使用右括号，获取第一个函数返回的值
                ///
                remarkAttribute obj = fieldInfo.GetCustomAttributes(true)[0] as remarkAttribute;
                return obj.getName();
            }
            else
            {
                return enu.ToString();
            }
        }
    }
  
}
