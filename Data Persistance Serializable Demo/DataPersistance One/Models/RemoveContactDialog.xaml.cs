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

namespace DataPersistance_One.Models
{
    /// <summary>
    /// Interaction logic for RemoveContactDialog.xaml
    /// </summary>
    public partial class RemoveContactDialog : Window
    {
        List<Contact> contacts;
        MainWindow main;
        public RemoveContactDialog(List<Contact> C, MainWindow m)
        {
            contacts = C;
            main = m;
            InitializeComponent();

            foreach (Contact c in contacts)
            {
                string toAdd = c.firstName + " " + c.lastName;
                cb_list.Items.Add(toAdd);
            }
        }

        private void btn_remove_Click(object sender, RoutedEventArgs e)
        {
            main.RemoveContactAt(cb_list.SelectedIndex);
            this.Close();
        }

        private void btn_cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
