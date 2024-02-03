using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_w67277
{ 
    abstract class MicrowaveModes
    {
        public int Temperature { get; set; }
        public int Time { get; set; }


        public MicrowaveModes(int temp, int time) { 
            this.Temperature = temp;
            this.Time = time;
        } 

        public void Print(bool fan = false, bool rotation = false, bool theat = false, bool bheat = false)
        {
            Console.WriteLine($"Ustawiono temperature na: {Temperature}, a czas na {Time}");
            Console.WriteLine($"Wentylator: {fan}");
            Console.WriteLine($"Obrót: {rotation}");
            Console.WriteLine($"Ogrzewanie od góry: {theat}");
            Console.WriteLine($"Ogrzewanie od dołu: {bheat}");

        }
    }
}
