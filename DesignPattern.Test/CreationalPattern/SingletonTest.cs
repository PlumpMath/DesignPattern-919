using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DesignPattern.CreationalPattern;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DesignPattern.Test.CreationalPattern
{
    /// <summary>单例测试专用类</summary>
    /// <remarks>事先声明,有关线程安全的部分其实并没有进行测试到.如果想要测试可以在单例中添加计数器,然后Parallel.For执行多次,如果存在同样的计数则表示线程不安全</remarks>
    /// <remark>再次声明,有关究竟有没有创建单例的部分,也是没有进行测试.如果想要测试可以Parallel.For执行多次(仅限线程安全的,线程不安全的直接单线程取两次对比内存地址吧),如果有不同的内存地址则表示单例失败</remark>
    [TestClass()]
    public class SingletonTest
    {
        [TestMethod()]
        public void PrivateCtorSingletonTest()
        {
            Assert.IsNotNull(PrivateCtorSingleton.Instance);
            Assert.AreSame(PrivateCtorSingleton.Instance, PrivateCtorSingleton.Instance);
            Assert.IsTrue(PrivateCtorSingleton.Instance.IsInited);
        }

        [TestMethod]
        public void SynchronizedSingletonTest()
        {
            Assert.IsNotNull(SynchronizedSingleton.Instance);
            Assert.AreSame(SynchronizedSingleton.Instance, SynchronizedSingleton.Instance);
            Assert.IsTrue(SynchronizedSingleton.Instance.IsInited);
        }

        [TestMethod]
        public void StaticSingletonTest()
        {
            Assert.IsNotNull(StaticSingleton.Instance);
            Assert.AreSame(StaticSingleton.Instance, StaticSingleton.Instance);
            Assert.IsTrue(StaticSingleton.Instance.IsInited);
        }

        [TestMethod]
        public void LazySingletonTest()
        {
            Assert.IsNotNull(LazySingleton.Instance);
            Assert.AreSame(LazySingleton.Instance, LazySingleton.Instance);
            Assert.IsTrue(LazySingleton.Instance.IsInited);
        }

        [TestMethod]
        public void CommonSingletonTest()
        {
            Assert.IsNotNull(MySingleton.Instance);
            Assert.AreSame(MySingleton.Instance, MySingleton.Instance);
            Assert.IsTrue(MySingleton.Instance.IsInited);
        }

        public class MySingleton : Singleton<MySingleton>
        {
            /// <summary>是否初始化</summary>
            public bool IsInited { get; set; }

            private MySingleton()
            {
                IsInited = true;
            }
        }
    }
}
