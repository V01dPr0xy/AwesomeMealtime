using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AwesomeMealtime.Models
{
    public class Ingredient
    //Assigned to Invictus Valkyrius
    {
        //Create a conversion method, and store into a variable that is to be used.
        //When setting its value, convert.
        //When getting, convert back?

        public string Name { get; set; }
        public List<Quantity> Quantities { get; set; }
        public List<ExpDate> ExpirationDates { get; set; }

        public struct ExpDate
        {
            public DateTime Time { get; set; }
            public List<Quantity> Dates { get; set; }
        }

        public struct Quantity
        {
            private double? qty;

            public double? Qty
            {
                get
                {
                    return qty;
                }
                set
                {
                    
                }
            }

            public Measurements Msmt { get; set; }

            double? Convert(Measurements m)
            {
                if(m == Measurements._)
                {
                    return null;
                }
                else if (m == Measurements.Bushel)
                {

                }
                else if (m == Measurements.Cups)
                {

                }
                else if (m == Measurements.Gallon)
                {

                }
                else if (m == Measurements.Gill)
                {

                }
                else if (m == Measurements.HalfBushel)
                {

                }
                else if (m == Measurements.Peck)
                {

                }
                else if (m == Measurements.Pint)
                {

                }
                else if (m == Measurements.Quart)
                {

                }

                throw new NotImplementedException();
            }
        }

        public enum Measurements
        {
            _,

            //Imperial
            Cups,
            Gill,
            Pint,
            Quart,
            Gallon,
            Peck,
            HalfBushel,
            Bushel,

            //Metric
            milliliter,
            centiliter,
            deciliter,
            liter,

        }


    }
}
