using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_w67277
{
    internal class Boiling : MicrowaveModes
    {
        public bool MicrovaweFan = true;
        public bool Rotation = true;
        public bool TopHeating = true;
        public bool BottomeHeating = true;



        public Boiling(int temp, int time) : base(temp, time)
        {
        }


        public void Print()
        {
            base.Print(rotation: Rotation, fan: MicrovaweFan, theat: TopHeating, bheat: BottomeHeating);
            Console.WriteLine("Wybrano tryb gotowanie");

        }
    }
}
