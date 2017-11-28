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
using DataPersistance_One.Models;

namespace DataPersistance_One.Models
{
    /// <summary>
    /// Interaction logic for UC_Contact.xaml
    /// </summary>
    public partial class UC_Contact : UserControl
    {
        public Contact contact;
        bool isOpen = false;
        public UC_Contact(Contact c)
        {
            contact = c;
            InitializeComponent();
            init();
        }

        private void init()
        {

            lbl_Name.Content = contact.firstName + " " + contact.lastName;

            PhoneNumbers.Children.Clear();
            PhoneNumbers.Children.Add(lbl_PN);
            foreach (PhoneNumber pn in contact.phoneNumbers)
            {
                Label nextPN = new Label()
                {
                    Content = pn.number + " (" + pn.type + ")",
                    Width = 200,
                    Height = 30,
                    FontSize = 13,
                    HorizontalAlignment = HorizontalAlignment.Left
                };
                PhoneNumbers.Children.Add(nextPN);
            }

            Emails.Children.Clear();
            Emails.Children.Add(lbl_E);
            foreach (Email e in contact.emails)
            {
                Label nextE = new Label()
                {
                    Content = e.emailAdress + " (" + e.type + ")",
                    Width = 300,
                    Height = 30,
                    FontSize = 13,
                    HorizontalAlignment = HorizontalAlignment.Left
                };
                Emails.Children.Add(nextE);
            }

            lbl_Group.Content = contact.group;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            if (isOpen)
            {
                RD0.Height = new GridLength(0);
                RD1.Height = new GridLength(0);
                RD2.Height = new GridLength(0);
                btn_Edit.Width = 0;
                btn_Open.Width = 300;
                this.Height = 30;
                isOpen = false;
            }
            else
            {
                RD0.Height = new GridLength(60);
                RD1.Height = new GridLength(60);
                RD2.Height = new GridLength(30);
                btn_Edit.Width = 100;
                btn_Open.Width = 200;
                this.Height = 180;
                isOpen = true;
            }
        }

        private void btn_Edit_Click(object sender, RoutedEventArgs e)
        {
            CreateEditContact dialog = new CreateEditContact(contact);
            dialog.ShowDialog();

            contact = dialog.contact;
            init();
        }
    }
}
