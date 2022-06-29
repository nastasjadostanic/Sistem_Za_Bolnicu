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
using System.Collections;
using MainPackage.Model;

namespace HospitalTeam12.Model
{
    /// <summary>
    /// Interaction logic for MedicineSearchDoctor.xaml
    /// </summary>
    public partial class MedicineSearchDoctor : Window
    {
        public ArrayList res { get; set; }
        public MedicineSearchDoctor()
        {
            InitializeComponent();
            this.DataContext = this;

            var m = new Medicine();
            res = new ArrayList();
            res = m.ViewAllByDoctor();
            dataGridMedicine.ItemsSource = res;
        }

        private void Button_Click_Search(object sender, RoutedEventArgs e)
        {
            var m = new Medicine();
            res = m.ViewMedicineByDoctor(medicineID.Text);
            dataGridMedicine.ItemsSource = res;
        }

        private void Button_Refresh(object sender, RoutedEventArgs e)
        {
            var m = new Medicine();
            res = new ArrayList();
            res = m.ViewAllByDoctor();
            dataGridMedicine.ItemsSource = res;

        }
    }
}
