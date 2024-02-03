using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_w67277
{
    internal class Grilling : MicrowaveModes
    {
        public bool BottomHeating = true;
        public bool TopHeating = true;

        public Grilling(int temp, int time) : base(temp, time)
        {
        }

        public void Print()
        {
            base.Print(bheat: BottomHeating, theat: TopHeating);
            Console.WriteLine("Wybrano tryb grilowanie");

        }
    }
}
