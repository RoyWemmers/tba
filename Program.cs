using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

// Originally made by Sietse Dijks
// Releasedate: 18-01-2014
// Current version: 1.5
// Last changes by: Michiel Pot and Alex van Pelt
// Change Date: 09-01-2015

namespace TextAdventureCS
{
    class Program
    {
        // Define the directions available to the player.
        // Refactored by Michiel and Alex
        const string MOVE_NORTH = "Go North";
        const string MOVE_WEST = "Go West";
        const string MOVE_SOUTH = "Go South";
        const string MOVE_EAST = "Go East";
        
        // Cluster the directions for validation purposes.
        // Refactored by Michiel and Alex
        static List<string> validDirections = new List<string> {
            MOVE_NORTH, 
            MOVE_WEST, 
            MOVE_SOUTH, 
            MOVE_EAST        
        };

        // Refactored by Michiel and Alex
        const string ACTION_SEARCH = "Search";
        const string ACTION_FIGHT = "Fight";
        const string ACTION_RUN = "Run";
        const string ACTION_QUIT = "Exit";
        const string ACTION_SHOP = "Blow the wooden whistle";
        const string ACTION_SHOWINVENTORY = "Show Inventory";
        const string ACTION_USEHEALTHPOTION = "Use Health Potion";

        static void Main(string[] args)
        {
            // General initializations to prevent magic numbers
            int mapwidth = 20;
            int mapheight = 8;
            int xstartpos = 1;
            int ystartpos = 1;
            // Welcome the player
            Console.WriteLine("Welcome to a textbased adventure");
            Console.WriteLine("Before you can start your journey, you will have to enter your name.");

            string name = null;
            string input = null;

            // Check for the correct name
            // Refactored from do - while to improve readability by Michiel and Alex
            while(input != "Y") 
            {
                if( input == null || input == "N" )
                {
                    Console.Clear();
                    Console.WriteLine("Please enter your name and press enter:");
                    name = Console.ReadLine();
                }

                Console.WriteLine("Your name is {0}",name);
                Console.WriteLine("Is this correct? (y/n)");
                input = Console.ReadLine();
                input = input.ToUpper();
            }           

            // Make the player
            Player player = new Player(name, 100, 100);
            //Welcome the player
            Welcome(ref player);

            // Initialize the map
            Map map = new Map(mapwidth, mapheight, xstartpos, ystartpos);
            // Put the locations with their items on the map
            InitMap(ref map);
            // Start the game
            Start(ref map, ref player);
            // End the program
            Quit();
        }

        static void Welcome(ref Player player)
        {
            int sleep = 0;
            Console.Clear();
            Console.WriteLine("You wake up in a forest...");
            Thread.Sleep(sleep);
            Console.WriteLine("You look around...");
            Thread.Sleep(sleep);
            Console.WriteLine("But all you can see is a dim light on the top hill...");
            Thread.Sleep(sleep);
            Console.WriteLine("You decide to walk towards the light...");
            Thread.Sleep(sleep);
            Console.WriteLine("Press enter to continue...");
            Console.ReadLine();
            Console.Clear();
        }

        static void InitMap(ref Map map)
        {
            // Add locations with their coordinates to this list.
            RiksRuin rik = new RiksRuin("Rik's Mountian");
            map.AddLocation(rik, 1, 1);

            Forrest forrest = new Forrest("Forrest");
            map.AddLocation(forrest, 2, 1);

            MainRoad mainroad = new MainRoad("Main Road");
            map.AddLocation(mainroad, 3, 1);
            map.AddLocation(mainroad, 4, 1);
            map.AddLocation(mainroad, 6, 1);

            Bridge bridge = new Bridge("Bridge");
            map.AddLocation(bridge, 5, 1);

            CastleGate CastleGate = new CastleGate("Castle Gate");
            map.AddLocation(CastleGate, 7, 1);

            InnerCastleRoad innercastleroad = new InnerCastleRoad("Inner Castle Road");
            map.AddLocation(innercastleroad, 8, 1);

            House House = new House("House");
            map.AddLocation(House, 3, 2);
        }

        static void Start(ref Map map, ref Player player)
        {
            Rik rik = new Rik("Rik", 10000, 10000);
            BloodDrake blooddrake = new BloodDrake("Blood Drake", 50, 10);
            AngryMan angryman = new AngryMan("Angry Man", 70, 10);
            List<string> menuItems = new List<string>();
            int choice;

            rik.EncounterRik();

            // Refactored by Michiel and Alex
            do
            {
                Console.Clear();
                map.GetLocation().Description();
                choice = ShowMenu(map, ref menuItems, ref player, ref blooddrake, ref angryman);

                if ( choice != menuItems.Count() )
                {
                    if ( validDirections.Contains( menuItems[choice] ) )
                    {
                        map.Move( menuItems[choice] );
                    }

                    switch ( menuItems[choice] )
                    {
                        case ACTION_SEARCH:
                            // Add code to perform an item pickup
                        break;

                        case ACTION_FIGHT:
                            // Add code for fighting here
                        break;

                        case ACTION_RUN:
                            // Add code for running here
                        break;

                        case ACTION_SHOWINVENTORY:
                            player.ShowInventory();
                            Console.ReadLine();
                            choice = 0;
                        break;

                        case ACTION_SHOP:
                            Shop shop = new Shop();
                            shop.ShowShop(ref player);
                            choice = 0;
                            Console.ReadLine();
                        break;

                        case "Fight the Blood Drake":
                            Console.Clear();
                            blooddrake.StartEncouter(ref player);
                            Console.ReadLine();
                            map.Move("Go North");
                        break;

                        case "Go via the side of the bridge":
                            Console.Clear();
                            player.ClimbBridge(ref player);
                            Console.ReadLine();
                            map.Move("Go North");
                        break;

                        case ACTION_USEHEALTHPOTION:
                            HealthPotion hp = new HealthPotion("Health Potion", true);
                            hp.UsePotion(ref player);
                            choice = 0;
                        break;

                        case "Fight the man":
                            Console.Clear();
                            angryman.StartEncounter(ref player);
                            Console.ReadLine();
                        break;

                        case "Leave the man":
                            Console.Clear();
                            map.Move("Go West");
                            Console.ReadLine();
                        break;

                        case "Climb over the wall":
                            map.Move("Go North");
                        break;
                    }
                }
            } 
            // When the choice is equal to the total item it means exit has been chosen.
            while ( choice < menuItems.Count() - 1);
        }

        // This Method builds the menu
        static int ShowMenu(Map map, ref List<string> menu, ref Player player, ref BloodDrake drake, ref AngryMan angryman)
        {
            int choice;
            string input;

            menu.Clear();
            ShowDirections(map, ref menu);
            
            if (map.GetLocation().CheckForItems())
            {
                bool acquirableitems = false;
                Dictionary<string, Objects> list = map.GetLocation().GetItems();
                Objects[] obj = list.Values.ToArray();
                for (int i = 0; i < obj.Count(); i++)
                {
                    if (obj[i].GetAcquirable())
                        acquirableitems = true;
                }
                if(acquirableitems)
                    menu.Add( ACTION_SEARCH );
            }
            if ((map.GetYPosition() == 5 && map.GetXPosition() == 1) && drake.IsAlive(drake.GetHealth()))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("On one of the pillars of the bridge is a smalle Blood Drake…");
                Console.WriteLine("The Blood Drake growls at you…");
                Console.WriteLine("It isn’t going to let you pass the bridge…");
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Gray;

                menu.Add("Fight the Blood Drake");
                menu.Add("Go via the side of the bridge");
            }

            if ((map.GetYPosition() == 3 && map.GetXPosition() == 2) && angryman.IsAlive(angryman.GetHealth()))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("An angry man opens the door, and screams:");
                Console.WriteLine("If you don't stop bothering me I will kick your teeth in!");
                Console.WriteLine("As you look inside the house you can see a bag of gold.");
                Console.WriteLine("Do you want to fight the man, and take his gold, or will you leave the man.");
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Gray;

                menu.Add("Leave the man");
                menu.Add("Fight the man");
            }

            if ((map.GetYPosition() == 7 && map.GetXPosition() == 1) && angryman.IsAlive(angryman.GetHealth()))
            { 
                menu.Add("Climb over the wall");
            }

            menu.Add( ACTION_QUIT );
            menu.Add( ACTION_SHOP );
            menu.Add( ACTION_SHOWINVENTORY );

            if(player.HasObject("Health Potion")) {
                menu.Add( ACTION_USEHEALTHPOTION );
            }

            do
            {
                for (int i = 0; i < menu.Count(); i++)
                {                       
                    Console.WriteLine("{0} - {1}", i + 1, menu[i]);
                }
                Console.WriteLine("Please enter your choice: 1 - {0}", menu.Count());
                HealthUI(player.GetName(), player.GetHealth(), player.GetMaxHealth(), player.GetStamina(), player.GetMaxStamina(), player.GetGold());
                input = Console.ReadLine();
                Console.Clear();
                map.GetLocation().Description();

            } while (!int.TryParse(input, out choice) || (choice > menu.Count() || choice < 0));

            //return choice;
            return ( choice - 1 );
        }

        static void ShowDirections(Map map, ref List<string> items)
        {
            map.AllowedDirections();

            if (map.GetNorth() == 1)
                items.Add( MOVE_NORTH );
            if (map.GetEast() == 1)
                items.Add( MOVE_EAST );
            if (map.GetSouth() == 1)
                items.Add( MOVE_SOUTH );
            if (map.GetWest() == 1)
                items.Add( MOVE_WEST );
        }

        static void Quit()
        {
            Console.Clear();
            Console.WriteLine("Thank you for playing and have a nice day!");
            Console.WriteLine("Press a key to exit...");
            Console.ReadKey();
        }

        public static void Dead()
        {
            Console.Clear();
            Console.WriteLine("You died!");
            Console.WriteLine("Thank you for playing and have a nice day!");
            Console.WriteLine("Press a key to exit...");
            Console.ReadKey();
        }

        static public void HealthUI(string name, int health, int maxHealth, int stamina, int maxStamina, float gold)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("##############################");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(name);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("{0, -3}","Health: ");  
            for (int i = 0; i < health; i += (maxHealth / 10))
            {
                Console.Write("=");
            }
            Console.Write("{0,-3}", "");
            Console.WriteLine(" {0}/{1}", health, maxHealth);

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("{0, -3}", "Stamina: ");
            for (int i = 0; i < stamina; i += (maxStamina / 10))
            {
                Console.Write("=");
            }
            Console.Write("{0,-3}", "");
            Console.WriteLine(" {0}/{1}", stamina, maxStamina);

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Gold: {0}G", gold);
            Console.WriteLine("##############################");
            Console.ForegroundColor = ConsoleColor.Gray;

           
        }

        static void FightUI()
        {
            Console.WriteLine("***************");
            Console.WriteLine("Press (i) to open inventory...");
            Console.WriteLine("Weapon : {0}   (+{1}) Damage");
            Console.WriteLine("Armor  : {0}   (+{1}) health");
            Console.WriteLine("***************");
        }
    }
}