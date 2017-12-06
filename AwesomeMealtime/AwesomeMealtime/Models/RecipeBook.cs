﻿using System;
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
    public class RecipeBook : INotifyPropertyChanged
    //Assigned to Matthew Guernsey
    {
        private ObservableCollection<Recipe> recipes;

        public ObservableCollection<Recipe> Recipes { get {return recipes;} set {recipes = value;} }

        public event PropertyChangedEventHandler PropertyChanged;

        public RecipeBook()
        {
            Recipes = new ObservableCollection<Recipe>();
        }

        protected void FieldChanged([CallerMemberName] string field = null)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(field));
            }
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

        public void EditRecipe(Recipe rec, string name, string desc, string warnMess, string dir, TimeSpan cookTime, TimeSpan prepTime, Recipe.Difficulty diff, bool warn, Image image)
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
            ObservableCollection<Recipe> filtered = new ObservableCollection<Recipe>();
            foreach(Recipe r in recipes)
            {
                if (r.Ingredients.Contains(ing)) filtered.Add(r);
            }
        }

        public void FilterRecipesByWarning(string warning)
        {
            ObservableCollection<Recipe> filtered = new ObservableCollection<Recipe>();
            foreach (Recipe r in recipes)
            {
                if (r.Warning_Message.Equals(warning)) filtered.Add(r);
            }
        }

        public void FilterRecipesByTime(TimeSpan time)
        {
            ObservableCollection<Recipe> filtered = new ObservableCollection<Recipe>();
            foreach (Recipe r in recipes)
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
