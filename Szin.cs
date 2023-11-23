using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wpf_2023_11_20_Szinkevero_Listbox
{
    internal class Szin
    {
        int red;
        int green;
        int blue;

        public Szin(int red, int green, int blue)
        {
            this.red = red;
            this.green = green;
            this.blue = blue;
        }

        public int Red { get => red; set => red = value; }
        public int Green { get => green; set => green = value; }
        public int Blue { get => blue; set => blue = value; }
    }
}
