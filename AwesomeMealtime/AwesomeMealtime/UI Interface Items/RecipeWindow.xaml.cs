using AwesomeMealtime.Models;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace AwesomeMealtime.UI_Interface_Items
{
    /// <summary>
    /// Interaction logic for RecipeWindow.xaml
    /// </summary>
    public partial class RecipeWindow : Window
    {
        Recipe recipe = new Recipe();
        ObservableCollection<Ingredient> ingredients = new ObservableCollection<Ingredient>();
        public RecipeWindow()
        {
            InitializeComponent();
            ComboDifficulty.ItemsSource = Enum.GetValues(typeof(Recipe.Difficulty)).Cast<Recipe.Difficulty>();
            MeasureBox.ItemsSource = Enum.GetValues(typeof(Ingredient.Measurements)).Cast<Ingredient.Measurements>();
            IngredientList.ItemsSource = ingredients;
        }

		public void GetReicpeReadyForEdit(Recipe basis)
		{
			RecName.Text = basis.Name;
			RecDesc.Text = basis.Dish_Description;
			RecDir.Text = basis.Directions;
			ckxWarning.IsChecked = basis.Warning;
			PrepTime_Mint.Text = basis.PrepTime.Minutes.ToString();
			PrepTime_Hour.Text = basis.PrepTime.Hours.ToString();
			CookTime_Mint.Text = basis.CookTime.Minutes.ToString();
			CookTime_Hour.Text = basis.CookTime.Hours.ToString();

			MeasureBox.SelectedIndex = (int)basis.Recipe_Difficulty;

			Img.Source = basis.MealPicture.Source;

			foreach(Ingredient i in basis.Ingredients)
			{
				ingredients.Add(i);
			}
			IngredientList.ItemsSource = ingredients;
		}

        private void RemoveIngredient(object sender, RoutedEventArgs e)
        {
            Ingredient ing = (Ingredient)IngredientList.SelectedItem;
            ingredients.Remove(ing);
            IngredientList.ItemsSource = ingredients;
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            recipe.Recipe_Difficulty = (Recipe.Difficulty)ComboDifficulty.SelectedItem;
        }

        private void Warning_Checked(object sender, RoutedEventArgs e)
        {
            recipe.Warning = true;
        }

        private void Warning_Unchecked(object sender, RoutedEventArgs e)
        {
            recipe.Warning = false;
        }

        private void AddIngredient(object sender, RoutedEventArgs e)
        {
            Ingredient ing = new Ingredient(IngName.Text);

            Ingredient.Quantity quantity = new Ingredient.Quantity();
            quantity.Msmt = (Ingredient.Measurements)MeasureBox.SelectedItem;
            quantity.Qty = (int.TryParse(IngQty.Text, out int result)) ? result : 0;
            ing.Quan = quantity;
            ingredients.Add(ing);
            IngredientList.ItemsSource = ingredients;
        }

        private void AddRecipe(object sender, RoutedEventArgs e)
        {
            recipe.Name = RecName.Text;
            recipe.Ingredients = ingredients;
            recipe.MealPicture = Img;
            recipe.Dish_Description = RecDesc.Text;
            recipe.Directions = RecDir.Text;
            int prepHour = (int.TryParse(PrepTime_Hour.Text, out int result) ? result : 0);
            int prepMin = (int.TryParse(PrepTime_Mint.Text, out int result2) ? result2 : 0);
            recipe.PrepTime = new TimeSpan(prepHour,prepMin,0);
            int cookHour = (int.TryParse(CookTime_Hour.Text, out int cookResult) ? cookResult : 0);
            int cookMin = (int.TryParse(CookTime_Mint.Text, out int cookResult2) ? cookResult2 : 0);
            recipe.CookTime = new TimeSpan(cookHour, cookMin, 0);
			recipe.Recipe_Difficulty = (Recipe.Difficulty)ComboDifficulty.SelectedIndex;
            DialogResult = true;
            this.Close();
        }

        public Recipe GetRecipe
        {
            get { return recipe; }
        }
        private void AddImage(object sender, RoutedEventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Title = "Select a picture";
            open.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" +
              "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
              "Portable Network Graphic (*.png)|*.png";
            if (open.ShowDialog() == true)
            {
                Img.Source = new BitmapImage(new Uri(open.FileName));
            }
        }
        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
