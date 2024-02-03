using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_w67277
{
    internal class Stewing : MicrowaveModes
    {
        public bool BottomHeating = true;
        public bool Rotation = true;

        public Stewing(int temp, int time) : base(temp, time)
        {
        }

        public void Print()
        {
            base.Print(rotation: Rotation, theat: BottomHeating);
            Console.WriteLine("Wybrano tryb duszenie");

        }
    }
}
