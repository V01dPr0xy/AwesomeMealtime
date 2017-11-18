using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AwesomeMealtime.Models
{
    public class RecipeBook
    {
        public List<Recipe> Recipes { get; set; }

        public void AddRecipe(Recipe rec)
        {
            if (rec != null)
                Recipes.Add(rec);
        }

        public void RemoveRecipe(Recipe rec)
        {
            if(Recipes != null)
            {
                for (int i = 0; i < Recipes.Count; i++)
                {
                    if(Recipes[i].Name.Equals(rec.Name))
                    {

                    }
                }
            }

            
        }
    }
}
