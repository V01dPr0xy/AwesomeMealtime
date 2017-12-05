using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
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
    /// Interaction logic for AddQuantityMsgBox.xaml
    /// </summary>
    public partial class AddQuantityMsgBox : Window
    {
        public double result = 0;
        public AddQuantityMsgBox(string s, bool b)
        {
            InitializeComponent();
            lbl_Measurement.Content = s;

            if (b)
            {
                btn.Content = "Remove";
            }
        }

        private void Amount_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            var textBox = sender as TextBox;
            e.Handled = Regex.IsMatch(e.Text, "[^0-9]+");
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            result = Double.Parse(Amount.Text);
            this.Close();
        }
    }
}
