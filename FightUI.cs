﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TextAdventureCS
{
    class FightUI
    {
        public FightUI()
        {

        }

        public int ShowFightUI(ref Player player)
        {
            int damage;
            Program.HealthUI(player.GetName(), player.GetHealth(), player.GetMaxHealth(), player.GetStamina(), player.GetMaxStamina());
            damage = FightMenu(ref player);
            return damage;
        }

        public int FightMenu(ref Player player)
        {
            string input;
            int choice;
            int damage = 0;
            List<string> menu = new List<string>();
            menu.Add("Basic Attack");

            do
            {
                for (int i = 0; i < menu.Count(); i++)
                {
                    Console.WriteLine("{0} - {1}", i + 1, menu[i]);
                }
                Console.WriteLine("Please enter your choice: 1 - {0}", menu.Count());
                input = Console.ReadLine();

            } while (!int.TryParse(input, out choice) || (choice > menu.Count() || choice < 0));

            choice -= 1;

            switch(menu[choice])
            {
                case "Basic Attack":
                    damage = player.BasicAttack(ref player, 0);
                    Console.WriteLine("You have dealt {0} damage!", damage);
                    return damage;
            }
            return damage;
        }
    }
}