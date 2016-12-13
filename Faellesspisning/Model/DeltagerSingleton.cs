using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using Faellesspinsning;
using Windows.Storage;
using Newtonsoft.Json;

namespace Faellesspisning.Model
{
   public class DeltagerSingleton :INotifyPropertyChanged
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
            this.mandagpris= 0.0;
            Test = 0.0;

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
        public void AddNewHus()
        {
            Model.HusInfo temphusinfo = new Model.HusInfo();
            temphusinfo.AntalBabyIHusstand = Newhus.AntalBabyIHusstand;
            temphusinfo.AntalBarnIHusstand = Newhus.AntalBarnIHusstand;
            temphusinfo.AntalTeenagerIHusstand = Newhus.AntalTeenagerIHusstand;
            temphusinfo.AntalVoksneIHusstand = Newhus.AntalVoksneIHusstand;
            temphusinfo.HusNummer = Newhus.HusNummer;
            temphusinfo.ComboBoxIndex2 = ComboBoxIndex;
            HList.Add(temphusinfo);

            //AntalKuverterMandag();
            this.Test = AntalKuverterMandag();

          
        }


        public void Slethus()
        {
            HList.Remove(SelectedHus);
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
            HentDataFraDiskAsync2();
            HentDataFraDiskAsync();
        }

        public async void HentDataFraDiskAsync2()
        {

            StorageFile file = await localfolder.GetFileAsync(filnavn2);
            string jsonText = await FileIO.ReadTextAsync(file);

            kokoghjælpere.IndsætJson(jsonText);

        }

        public async void HentDataFraDiskAsync()
        {
            this.HList.Clear();

            StorageFile file = await localfolder.GetFileAsync(filnavn);
            string jsonText = await FileIO.ReadTextAsync(file);

            HList.IndsætJson(jsonText);
            
        }

        public void Rydliste()
        {
            this.HList.Clear();
        }

        public int MandagTilmeldte()
        {
            int Antal = 0;
            foreach (var i in DeltagerListe)
            {
                Antal += i.AntalPersonerIHusstand;
            }
            return Antal;
        }

        public void AddCombobox()
        {
            ComboBox = new List<string>() { "Mandag", "Tirsdag", "Onsdag", "Torsdag", "Fredag", "Lørdag", "Søndag", "Alle hverdage" };
        }


        // udregning per dag (kuvert)
        #region Test af AntalkuverterMandag
            // det virker men den lægger altid beløbet oven i sig selv
        private double test;

        public double Test
        {
            get{ return test; }
            set
            {
                test = value;
                OnPropertyChanged("Test");    
            }
        }
        #endregion


        public double AntalKuverterMandag()
        {
            double  kuverter = 0.0;
            foreach (var i in HList)
            {
                if (ComboBoxIndex == 0)
                {
                    kuverter += (i.AntalBarnIHusstand * 0.25) + (i.AntalTeenagerIHusstand * 0.5) + (i.AntalVoksneIHusstand);
                } 
            }
            return kuverter;
        }

        public double GetKuvert { get { return AntalKuverterMandag(); }}




// virker men kun hvis vi laver den anden textboks om til en textblock
        private double mandagpris;

        public double Mandagpris
        {
            get { return mandagpris; }
            set
            {
                mandagpris = value/GetKuvert;
                OnPropertyChanged("Mandagpris");
            }
        }












    }
}
