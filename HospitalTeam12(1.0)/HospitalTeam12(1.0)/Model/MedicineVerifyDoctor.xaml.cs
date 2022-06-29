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

namespace HospitalTeam12.Model
{
    /// <summary>
    /// Interaction logic for MedicineVerifyDoctor.xaml
    /// </summary>
    public partial class MedicineVerifyDoctor : Window
    {
        public ArrayList res { get; set; }
        public MedicineVerifyDoctor()
        {
            InitializeComponent();

            var m = new Medicine();
            res = new ArrayList();
            res = m.ViewAllByDoctor();
            dataGridMedicine.ItemsSource = res;
        }

        private void Button_Verify(object sender, RoutedEventArgs e)
        {
            var m = new Medicine();
            res = m.ViewMedicineByDoctor(medicineID.Text);
            String status = "";
            if (VerifyCheck.IsChecked == true)
            {
                status = "CONFIRMED";
            }
            else
            {
                status = "WAITING";
            }
            foreach(Medicine item in res)
            {
                m.UpdateByDoctor(item.Id, item.Name, item.Description, item.Ingredients, item.AlternativeMedicine, status, item.Explanation);
            }
            res = m.ViewAllByDoctor();
            dataGridMedicine.ItemsSource = res;

        }

        private void Button_Deny(object sender, RoutedEventArgs e)
        {
            var m = new Medicine();
            res = m.ViewMedicineByDoctor(medicineID.Text);
          
            foreach (Medicine item in res)
            {
                m.UpdateByDoctor(item.Id, item.Name, item.Description, item.Ingredients, item.AlternativeMedicine, "DENIED", item.Explanation);
            }
            res = m.ViewAllByDoctor();
            dataGridMedicine.ItemsSource = res;
        }
    }
}
