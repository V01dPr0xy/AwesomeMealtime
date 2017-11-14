using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AwesomeMealtime.Models
{
    public class Ingredient
    {
        public string Name { get; set; }
        public List<Quantity> Quantities { get; set; }
        public List<ExpDate> ExpirationDates { get; set; }

        public struct ExpDate
        {
            public TimeSpan Time { get; set; }
            public List<Quantity> Dates { get; set; }
        }

        public struct Quantity
        {
            public double Qty { get; set; }

        }

        enum Measurement
        {
            _,
            Cups,
            Gill,
            Pint, 
            Quart,
            Gallon,
            Peck,
            HalfBushel,
            Bushel
        }
    }
}
