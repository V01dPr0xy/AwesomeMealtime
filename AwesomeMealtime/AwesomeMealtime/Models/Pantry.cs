using System.Collections.Generic;

namespace AwesomeMealtime.Models
{
    public class Pantry
        //Assigned to Micah Ketchum
    {
        public Pantry()
        {
            ingredients = new List<Ingredient>();
        }

        public List<Ingredient> ingredients { get; set; }

        public void Add(Ingredient ingredient) {
            ingredients.Add(ingredient);
            System.Console.WriteLine("Added.");
        }

        public void Remove(Ingredient ingredient) {
            ingredients.Remove(ingredient);
        }

        public void Edit() {

        }

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
                for (int x = 0; x < ingredient.Quantities.Count; x++)
                {
                    if (filter == ingredient.Quantities[x].Qty)
                    {
                        filterIngredients.Add(ingredient.Quantities[x].Qty, ingredient);
                    }
                }
            }

            return filterIngredients;
        }

        public List<Ingredient> SortAlphabetical() {
            //sort ingredients by alphabetical order
            ingredients.Sort((x, y) => string.Compare(x.Name, y.Name));
            return ingredients;
        }

        public void SortReverseAlphabetical(){
            //sort ingredients by reverse alphabetical order
            ingredients.Sort((x, y) => string.Compare(x.Name, y.Name));
            ingredients.Reverse();
        }

        public void Expiration_Warning() {

        }

        public void Expiration_Dispose() {

        }
    }
}