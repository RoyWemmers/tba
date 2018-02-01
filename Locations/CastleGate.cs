using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TextAdventureCS
{ 
    class CastleGate : Location
    {

        public CastleGate(String name)
            : base (name)
        {

        }

        public override void Description()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("You have arrived at the Castle gate");
            Console.WriteLine("The gate itself isn't that big but the walls around it are huge.");
        }

    }
}
