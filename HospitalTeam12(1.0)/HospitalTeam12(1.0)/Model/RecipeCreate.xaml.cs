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
using System.Collections;

namespace HospitalTeam12.Model
{
    public partial class RecipeCreate : Window
    {
        public ArrayList res { get; set; }
        public RecipeCreate()
        {
            InitializeComponent();

            this.DataContext = this;
        }

        private void Button_Create_Recipe(object sender, RoutedEventArgs e)
        {
            
            var m = new MedicalRecord();
            var r = new Recipe();
            r.SetHRN(health_record_num.Text);
            r.SetName(name.Text);
            r.SetQuantity(quantity.Text);
            r.SetInstructions(instruction.Text);
            r.dt = DateTime.Now.ToString();

            var medicine = new Medicine();
            if (medicine.ViewAllergenByDoctor(health_record_num.Text,name.Text)!=null)
            {
                MessageBox.Show(name.Text+" is allergen for that patient!", "", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                m.CreateRecipe(r);
            }
            

        }

        private void Allergen_Button(object sender, RoutedEventArgs e)
        {
            var medicine = new Medicine();
            if(medicine.CreateAllergenByDoctor(health_record_num.Text, name.Text))
            {
                MessageBox.Show("Allergen successfully added.","", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Allergen already added.", "", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void AllergenSearch_Button(object sender, RoutedEventArgs e)
        {
            var medicine = new Medicine();
            res = medicine.ViewAllergensByDoctor(health_record_num.Text);
            dataGridAllergen.ItemsSource = res;
        }
    }
}
