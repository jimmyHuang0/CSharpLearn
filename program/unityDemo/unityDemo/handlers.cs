﻿using System;
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

    public class UserHandler : ICallHandler
    {
        public int Order { get; set; }
        public IMethodReturn Invoke(IMethodInvocation input, GetNextHandlerDelegate getNext)
        {
            User user = input.Inputs[0] as User;
            if (user.Password.Length < 10)
            {
                return input.CreateExceptionMethodReturn(new Exception("密码长度不能小于10位"));
            }
            Console.WriteLine("参数检测无误");


            IMethodReturn methodReturn = getNext()(input, getNext); //getNext.Invoke().Invoke(input, getNext);

            //Console.WriteLine("已完成操作");

            return methodReturn;
        }
    }

    public class LogHandler : ICallHandler
    {
        public int Order { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="input">方法调用的参数列表</param>
        /// <param name="getNext"></param>
        /// <returns></returns>
        public IMethodReturn Invoke(IMethodInvocation input, GetNextHandlerDelegate getNext)
        {
            User user = input.Inputs[0] as User;
            string message = $"RegUser:Username:{user.Name},Password:{user.Password}";
            Console.WriteLine("日志已记录，Message:{0},Ctime:{1}", message, DateTime.Now);
            return getNext()(input, getNext);
        }
    }


    public class ExceptionHandler : ICallHandler
    {
        public int Order { get; set; }
        public IMethodReturn Invoke(IMethodInvocation input, GetNextHandlerDelegate getNext)
        {
            IMethodReturn methodReturn = getNext()(input, getNext);
            if (methodReturn.Exception == null)
            {
                Console.WriteLine("无异常");
            }
            else
            {
                Console.WriteLine($"异常:{methodReturn.Exception.Message}");
            }
            return methodReturn;
        }
    }

    public class AfterLogHandler : ICallHandler
    {
        public int Order { get; set; }
        public IMethodReturn Invoke(IMethodInvocation input, GetNextHandlerDelegate getNext)
        {
            IMethodReturn methodReturn = getNext()(input, getNext);
            User user = input.Inputs[0] as User;
            string message = string.Format("RegUser:Username:{0},Password:{1}", user.Name, user.Password);
            Console.WriteLine("完成日志，Message:{0},Ctime:{1},计算结果{2}", message, DateTime.Now, methodReturn.ReturnValue);
            return methodReturn;
        }
    }






    #region 特性
    public class UserHandlerAttribute : HandlerAttribute
    {
        public override ICallHandler CreateHandler(IUnityContainer container)
        {
            ICallHandler handler = new UserHandler() { Order = this.Order };
            return handler;
        }
    }

    public class LogHandlerAttribute : HandlerAttribute
    {
        public override ICallHandler CreateHandler(IUnityContainer container)
        {
            return new LogHandler() { Order = this.Order };
        }
    }

    public class ExceptionHandlerAttribute : HandlerAttribute
    {
        public override ICallHandler CreateHandler(IUnityContainer container)
        {
            return new ExceptionHandler() { Order = this.Order };
        }
    }

    public class AfterLogHandlerAttribute : HandlerAttribute
    {
        public override ICallHandler CreateHandler(IUnityContainer container)
        {
            return new AfterLogHandler() { Order = this.Order };
        }
    }
    #endregion 特性
}
