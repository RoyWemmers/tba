using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TextAdventureCS
{
    class FightUI
    {
        const string ACTION_BASICATTACK = "Basic Attack";
        const string ACTION_PUNCH = "Punch";
        const string ACTION_KICK = "Kick";

        public FightUI()
        {

        }

        public int ShowFightUI(ref Player player, ref Map map)
        {
            int damage;
            Program.HealthUI(player.GetName(), player.GetHealth(), player.GetMaxHealth(), player.GetStamina(), player.GetMaxStamina(), player.GetGold());
            damage = FightMenu(ref player, ref map);
            return damage;
        }

        public int FightMenu(ref Player player, ref Map map)
        {
            string input;
            int choice;
            int damage = 0;
            List<string> menu = new List<string>();
            menu.Add(ACTION_BASICATTACK);
            menu.Add(ACTION_PUNCH);
            menu.Add(ACTION_KICK);

            do
            {
                if (!player.IsAlive())
                {
                    Program.Dead();
                    return 0;
                }

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
                case ACTION_BASICATTACK:
                    damage = player.BasicAttack(ref player, 0);
                    Console.WriteLine("You have dealt {0} damage!", damage);
                    return damage;
                case ACTION_PUNCH:
                    damage = player.Punch(ref player, 0);
                    Console.WriteLine("You have dealt {0} damage!", damage);
                    return damage;
                case ACTION_KICK:
                    damage = player.Kick(ref player, 0);
                    Console.WriteLine("You have dealt {0} damage!", damage);
                    return damage;
            }
            return damage;
        }


    }
}
