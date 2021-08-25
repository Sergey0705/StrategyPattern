using StrategyPattern.Model;
using StrategyPattern.Strategy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static StrategyPattern.Model.Order;

namespace StrategyPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            var order = new Order();

            order.DestinationCountry = "Latvia";

            if (order.DestinationCountry.ToLowerInvariant() == "belarus")
            {
                order.SalesTaxStrategy = new BelarusSalesTaxStrategy();
            }
            else if (order.DestinationCountry.ToLowerInvariant() == "latvia")
            {
                order.SalesTaxStrategy = new LatviaSalesTaxStrategy();
            }

            order.LineItems.Add(new Item("Fruits", 100, ItemType.Food), 1);
            order.LineItems.Add(new Item("Computers", 200, ItemType.Hardware), 2);

            Console.WriteLine($"Сумма налога с заказа: {order.GetTax()}");

            Console.ReadKey();
        }
    }
}
