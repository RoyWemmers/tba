using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TextAdventureCS
{
    class RiksRuin: Location
    {

        public RiksRuin(string name)
            : base (name)
        {

        }

        public override void Description()
        {
            Console.WriteLine("You are now on Rik's Mountain");
        }

    }
}
