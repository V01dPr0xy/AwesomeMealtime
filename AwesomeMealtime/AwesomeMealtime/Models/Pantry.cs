using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace AwesomeMealtime.Models
{
    public class Pantry
        //Assigned to Micah Ketchum
    {
        public Pantry()
        {
			ingredients = new ObservableCollection<Ingredient>();
			expWarningMsg = new ObservableCollection<string>();
			expRemovalMsg = new ObservableCollection<string>();
		}

		public ObservableCollection<Ingredient> ingredients { get; set; }
		public ObservableCollection<string> expWarningMsg { get; set; }
        public ObservableCollection<string> expRemovalMsg { get; set; }

        public Dictionary<string, Ingredient> FilterName(string filter) {
            //search for a specific ingredient by name
            Dictionary<string, Ingredient> filterIngredients = new Dictionary<string, Ingredient>();
            filter = filter.ToLower();

            foreach(Ingredient ingredient in ingredients)
            {
                string name = ingredient.Name.ToLower();
                if (name.Contains(filter))
                {
                    filterIngredients.Add(ingredient.Name, ingredient);
                }
            }
            return filterIngredients;
        }
        public Dictionary<double, Ingredient> FilterQuantity(double filter)
        {
            Dictionary<double, Ingredient> filterIngredients = new Dictionary<double, Ingredient>();
            foreach(Ingredient ingredient in ingredients)
            {
				if (ingredient.TotalQuantity >= filter) {
					filterIngredients.Add(ingredient.TotalQuantity, ingredient);
				}
            }

            return filterIngredients;
        }

		public void SortAlphabetical()
		{
			List<Ingredient> ing = new List<Ingredient>();

			int index = 0;

			foreach (Ingredient i in ingredients)
			{
				ing[index] = i;
			}

			ing.Sort();
			index = 0;

			foreach (Ingredient i in ing)
			{
				ingredients[index] = i;
			}
		}
		public void SortReverseAlphabetical()
		{
			List<Ingredient> ing = new List<Ingredient>();

			int index = 0;

			foreach(Ingredient i in ingredients)
			{
				ing[index] = i;
			}

			ing.Reverse();
			index = 0;

			foreach (Ingredient i in ing)
			{
				ingredients[index] = i;
			}
		}

		public void Expiration_Warning() {
            foreach(Ingredient ingredient in ingredients)
            {   
                foreach(Ingredient.ExpDate date in ingredient.ExpirationDates )
                {
                    DateTime expDate = date.Time;
                    if ((expDate - DateTime.Now).TotalDays < 7)
                    {
                        expWarningMsg.Add(ingredient.Name +": " + ingredient.TotalQuantity + " Is close to Exp on " + date + "!");
                    }

                }

            }

        }
        public void Expiration_Dispose() {
            foreach(Ingredient ingredient in ingredients)
            {
                foreach(Ingredient.ExpDate date in ingredient.ExpirationDates)
                {
                    DateTime expDate = date.Time;
                     if (expDate > DateTime.Now)
                     {
                        expRemovalMsg.Add(ingredient.Name + ": " + ingredient.TotalQuantity + " Has Exp on " + date + "!");
                        ingredients.Remove(ingredient);
                     }

                }

            }
        }
    }
}