using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;

namespace Faellesspisning.Model
{
   public class HusListe : ObservableCollection<HusInfo>
    {
        List<HusInfo> DeltagerListe = new List<HusInfo>();

        public HusListe() :base()
        {
            
            DeltagerListe.Add(new HusInfo() {});

            this.Add(new HusInfo()
            {
                HusNummer = "22a",
                ComboBoxIndex2=2,
                AntalVoksneIHusstand = 2,
                AntalTeenagerIHusstand = 1,
                AntalBarnIHusstand = 2,
                AntalBabyIHusstand = 2
            });



            this.Add(new HusInfo()
            {
                HusNummer = "69",
                ComboBoxIndex2 = 5,
                AntalVoksneIHusstand = 2,
                AntalTeenagerIHusstand = 3,
                AntalBarnIHusstand = 1,
                AntalBabyIHusstand = 4,
            });



            this.Add(new HusInfo()
            {
                HusNummer = "420",
                ComboBoxIndex2 = 3,
                AntalVoksneIHusstand = 3,
                AntalTeenagerIHusstand = 1,
                AntalBarnIHusstand = 0,
                AntalBabyIHusstand = 1,
            });
        }


        public void IndsætJson(string JsonText)
        {
            List<HusInfo> nyListe = JsonConvert.DeserializeObject<List<HusInfo>>(JsonText);
            foreach (var i in nyListe)
            {
                this.Add(i);
            }
        }

    }
}