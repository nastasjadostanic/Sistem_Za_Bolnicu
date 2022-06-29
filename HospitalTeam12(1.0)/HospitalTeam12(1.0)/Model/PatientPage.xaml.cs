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
    public partial class PatientPage : Window
    {
        public PatientPage()
        {
            InitializeComponent();
        }

        private void Click_Reschedule(object sender, RoutedEventArgs e)
        {
            PATIENT.Content = new ReschedulePagePatientWpfPAGE();
            // Model.ReschedulePagePatient win = new Model.ReschedulePagePatient();
            // win.Show();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            PATIENT.Content = new SchedulePagePatientWpfPAGE();
            //Model.SchedulePagePatient win = new Model.SchedulePagePatient();
            //win.Show();
        }

        private void Click_Search(object sender, RoutedEventArgs e)
        {
            PATIENT.Content = new SearchExeminationPagePatientWpfPAGE();
            // Model.SearchExeminationPagePatient win = new Model.SearchExeminationPagePatient();
            //win.Show();

        }

        private void Click_Remove(object sender, RoutedEventArgs e)
        {
            PATIENT.Content = new RemoveExeminationPagePatientWpfPAGE();
            // Model.RemoveExeminationPagePatient win = new Model.RemoveExeminationPagePatient();
            //  win.Show();
        }

       

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            PATIENT.Content = new NotificationPatientWpfPAGE();
            // Model.NotificationPatient win = new Model.NotificationPatient();
            //win.Show();
        }

        private void Button_Click_hospital(object sender, RoutedEventArgs e)
        {
            PATIENT.Content = new HospitalGradesWpfPAGE();
            //Model.HospitalGrades win = new Model.HospitalGrades();
            // win.Show();
        }

        private void Button_Click_doctor(object sender, RoutedEventArgs e)
        {
            PATIENT.Content = new DoctorGradesWpfPAGE();
            //Model.DoctorGrades win = new Model.DoctorGrades();
            // win.Show();
        }

        private void Button_Click_instruction(object sender, RoutedEventArgs e)
        {
            PATIENT.Content = new InstructionPageWpfPAGE();
            //Model.InstructionPage win = new Model.InstructionPage();
            // win.Show();
        }

        private void Button_Click_profile(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_health_record(object sender, RoutedEventArgs e)
        {
            PATIENT.Content = new HealthRecordWpfPAGE();
        }

        private void Button_Click_payment(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_rate_app(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_logout(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)//edit
        {
            PATIENT.Content = new EditThePatientPWpfPAGE();
            //Model.EditThePatientP win = new Model.EditThePatientP();
            // win.Show();
        }
    }
}
