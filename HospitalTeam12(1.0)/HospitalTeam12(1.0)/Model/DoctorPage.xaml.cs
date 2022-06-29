using System;
using System.Collections.Generic;
using System.Collections;
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
    /// Interaction logic for DoctorPage.xaml
    /// </summary>
    public partial class DoctorPage : Window
    {
        public DoctorPage()
        {
            InitializeComponent();
        }

        

        private void Click_Search(object sender, RoutedEventArgs e)
        {
            Model.SearchExeminationPage win = new Model.SearchExeminationPage();
            win.Show();
        }

        private void Click_Remove(object sender, RoutedEventArgs e)
        {
            Model.RemoveExeminationPage win = new Model.RemoveExeminationPage();
            win.Show();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Model.SchedulePage win = new Model.SchedulePage();
            win.Show();
        }

        private void Click_Reschedule(object sender, RoutedEventArgs e)
        {
            Model.ReschedulePage win = new Model.ReschedulePage();
            win.Show();
        }

        private void Surgery_schedule(object sender, RoutedEventArgs e)
        {
            Model.SurgerySchedule win = new Model.SurgerySchedule();
            win.Show();
        }

        private void Surgery_Search(object sender, RoutedEventArgs e)
        {
            Model.SurgerySearch win = new Model.SurgerySearch();
            win.Show();
        }

        private void Surgery_SearchAll(object sender, RoutedEventArgs e)
        {
            Model.SurgerySearchAll win = new Model.SurgerySearchAll();
            win.Show();
        }

        private void Surgery_Reschedule(object sender, RoutedEventArgs e)
        {
            Model.SurgeryReschedule win = new Model.SurgeryReschedule();
            win.Show();
        }

        private void Surgery_Remove(object sender, RoutedEventArgs e)
        {
            Model.SurgeryRemove win = new Model.SurgeryRemove();
            win.Show();
        }

        private void Recipe_create(object sender, RoutedEventArgs e)
        {
            Model.RecipeCreate win = new Model.RecipeCreate();
            win.Show();
        }

        private void Recipe_Search(object sender, RoutedEventArgs e)
        {
            Model.RecipeSearch win = new Model.RecipeSearch();
            win.Show();
        }

        private void Recipe_update(object sender, RoutedEventArgs e)
        {
            Model.RecipeUpdate win = new Model.RecipeUpdate();
            win.Show();
        }

        private void Anamnesis_create(object sender, RoutedEventArgs e)
        {
            Model.AnamnesisCreate win = new Model.AnamnesisCreate();
            win.Show();
        }

        private void Anamnesis_Search(object sender, RoutedEventArgs e)
        {
            Model.AnamnesisSearch win = new Model.AnamnesisSearch();
            win.Show();
        }

        private void Anamnesis_update(object sender, RoutedEventArgs e)
        {
            Model.AnamnesisUpdate win = new Model.AnamnesisUpdate();
            win.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Model.MedicineSearchDoctor win = new Model.MedicineSearchDoctor();
            win.Show();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Model.MedicineUpdateDoctor win = new Model.MedicineUpdateDoctor();
            win.Show();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            Model.MedicineVerifyDoctor win = new Model.MedicineVerifyDoctor();
            win.Show();
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            Model.MedicineInstructionDoctor win = new Model.MedicineInstructionDoctor();
            win.Show();
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            Model.MedicineHospitalInstructionDoctor win = new Model.MedicineHospitalInstructionDoctor();
            win.Show();
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            Model.MedicineHospitalInstructionUpdate win = new Model.MedicineHospitalInstructionUpdate();
            win.Show();
        }

        private void Button_Click_7(object sender, RoutedEventArgs e)
        {
            Model.MedicineInstructionUpdate win = new Model.MedicineInstructionUpdate();
            win.Show();
        }
    }
}
