using System;
using System.Collections.Generic;
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
using AwesomeMealtime.Models;

namespace AwesomeMealtime.UI_Interface_Items
{
    /// <summary>
    /// Interaction logic for Wnd_Ingredient.xaml
    /// This may need to be reworked later
    /// </summary>
    public partial class Wnd_Ingredient : Window
    {
        Ingredient theIngredient;
        IngredientBTN source;
        TextBox name;
        public Wnd_Ingredient(IngredientBTN s, Ingredient ing)
        {
            theIngredient = ing;
            source = s;
            InitializeComponent();
            name = tb_Name;
            init();
        }

        public void init()
        {
            sp_Content.Children.Clear();
            sp_Content.Children.Add(name);
            tb_Name.Text = theIngredient.Name;

            foreach (Ingredient.Quantity q in theIngredient.Quantities)
            {
                Label lb = new Label()
                {
                    Content = getQuantityString(q),
                    Margin = new Thickness(100, 0, 0, 0)
                };
                sp_Content.Children.Add(lb);
            }
        }

        private string getQuantityString(Ingredient.Quantity q)
        {
            string toReturn = "";

            toReturn += q.Qty;
            toReturn += " ";
            if (q.Msmt == Ingredient.Measurements._)
            {
                toReturn += theIngredient.Name;
                toReturn += "s";
            }
            else
            {
                toReturn += q.Msmt;
            }

            return toReturn;
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Are you Sure?\nThis cannot be undone.", "Save Changes", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                theIngredient.Name = tb_Name.Text;
                source.MakeChanges();
                init();
            }

        }

        private void Revert_Click(object sender, RoutedEventArgs e)
        {
            init();
        }
    }
}
