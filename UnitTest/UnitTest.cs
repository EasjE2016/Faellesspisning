using System;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using Faellesspisning.Model;

namespace UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        private DeltagerSingleton deltager = DeltagerSingleton.Instance;
        

     [TestMethod]
        public void TestMethod1()
        {
            try
            {
                deltager.AddNewHus();
                Assert.Fail();
            }
            catch (Exception ex)
            {

                Assert.AreEqual("Husk husnummer", ex.Message);
            }
            
            
        }

        [TestMethod]
        public void TestMethod2()
        {
            try
            {
                deltager.Newhus.HusNummer = "23";
                deltager.AddNewHus();
                Assert.AreEqual("23", deltager.Newhus.HusNummer);

            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }


        }
    }
}
