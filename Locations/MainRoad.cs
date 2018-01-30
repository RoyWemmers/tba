using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TextAdventureCS
{
    class MainRoad : Location
    {
        public MainRoad(string name)
            : base(name)
        {
             
        }
        public override void Description()
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("You are on the Main Road");
            Console.WriteLine();
        }

    }
}
