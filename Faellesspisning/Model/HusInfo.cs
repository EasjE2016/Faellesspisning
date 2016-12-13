using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faellesspisning.Model
{
   public class HusInfo
    {


        //instance field
        public double Mandag;
        public double Tirsdag;
        public double Onsdag;
        public double Torsdag;
        public double Fredag;
        public double Lørdag;
        public double Søndag;
        //public int AntalPersonerIHusstand;
        //public double TotalDagsPris;
        //public double TotalAntalKuverter;
        //public double AntalKuverterIHusstand;

        //public double GetAntalKuverterIHusstand()
        //{
        //    return GetAntalBabyIHusstandKuvert() + GetAntalBabyIHusstandKuvert() + GetAntalTeenagerIHusstandKuvert() + GetAntalVoksneIHusstandKuvert();
        //}



        //public double GetAntalVoksneIHusstandKuvert()
        //{
        //    return AntalVoksneIHusstand * 1.0;
        //}

        //public double GetAntalTeenagerIHusstandKuvert()
        //{
        //    return AntalTeenagerIHusstand * 0.5;
        //}

        //public double GetAntalBarnIHusstandKuvert()
        //{
        //    return AntalBarnIHusstand * 0.25;
        //}

        //public double GetAntalBabyIHusstandKuvert()
        //{
        //    return AntalBabyIHusstand * 0;
        //}

        //public double GetPrisPerKuvert()
        //{
        //    return TotalDagsPris / TotalAntalKuverter;
        //}

        //public double GetPrisPerHusstand()
        //{
        //    return GetPrisPerKuvert() * AntalKuverterIHusstand; //skal kunne bruges ved et bestemt husnummer 
        //}



        public int ComboBoxIndex2 { get; set; }

        public int AntalVoksneIHusstand { get; set; }
        public int AntalTeenagerIHusstand { get; set; }
        public int AntalBarnIHusstand { get; set; }
        public int AntalBabyIHusstand { get; set; }
        public string HusNummer { get; set; }
        //public bool KommerMandag { get; set; }
        //public bool KommerTirsdag { get; set; }
        //public bool KommerOnsdag { get; set; }
        //public bool KommerTorsdag { get; set; }
        //public bool KommerFredag { get; set; }
        //public bool KommerLørdag { get; set; }
        //public bool KommerSøndag { get; set; }

         //public double TotalUgePris()
        //{
        //    return Mandag + Tirsdag + Onsdag + Torsdag + Fredag + Lørdag + Søndag;
        //}

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
