using System;
using DesignPattern.CreationalPattern;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DesignPattern.Test.CreationalPattern
{
    [TestClass]
    public class BuilderTest
    {
        [TestMethod]
        public void Builder()
        {
            new Director().Build(new Builder(new Dress()));
        }
    }
}
