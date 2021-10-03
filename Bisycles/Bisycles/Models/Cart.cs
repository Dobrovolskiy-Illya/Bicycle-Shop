using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bisycles.Models
{
    public class Cart
    {
        private List<CartLine> lineCollection = new List<CartLine>();
        public void AddItem (Bicycle bicycle, int quantity)
        {
            CartLine line = lineCollection
                                        .FirstOrDefault(x => x.Bicycle.BicycleId == bicycle.BicycleId);
            if (line == null)
            {
                lineCollection.Add(new CartLine
                {
                    Bicycle = bicycle,
                    Quantity = quantity
                });
            }
            else
            {
                line.Quantity += quantity;
            }
        }

        public decimal ComputeTotalValue()
        {
            return lineCollection.Sum(x => x.Bicycle.BicyclePrice * x.Quantity);
        }

        public void RemoveLine (Bicycle bicycle)
        {
            lineCollection.RemoveAll(x => x.Bicycle.BicycleId == bicycle.BicycleId);
        }

        public void RemoveOneItem (Bicycle bicycle)
        {
            foreach (var i in lineCollection)
            {
                if (i.Bicycle.BicycleId == bicycle.BicycleId)
                {
                    if (i.Quantity >= 2)
                    {
                        i.Quantity--;
                    }
                    else
                    {
                        RemoveLine(bicycle);
                        break;
                    }
                }
            }
        }

        public void AddOneItem(Bicycle bicycle)
        {
            foreach (var i in lineCollection)
            {
                if (i.Bicycle.BicycleId == bicycle.BicycleId)
                {
                    i.Quantity++;
                    break;
                }
            }
        }

        public void Clear()
        {
            lineCollection.Clear();
        }

        public IEnumerable<CartLine> Lines => lineCollection;
    }

    public class CartLine
    {
        public Bicycle Bicycle { get; set; }
        public int Quantity { get; set; }
    }
}
