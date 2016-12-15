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
        //vi tester at hus nummer ikke kan være blank ved at lave en string med mellemrum
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
        // vi sætter husnummer til at være tom altså null og forventer der skal være fejl
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

        [TestMethod]
        //vi tester at vi får fejl hvis vores berening er over 3 da vi forventer 2.75
        public void TestAfBereningsMetode()
        {
            try
            {
                
        
            double AntalBarnIHusstand = 2;
            double AntalTeenagerIHusstand = 1;
            double AntalVoksneIHusstand = 2;

           double test = (AntalBarnIHusstand * 0.25) + (AntalTeenagerIHusstand * 0.5) + (AntalVoksneIHusstand);
                if (test==3)
                {

                }
                else
        Assert.Fail();
            
            }
            catch (Exception x)
            {
                
                Assert.AreEqual("Fejl i beregning det skal skrive 2.75",x);
            }
        }
    }
}
