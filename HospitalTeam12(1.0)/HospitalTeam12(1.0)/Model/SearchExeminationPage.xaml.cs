using MainPackage.Model;
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

namespace HospitalTeam12.Model
{
    public partial class SearchExeminationPage : Window
    {
        public SearchExeminationPage()
        {
            InitializeComponent();
        }

     

        private void Button_Click_Search(object sender, RoutedEventArgs e)
        {
            var ee = new Examination();

            var e2 = new Examination();
            e2 = ee.ViewExamination(examID.Text);
            

           lbl1.Content = "ID       RoomNumber       Floor      PatientName      PatientLastName      PatientHealthRecordNumber      PatientJMBG   DoctorFirstName  DoctorLastName";
           lbl2.Content = e2.Id + " " + e2.GetDoctor().GetRoom().Number + " " + e2.GetDoctor().GetRoom().Floor +
                " " + e2.GetPatient().GetUser().FirstName + " " + e2.GetPatient().GetUser().LastName + " " + e2.GetPatient().HealthRecordNumber +
                " " + e2.GetPatient().GetUser().Jmbg + " " + e2.GetDoctor().GetUser().FirstName + " " + e2.GetDoctor().GetUser().LastName +
                " " + e2.day + " " + e2.mnth + " " + e2.year + " " + e2.hour + " " + e2.min + "\n";
        }
    }
}
