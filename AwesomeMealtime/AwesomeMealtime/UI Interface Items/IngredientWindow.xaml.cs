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

		public IngredientWindow()
		{
			InitializeComponent();

			cbbMeasureType.ItemsSource = Enum.GetValues(typeof(Models.Ingredient.Measurements)).Cast< Models.Ingredient.Measurements> (); 
		}

		private void btnAccept_Click(object sender, RoutedEventArgs e)
		{
			int amount;
			DateTime time;

			if (!tbxName.Text.Equals("Name Me!") || tbxName.Text != null)
			{
				proto = new Ingredient(tbxName.Text);

				if (tbxAmount.Text != null && cbbMeasureType.SelectedIndex != -1)
				{
					Int32.TryParse(tbxAmount.Text, out amount);
					Ingredient.Measurements unit = (Ingredient.Measurements)cbbMeasureType.SelectedIndex;

					Ingredient.Quantity qty = new Ingredient.Quantity() { Msmt = unit, Qty = amount };

					proto.Quantities.Add(qty);
				}
				else if (tbxAmount.Text == null)
				{
					amount = 0;
					Ingredient.Measurements unit = Ingredient.Measurements._;

					Ingredient.Quantity qty = new Ingredient.Quantity() { Msmt = unit, Qty = amount };

					proto.Quantities.Add(qty);
				}

				if (tbxExpire.Text != null)
				{
					DateTime.TryParse(tbxExpire.Text, out time);

				}



				this.Close();
			}
		}

		private void tbxName_TextChanged(object sender, TextChangedEventArgs e)
		{
			if(!tbxName.Text.Equals("Name Me!") && tbxName.Text != null)
			{
				if (tbxAmount.Text == null || (tbxAmount.Text != null && cbbMeasureType.SelectedIndex != -1))
				{
					btnAccept.IsEnabled = true;
				}
			}
		}
	}
}
