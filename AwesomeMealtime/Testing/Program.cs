using AwesomeMealtime.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static AwesomeMealtime.Models.Ingredient;

namespace Testing
{
    class Program
    {
        static void Main(string[] args)
        {
            Ingredient ing1_ = new Ingredient("Carrot")
            {
                Quantities = new List<Quantity>() { new Quantity() { Msmt = Measurements.Cups, Qty = 5.9d },
                    new Quantity() { Msmt = Measurements.Quart} },
                ExpirationDates = new List<ExpDate>() {
                    new ExpDate() {
                        Time = new DateTime(year:2020, month:7, day:19),
                        Dates = new List<Quantity>() { new Quantity() { Msmt = Measurements.Cups, Qty = 5.0d } }
                    }
                }
            };

            Ingredient ing2_ = new Ingredient("Chicken")
            {
                Quantities = new List<Quantity>() { new Quantity() { Msmt = Measurements.Cups, Qty = 7.9d },
                    new Quantity() { Msmt = Measurements.Quart} },
                ExpirationDates = new List<ExpDate>() {
                    new ExpDate() {
                        Time = new DateTime(year:2021, month:6, day:18),
                        Dates = new List<Quantity>() { new Quantity() { Msmt = Measurements.Cups, Qty = 5.3d } }
                    }
                }
            };

            Pantry pan = new Pantry();

            pan.Add(ing1_);
            pan.Add(ing2_);

            Dictionary<double, Ingredient> doubles = pan.FilterQuantity(7.9d);

            foreach(Ingredient i in doubles.Values)
            {
                Console.WriteLine(i.Name + "...This ran");
            }
        }
    }
}
