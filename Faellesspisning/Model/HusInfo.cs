using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faellesspisning.Model
{
   public class HusInfo
    {
        public int ComboBoxIndex2 { get; set; }

        public int AntalVoksneIHusstand { get; set; }
        public int AntalTeenagerIHusstand { get; set; }
        public int AntalBarnIHusstand { get; set; }
        public int AntalBabyIHusstand { get; set; }

        private string _husNummer;

        public string HusNummer
        {
            get { return _husNummer; }
            set {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Husk husnummer");
                _husNummer = value;
            }
        }



        public override string ToString()
        {
            string s;

            s = "Hus: " + HusNummer + ", ";
            switch (ComboBoxIndex2)
            {
                case 0: s += "Mandag";  break;
                case 1: s += "Tirsdag"; break;
                case 2: s += "Onsdag"; break;
                case 3: s += "Torsdag"; break;
                case 4: s += "Fredag"; break;
                case 5: s += "Lørdag"; break;
                case 6: s += "Søndag"; break;
                case 7: s += "Alle hverdage"; break;
            }
            s +=
            ", " + "Voksne: " + AntalVoksneIHusstand +
            ", " + "Teenagere: " + AntalTeenagerIHusstand +
            ", " + "Børn: " + AntalBarnIHusstand +
            ", " + "Baby: " + AntalBabyIHusstand;
            return s;
        }

        public double Antalkuverter()
        {
        return (AntalBarnIHusstand * 0.25) + (AntalTeenagerIHusstand * 0.5) + (AntalVoksneIHusstand);
        }

        public double Ugepris(double kuvertpris)
        {
            return kuvertpris * Antalkuverter();
           
        }


    }   
}
