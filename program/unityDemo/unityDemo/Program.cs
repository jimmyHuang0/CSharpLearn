using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;
using Unity.Interception.ContainerIntegration;
using Unity.Interception.Interceptors.InstanceInterceptors.InterfaceInterception;
using Unity.Interception.PolicyInjection.Pipeline;
using Unity.Interception.PolicyInjection.Policies;

namespace unityDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            UnityAOP.Show();
            Console.ReadLine();
        }
    }

    public class UnityAOP
    {
        public static void Show()
        {
            User user = new User()
            {
                Name = "Eleven",
                Password = "12345678957576"
            };
            {
                UserProcessor processor = new UserProcessor();
                processor.RegUser(user);

                Console.WriteLine("*********************");
            }
            {
                IUnityContainer container = new UnityContainer();//声明一个容器
                container.RegisterType<IUserProcessor, UserProcessor>();//声明UnityContainer并注册IUserProcessor
                IUserProcessor processor = container.Resolve<IUserProcessor>();
                processor.RegUser(user);//调用

                container.AddNewExtension<Interception>().Configure<Interception>()
                    .SetInterceptorFor<IUserProcessor>(new InterfaceInterceptor());


                //IUserProcessor userprocessor = new UserProcessor();
                IUserProcessor userprocessor = container.Resolve<IUserProcessor>();

                Console.WriteLine("********************");
                userprocessor.RegUser(user);//调用
                userprocessor.GetUser(user);//调用


            }
        }
    }


    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
    }


    [UserHandlerAttribute(Order = 1)]
    [ExceptionHandlerAttribute(Order = 3)]
    [LogHandlerAttribute(Order = 2)]
    [AfterLogHandlerAttribute(Order = 5)]
    public interface IUserProcessor
    {
        void RegUser(User user);
        User GetUser(User user);
    }


    public class UserProcessor : IUserProcessor
    {
        public void RegUser(User user)
        {
            Console.WriteLine("用户已注册。");
        }

        public User GetUser(User user)
        {
            return user;
        }
    }

}
