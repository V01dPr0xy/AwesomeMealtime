using System.Collections.Generic;

namespace AwesomeMealtime.Models
{
    public class Pantry
        //Assigned to Micah Ketchum
    {
        public List<Ingredient> ingredients { get; set; }

        public void Add(Ingredient ingredient) {
            ingredients.Add(ingredient);
        }

        public void Remove(Ingredient ingredient) {
            ingredients.Remove(ingredient);
        }

        public void Edit() {

        }

        public Dictionary<string, Ingredient> FilterName(string filter) {
            //search for a specific ingredient by name
            Dictionary<string, Ingredient> filterIngredients = new Dictionary<string, Ingredient>();
            foreach(Ingredient ingredient in ingredients)
            {
                if (filter.Equals(ingredient.Name))
                {
                    filterIngredients.Add(ingredient.Name, ingredient);
                }
            }
            return filterIngredients;
        }

        public void Sort() {
            //sorting the ingredients by alphebetical, expiration, etc.
            ingredients.Sort((x, y) => string.Compare(x.Name, y.Name));
        }

        public void Expiration_Warning() {

        }

        public void Expiration_Dispose() {

        }
    }
}