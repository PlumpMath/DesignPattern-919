using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DesignPattern.Test.CreationalPattern
{
    [TestClass]
    public class FactoryMethodTest
    {
        [TestMethod]
        public void MethodFactory_WriteEvent()
        {
            var factory=new DesignPattern.CreationalPattern.FactoryMethod.MethodFactory();
            var result = factory.WriteFactory("event");
            Assert.IsTrue(result == "EventLog Success!");
        }
        [TestMethod]
        public void MethodFactory_WriteFile()
        {
            var factory = new DesignPattern.CreationalPattern.FactoryMethod.MethodFactory();
            var result = factory.WriteFactory("file");
            Assert.IsTrue(result == "FileLog Success!");
        }
        [TestMethod]
        public void ClassFactory_WriteFile()
        {
            var factory = new DesignPattern.CreationalPattern.FactoryMethod.ClassFactory();
            var result = factory.WriteFactory("file").WriteLog();
            Assert.IsTrue(result == "Write FileLog Success!");
        }
        [TestMethod]
        public void ClassFactory_ReadFile()
        {
            var factory = new DesignPattern.CreationalPattern.FactoryMethod.ClassFactory();
            var result = factory.WriteFactory("file").ReadLog();
            Assert.IsTrue(result == "Read FileLog Success!");
        }
    }
}
