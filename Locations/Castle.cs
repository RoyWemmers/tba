using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TextAdventureCS
{
    class Castle : Location
    {
        public Castle(string name)
            : base(name)
        {

        }
        public override void Description()
        {
            // Insert a nice description
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("You are now in the Castle!");
            Console.WriteLine("The Castle is old and run down!");
            Console.WriteLine("Jan-Jaap Theo-Bert: 'WHO DARES TO TRESPASS MY CASTLE?!'");
            Console.WriteLine("The Jan-Jaap Theo-Bert Charges at you!");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Gray;
        }
    }
}
