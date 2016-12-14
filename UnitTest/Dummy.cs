using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTest
{
    internal class Dummy
    {
        private string husnavn;

        public string Husnavn
        {
            get { return husnavn; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Indtast husnavn!");
                }
            }
        }
    }
}