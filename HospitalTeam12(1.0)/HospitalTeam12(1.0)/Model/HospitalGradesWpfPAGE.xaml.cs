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
    /// Interaction logic for HospitalGradesWpfPAGE.xaml
    /// </summary>
    public partial class HospitalGradesWpfPAGE : Page
    {
        public HospitalGradesWpfPAGE()
        {
            InitializeComponent();
            for (int i = 1; i < 11; i++)
            {
                Kindness.Items.Add(newItem: i);
                Professionalism.Items.Add(newItem: i);
                General.Items.Add(newItem: i);
            }
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
            Patient patient = new Patient();
            patient = patient.SearchPatientByJMBG("123456789");
            Grades grades = new Grades(int.Parse(Kindness.Text), int.Parse(Professionalism.Text), int.Parse(General.Text), "HOSPITAL");
            if (grades.hadExam(patient) == true)
                grades.writeGrades(grades);
        }
    }
}
