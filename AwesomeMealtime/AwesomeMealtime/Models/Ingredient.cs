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

        public bool CompareQuantites(double filter, Quantity qty)
        {
            if (qty.ConvertToOunces(qty.Msmt, filter) == qty.Qty)
                return true;
            else
                return false;
        }

        public struct ExpDate
        {
            public DateTime Time { get; set; }
            public Quantity Sizes { get; set; }
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

            public double ConvertToOunces(Measurements m, double param)
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


            public double ConvertFromOunces(double q)
            {
                double result = new double();

                switch (Msmt)
                {
                    case Measurements.Bushel://
                        result = q / 1191.57;
                        break;

                    case Measurements.Centiliter://
                        result = q / 0.33814;
                        break;

                    case Measurements.Cups://
                        result = q / 8;
                        break;

                    case Measurements.Deciliter://
                        result = q / 3.3814;
                        break;

                    case Measurements.Gallon://
                        result = q / 128;
                        break;

                    case Measurements.Gill://1=4
                        result = q / 4;
                        break;

                    case Measurements.HalfBushel://1=595.787
                        result = q / 595.787;
                        break;

                    case Measurements.Liter://1=33.814
                        result = q / 33.814;
                        break;

                    case Measurements.Milliliter://1=0.033814
                        result = q / 0.033814;
                        break;

                    case Measurements.Peck://1=297.894
                        result = q / 297.894;
                        break;

                    case Measurements.Pint://1=16
                        result = q / 16;
                        break;

                    case Measurements.Quart://1=32
                        result = q / 32;
                        break;

                    case Measurements.Tablespoon://1=0.5
                        result = q / .5;
                        break;

                    case Measurements.Teaspoon://1=1/6
                        result = q * 6;
                        break;

                    default:
                        break;
                }

                return result;
            }
        }

		public static Measurements GetMeasurementFromString(string input)
		{
			Measurements unit;

			switch(input)
			{
				case "_":
					unit = Measurements._;
					break;
				case "Cups":
					unit = Measurements.Cups;
					break;
				case "Gill":
					unit = Measurements.Gill;
					break;
				case "Pint":
					unit = Measurements.Pint;
					break;
				case "Quart":
					unit = Measurements.Quart;
					break;
				case "Gallon":
					unit = Measurements.Gallon;
					break;
				case "Peck":
					unit = Measurements.Peck;
					break;
				case "HalfBushel":
					unit = Measurements.HalfBushel;
					break;
				case "Bushel":
					unit = Measurements.Bushel;
					break;
				case "Tablespoon":
					unit = Measurements.Tablespoon;
					break;
				case "Teaspoon":
					unit = Measurements.Teaspoon;
					break;
				case "Milliliter":
					unit = Measurements.Milliliter;
					break;
				case "Centiliter":
					unit = Measurements.Centiliter;
					break;
				case "Deciliter":
					unit = Measurements.Deciliter;
					break;
				case "Liter":
					unit = Measurements.Liter;
					break;
				default:
					unit = Measurements._;
					break;

			}

			return unit;
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
