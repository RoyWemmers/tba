using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace TextAdventureCS
{
    class Bridge : Location
    {
        public Bridge(string name)
            : base(name)
        {

        }
        public override void Description()
        {
            // Insert a nice description
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("You are at the Bridge");
            Console.WriteLine("The bridge appears to be old…");
            Console.WriteLine("The Bridge crosses a really fast flowing river…");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Gray;
        }


    }
}
