using DesignPattern.CreationalPattern;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DesignPattern.Test.CreationalPattern
{
    [TestClass()]
    public class AbstractFactoryTest
    {
        [TestMethod()]
        public void MethodFactory_CreateEventLog()
        {
            AbstractFactory.LogFactory log=new AbstractFactory.EventFactory();
            Assert.AreEqual(log.Create().Write(),new AbstractFactory.EventLog().Write());
        }
    }
}
