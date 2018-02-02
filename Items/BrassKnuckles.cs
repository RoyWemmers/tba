using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TextAdventureCS
{
    class BrassKnuckles : Objects
    {
        public BrassKnuckles(string name, bool acquirable)
            :base (name, acquirable)
        {
        }

        override protected void Description()
        {
            Console.WriteLine("ol' Reliable");
        }

    }
}
