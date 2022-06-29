using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    
    public partial class MedicinesPage : Page
    {
        public ObservableCollection<Medicine> Medicines { get; set; }

        public MedicinesPage()
        {
            InitializeComponent();
            this.DataContext = this;
            Medicine m = new Medicine();
            Medicines = new System.Collections.ObjectModel.ObservableCollection<Medicine>();
            string[] tmp = m.GetAll();
            for (int i = 0; i < tmp.Length; i++)
            {
                string[] words = tmp[i].Split();
                
                    Medicines.Add(new Medicine { Id = words[0], Name = words[1], Description = words[2], Ingredients = words[3], AlternativeMedicine = words[4], Status = words[5], Explanation=words[6] });
            }
            
        }

        private void Button_Click_Create(object sender, RoutedEventArgs e)
        {
            Model.CreateMedicinePage win = new Model.CreateMedicinePage();
            win.Show();
        }

        private void Button_Click_Update(object sender, RoutedEventArgs e)
        {
            if (Status.Text == "DENIED")
            {
                Medicine m = new Medicine();
                m.Update(Id.Text, Name.Text, Description.Text, Ingedients.Text, AlternativeMedicine.Text, Status.Text, "StillNotWritten");
                Id.Text = "";
                Name.Text = "";
                Description.Text = "";
                Ingedients.Text = "";
                AlternativeMedicine.Text = "";
                Status.Text = "";
                Explanation.Text = "";
            }
            else 
            {
                MessageBox.Show("It is not possible to update a medicine which is with status VERIFIED or WAITING.", "", MessageBoxButton.OK, MessageBoxImage.Error);
            }
           
        }

        private void Button_Click_Delete(object sender, RoutedEventArgs e)
        {
            if (Medicines.Count > 0)
            {

                Medicine m = new Medicine();
                m = (Medicine)MedicineUp.SelectedItem;
                m.Delete(m.Id);

            }
            else
            {
                MessageBox.Show("It is not possible to delete from empty table.", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            //this.Hide();
           ///Model.AllMedicinePage win = new Model.AllMedicinePage();
           // win.Show();
        }

        private void MedicineUp_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
          
            if (this.MedicineUp.SelectedItem.ToString() == "DENIED")
            {
                //KAKO POSTAVITI OVE DA SE VIDE 
                this.Explanation.Visibility = System.Windows.Visibility.Visible;
                this.ExpLbl.Visibility = System.Windows.Visibility.Visible;
            }
        }


    }
}

