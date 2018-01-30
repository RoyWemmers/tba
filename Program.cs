﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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

        static void Main(string[] args)
        {
            // General initializations to prevent magic numbers
            int mapwidth = 8;
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
                    Console.WriteLine("Please enter your name and press enter:");
                    name = Console.ReadLine();
                }

                Console.WriteLine("Your name is {0}",name);
                Console.WriteLine("Is this correct? (y/n)");
                input = Console.ReadLine();
                input = input.ToUpper();
            }           

            // Make the player
            Player player = new Player(name, 100);
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
            Console.Clear();
            Console.WriteLine("Welcome to the world of Flightwood");
            Console.WriteLine("You just woke up from a very long sleep.");
            Console.WriteLine("You can't really remember anything but your name.");
            Console.WriteLine("Which by the way is {0}", player.GetName());
            
            // Added newline to improve readability.
            Console.WriteLine();

            player.ShowInventory();
            Console.WriteLine("You look around you and realise that you are in a forest.");
            Console.WriteLine("In the distance you hear the howl of an animal.");
            Console.WriteLine("You slowly come to your senses and choose to go.");
            Console.WriteLine("Press a key to continue..");
            Console.ReadKey();
        }

        static void InitMap(ref Map map)
        {
            // Add locations with their coordinates to this list.
            Forrest forrest = new Forrest("Black Forrest");
            map.AddLocation(forrest, 1, 1);
            MainRoad mainroad = new MainRoad("Main Road");
            map.AddLocation(mainroad, 2, 1);
            Bridge bridge = new Bridge("Bridge");
            map.AddLocation(bridge, 3, 1);
        }

        static void Start(ref Map map, ref Player player)
        {
            List<string> menuItems = new List<string>();
            int choice;

            // Refactored by Michiel and Alex
            do
            {
                Console.Clear();
                map.GetLocation().Description();
                choice = ShowMenu(map, ref menuItems);

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
                    }
                }
            } 
            // When the choice is equal to the total item it means exit has been chosen.
            while ( choice < menuItems.Count() - 1);
        }

        // This Method builds the menu
        static int ShowMenu(Map map, ref List<string> menu)
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
            if (map.GetLocation().HasEnemy())
            {
                menu.Add( ACTION_FIGHT );
                menu.Add( ACTION_RUN );
            }
            if(map.GetLocation().IsBridge())
            {
                menu.Add("Fight the Blood Drake");
                menu.Add("Go via the side of the bridge");
            }
            menu.Add( ACTION_QUIT );

            do
            {
                for (int i = 0; i < menu.Count(); i++)
                {                       
                    Console.WriteLine("{0} - {1}", i + 1, menu[i]);
                }
                Console.WriteLine("Please enter your choice: 1 - {0}", menu.Count());
                HealthUI();
                input = Console.ReadLine();

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

        static void HealthUI()
        {
            int health = 100;
            Console.WriteLine("###############");

            Console.Write("Health: ");
            for (int i = 0; i < health; i += 10)
            {
                Console.Write("=");
            }
            Console.Write("{0,-5}", "");
            Console.WriteLine(" {0, 5}/100", health);
            Console.WriteLine("Stamina : {0}");
            Console.WriteLine("###############");

            Console.WriteLine("***************");
            Console.WriteLine("Press (i) to open inventory...");
            Console.WriteLine("Weapon : {0}   (+{1}) Damage");
            Console.WriteLine("Armor  : {0}   (+{1}) health");
            Console.WriteLine("***************");
        }
    }
}