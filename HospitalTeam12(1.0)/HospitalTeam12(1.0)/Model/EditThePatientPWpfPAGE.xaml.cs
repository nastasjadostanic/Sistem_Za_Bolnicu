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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HospitalTeam12.Model
{
    /// <summary>
    /// Interaction logic for EditThePatientPWpfPAGE.xaml
    /// </summary>
    public partial class EditThePatientPWpfPAGE : Page
    {
        public EditThePatientPWpfPAGE()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var p = new Patient();

            //   p.EditAccountP(First.Text, Last.Text, DoB.Text, Email.Text, Phone.Text, Address.Text);
            First.Text = "";
            Last.Text = "";
            DoB.Text = "";
            Email.Text = "";
            Phone.Text = "";
            Address.Text = "";
        }
    }
}
