using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ2Objects_04_Ordering
{
    class Auto
    {
        public string Modell { get; set; }
        public int Baujahr { get; set; }

        public Auto(string modell, int baujahr)
        {
            Modell = modell;
            Baujahr = baujahr;
        }

        public override string ToString()
        {
            return $"{{{Modell, -16} {nameof(Baujahr)}={Baujahr.ToString()}}}";
        }
    }
}
