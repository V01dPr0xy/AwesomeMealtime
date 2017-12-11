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
        RecipeBook recipeBook = new RecipeBook();

		public MainWindow()
        {
            InitializeComponent();
			myDriver.Init();

			foreach(Ingredient i in myDriver.Current_Pantry.ingredients)
			{
				StackPanel sp = new StackPanel();
				DisplayIngredient(ref sp, i);
			}

			Notifications();

            Closing += OnWindowClosing; //don't remove this
        }


		//Recipe Events
		private void btn_RecipeAdd_Click(object sender, RoutedEventArgs e)
        {
            //RecipeWindow recwin = new RecipeWindow();
            //if (recwin.ShowDialog() == true)
            //{
            //    Recipe r = recwin.GetRecipe;
            //    MessageBox.Show(r.Name);
            //    recipeBook.AddRecipe(r);
            //    RecipeList.ItemsSource = recipeBook.Recipes;
            //}
               
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

			if (add.ShowDialog() == true) {}

			if (add.proto != null)
			{
				confirm = add.proto;

				StackPanel stack = new StackPanel();
				stack.Orientation = Orientation.Horizontal;

				DisplayIngredient(ref stack, confirm);

				spl_Pantry.Children.Add(stack);
				
			}
		}
		private void DisplayIngredient(ref StackPanel parent, Ingredient values)
		{
			Label l = new Label();
			l.Content = values.Name;
			parent.Children.Add(l);

			l = new Label();
			l.Content = $"{values.TotalQuantity} oz";
			parent.Children.Add(l);

			StackPanel pack = new StackPanel();
			pack.Orientation = Orientation.Horizontal;
			pack.Width = 300;

			foreach (ExpDate ex in values.ExpirationDates)
			{
				StackPanel dates = new StackPanel();

				l = new Label();
				l.Content = $"{ex.Size.Qty} {ex.Size.Msmt}";
				dates.Children.Add(l);

				l = new Label();
				l.Content = ex.Time.Date;
				dates.Children.Add(l);

				pack.Children.Add(dates);
			}

			ScrollViewer view = new ScrollViewer();
			view.HorizontalScrollBarVisibility = ScrollBarVisibility.Auto;
			view.Content = pack;

			parent.Children.Add(view);

			Button btn = new Button();
			btn.Content = "adjust";
			btn.Click += BtnAddMore_Click;
			btn.Width = 50;
			btn.Height = 26;
			parent.Children.Add(btn);
		}
		private void GetPartsFromButton(Button sender, out string name, ref List<string> dates, ref List<string> sizes)
		{
			StackPanel sp = (StackPanel)sender.Parent;
			var v = sp.Children[2];
			StackPanel d = (StackPanel)((ScrollViewer)v).Content;

			name = ((Label)sp.Children[0]).Content.ToString();

			foreach (var x in d.Children)
			{
				Label l = (Label)((StackPanel)x).Children[0];
				sizes.Add(l.Content.ToString());

				l = (Label)((StackPanel)x).Children[1];
				dates.Add(l.Content.ToString());
			}

		}
		private void BtnAddMore_Click(object sender, RoutedEventArgs e)
		{
			Button b = (Button)sender;
			StackPanel parent = (StackPanel)b.Parent;

			string name;
			List<string> dates = new List<string>();
			List<string> size = new List<string>();

			GetPartsFromButton(b, out name, ref dates, ref size);

			Ingredient test = Ingredient.GetIngredientFromParts(name, dates, size);

			IngredientWindow add = new IngredientWindow();

			add.FillValuesForEdit(test);

			if (add.ShowDialog() == true) {}

			if (add.proto != null)
			{
				test = add.proto;

				parent.Children.Clear();
				DisplayIngredient(ref parent, test);

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
			myDriver.Current_Pantry.ingredients.Clear();

			foreach(var v in spl_Pantry.Children)
			{
				StackPanel s = (StackPanel)v;

				List<string> dates = new List<string>();
				List<string> amount = new List<string>();
				string name;

				GetPartsFromButton((Button)s.Children[3], out name, ref dates, ref amount);
				Ingredient i = Ingredient.GetIngredientFromParts(name, dates, amount);

				myDriver.Current_Pantry.ingredients.Add(i);
			}

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

			Notifications();
		}
		private void NotificationDesposal_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
		{
			string target = ((Label)sender).Content.ToString();

			if (target != null)
			{
				myDriver.Current_Pantry.expRemovalMsg.Remove(target);
			}

			Notifications();
		}
		private void Notifications()
		{
			Models.Pantry p = myDriver.Current_Pantry;
			spl_Expired.Children.Clear();
			spl_Warning.Children.Clear();

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
