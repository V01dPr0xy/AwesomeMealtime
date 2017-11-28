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
    /// Interaction logic for CreateEditContact.xaml
    /// </summary>
    public partial class CreateEditContact : Window
    {
        public Contact contact;
        public CreateEditContact(Contact c)
        {
            contact = c;
            InitializeComponent();
            init();

            cb_Group.Items.Add("Family");
            cb_Group.Items.Add("Friends");
            cb_Group.Items.Add("Coworkers");

            cb_Group.SelectedIndex = (int)contact.group;
        }

        public void init()
        {
            if (contact.firstName != null)
            {
                tb_FirstName.Text = contact.firstName;
            }
            else
                tb_FirstName.Text = "First Name";
            if (contact.lastName != null)
            {
                tb_LastName.Text = contact.lastName;
            }
            else
                tb_LastName.Text = "Last Name";
            initLiBxPN();
            initLiBxE();
        }

        private void initLiBxPN()
        {
            if (contact.phoneNumbers == null)
            {
                contact.phoneNumbers = new List<PhoneNumber>();
            }
            foreach (PhoneNumber p in contact.phoneNumbers)
            {
                Label label = new Label()
                {
                    Content = p.number + " (" + p.type + ")",
                    Height = 22,
                    FontSize = 10,
                    VerticalAlignment = VerticalAlignment.Top
                };

                libx_PhoneNum.Items.Add(label);
            }
        }

        private void initLiBxE()
        {
            if (contact.emails == null)
            {
                contact.emails = new List<Email>();
            }
            foreach (Email e in contact.emails)
            {
                Label label = new Label()
                {
                    Content = e.emailAdress + " (" + e.type + ")",
                    Height = 24,
                    FontSize = 10,
                    VerticalAlignment = VerticalAlignment.Top
                };

                libx_Emails.Items.Add(label);
            }
        }
        private void btn_FNSave_Click(object sender, RoutedEventArgs e)
        {
            contact.firstName = tb_FirstName.Text;
        }

        private void btn_FNUndo_Click(object sender, RoutedEventArgs e)
        {
            if (contact.firstName != null)
            {
                tb_FirstName.Text = contact.firstName;
            }
            else
                tb_FirstName.Text = "First Name";
        }

        private void btn_LNSave_Click(object sender, RoutedEventArgs e)
        {
            contact.lastName = tb_LastName.Text;
        }

        private void btn_LNUndo_Click(object sender, RoutedEventArgs e)
        {
            if (contact.lastName != null)
            {
                tb_LastName.Text = contact.lastName;
            }
            else
                tb_LastName.Text = "Last Name";

        }

        private void btn_pnAdd_Click(object sender, RoutedEventArgs e)
        {
            PhoneNumber newPhone = new PhoneNumber();
            CreateEditPhoneNumber PNEdit = new CreateEditPhoneNumber(newPhone);
            PNEdit.ShowDialog();
            contact.phoneNumbers.Add(PNEdit.ph);
            libx_PhoneNum.Items.Clear();
            initLiBxPN();
        }

        private void btn_pnRemove_Click(object sender, RoutedEventArgs e)
        {
            if (libx_PhoneNum.SelectedIndex >= 0 && libx_PhoneNum.SelectedIndex < contact.phoneNumbers.Count)
            {
                contact.phoneNumbers.RemoveAt(libx_PhoneNum.SelectedIndex);
                libx_PhoneNum.Items.Clear();
                initLiBxPN();
            }

        }

        private void btn_pnEdit_Click(object sender, RoutedEventArgs e)
        {
            if (libx_PhoneNum.SelectedIndex >= 0 && libx_PhoneNum.SelectedIndex < contact.phoneNumbers.Count)
            {
                PhoneNumber EditPhone = contact.phoneNumbers[libx_PhoneNum.SelectedIndex];
                CreateEditPhoneNumber PNEdit = new CreateEditPhoneNumber(EditPhone);
                PNEdit.ShowDialog();
                contact.phoneNumbers[libx_PhoneNum.SelectedIndex] = PNEdit.ph;
                libx_PhoneNum.Items.Clear();
                initLiBxPN();
            }
        }

        private void libx_PhoneNum_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
        }

        private void btn_eAdd_Click(object sender, RoutedEventArgs e)
        {
            Email newEmail = new Email();
            CreateEditEmail EEdit = new CreateEditEmail(newEmail);
            EEdit.ShowDialog();
            contact.emails.Add(EEdit.email);
            libx_Emails.Items.Clear();
            initLiBxE();
        }

        private void btn_eRemove_Click(object sender, RoutedEventArgs e)
        {
            if (libx_Emails.SelectedIndex >= 0 && libx_Emails.SelectedIndex < contact.emails.Count)
            {
                contact.emails.RemoveAt(libx_Emails.SelectedIndex);
                libx_Emails.Items.Clear();
                initLiBxE();
            }

        }

        private void btn_eEdit_Click(object sender, RoutedEventArgs e)
        {
            if (libx_Emails.SelectedIndex >= 0 && libx_Emails.SelectedIndex < contact.emails.Count)
            {
                Email newEmail = contact.emails[libx_Emails.SelectedIndex];
                CreateEditEmail EEdit = new CreateEditEmail(newEmail);
                EEdit.ShowDialog();
                contact.emails[libx_Emails.SelectedIndex] = EEdit.email;
                libx_Emails.Items.Clear();
                initLiBxE();
            }
        }

        private void cb_Group_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            contact.group = (Group)cb_Group.SelectedIndex;
        }
    }
}
