using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace PluginBase
{
    public class TypeLoader 
    {
        protected RemoteTypeLoader remoteTypeLoader;
        public AppDomain RemoteDomain { get; private set; }

        public RemoteTypeLoader CreateRemoteTypeLoader(Type remoteLoaderType, string targetDomainName = null)
        {
            //先初始化一个APPDomain的设置集合
            AppDomainSetup setup = new AppDomainSetup();
            //获取或设置应用程序的名称。
            setup.ApplicationName = "AppLoader";
            //获取或设置包含该应用程序的目录的名称。
            setup.ApplicationBase = AppDomain.CurrentDomain.BaseDirectory;
            //获取或设置应用程序基目录下的目录列表，这些目录被探测以寻找其中的私有程序集。
            setup.PrivateBinPath = "plugins";
            //获取或设置特定于应用程序且从中对文件进行卷影复制的区域的名称。
            setup.CachePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "CachePath");;
            /*
                setup.ShadowCopyFiles = "true";这句很重要
                ,其作用就是启用影像复制程序集
                ,什么是影像复制程序集,复制程序集是保证"热插拔"
                实现的主要工作.AppDomain加载程序集的时候,如果没有ShadowCopyFiles
                ,那就直接加载程序集,结果就是程序集被锁定,相反,如果启用了ShadowCopyFiles
                ,则CLR会将准备加载的程序集拷贝一份至CachePath
                ,再加载CachePath的这一份程序集,这样原程序集也就不会被锁定了.
             */
            setup.ShadowCopyFiles = "true";
            //获取或设置目录的名称，这些目录包含要进行卷影复制的程序集。
            setup.ShadowCopyDirectories = string.Concat(setup.ApplicationBase, ";", setup.PrivateBinPath);
            ///更改的属性AppDomainSetup实例不会影响任何现有AppDomain。 
            ///它可能会影响仅创建一个新AppDomain，
            ///当CreateDomain方法调用与AppDomainSetup作为参数的实例。

            //使用指定的名称、证据和应用程序域设置信息创建新的应用程序域。
            this.RemoteDomain = AppDomain.CreateDomain(targetDomainName ?? string.Concat("AppLoaderDomain_", Guid.NewGuid().ToString()), null, setup);

            Type typeName = remoteLoaderType;

            //创建在指定程序集文件中定义的指定类型的新实例。
            /// 参数:
            //   assemblyName:
            //     程序集的显示名称。请参见 System.Reflection.Assembly.FullName。
            //
            //   typeName:
            //     System.Type.FullName 属性返回的所请求类型的完全限定名称，包含命名空间而不是程序集。
            //
            // 返回结果:
            //     typeName 所指定对象的实例。
            RemoteTypeLoader ret = (RemoteTypeLoader)RemoteDomain.CreateInstanceAndUnwrap(typeName.Assembly.FullName, typeName.FullName);

            return ret;
        }
        protected TypeLoader()
        { }

        public TypeLoader(string targetAssembly)
        {
            this.remoteTypeLoader = CreateRemoteTypeLoader(typeof(RemoteTypeLoader));
            this.remoteTypeLoader.InitTypeLoader(targetAssembly);
        }

        public void Unload()
        {
            AppDomain.Unload(this.RemoteDomain);
        }
    }
}
