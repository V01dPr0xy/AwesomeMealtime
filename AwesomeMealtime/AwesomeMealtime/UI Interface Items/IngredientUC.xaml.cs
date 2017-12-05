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
using System.Windows.Navigation;
using System.Windows.Shapes;
using AwesomeMealtime.Models;

namespace AwesomeMealtime.UI_Interface_Items
{
    /// <summary>
    /// Interaction logic for IngredientUC.xaml
    /// </summary>
    public partial class IngredientUC : UserControl
    {
        Ingredient theIngredient;
        MainWindow source;
        TextBox name;

        bool isOpen = true;
        public IngredientUC(MainWindow s, Ingredient ing)
        {
            theIngredient = ing;
            source = s;
            InitializeComponent();
            name = tb_Name;
            init();
        }

        public void init()
        {
            tb_Name.Text = theIngredient.Name;

            foreach (Ingredient.Quantity q in theIngredient.Quantities)
            {
                Label lb = new Label()
                {
                    Content = getQuantityString(q),
                    Margin = new Thickness(100, 0, 0, 0)
                };
                sp_Content.Items.Add(lb);
            }
            Label lbl = new Label() { Content = "new", Margin = new Thickness(100, 0, 0, 0) };
            sp_Content.Items.Add(lbl);
        }

        public void itemsRefresh()
        {
            sp_Content.Items.Clear();
            foreach (Ingredient.Quantity q in theIngredient.Quantities)
            {
                Label lb = new Label()
                {
                    Content = getQuantityString(q),
                    Margin = new Thickness(100, 0, 0, 0)
                };
                sp_Content.Items.Add(lb);
            }
            Label lbl = new Label() { Content = "new", Margin = new Thickness(100, 0, 0, 0) };
            sp_Content.Items.Add(lbl);
        }

        private string getQuantityString(Ingredient.Quantity q)
        {
            string toReturn = "";

            toReturn += q.ConvertFromOunces();
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
                init();
            }

        }

        private void Revert_Click(object sender, RoutedEventArgs e)
        {
            init();
        }

        private void btn_Open_Click(object sender, RoutedEventArgs e)
        {
            if (isOpen)
            {
                btn_Open.Content = "Close";
                Size1.Height = new GridLength(30);
                Size2.Height = new GridLength(0);
            }
            else
            {
                btn_Open.Content = "Open";
                Size1.Height = new GridLength(270);
                Size2.Height = new GridLength(30);

            }
            isOpen = !isOpen;
        }

        private void btn_addAmount_Click(object sender, RoutedEventArgs e)
        {
            int i = sp_Content.SelectedIndex;
            if (i == -1)
                return;

            string type = theIngredient.Quantities[i].Msmt.ToString();
            AddQuantityMsgBox a = new AddQuantityMsgBox(type, false);
            a.ShowDialog();

            theIngredient.Quantities[i] = new Ingredient.Quantity() { Msmt = theIngredient.Quantities[i].Msmt,
                Qty = theIngredient.Quantities[i].ConvertFromOunces() + a.result };
            itemsRefresh();

        }

        private void btn_RemoveAmount_Click(object sender, RoutedEventArgs e)
        {
            int i = sp_Content.SelectedIndex;
            if (i == -1)
                return;

            string type = theIngredient.Quantities[i].Msmt.ToString();
            AddQuantityMsgBox a = new AddQuantityMsgBox(type, true);
            a.ShowDialog();

            theIngredient.Quantities[i] = new Ingredient.Quantity()
            {
                Msmt = theIngredient.Quantities[i].Msmt,
                Qty = theIngredient.Quantities[i].ConvertFromOunces() - a.result
            };
            itemsRefresh();


        }
    }
}
