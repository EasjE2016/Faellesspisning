using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faellesspisning.Model
{
   public class HusInfo
    {
        
        public HusInfo()
        {

        }





        //instance field
        public double Mandag;
        public double Tirsdag;
        public double Onsdag;
        public double Torsdag;
        public double Fredag;
        public double Lørdag;
        public double Søndag;
        public int AntalPersonerIHusstand;
        public double TotalDagsPris;
        public double TotalAntalKuverter;
        public double AntalKuverterIHusstand;

        public double GetAntalKuverterIHusstand()
        {
            return GetAntalBabyIHusstandKuvert() + GetAntalBabyIHusstandKuvert() + GetAntalTeenagerIHusstandKuvert() + GetAntalVoksneIHusstandKuvert();
        }

        //TODO: Få metode til at virke fejl pga ""
        //public double GetAntalPersonerIHusstand()
        //{
        //    return AntalPersonerIHusstand = AntalBabyIHusstand + AntalBarnIHusstand + AntalTeenagerIHusstand + AntalVoksneIHusstand;
        //}

    public double GetAntalVoksneIHusstandKuvert()
        {
            return AntalVoksneIHusstand * 1.0;
        }

        public double GetAntalTeenagerIHusstandKuvert()
        {
            return AntalTeenagerIHusstand * 0.5;
        }

        public double GetAntalBarnIHusstandKuvert()
        {
            return AntalBarnIHusstand * 0.25;
        }

        public double GetAntalBabyIHusstandKuvert()
        {
            return AntalBabyIHusstand * 0;
        }

        public double GetPrisPerKuvert()
        {
            return TotalDagsPris / TotalAntalKuverter;
        }

        public double GetPrisPerHusstand()
        {
            return GetPrisPerKuvert() * AntalKuverterIHusstand; //skal kunne bruges ved et bestemt husnummer 
        }




        public int AntalVoksneIHusstand { get; set; }
        public int AntalTeenagerIHusstand { get; set; }
        public int AntalBarnIHusstand { get; set; }
        public int AntalBabyIHusstand { get; set; }
        public string HusNummer { get; set; }
        public bool KommerMandag { get; set; }
        public bool KommerTirsdag { get; set; }
        public bool KommerOnsdag { get; set; }
        public bool KommerTorsdag { get; set; }
        public bool KommerFredag { get; set; }
        public bool KommerLørdag { get; set; }
        public bool KommerSøndag { get; set; }


        //Metode

        public double TotalUgePris()
        {
            return Mandag + Tirsdag + Onsdag + Torsdag + Fredag + Lørdag + Søndag;
        }

        public override string ToString()
        {
            string s;

            s= "Hus: " + HusNummer +
            ", " + "Voksne: " + AntalVoksneIHusstand +
            ", " + "Teenagere: " + AntalTeenagerIHusstand +
            ", " + "Børn: " + AntalBarnIHusstand +
            ", " + "Baby: " + AntalBabyIHusstand + " Dage: ";
            if (KommerMandag) s += "Mandag ";
            if (KommerTirsdag) s += "Tirsdag ";
            if (KommerOnsdag) s += "Onsdag ";
            if (KommerTorsdag) s += "Torsdag ";
            if (KommerFredag) s += "Fredag ";
            if (KommerLørdag) s += "Lørdag ";
            if (KommerSøndag) s += "Søndag ";
            return s;
            }
        // vi skal havde lavet en metode (selectedhus) som kan vælge et hus og se hvor mange der er i den valgte husstand



    }   
}
