using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TextAdventureCS
{
    class Shop
    {
        public Shop()
        {

        }

        public void ShowShop(ref Player player)
        {
            Console.Clear();
            List<object> shop = new List<object>();

            HealthPotion hp = new HealthPotion("Health Potion", true);
            object[] healthpotion = new object[3];
            healthpotion[0] = hp;
            healthpotion[1] = "Health Potion";
            healthpotion[2] = 1;

            shop.Add(healthpotion);

            BuyShop(ref player, ref healthpotion, ref shop, ref hp);


        }

        public void BuyShop(ref Player player, ref object[] healthpotion, ref List<object> shop, ref HealthPotion hp)
        {
            string input;
            Console.WriteLine("Shop: ");
            Console.WriteLine("{0}) {1} {2}",1 ,healthpotion[1], healthpotion[2]);
            Console.WriteLine("2) Go back to Main Road");

            do
            {
                input = Console.ReadLine();
            } while (input != "1" && input != "2");

            if (input == "1")
            {
                BuyHealthPotion(ref player, ref hp);
            }

        }

        public void BuyHealthPotion(ref Player player, ref HealthPotion hp)
        {
            
            player.SetGold(-1);
            player.PickupItem(hp);
            player.ShowInventory();
        }
    }
}
