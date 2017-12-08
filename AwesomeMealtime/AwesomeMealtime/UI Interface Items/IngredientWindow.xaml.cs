using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using AwesomeMealtime.Models;
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
	/// Interaction logic for IngredientWindow.xaml
	/// </summary>
	public partial class IngredientWindow : Window
	{
		public Ingredient proto;

		private StackPanel selected;

		public IngredientWindow()
		{
			InitializeComponent();

			cbbMeasureType.ItemsSource = Enum.GetValues(typeof(Models.Ingredient.Measurements)).Cast< Models.Ingredient.Measurements> (); 
		}

		private void btnAccept_Click(object sender, RoutedEventArgs e)
		{

		}

		private void tbxName_TextChanged(object sender, TextChangedEventArgs e)
		{

			if(!tbxName.Text.Equals("Name Me!") && tbxName.Text != null)
			{
				if (spl_Stuff.Children != null && spl_Stuff.Children.Count > 0)
				{
					btnAccept.IsEnabled = true;
				}
			}
		}

		private void btnAdd_Click(object sender, RoutedEventArgs e)
		{
			int amount;
			DateTime time;
			Label l;
			if(Int32.TryParse(tbxAmount.Text, out amount) && DateTime.TryParse(tbxDate.Text, out time) && cbbMeasureType.SelectedIndex != -1) {
				StackPanel stack = new StackPanel();
				stack.MouseLeftButtonDown += ScrollViewer_MouseLeftButtonDown;

				l = new Label();
				string content = $"{amount.ToString()} + {(Ingredient.Measurements)cbbMeasureType.SelectedIndex}";
				l.Content = content;
				stack.Children.Add(l);

				l = new Label();
				l.Content = time.ToString();
				stack.Children.Add(l);

				spl_Stuff.Children.Add(stack);
			}
		}

		private void ScrollViewer_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
		{
			if ((StackPanel)sender != null)
			{
				selected = (StackPanel)sender;
			}
		}

		private void btnSub_Click(object sender, RoutedEventArgs e)
		{
			if(selected != null)
			{
				spl_Stuff.Children.Remove(selected);
				selected = null;
			}
		}
	}
}
