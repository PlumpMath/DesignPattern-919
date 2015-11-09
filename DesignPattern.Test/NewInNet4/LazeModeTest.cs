using DesignPattern.NewInNet4;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DesignPattern.Test.NewInNet4
{
    [TestClass()]
    public class LazeModeTest
    {
        [TestMethod()]
        public void GetPersonTest()
        {
            Assert.IsTrue(LazeMode.Instance.GetPerson()=="False岳珅True");
        }

        [TestMethod()]
        public void PersonLoaderTest()
        {
            Assert.IsNotNull(LazeMode.Instance.PersonLoader());
            Assert.IsTrue(LazeMode.Instance.PersonLoader().Name=="岳珅");
        }
    }
}
