using AwesomeMealtime.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static AwesomeMealtime.Models.Ingredient;

namespace Pantry_Test
{
    class Driver
    {
        Pantry pantry;

        public void Run()
        {
            pantry = new Pantry();

            pantry.Add(new Ingredient("Carrot")
            {
                Name = "Carrot",
                Quantities = new List<Quantity>() { new Quantity() { Qty = 5.0d, Msmt = Measurements._ } },
                ExpirationDates = new List<ExpDate>() {
                    new ExpDate() {
                        Time = new DateTime(year:2020, month:7, day:19),
                        Dates = new List<Quantity>() { new Quantity() { Qty = 5.0d, Msmt = Measurements._ } }
                    }
                }
            });

            pantry.Add(new Ingredient("Chicken")
            {
                Name = "Chicken",
                Quantities = new List<Quantity>() { new Quantity() { Qty = 7.0d, Msmt = Measurements._ } },
                ExpirationDates = new List<ExpDate>() {
                    new ExpDate() {
                        Time = new DateTime(year:2021, month:6, day:18),
                        Dates = new List<Quantity>() { new Quantity() { Qty = 6.0d, Msmt = Measurements._ } }
                    }
                }
            });

            pantry.Add(new Ingredient("Strawberry")
            {
                Name = "Strawberry",
                Quantities = new List<Quantity>() { new Quantity() { Qty = 100.0d, Msmt = Measurements.Gallon } },
                ExpirationDates = new List<ExpDate>() {
                    new ExpDate() {
                        Time = new DateTime(year:2019, month:5, day:17),
                        Dates = new List<Quantity>() { new Quantity() { Qty = 100.0d, Msmt = Measurements.Gallon } }
                    }
                }
            });

            //Dictionary<string, Ingredient> res = pantry.FilterName("Chicken");

            //foreach(Ingredient i in res.Values)
            //{
            //    Console.WriteLine(i.ToString());
            //}

            pantry.Sort();

            foreach(Ingredient i in pantry.ingredients)
            {
                Console.WriteLine(i.Name);
            }

        }
    }
}
