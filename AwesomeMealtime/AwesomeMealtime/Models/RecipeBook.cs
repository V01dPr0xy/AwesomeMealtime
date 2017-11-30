using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace AwesomeMealtime.Models
{
    public class RecipeBook : INotifyPropertyChanged
    //Assigned to Matthew Guernsey
    {
        private List<Recipe> recipes;

        public List<Recipe> Recipes { get {return recipes;} set {recipes = value;} }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void FieldChanged([CallerMemberName] string field = null)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(field));
            }
        }

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
            rec.Recipe_Difficulty = diff;
            rec.Warning = warn;
            rec.MealPicture = image;
        }

        public void FilterRecipesByIngredients(Ingredient ing)
        {
            List<Recipe> filtered = new List<Recipe>();
            foreach(Recipe r in recipes)
            {
                if (r.Ingredients.Contains(ing)) filtered.Add(r);
            }
            sp_Data.Children.Add(filtered);
        }

        public void SortRecipes()
        {
            Recipes.Sort();
        }
    }
}
