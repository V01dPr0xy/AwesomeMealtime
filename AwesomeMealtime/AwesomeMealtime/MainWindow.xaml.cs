using AwesomeMealtime.Models;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using AwesomeMealtime.UI_Interface_Items;
using static AwesomeMealtime.Models.Ingredient;
using System.ComponentModel;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;

namespace AwesomeMealtime
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        RecipeBook recipeBook = new RecipeBook();
        Driver myDriver = new Driver();
        GridLength Biggie = new GridLength(20.0, GridUnitType.Star);
        GridLength Smalls = new GridLength(0.0, GridUnitType.Star);
        public MainWindow()
        {
            InitializeComponent();
            Ingredient ing1_ = new Ingredient("Carrot")
            {
                Quantities = new List<Quantity>() { new Quantity() { Msmt = Measurements.Cups, Qty = 5.0d } },
                ExpirationDates = new List<ExpDate>() {
                    new ExpDate() {
                        Time = new DateTime(year:2020, month:7, day:19),
                        Dates = new List<Quantity>() { new Quantity() { Msmt = Measurements.Cups, Qty = 5.0d } }
                    }
                }                
            };
            //adding an ingredient to the data feild should be as easy as this.
            //IngredientBTN carrot = new IngredientBTN(ing1_);
            IngredientUC carrot = new IngredientUC(this, ing1_);
            sp_Data.Children.Add(carrot);
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
            int i = 0;
            foreach(Recipe rec in recipeBook.Recipes)
            {
                Label lbl = new Label();
                lbl.DataContext = recipeBook.Recipes[i];
                lbl.Content = recipeBook.Recipes[i].Name;
                sp_Data.Children.Add(lbl);
                i++;
            }
        }

        private void btn_RecipeAdd_Click(object sender, RoutedEventArgs e)
        {
			
		}

		private void btn_RecipeRemove_Click(object sender, RoutedEventArgs e)
        {

        }
        private void btn_PantryAdd_Click(object sender, RoutedEventArgs e)
        {
			IngredientWindow add = new IngredientWindow();

			if(add.ShowDialog() == true)
			{

			}
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
            FileStream fs = new FileStream("MyRecipe.bin", FileMode.Create);
            if (myDriver.Book != null)
            {
                BinaryFormatter formatter = new BinaryFormatter();
                try
                {
                    formatter.Serialize(fs, myDriver.Book);
                }
                catch (SerializationException a)
                {
                    Console.WriteLine("My Recipe Failed to Serialize." + a.Message);
                    throw;
                }
                finally
                {
                    fs.Close();
                }
            }
            if (myDriver.Current_Pantry != null)
            {
                BinaryFormatter formatter = new BinaryFormatter();
                FileStream fs2 = new FileStream("MyPantry.bin", FileMode.Create);
                try
                {
                    formatter.Serialize(fs2, myDriver.Current_Pantry);
                }
                catch (SerializationException b)
                {
                    Console.WriteLine("My Pantry Failed to Serialize " + b.Message);
                    throw;
                }
                finally
                {
                    fs2.Close();
                }
            }
            System.Windows.Application.Current.Shutdown();
        }
    }
}
