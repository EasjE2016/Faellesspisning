﻿using System;
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


        #region Menu opdatering fra view til view

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



    }
}
