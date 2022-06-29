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
    
    public partial class ManagerPage : Window
    {
        public ManagerPage()
        {
            InitializeComponent();
        }

        
        private void Button_Click_ShowAll(object sender, RoutedEventArgs e)
        {
            Manager.Content = new RoomsPage();
            //this.Manager.Navigate(typeof(RoomsPage));
            //Model.AllRoomPage win = new Model.AllRoomPage();
            //win.Show();
        }

        private void Button_Click_ShowEquipment(object sender, RoutedEventArgs e)
        {
            Manager.Content = new EquipmentsPage();
            //Model.AllEquipment win = new Model.AllEquipment();
            //win.Show();
        }

      
        private void Button_Click_ShowAllMedicine(object sender, RoutedEventArgs e)
        {
            Manager.Content = new MedicinesPage();
            //Model.AllMedicinePage win = new Model.AllMedicinePage();
            //win.Show();
        }

        private void Manager_Navigated(object sender, System.Windows.Navigation.NavigationEventArgs e)
        {

        }

        private void Button_Click_Profil(object sender, RoutedEventArgs e)
        {
            Manager.Content = new ProfilPage();
        }

        private void Button_Click_Logout(object sender, RoutedEventArgs e)
        {
           this.Hide();
        }
    }
}
