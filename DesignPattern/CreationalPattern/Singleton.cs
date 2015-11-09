using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DesignPattern.CreationalPattern
{

    #region 1.最基本的单例模式

    /// <summary>私有化构造函数实现线程不安全的单例模式</summary>
    public sealed class PrivateCtorSingleton
    {
        private static PrivateCtorSingleton _instance;

        private PrivateCtorSingleton()
        {
            IsInited = true; //just 4 test
        }

        public static PrivateCtorSingleton Instance
        {
            get { return _instance ?? (_instance = new PrivateCtorSingleton()); }
        }

        /// <summary>是否初始化</summary>
        public bool IsInited { get; set; }
    }

    #endregion

    #region 2.私有化构造函数实现线程安全的单例模式

    /// <summary>私有化构造函数实现线程安全的单例模式</summary>
    public sealed class SynchronizedSingleton
    {
        private static SynchronizedSingleton _instance;
        private static readonly object ObjLock = new object(); //用于lock的必须是引用类型,以确保该对象指向的内存地址相同,值类型则会进行装箱操作,你懂得.

        private SynchronizedSingleton()
        {
            IsInited = true;
        }

        public static SynchronizedSingleton Instance
        {
            get
            {
                if (_instance != null) return _instance;//如果没有这句,每次都要加锁然后判断,会因此增加开销,损失性能,用屁股想一下都知道哒
                lock (ObjLock)//Monitor.Enter(ObjLock),排它锁
                {
                    return _instance ?? (_instance = new SynchronizedSingleton());
                }//Monitor.Exit(ObjLock)
            }
        }

        /// <summary>是否初始化</summary>
        public bool IsInited { get; set; }
    }

    #endregion

    #region 3.基于静态构造函数的单例模式✦

    /// <summary>基于静态构造函数的单例模式</summary>
    /// <remarks>static你懂得...绝对的线程安全,绝对的单例</remarks>
    /// <remarks>缺点就是对实例化的控制权小了点</remarks>
    /// <remarks>至于为啥有俩无参构造函数~~~23333去看msdn吧</remarks>
    public class StaticSingleton
    {
        private static readonly StaticSingleton instance = new StaticSingleton();
        static StaticSingleton()
        {

        }

        private StaticSingleton()
        {
            IsInited = true;
        }

        public static StaticSingleton Instance
        {
            get { return instance; }
        }
        /// <summary>是否初始化</summary>
        public bool IsInited { get; set; }
    }

    #endregion

    #region 4.基于.Net Framework4.0的新特性Lazy实现的线程安全的单例模式

    /// <summary>基于Lazy的单例模式</summary>
    public class LazySingleton
    {
        private static readonly Lazy<LazySingleton> Lazy =
            new Lazy<LazySingleton>(() => new LazySingleton(), true);

        public static LazySingleton Instance
        {
            get { return Lazy.Value; }
        }

        private LazySingleton()
        {
            IsInited = true;
        }

        /// <summary>是否初始化</summary>
        public bool IsInited { get; set; }
    }

    #endregion

    #region 5.通过嵌套的方式实现单例模式

    /// <summary>通过嵌套的方式实现单例模式</summary>
    public class NestedSingleton
    {
        public sealed class Singleton
        {
            private Singleton()
            {
            }

            public static Singleton Instance
            {
                get { return Nested.Instance; }
            }

            private class Nested
            {
                static Nested()
                {
                }

                internal static readonly Singleton Instance = new Singleton();
            }
        }
    }

    #endregion

    //暂时只想到这些,其实应该不止的,甚至可以通过反射来实现通用单例

    #region 6.通用单例模式(继承于本类的必须有私有的构造函数)

    /// <summary>通用单例模式(继承于本类的必须有私有的构造函数)</summary>
    /// <typeparam name="T"></typeparam>
    public abstract class Singleton<T> //声明抽象类,不直接使用,必须继承才行
    {
        //使用Lazy<T>作为_instance，T就是我们要实现单例的继承类
        private static readonly Lazy<T> _instance = new Lazy<T>(() =>
        {
            var ctors = typeof (T).GetConstructors(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);
            if (ctors.Count() != 1)
                throw new InvalidOperationException(string.Format("Type {0} must have exactly one constructor.",
                    typeof (T)));
            var ctor = ctors.SingleOrDefault(c => !c.GetParameters().Any() && c.IsPrivate); //验证T的构造函数必须是私有的
            if (ctor == null)
                throw new InvalidOperationException(
                    String.Format("The constructor for {0} must be private and take no parameters.", typeof (T)));
            return (T) ctor.Invoke(null); //仅Invoke一次,单例嘛~~~多次的话还算什么单例
        });

        public static T Instance
        {
            get { return _instance.Value; }
        }
    }

    #endregion

}
