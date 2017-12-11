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
using System.Windows.Media;

namespace AwesomeMealtime
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Driver myDriver = new Driver();
		//bool PantrySearchChanged;
		StackPanel selected;

		public MainWindow()
        {
            InitializeComponent();
			myDriver.Init();

			foreach(Ingredient i in myDriver.Current_Pantry.ingredients)
			{
				StackPanel sp = new StackPanel();
				sp.Orientation = Orientation.Horizontal;
				DisplayIngredient(ref sp, i);

				spl_Pantry.Children.Add(sp);
			}

			RecipeList.ItemsSource = myDriver.Book.Recipes;

			Notifications();

            Closing += OnWindowClosing; //don't remove this
        }


		//Recipe Events
		private void btn_RecipeAdd_Click(object sender, RoutedEventArgs e)
        {
			RecipeWindow recwin = new RecipeWindow();
			if (recwin.ShowDialog() == true)
			{
				Recipe r = recwin.GetRecipe;
				myDriver.Book.AddRecipe(r);
				RecipeList.ItemsSource = myDriver.Book.Recipes;
			}

		}
		private void btn_RecipeRemove_Click(object sender, RoutedEventArgs e)
        {
			if (selected != null)
			{
				Recipe r = (Recipe)(((StackPanel)selected).DataContext);
				myDriver.Book.Recipes.Remove(r);

				lblRecName.Content = "";
				lblRecWarning.Content = "";
				lblRecPrepTime.Content = "";
				lblRecInstruct.Content = "";
				lblRecDifficult.Content = "";
				lblRecCookTime.Content = "";
				lblRecDescrib.Content = "";

				imgRecipe.Source = null;

				spl_IngridentList.Children.Clear();

				selected = null;
			}

        }
		private void spl_RecipeList_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
		{
			selected = (StackPanel)sender;
			spl_IngridentList.Children.Clear();
			Recipe r = (Recipe)selected.DataContext;

			lblRecName.Content = r.Name;
			lblRecInstruct.Content = r.Directions;
			lblRecDescrib.Content = r.Dish_Description;
			lblRecCookTime.Content = r.CookTime.ToString();
			lblRecPrepTime.Content = r.PrepTime.ToString();

			var converter = new ImageSourceConverter();

			try
			{
				imgRecipe.Source = (ImageSource)converter.ConvertFromString(r.MealPicture);
			}
			catch
			{
				MessageBox.Show("Image didn't load");
			}
			
			if(r.Warning)
			{
				lblRecWarning.Content = "Caution!";
			}
			else
			{
				lblRecWarning.Content = "";
			}

			foreach(Ingredient i in r.Ingredients)
			{
				Label l = new Label();
				l.Content = $"{i.Name} {i.Quan.Qty} {i.Quan.Msmt}";

				spl_IngridentList.Children.Add(l);
			}

			int diff = (int)r.Recipe_Difficulty + 1;

			lblRecDifficult.Content = $"D {diff}";
		}
		private void btn_RecipeEdit_Click(object sender, RoutedEventArgs e)
		{
			if (selected != null)
			{
				RecipeWindow recwin = new RecipeWindow();

				recwin.GetReicpeReadyForEdit((Recipe)selected.DataContext);

				if (recwin.ShowDialog() == true)
				{
					Recipe r = recwin.GetRecipe;
					Models.RecipeBook.EditRecipe((Recipe)selected.DataContext, r);
					RecipeList.ItemsSource = myDriver.Book.Recipes;
				}

				selected = null;
			}
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

			btn = new Button();
			btn.Content = "remove";
			btn.Click += BtnRemoveIngredient_Click;
			btn.Width = 50;
			btn.Height = 26;
			parent.Children.Add(btn);

		}
		private void BtnRemoveIngredient_Click(object sender, RoutedEventArgs e)
		{
			Button b = (Button)sender;
			StackPanel parent = (StackPanel)b.Parent;
			spl_Pantry.Children.Remove(parent);
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
			MessageBox.Show("This is will do something someday");
		}
		private void tbxSearch_TextChanged(object sender, TextChangedEventArgs e)
		{
			//PantrySearchChanged = true;
		}
		private void FillPantry()
		{
			myDriver.Current_Pantry.ingredients.Clear();

			foreach (var v in spl_Pantry.Children)
			{
				StackPanel s = (StackPanel)v;

				List<string> dates = new List<string>();
				List<string> amount = new List<string>();
				string name;

				GetPartsFromButton((Button)s.Children[3], out name, ref dates, ref amount);
				Ingredient i = Ingredient.GetIngredientFromParts(name, dates, amount);

				myDriver.Current_Pantry.ingredients.Add(i);
			}
			spl_Pantry.Children.Clear();

		}
		private void cbbSort_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			FillPantry();

			if(cbbSort.SelectedIndex == -1 || cbbSort.SelectedIndex == 0)
			{
				myDriver.Current_Pantry.SortAlphabetical();
			}
			else if(cbbSort.SelectedIndex == 1)
			{
				myDriver.Current_Pantry.SortReverseAlphabetical();
			}

			foreach (Ingredient i in myDriver.Current_Pantry.ingredients)
			{
				StackPanel s = new StackPanel();
				s.Orientation = Orientation.Horizontal;

				DisplayIngredient(ref s, i);
				spl_Pantry.Children.Add(s);
			}

			myDriver.Current_Pantry.ingredients.Clear();
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
			FillPantry();

			myDriver.Close();

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
