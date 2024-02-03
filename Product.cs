using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_w67277
{
    internal class Product
    {
        public string FoodName;
        public int Temperature;
        public int Time;
        public int MicrowaveMode;

        public Product(string name, int temp, int time, int mode) {
            this.FoodName = name;
            this.Temperature = temp;
            this.Time = time;
            this.MicrowaveMode = mode;
        }


    }
}
