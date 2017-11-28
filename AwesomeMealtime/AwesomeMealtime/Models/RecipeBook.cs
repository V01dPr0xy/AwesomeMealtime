using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace AwesomeMealtime.Models
{
    public class RecipeBook
        //Assigned to Matthew Guernsey
    {
        public List<Recipe> Recipes { get; set; }

        public void AddRecipe(Recipe rec)
        {
            if (rec != null)
            {
                for (int i = 0; i < Recipes.Count; i++)
                {
                    if (Recipes[i].Name.Equals(rec.Name))
                        Recipes.Add(rec);
                }
            }
        }

        public void RemoveRecipe(Recipe rec)
        {
            if (Recipes != null)
                if (!Recipes.Contains(rec))
                    Recipes.Remove(rec);
        }

        public void EditRecipe(Recipe rec, string name, string desc, string warnMess, List<string> dir, TimeSpan cookTime, TimeSpan prepTime, Recipe.Difficulty diff, bool warn, Image image)
        {
            rec.Name = name;
            rec.Dish_Description = desc;
            rec.Warning_Message = warnMess;
            rec.Directions = dir;
            rec.CookTime = cookTime;
            rec.PrepTime = prepTime;
            rec.RecipeDifficulty = diff;
            rec.Warning = warn;
            rec.MyProperty = image;
        }

        public void FilterRecipes()
        {
            
        }

        public void SortRecipes()
        {
            Recipes.Sort();
        }
    }
}
