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
            Console.WriteLine("On one of the pillars of the bridge is a smalle Blood Drake…");
            Console.WriteLine("The Blood Drake growls at you…");
            Console.WriteLine("It isn’t going to let you pass the bridge…");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Gray;
        }

    }
}
