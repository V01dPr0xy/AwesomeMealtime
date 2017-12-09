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
using System.Windows.Data;

namespace AwesomeMealtime
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Driver myDriver = new Driver();

		public MainWindow()
        {
            InitializeComponent();
			myDriver.Init();

			Notifications();

            Closing += OnWindowClosing; //don't remove this
        }


		//Recipe Events
		private void btn_RecipeAdd_Click(object sender, RoutedEventArgs e)
        {
            RecipeWindow recwin = new RecipeWindow();
            recwin.ShowDialog();
		}
		private void btn_RecipeRemove_Click(object sender, RoutedEventArgs e)
        {

        }
		private void ShowRecipe_Click(object sender, RoutedEventArgs e)
		{


		}


		//Pantry Events
		private void btn_PantryAddNew_Click(object sender, RoutedEventArgs e)
        {
			IngredientWindow add = new IngredientWindow();
			Ingredient confirm;

			add.tbxName.Text = "Carrot";
			add.tbxAmount.Text = "1";
			add.tbxDate.Text = "12/12/20";

			if(add.ShowDialog() == true) {}

			if (add.proto != null)
			{
				confirm = add.proto;
				myDriver.Current_Pantry.Add(confirm);

				StackPanel stack = new StackPanel();
				stack.Orientation = Orientation.Horizontal;

				Label l = new Label();
				l.Content = add.proto.Name;
				stack.Children.Add(l);

				l = new Label();
				l.Content = add.proto.Quantities.ToString();
				stack.Children.Add(l);

				//l = new Label();
				//l.Content = add.proto.Quantities.ToString();
				//stack.Children.Add(l);

				spl_Pantry.Children.Add(stack);
				
			}
		}
		private void btn_PantrySearch_Click(object sender, RoutedEventArgs e)
		{
			//TO DO: add search functionality
			//Will need a check to see if we are in pantry or in Recipe book
			//string input = tb_Search.Text;
			//MessageBox.Show(input);
			//TO DO: Something with input
		}


		//App stuff //
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

		//On closing
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

		//Notification stuff
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


		//Main Toggle
		private void btnBook_Click(object sender, RoutedEventArgs e)
        {
            btnBook.IsEnabled = false;
            btnPantry.IsEnabled = true;

            GPantry.Visibility = Visibility.Collapsed;
            GRecipe.Visibility = Visibility.Visible;
        }
        private void btnPantry_Click(object sender, RoutedEventArgs e)
        {
            btnPantry.IsEnabled = false;
            btnBook.IsEnabled = true;


            GRecipe.Visibility = Visibility.Collapsed;
            GPantry.Visibility = Visibility.Visible;
        }
		
	}
}
