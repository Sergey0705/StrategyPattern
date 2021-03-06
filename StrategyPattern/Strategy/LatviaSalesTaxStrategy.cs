using StrategyPattern.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static StrategyPattern.Model.Order;

namespace StrategyPattern.Strategy
{
    class LatviaSalesTaxStrategy : ISalesTaxStrategy
    {
        public double GetTaxForOrder(Order order)
        {
            double totalTax = 0;

            foreach (var item in order.LineItems)
            {
                switch (item.Key.ItemType)
                {
                    case ItemType.Food:
                        totalTax += (item.Key.Price * 0.10) * item.Value;
                        break;
                    case ItemType.Literature:
                        totalTax += (item.Key.Price * 0.15) * item.Value;
                        break;
                    case ItemType.Service:
                    case ItemType.Hardware:
                        totalTax += (item.Key.Price * 0.20) * item.Value;
                        break;
                }
            }
            return totalTax;
        }
    }
}
