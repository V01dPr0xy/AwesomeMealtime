using AwesomeMealtime.Models;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using AwesomeMealtime.UI_Interface_Items;
using static AwesomeMealtime.Models.Ingredient;
using System.ComponentModel;

namespace AwesomeMealtime
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        GridLength Biggie = new GridLength(20.0, GridUnitType.Star);
        GridLength Smalls = new GridLength(0.0, GridUnitType.Star);
        public MainWindow()
        {
            InitializeComponent();
            Ingredient ing1_ = new Ingredient
            {
                Name = "Carrot",
                Quantities = new List<Quantity>() { new Quantity() { Qty = 5.0d, Msmt = Measurements._ } },
                ExpirationDates = new List<ExpDate>() {
                    new ExpDate() {
                        Time = new DateTime(year:2020, month:7, day:19),
                        Dates = new List<Quantity>() { new Quantity() { Qty = 5.0d, Msmt = Measurements._ } }
                    }
                }                
            };
            //adding an ingredient to the data feild should be as easy as this.
            IngredientBTN carrot = new IngredientBTN(ing1_);
            sp_Data.Children.Add(carrot.button);
            //
            for (int i = 0; i < 100; i++)
            {//just a test for now...

                Button hello = new Button();
                hello.Content = "Hello!";

                sp_Data.Children.Add(hello);
            }

            Closing += OnWindowClosing; //don't remove this
        }

        private void ShowPantry_Click(object sender, RoutedEventArgs e)
        {
            Def_CRecipe.Width = Smalls;//You're killing me
            Def_CPantry.Width = Biggie;

            LoadPantry();
        }

        private void ShowRecipe_Click(object sender, RoutedEventArgs e)
        {
            Def_CRecipe.Width = Biggie;
            Def_CPantry.Width = Smalls;

            LoadRecipe();
        }

        private void btn_Search_Click(object sender, RoutedEventArgs e)
        {
            //TO DO: add search functionality
            //Will need a check to see if we are in pantry or in Recipe book
            string input = tb_Search.Text;
            MessageBox.Show(input);
            //TO DO: Something with input
        }
        /// <summary>
        /// This will load the pantry data from the current pantry
        /// to sp_Data, not to be confused with loading a new pantry
        /// from a file
        /// </summary>
        private void LoadPantry()
        {
            sp_Data.Children.Clear();
            //TO DO: Load Pantry from Pantry data
        }

        /// <summary>
        /// This will load the Recipe book data from the current Recipe book
        /// to sp_Data, not to be confused with loading a new Recipe book
        /// from a file
        /// </summary>
        private void LoadRecipe()
        {
            sp_Data.Children.Clear();
            //TO DO: Load Recipe book from Recipe book data
        }

        private void btn_RecipeAdd_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btn_RecipeRemove_Click(object sender, RoutedEventArgs e)
        {

        }
        private void btn_PantryAdd_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btn_PantryRemove_Click(object sender, RoutedEventArgs e)
        {

        }

        private void AppExit_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }

        private void AppSave_Click(object sender, RoutedEventArgs e)
        {//TO DO: Run Recipe and Pantry Save operations
            MessageBox.Show(sender.ToString());
        }

        private void AppOpen_Click(object sender, RoutedEventArgs e)
        {//TO DO: Run Recipe and Pantry Load operations
            MessageBox.Show(sender.ToString());
        }
        private void OnWindowClosing(object sender, CancelEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }
    }
}
