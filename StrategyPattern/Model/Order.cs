using StrategyPattern.Strategy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyPattern.Model
{
    public class Order
    {
        public Dictionary<Item, int> LineItems { get; } = new Dictionary<Item, int>();

        public ISalesTaxStrategy SalesTaxStrategy { get; set; }

        public string DestinationCountry { get; set; }

        public double GetTax()
        {
            if (SalesTaxStrategy == null)
            {
                return 0;
            }
            return SalesTaxStrategy.GetTaxForOrder(this);
        }

        public class Item
        {
            public string Name { get; }
            public double Price { get; }
            public ItemType ItemType { get; set; }
            public Item(string name, double price, ItemType type)
            {
                Name = name;
                Price = price;
                ItemType = type;
            }
        }

        public enum ItemType
        {
            Service,
            Food,
            Hardware,
            Literature
        }
    }
}
