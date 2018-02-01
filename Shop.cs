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

        public void ShowShop()
        {
            List<object> shop = new List<object>();

            HealthPotion hp = new HealthPotion("Health Potion", true);
            object[] healthpotion = new object[2];
            healthpotion[0] = hp;
            healthpotion[1] = "Health Potion";
            healthpotion[2] = 1;



            shop.Add(healthpotion);

        }

        public void BuyShop(ref Player player, ref object[] healthpotion, ref List<object> shop)
        {
            Console.WriteLine("Shop: ");
            Console.WriteLine("{0}) {1} {2}",1 ,healthpotion[1], healthpotion[2]);

        }

        public void BuyHealthPotion(ref Player player, ref HealthPotion hp)
        {
            player.SetGold(-1);
            player.PickupItem(hp);
        }
    }
}
