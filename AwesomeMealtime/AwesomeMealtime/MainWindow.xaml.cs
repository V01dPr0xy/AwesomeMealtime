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
        Driver myDriver = new Driver();
        GridLength Biggie = new GridLength(20.0, GridUnitType.Star);
        GridLength Smalls = new GridLength(0.0, GridUnitType.Star);

		public MainWindow()
        {
            InitializeComponent();
			myDriver.Init();

			//Notifications();

            Closing += OnWindowClosing; //don't remove this
        }

		private void Notifications()
		{
			Models.Pantry p = myDriver.Current_Pantry;
            if (p == null)
                return;
			Label l;

			foreach (String msg in p.expWarningMsg)
			{
				l = new Label();
				l.Content = msg;
				l.MouseLeftButtonDown += NotificationWarning_MouseLeftButtonDown;
				spl_Warning.Children.Add(l);
			}

			foreach (String msg in p.expRemovalMsg)
			{
				l = new Label();
				l.Content = msg;
				l.MouseLeftButtonDown += NotificationDesposal_MouseLeftButtonDown;
				spl_Expired.Children.Add(l);
			}
		}
        private void ShowRecipe_Click(object sender, RoutedEventArgs e)
        {

        }
        private void btn_Search_Click(object sender, RoutedEventArgs e)
        {
        }
        private void btn_RecipeAdd_Click(object sender, RoutedEventArgs e)
        {
            RecipeWindow recwin = new RecipeWindow();
            recwin.ShowDialog();
            //recwin.Close();
		}
		private void btn_RecipeRemove_Click(object sender, RoutedEventArgs e)
        {

        }
        private void btn_PantryAddNew_Click(object sender, RoutedEventArgs e)
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
		private void NotificationWarning_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
		{
			string target = ((Label)sender).Content.ToString();

			if(target != null)
			{
				myDriver.Current_Pantry.expWarningMsg.Remove(target);
			}
		}
		private void NotificationDesposal_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
		{
			string target = ((Label)sender).Content.ToString();

			if (target != null)
			{
				myDriver.Current_Pantry.expRemovalMsg.Remove(target);
			}
		}

		private void btnAdd_Click(object sender, RoutedEventArgs e)
		{

		}
	}
}
