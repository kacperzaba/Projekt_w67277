using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_w67277
{
    internal class Melting : MicrowaveModes
    {
        public bool MicrovaweFan = true;
        public bool Rotation = true;

        public Melting(int temp, int time) : base(temp, time)
        {
        }

        public void Print()
        {
            base.Print(rotation: Rotation, fan: MicrovaweFan);
            Console.WriteLine("Wybrano tryb roztapianie");

        }


    }
}
