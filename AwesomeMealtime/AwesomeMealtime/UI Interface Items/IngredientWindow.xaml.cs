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
			if(AcceptCheck())
			{
				proto = new Ingredient(tbxName.Text);

				foreach (StackPanel sp in spl_Stuff.Children)
				{
					Ingredient.ExpDate exp = new Ingredient.ExpDate();

					//exp.Dates = DateTime.Parse(((Label)sp.Children[1]).Content.ToString()));

					string raw = ((Label)sp.Children[0]).Content.ToString();
					int index = raw.IndexOf(' ');
					string samount = raw.Substring(0, index);
					string type = raw.Substring(index+1);

					Ingredient.Quantity qty = new Ingredient.Quantity();
					qty.Msmt = Ingredient.GetMeasurementFromString(type);
					qty.Qty = Double.Parse(samount);



				}

				Close();
			}

		}

		private void tbxName_TextChanged(object sender, TextChangedEventArgs e)
		{

			btnAccept.IsEnabled = AcceptCheck();
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
				string content = $"{amount.ToString()} {(Ingredient.Measurements)cbbMeasureType.SelectedIndex}";
				l.Content = content;
				stack.Children.Add(l);

				l = new Label();
				l.Content = time.ToString();
				stack.Children.Add(l);

				spl_Stuff.Children.Add(stack);
			}

			btnAccept.IsEnabled = AcceptCheck();
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

			btnAccept.IsEnabled = AcceptCheck();
		}

		private bool AcceptCheck()
		{
			bool verdict = true;

			if(spl_Stuff == null || spl_Stuff.Children == null || tbxName.Text == null || spl_Stuff.Children.Count < 1 || tbxName.Text.Equals("Name Me!"))
			{
				verdict = false;
			}

			return verdict;
		}
	}
}
