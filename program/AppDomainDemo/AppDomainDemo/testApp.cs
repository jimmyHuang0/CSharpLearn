using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AppDomainDemo
{
    class Program
    {
           
        static void Main(string[] arg)
        {
            Console.WriteLine(Thread.GetDomainID()); 

            while (Console.ReadLine()!= "x")
            {
                Plugin plugin = new Plugin();
                plugin.creatAppDomain();

            }



            Console.ReadLine();

        }

       
    }


    public class Plugin
    {
        AppDomain _domain = null;

        public void creatAppDomain()
        {
            //步骤一：设置domain的环境
            AppDomainSetup setup = new AppDomainSetup();
            setup.ApplicationName = "AppLoader";
            setup.ApplicationBase = AppDomain.CurrentDomain.BaseDirectory;
            setup.PrivateBinPath = AppDomain.CurrentDomain.BaseDirectory;// "plugins";
            setup.CachePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "CachePath"); ;
            setup.ShadowCopyFiles = "true";
            setup.ShadowCopyDirectories = string.Concat(setup.ApplicationBase, ";", setup.PrivateBinPath);

            //步骤二：生成一个新的domain
            this._domain = AppDomain.CreateDomain(string.Concat("AppLoaderDomain_", Guid.NewGuid().ToString()), null, setup);

            //步骤三：在新的domain里面创建实例

            ///方法一：CreateInstanceAndUnwrap
            ///这是合并的便捷方法 CreateInstance和 ObjectHandleUnwrap。此方法调用的默认构造函数typeName。
            ///
            ///CreateInstanceAndUnwrap 会与新的dll绑定，因为返回一个引用是用到新的dll，而这个引用是在父Domain里的。
            ///使用，就要加上AppDomain.CurrentDomain.SetShadowCopyFiles()这一句，就可以覆盖dll
            ///
            //AppDomain.CurrentDomain.SetShadowCopyFiles();
            //var ret = _domain.CreateInstanceAndUnwrap("Plugin1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Plugin1.pluginClass");

            ///方法二：CreateInstance
            ///
            _domain.CreateInstance("pluginWinD", "pluginWinD.pluginClass");
            
            AppDomain.Unload(_domain);
        }


    }
}
