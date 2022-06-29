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
    /// Interaction logic for SearchThePatient.xaml
    /// </summary>
    public partial class SearchThePatient : Window
    {
        public SearchThePatient()
        {
            InitializeComponent();
        }

        private void Button_Click_Search(object sender, RoutedEventArgs e)
        {
            var p = new Patient();
            var p2 = new Patient();

            p2 = p.SearchPatientByJMBG(searchJMBG.Text);

            prva.Content = "FirstName       LastName       DateOfBirth      JMBG      Email     Phone   Address   Username   Password     HealthRecordNumber ";
            druga.Content = p2.GetUser().FirstName + "\t" + p2.GetUser().LastName
                            + "\t" + p2.GetUser().DateOfBirth + "\t" + p2.GetUser().Jmbg
                            + "\t" + "              " + p2.GetUser().Email + "\t" + p2.GetUser().Phone
                            + "\t" + p2.GetUser().Address + "\t" + p2.GetUser().Username
                            + "\t" + p2.GetUser().Password + "\t" + p2.HealthRecordNumber + "\n";

        }
    }
}
