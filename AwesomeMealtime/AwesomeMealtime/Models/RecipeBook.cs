using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace AwesomeMealtime.Models
{
	[Serializable]
    public class RecipeBook
    //Assigned to Matthew Guernsey
    {
        public ObservableCollection<Recipe> Recipes { get; set; }

        public RecipeBook()
        {
            Recipes = new ObservableCollection<Recipe>();
        }

        public void AddRecipe(Recipe rec)
        {
            if(Recipes.Count.Equals(0)) Recipes.Add(rec);
            else
            {
                for (int i = 0; i < Recipes.Count; i++)
                {
                    if (!Recipes[i].Name.ToLower().Equals(rec.Name.ToLower())) Recipes.Add(rec);
                }
            }
             
        }

        public void RemoveRecipe(Recipe rec)
        {
            if (Recipes != null)
                if (!Recipes.Contains(rec))
                    Recipes.Remove(rec);
        }

        public static void EditRecipe(Recipe rec, string name, string desc, string dir, TimeSpan cookTime, TimeSpan prepTime, Recipe.Difficulty diff, bool warn, string image, ObservableCollection<Ingredient> ing)
        {
            rec.Name = name;
            rec.Dish_Description = desc;
            rec.Directions = dir;
            rec.CookTime = cookTime;
            rec.PrepTime = prepTime;
            rec.Recipe_Difficulty = diff;
            rec.Warning = warn;
            rec.MealPicture = image;
			rec.Ingredients = ing;
        }

		public static void EditRecipe(Recipe rec, Recipe edit)
		{
			EditRecipe(rec, edit.Name, edit.Dish_Description, edit.Directions, edit.CookTime, edit.PrepTime, edit.Recipe_Difficulty, edit.Warning, edit.MealPicture, edit.Ingredients);
		}


		public void FilterRecipesByIngredients(Ingredient ing)
        {
            ObservableCollection<Recipe> filtered = new ObservableCollection<Recipe>();
            foreach(Recipe r in Recipes)
            {
                if (r.Ingredients.Contains(ing)) filtered.Add(r);
            }
        }

        public void FilterRecipesByTime(TimeSpan time)
        {
            ObservableCollection<Recipe> filtered = new ObservableCollection<Recipe>();
            foreach (Recipe r in Recipes)
            {
                if (r.CookTime + r.PrepTime <= time) filtered.Add(r);
            }
        }

        public void SortRecipes()
        {
            Recipes.OrderBy(rec => rec.Name);
        }

        public void SortRecipesByDifficulty()
        {
            Recipes.OrderBy(rec => rec.Recipe_Difficulty);
        }
    }
}
