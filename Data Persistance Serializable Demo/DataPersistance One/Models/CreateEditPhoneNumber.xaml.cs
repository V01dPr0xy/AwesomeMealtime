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

namespace DataPersistance_One.Models
{
    /// <summary>
    /// Interaction logic for CreateEditPhoneNumber.xaml
    /// </summary>
    public partial class CreateEditPhoneNumber : Window
    {
        public PhoneNumber ph;
        public CreateEditPhoneNumber(PhoneNumber p)
        {
            ph = p;
            InitializeComponent();
            init();

            Label work = new Label()
            { Content = "Work" };

            Label home = new Label()
            { Content = "Home" };

            Label cell = new Label()
            { Content = "Cell" };

            cb_Type.Items.Add(work);
            cb_Type.Items.Add(home);
            cb_Type.Items.Add(cell);

            cb_Type.SelectedIndex = (int)ph.type;
        }

        private void init()
        {
            if (ph.number != null)
            {
                string abc = "";
                abc += ph.number[0].ToString() + ph.number[1].ToString() + ph.number[2].ToString();

                string def = "";
                def += ph.number[4].ToString() + ph.number[5].ToString() + ph.number[6].ToString();

                string ghij = "";
                ghij += ph.number[8].ToString() + ph.number[9].ToString() + ph.number[10].ToString() + ph.number[11].ToString();

                txb_012.Text = abc;
                txb_345.Text = def;
                txb_6789.Text = ghij;
            }
        }
        
        private void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            var textBox = sender as TextBox;
            e.Handled = Regex.IsMatch(e.Text, "[^0-9]+");
        }

        private void btn_Save_Click(object sender, RoutedEventArgs e)
        {
            while (txb_012.Text.Length < 3)
            {
                txb_012.Text += " ";
            }
            while (txb_345.Text.Length < 3)
            {
                txb_012.Text += " ";
            }
            while (txb_6789.Text.Length < 4)
            {
                txb_012.Text += " ";
            }

            string num = txb_012.Text + "-" + txb_345.Text + "-" + txb_6789.Text;
            ph.number = num;

            ph.type = (NumberType)cb_Type.SelectedIndex;
            this.Close();
        }

        private void btn_Undo_Click(object sender, RoutedEventArgs e)
        {
            init();
            cb_Type.SelectedIndex = (int)ph.type;
        }
    }
}
