using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using Windows.UI.Xaml.Controls;
using Newtonsoft.Json;

namespace Faellesspisning.Model 
{
    public class DagsplanSingleton : INotifyPropertyChanged
    {
        //singleton
        private static DagsplanSingleton instance = new DagsplanSingleton();

        public static DagsplanSingleton Instance
        {
            get { return instance; }
        }


        public Dictionary<String, String[]> kokoghjælpere { get; set; }


        public string[] CrewMandag { get { return kokoghjælpere["Mandag"]; } }
        public string[] CrewTirsdag { get { return kokoghjælpere["Tirsdag"]; } }
        public string[] CrewOnsdag { get { return kokoghjælpere["Onsdag"]; } }
        public string[] CrewTorsdag { get { return kokoghjælpere["Torsdag"]; } }
        public string[] CrewFredag { get { return kokoghjælpere["Fredag"]; } }
        public string[] CrewLørdag { get { return kokoghjælpere["Lørdag"]; } }
        public string[] CrewSøndag { get { return kokoghjælpere["Søndag"]; } }

        

        public Dictionary<String, string[]> udlæg { get; set; }
        public string[] udlægMandag { get { return udlæg["Mandag"]; } }
        public string[] udlægTirsdag { get { return udlæg["Tirsdag"]; } }
        public string[] udlægOnsdag { get { return udlæg["Onsdag"]; } }
        public string[] udlægTorsdag { get { return udlæg["Torsdag"]; } }
        public string[] udlægFredag { get { return udlæg["Fredag"]; } }
        public string[] udlægLørdag { get { return udlæg["Lørdag"]; } }
        public string[] udlægSøndag { get { return udlæg["Søndag"]; } }



        #region vores PropertyChangedEventHandler 
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion

        #region Instance field Menu dage
        private string mandagMenu;
        private string tirsdagMenu;
        private string onsdagMenu;
        private string torsdagMenu;
        private string fredagMenu;
        private string lørdagMenu;
        private string søndagMenu;
        #endregion


        #region Menu

        public string MandagMenu
        {
            get { return mandagMenu; }
            set
            {
                mandagMenu = value;
                OnPropertyChanged("MandagMenu");
            }
        }

        public string TirsdagMenu
        {
            get { return tirsdagMenu; }
            set
            {
                tirsdagMenu = value;
                OnPropertyChanged("TirsdagMenu");
            }
        }
        public string OnsdagMenu
        {
            get { return onsdagMenu; }
            set
            {
                onsdagMenu = value;
                OnPropertyChanged("OnsdagMenu");
            }
        }
        public string TorsdagMenu
        {
            get { return torsdagMenu; }
            set
            {
                torsdagMenu = value;
                OnPropertyChanged("TorsdagMenu");
            }
        }
        public string FredagMenu
        {
            get { return fredagMenu; }
            set
            {
                fredagMenu = value;
                OnPropertyChanged("FredagMenu");
            }
        }
        public string LørdagMenu
        {
            get { return lørdagMenu; }
            set
            {
                lørdagMenu = value;
                OnPropertyChanged("LørdagMenu");
            }
        }
        public string SøndagMenu
        {
            get { return søndagMenu; }
            set
            {
                søndagMenu = value;
                OnPropertyChanged("SøndagMenu");
            }
        }
#endregion

        


        //ctor
        private DagsplanSingleton()
        {
            this.mandagMenu = "";
            this.tirsdagMenu ="";
            this.onsdagMenu = "";
            this.torsdagMenu = "";
            this.fredagMenu = "";
            this.lørdagMenu = "";
            this.søndagMenu = "";

            kokoghjælpere = new Dictionary<string, string[]>();

            kokoghjælpere.Add("Mandag", new string[3]);
            kokoghjælpere.Add("Tirsdag", new string[3]);
            kokoghjælpere.Add("Onsdag", new string[3]);
            kokoghjælpere.Add("Torsdag", new string[3]);
            kokoghjælpere.Add("Fredag", new string[3]);
            kokoghjælpere.Add("Lørdag", new string[3]);
            kokoghjælpere.Add("Søndag", new string[3]);



            udlæg = new Dictionary<String, String[]>();

            udlæg.Add("Mandag", new string[0]);
            udlæg.Add("Tirsdag", new string[0]);
            udlæg.Add("Onsdag", new string[0]);
            udlæg.Add("Torsdag", new string[0]);
            udlæg.Add("Fredag", new string[0]);
            udlæg.Add("Lørdag", new string[0]);
            udlæg.Add("Søndag", new string[0]);



        }

        public void IndsætJson(string JsonText)
        {
            DagsplanSingleton nyListe = JsonConvert.DeserializeObject<DagsplanSingleton>(JsonText);
            instance.MandagMenu = nyListe.MandagMenu;
            instance.TirsdagMenu = nyListe.TirsdagMenu;
            instance.OnsdagMenu = nyListe.OnsdagMenu;
            instance.TorsdagMenu = nyListe.TorsdagMenu;
            instance.FredagMenu = nyListe.FredagMenu;
            instance.LørdagMenu = nyListe.LørdagMenu;
            instance.SøndagMenu = nyListe.SøndagMenu;
            instance.kokoghjælpere = nyListe.kokoghjælpere;
           
        }

        public void IndsætUdlægJson (string JsonText)
        {
            DeltagerSingleton MinListe = JsonConvert.DeserializeObject<DeltagerSingleton>(JsonText);
            
            
        }


    }
}
