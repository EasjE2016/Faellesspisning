﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faellesspisning.Model
{
   public class HusListe : ObservableCollection<HusInfo>
    {
        public HusListe() :base()
        {
            this.Add(new HusInfo());
            //TODO: tilføj set metoder i husinfo
        }
    }
}
