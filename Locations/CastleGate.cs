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
            Console.WriteLine();
            Console.Write("You have arrived at the ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("CastleGate");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("The gate itself isn't that big but the walls around it are huge.");
            Console.WriteLine("The gates look small enough to climb over, since");
            Console.WriteLine("the walls are too high this seems to be your only option");
            Console.WriteLine();
        }

    }
}
