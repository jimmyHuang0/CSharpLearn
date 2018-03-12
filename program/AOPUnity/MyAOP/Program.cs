using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAOP
{
    /// <summary>
    /// 1 AOP面向切面编程
    /// 2 静态代理实现AOP
    /// 3 动态代理实现AOP
    /// 4 Unity、MVC中的AOP
    /// 
    /// POP
    /// 
    /// OOP：面向对象编程，万物皆对象，类与类交互，组成功能/组件/系统，适合做大项目，大系统
    ///      静态的，封闭的，任何需求的变化都会带来影响
    ///      GOF23种设计模式 设计模式原则，解决类与类之间的交互稳定
    ///      类的自身变化，增加功能需求，解决不了的
    ///      
    /// AOP：面向切面编程，实际上是对OOP的一种补充
    ///      允许通过外部方式来修改对象，可以在不破坏类型封装的前提下，去提供新的功能
    ///      只是增加通用逻辑，，比如事务、日志、异常、权限、校验、缓存
    ///      
    /// 反射  包一层  特性  filter  代理模式   装饰器模式   注入
    /// 
    /// AOP:装饰器/代理模式                静态AOP
    ///     realproxy/emit生成/Unity       动态代理AOP
    ///     mvc filter                     反射+统一入口，特性
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("欢迎来到.Net高级班vip课程，今天学习面向切面AOP");
                #region AOP show
               //Console.WriteLine("***********************");
               //DecoratorAOP.Show();
               //
               //Console.WriteLine("***********************");
               //ProxyAOP.Show();
               //Console.WriteLine("***********************");
               //CastleProxyAOP.Show();
               //Console.WriteLine("***********************");
                UnityAOP.Show();
                #endregion
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.Read();
        }
    }
}
