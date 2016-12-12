using Faellesspinsning;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using System.IO;
using Newtonsoft.Json;


namespace Faellesspisning.Viewmodel
{
    public class DeltagereViewmodel
    {

        private Model.DeltagerSingleton mindeltager = Model.DeltagerSingleton.Instance;

        public Model.DeltagerSingleton Mindeltager { get { return mindeltager; } }
    }
}
