using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TextAdventureCS
{
    class InnerCastleRoad : Location
    {
        public InnerCastleRoad(string name)
            : base(name)
        {

        }
        public override void Description()
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("You are on the Inner ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Castle Road");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine();
        }

    }
}
