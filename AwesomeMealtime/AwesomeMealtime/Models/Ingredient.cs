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

        public Ingredient(string name)
        {
            Name = name;
            Quantities = new List<Quantity>();
            ExpirationDates = new List<ExpDate>();
        }

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
            private double qty;
            public Measurements Msmt { get; set; }
            public double Qty
            {
                get
                {
                    return qty;
                }
                set
                {
                    qty = ConvertToOunces(Msmt, value);
                }
            }

            public void AddTo(double d)
            {
                qty += ConvertToOunces(Msmt, d);
            }

            double ConvertToOunces(Measurements m, double param)
            {
                double result = new double();

                switch (m)
                {
                    case Measurements.Bushel://
                        result = param * 1191.57;
                        break;

                    case Measurements.Centiliter://
                        result = param * 0.33814;
                        break;

                    case Measurements.Cups://
                        result = param * 8;
                        break;

                    case Measurements.Deciliter://
                        result = param * 3.3814;
                        break;

                    case Measurements.Gallon://
                        result = param * 128;
                        break;

                    case Measurements.Gill://1=4
                        result = param * 4;
                        break;

                    case Measurements.HalfBushel://1=595.787
                        result = param * 595.787;
                        break;

                    case Measurements.Liter://1=33.814
                        result = param * 33.814;
                        break;

                    case Measurements.Milliliter://1=0.033814
                        result = param * 0.033814;
                        break;

                    case Measurements.Peck://1=297.894
                        result = param * 297.894;
                        break;

                    case Measurements.Pint://1=16
                        result = param * 16;
                        break;

                    case Measurements.Quart://1=32
                        result = param * 32;
                        break;

                    case Measurements.Tablespoon://1=0.5
                        result = param * .5;
                        break;

                    case Measurements.Teaspoon://1=1/6
                        result = param / 6;
                        break;

                    default:
                        break;
                }

                return result;
            }


            public double ConvertFromOunces()
            {
                double result = new double();

                switch (Msmt)
                {
                    case Measurements.Bushel://
                        result = qty / 1191.57;
                        break;

                    case Measurements.Centiliter://
                        result = qty / 0.33814;
                        break;

                    case Measurements.Cups://
                        result = qty / 8;
                        break;

                    case Measurements.Deciliter://
                        result = qty / 3.3814;
                        break;

                    case Measurements.Gallon://
                        result = qty / 128;
                        break;

                    case Measurements.Gill://1=4
                        result = qty / 4;
                        break;

                    case Measurements.HalfBushel://1=595.787
                        result = qty / 595.787;
                        break;

                    case Measurements.Liter://1=33.814
                        result = qty / 33.814;
                        break;

                    case Measurements.Milliliter://1=0.033814
                        result = qty / 0.033814;
                        break;

                    case Measurements.Peck://1=297.894
                        result = qty / 297.894;
                        break;

                    case Measurements.Pint://1=16
                        result = qty / 16;
                        break;

                    case Measurements.Quart://1=32
                        result = qty / 32;
                        break;

                    case Measurements.Tablespoon://1=0.5
                        result = qty / .5;
                        break;

                    case Measurements.Teaspoon://1=1/6
                        result = qty * 6;
                        break;

                    default:
                        break;
                }

                return result;
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
            Tablespoon,
            Teaspoon,

            //Metric
            Milliliter,
            Centiliter,
            Deciliter,
            Liter
        }


    }
}
