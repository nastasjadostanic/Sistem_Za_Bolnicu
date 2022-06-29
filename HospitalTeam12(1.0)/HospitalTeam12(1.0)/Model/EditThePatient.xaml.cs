using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using MainPackage.Model;

namespace HospitalTeam12.Model
{
    /// <summary>
    /// Interaction logic for EditThePatient.xaml
    /// </summary>
    public partial class EditThePatient : Window
    {
        public EditThePatient()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var p = new Patient();

         //   p.EditAccount(First.Text, Last.Text, DoB.Text, Jmbg.Text, Email.Text, Phone.Text, Address.Text, Username.Text, Password.Text, HCN.Text);
            First.Text = "";
            Last.Text = "";
            DoB.Text = "";
            Jmbg.Text = "";
            Email.Text = "";
            Phone.Text = "";
            Address.Text = "";
            Username.Text = "";
            Password.Text = "";
            HCN.Text = "";

         //   if (p.EditAccount(First.Text, Last.Text, DoB.Text, Jmbg.Text, Email.Text, Phone.Text, Address.Text, Username.Text, Password.Text, HCN.Text) == false) { eror.Content = "No match for JMBG"; }

        }
    }
}
