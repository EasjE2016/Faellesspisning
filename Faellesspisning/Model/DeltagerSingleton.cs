﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using Faellesspinsning;
using Windows.Storage;
using Newtonsoft.Json;
using Windows.UI.Popups;

namespace Faellesspisning.Model
{
    public class DeltagerSingleton : INotifyPropertyChanged
    {
        private static DeltagerSingleton instance = new DeltagerSingleton();

        public static DeltagerSingleton Instance
        {
            get { return instance; }
        }


        private DeltagerSingleton()
        {
            HList = new Model.HusListe();
            Newhus = new Model.HusInfo();
            AddHusCommand = new RelayCommand(AddNewHus);
            SletHusCommand = new RelayCommand(Slethus);
            SletAlleCommand = new RelayCommand(Rydliste);
            HentJsonCommand = new RelayCommand(HentData);
            GemJsonCommand = new RelayCommand(GemData);
            AddCombobox();
            kokoghjælpere = DagsplanSingleton.Instance;
            localfolder = ApplicationData.Current.LocalFolder;
            this.mandagpris = 0.0;
            this.tirsdagpris = 0.0;
            this.onsdagpris = 0.0;
            this.torsdagpris = 0.0;
            this.fredagpris = 0.0;
            this.lørdagpris = 0.0;
            this.søndagpris = 0.0;
            this.huspris = 0.0;
            HusPris();
            HentData();

        }

        private readonly string filnavn = "HusListe.json";
        private readonly string filnavn2 = "Planlægning.json";

        public Model.HusListe HList { get; set; }
        public Model.HusInfo Newhus { get; set; }
        public Model.DagsplanSingleton kokoghjælpere { get; set; }
        public RelayCommand AddHusCommand { get; set; }
        public RelayCommand SletHusCommand { get; set; }
        public RelayCommand RedigerCommand { get; set; }
        public RelayCommand BeregnPrisCommand { get; set; }
        public RelayCommand PlanlægCommand { get; set; }
        public RelayCommand SletAlleCommand { get; set; }
        public RelayCommand GemJsonCommand { get; set; }
        public RelayCommand HentJsonCommand { get; set; }
        public List<string> ComboBox { get; set; }
        public int ComboBoxIndex { get; set; }
        public RelayCommand Tilmeldknap { get; set; }

        StorageFolder localfolder = null;



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

        #region Select hus prop & instance field + comment
        //WriteLine(nameof(person.Address.ZipCode)); // prints "ZipCode”
        // nameof kan altså gå ind på vores Plist fx og finde navn.
        //bliver brugt her med SletElev metode

        private Model.HusInfo SelectedHus;

        public Model.HusInfo selectedHus
        {
            get { return SelectedHus; }
            set
            {
                this.SelectedHus = value;
                this.OnPropertyChanged(nameof(selectedHus));
            }
        }
        #endregion



        List<Model.HusInfo> DeltagerListe = new List<Model.HusInfo>();


        //metode til at lave nyt hus
        public async void AddNewHus()
        {

            try
            {
                Model.HusInfo temphusinfo = new Model.HusInfo();
                temphusinfo.AntalBabyIHusstand = Newhus.AntalBabyIHusstand;
                temphusinfo.AntalBarnIHusstand = Newhus.AntalBarnIHusstand;
                temphusinfo.AntalTeenagerIHusstand = Newhus.AntalTeenagerIHusstand;
                temphusinfo.AntalVoksneIHusstand = Newhus.AntalVoksneIHusstand;
                temphusinfo.HusNummer = Newhus.HusNummer;
                temphusinfo.ComboBoxIndex2 = ComboBoxIndex;
                HList.Add(temphusinfo);
                GemData();
            }
            catch (Exception x)
            {
                var dialog = new MessageDialog(x.Message);
                await dialog.ShowAsync();
            }


        }


        public void Slethus()
        {
            HList.Remove(SelectedHus);
            GemData();
        }

        public void GemData()
        {
            GemDataTilDiskAsync(HList, filnavn);
            GemDataTilDiskAsync(kokoghjælpere, filnavn2);
        }


        public async void GemDataTilDiskAsync(Object objToSave, String FileName)
        {
            string jsonText = JsonConvert.SerializeObject(objToSave);
            StorageFile file = await localfolder.CreateFileAsync(FileName, CreationCollisionOption.ReplaceExisting);
            await FileIO.WriteTextAsync(file, jsonText);

        }

        public void HentData()
        {
            HentDataFraDiskAsync();
            HentDataFraDiskAsync2();
        }

        public async void HentDataFraDiskAsync()
        {
            this.HList.Clear();

            StorageFile file = await localfolder.GetFileAsync(filnavn);
            string jsonText = await FileIO.ReadTextAsync(file);

            HList.IndsætJson(jsonText);

        }

        public async void HentDataFraDiskAsync2()
        {

            StorageFile file = await localfolder.GetFileAsync(filnavn2);
            string jsonText = await FileIO.ReadTextAsync(file);

            kokoghjælpere.IndsætJson(jsonText);

        }



        public void Rydliste()
        {
            this.HList.Clear();
            GemData();
        }


        public void AddCombobox()
        {
            ComboBox = new List<string>() { "Mandag", "Tirsdag", "Onsdag", "Torsdag", "Fredag", "Lørdag", "Søndag", "Alle hverdage" };
        }


        #region Mandag Pris beregning

        // udregning per dag (kuvert)
        public double AntalKuverterMandag()
        {
            return Antalkuverter(0);
        }

        public double GetKuvertMandag { get { return AntalKuverterMandag(); } }

        private double mandagpris;

        public double Mandagpris
        {
            get { return mandagpris; }
            set
            {
                mandagpris = value;
                OnPropertyChanged(nameof(Mandagpris));
            }
        }
        #endregion

        #region Tirsdag Pris beregning

        // udregning per dag (kuvert)
        public double AntalKuverterTirsdag()
        {
            return Antalkuverter(1);
        }

        // virker men kun hvis vi laver den anden textboks om til en textblock
        private double tirsdagpris;

        public double Tirsdagpris
        {
            get { return tirsdagpris; }
            set
            {
                tirsdagpris = value;
                OnPropertyChanged(nameof(Tirsdagpris));
            }
        }
        public double GetKuvertTirsdag { get { return AntalKuverterTirsdag(); } }
        #endregion

        #region Onsdag Pris beregning

        // udregning per dag (kuvert)
        public double AntalKuverterOnsdag()
        {
            return Antalkuverter(2);
        }

        public double GetKuvertOnsdag { get { return AntalKuverterOnsdag(); } }


        // virker men kun hvis vi laver den anden textboks om til en textblock
        private double onsdagpris;

        public double Onsdagpris
        {
            get { return onsdagpris; }
            set
            {
                onsdagpris = value;
                OnPropertyChanged(nameof(Onsdagpris));
            }
        }
        #endregion

        #region Torsdag Pris beregning

        // udregning per dag (kuvert)
        public double AntalKuverterTorsdag()
        {
            return Antalkuverter(3);
        }

        public double GetKuvertTorsdag { get { return AntalKuverterTorsdag(); } }


        // virker men kun hvis vi laver den anden textboks om til en textblock
        private double torsdagpris;

        public double Torsdagpris
        {
            get { return torsdagpris; }
            set
            {
                torsdagpris = value;
                OnPropertyChanged(nameof(Torsdagpris));
            }
        }
        #endregion

        #region Fredag Pris beregning

        // udregning per dag (kuvert)
        public double AntalKuverterFredag()
        {
            return Antalkuverter(4);
        }

        public double GetKuvertFredag { get { return AntalKuverterFredag(); } }

        // virker men kun hvis vi laver den anden textboks om til en textblock
        private double fredagpris;

        public double Fredagpris
        {
            get { return fredagpris; }
            set
            {
                fredagpris = value;
                OnPropertyChanged(nameof(Fredagpris));
            }
        }
        #endregion

        #region Lørdag Pris beregning

        // udregning per dag (kuvert)
        public double AntalKuverterLørdag()
        {
            return Antalkuverter(5);
        }

        public double GetKuvertLørdag { get { return AntalKuverterLørdag(); } }


        // virker men kun hvis vi laver den anden textboks om til en textblock
        private double lørdagpris;

        public double Lørdagpris
        {
            get { return lørdagpris; }
            set
            {
                lørdagpris = value;
                OnPropertyChanged(nameof(Lørdagpris));
            }
        }
        #endregion

        #region Søndag Pris beregning

        // udregning per dag (kuvert)
        public double AntalKuverterSøndag()
        {
            return Antalkuverter(6);
        }

        public double GetKuvertSøndag { get { return AntalKuverterSøndag(); } }


        // virker men kun hvis vi laver den anden textboks om til en textblock
        private double søndagpris;

        public double Søndagpris
        {
            get { return søndagpris; }
            set
            {
                søndagpris = value;
                OnPropertyChanged(nameof(Søndagpris));
            }
        }
        #endregion

        // beregner antal kurverter
        private double Antalkuverter(int dag)
        {
            double kuverter = 0.0;
            foreach (var i in HList)
            {
                if (i.ComboBoxIndex2 == dag)
                {
                    kuverter += (i.Antalkuverter());
                }
            }
            return kuverter;
        }


        //ide til foreach

        double ugeKuvert()
        {
            return Antalkuverter(0) + Antalkuverter(1) + Antalkuverter(2) + Antalkuverter(3) + Antalkuverter(4) + Antalkuverter(5) + Antalkuverter(6);
        }

        double ugePris()
        {
            return this.mandagpris + this.tirsdagpris + this.onsdagpris + this.torsdagpris + this.fredagpris + this.lørdagpris + this.søndagpris;
        }

        double ugeKuvertPris()
        {
            return ugePris() / ugeKuvert();
        }

        private string henterhusnummer;

        public string Henterhusnummer
        {
            get { return henterhusnummer; }
            set
            {
                henterhusnummer = value;
                OnPropertyChanged(nameof(Vishuspris));
            }
        }

        private double huspris;

        public double HusPris()
        {
            double huskuvertpådag = 0;

            foreach (var i in HList)
            {
                if (henterhusnummer == i.HusNummer)
                {
                    huskuvertpådag += ((i.AntalBarnIHusstand * 0.25) + (i.AntalTeenagerIHusstand * 0.5) + i.AntalVoksneIHusstand);
                }
            }

            huspris = huskuvertpådag * ugeKuvertPris();
            return huspris;
        }

        public double Vishuspris
        {
            get { return HusPris(); }
        }
    }
}
