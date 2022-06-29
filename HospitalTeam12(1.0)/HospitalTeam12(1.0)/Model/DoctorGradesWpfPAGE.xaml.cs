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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HospitalTeam12.Model
{
    /// <summary>
    /// Interaction logic for DoctorGradesWpfPAGE.xaml
    /// </summary>
    public partial class DoctorGradesWpfPAGE : Page
    {
        public DoctorGradesWpfPAGE()
        {
            Doctor dr = new Doctor();
            Patient patient = new Patient();
            patient = patient.SearchPatientByJMBG("123456789");
            InitializeComponent();
            int numOfDoctors = 0;
            Doctor[] doctors = dr.hadExamAtDoctors(patient, ref numOfDoctors);

            for (int i = 0; i < numOfDoctors; i++)
            {
                Doctors.Items.Add(newItem: doctors[i].user.FirstName + " " + doctors[i].user.LastName);
                i++;
            }
            for (int i = 1; i < 11; i++)
            {
                Kindness.Items.Add(newItem: i);
                Professionalism.Items.Add(newItem: i);
                General.Items.Add(newItem: i);
            }
        }

        private void Doctors_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }



        private void Kindness_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Professionalism_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void General_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Submit_Click(object sender, RoutedEventArgs e)
        {
            Doctor doctor = new Doctor();
            doctor = doctor.SearchDoctorByNameAndLastName(Doctors.Text);



            Grades grades = new Grades(int.Parse(Kindness.Text), int.Parse(Professionalism.Text), int.Parse(General.Text), doctor.user.Jmbg);
            grades.writeGrades(grades);

        }
    }
}
