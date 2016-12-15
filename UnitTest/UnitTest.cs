using System;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using Faellesspisning.Model;

namespace UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        private DeltagerSingleton deltager = DeltagerSingleton.Instance;
        HusInfo mithus = new HusInfo();

     [TestMethod]
        public void TestHusNummerKanIkkeVæreBlank()
        {
            try
            {
                mithus.HusNummer = "   ";

                Assert.Fail();
            }
            catch (Exception ex)
            {

                Assert.AreEqual("Husk husnummer", ex.Message);
            }
        }


        [TestMethod]
        public void TestHusNummerKanIkkeVæreNull()
        {
            try
            {
                mithus.HusNummer = null;

                Assert.Fail();
            }
            catch (Exception ex)
            {

                Assert.AreEqual("Husk husnummer", ex.Message);
            }
        }
    }
}
