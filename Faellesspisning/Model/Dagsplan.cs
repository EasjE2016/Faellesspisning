﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace Faellesspisning.Model 
{
    public class Dagsplan : INotifyPropertyChanged
    {
        //singleton
        private static Dagsplan instance = new Dagsplan();

        public static Dagsplan Instance
        {
            get { return instance; }
        }

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


        private string mandagMenu;
        private string tirsdagMenu;
        private string onsdagMenu;
        private string torsdagMenu;
        private string fredagMenu;
        private string lørdagMenu;
        private string søndagMenu;

        private string kokMandag;
        private string kokTirsdag;
        private string kokOnsdag;
        private string kokTorsdag;
        private string kokFredag;
        private string kokLørdag;
        private string kokSøndag;

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

        #region Kokke
        public string KokMandag
        {
            get { return kokMandag; }
            set
            {
                kokMandag = value;
                OnPropertyChanged("KokMandag");
            }
        }

        public string KokTirsdag
        {
            get { return kokTirsdag; }
            set
            {
                kokTirsdag = value;
                OnPropertyChanged("KokTirsdag");
            }
        }

        public string KokOnsdag
        {
            get { return kokOnsdag; }
            set
            {
                kokOnsdag = value;
                OnPropertyChanged("KokOnsdag");
            }
        }

        public string KokTorsdag
        {
            get { return kokTorsdag; }
            set
            {
                kokTorsdag = value;
                OnPropertyChanged("KokTorsdag");
            }
        }

        public string KokFredag
        {
            get { return kokFredag; }
            set
            {
                kokFredag = value;
                OnPropertyChanged("KokFredag");
            }
        }

        public string KokLørdag
        {
            get { return kokLørdag; }
            set
            {
                kokLørdag = value;
                OnPropertyChanged("KokLørdag");
            }
        }

        public string KokSøndag
        {
            get { return kokSøndag; }
            set
            {
                kokSøndag = value;
                OnPropertyChanged("KokSøndag");
            }
        }

        #endregion

        //ctor
        private Dagsplan()
        {
            this.mandagMenu = "";
            this.tirsdagMenu ="";
            this.onsdagMenu = "";
            this.torsdagMenu = "";
            this.fredagMenu = "";
            this.lørdagMenu = "";
            this.søndagMenu = "";
            this.kokMandag = "";
            this.kokTirsdag = "";
            this.kokOnsdag = "";
            this.kokTorsdag = "";
            this.kokFredag = "";
            this.kokLørdag = "";
            this.kokSøndag = "";

        }



    }
}
