using System;
using System.Collections;
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
    /// <summary>
    /// Interaction logic for EquipmentsPage.xaml
    /// </summary>
    public partial class EquipmentsPage : Page
    {
        public EquipmentsPage()
        {
            InitializeComponent();
            this.DataContext = this;
            Equipment eq = new Equipment();
            EquipmentBinding eqb = new EquipmentBinding();
            Equipments = new System.Collections.ObjectModel.ObservableCollection<EquipmentBinding>();
            string[] tmp = eq.GetAll();
            for (int i = 0; i < tmp.Length; i++)
            {
                string[] words = tmp[i].Split();
                Equipments.Add(new EquipmentBinding { Id = words[0], Name = words[1], Quantity = words[2], Type = words[3], Room = words[4] });
            }

            TYPE.Items.Add("Static");
            TYPE.Items.Add("Dinamic");
            Room r = new Room();
            string[] rooms = r.GetAll();
            for (int i = 0; i < rooms.Length; i++)
            {
                string[] words = rooms[i].Split();
                ROOM.Items.Add(words[0]);
            }
            ROOM.Items.Add("Stockroom");
        }

        public ObservableCollection<EquipmentBinding> Equipments { get; set; }

        private void StaticUp_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click_Create(object sender, RoutedEventArgs e)
        {
            Model.CreateEquipmentPage win = new Model.CreateEquipmentPage();
            win.Show();
        }

        private void Button_Click_Update(object sender, RoutedEventArgs e)
        {
            var eq = new Equipment();
            eq.Update(Id.Text, Na.Text, Qu.Text, Ty.Text, Ro.Text);
            Id.Text = "";
            Na.Text = "";
            Qu.Text = "";
            Ty.Text = ""; //ovo se moze staviti da je combo al to kasnije ako ostane vremena
            Ro.Text = "";
        }

        private void Button_Click_Delete(object sender, RoutedEventArgs e)
        {
            var eq = new EquipmentBinding();

            eq = (EquipmentBinding)EquipmentUp.SelectedItem;
            eq.Delete(eq.Id);
            Na.Text = "";
            Qu.Text = "";
            Ty.Text = "";
            Ro.Text = "";

            //this.Hide();
            Model.AllEquipment win = new Model.AllEquipment();
            win.Show();


        }
        private void Button_Click_Reload(object sender, RoutedEventArgs e)
        {
           // this.Hide();
            Model.AllEquipment win = new Model.AllEquipment();
            win.Show();
        }
        private void Button_Click_Move(object sender, RoutedEventArgs e)
        {

            if (Ty.Text == "Static")
            {
                Model.StaticMovingPage win = new Model.StaticMovingPage();
                win.Show();
            }
            else MessageBox.Show("You have to move static equipment.", "", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void Button_Click_Deploy(object sender, RoutedEventArgs e)
        {
            EquipmentBinding eq = new EquipmentBinding();
            eq = (EquipmentBinding)EquipmentUp.SelectedItem;
            if (eq == null)
                MessageBox.Show("You have to choose equipment first.", "", MessageBoxButton.OK, MessageBoxImage.Error);
            else
            {
                eq.Deploy(eq.Id, eq.Name, eq.Quantity);
                //this.Hide();
                Model.AllEquipment win = new Model.AllEquipment();
                win.Show();
            }

        }
        public ArrayList rez { get; set; }
        private void Button_Click_Search(object sender, RoutedEventArgs e)
        {
            EquipmentBinding eq = new EquipmentBinding();
            rez = eq.Search(InputByUser.Text);
            EquipmentUp.ItemsSource = rez;
        }

        private void TYPE_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void ROOM_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click_FilterT(object sender, RoutedEventArgs e)
        {
            EquipmentBinding eq = new EquipmentBinding();
            rez = eq.FilterByType(TYPE.Text);
            EquipmentUp.ItemsSource = rez;
        }

        private void Button_Click_FilterR(object sender, RoutedEventArgs e)
        {
            EquipmentBinding eq = new EquipmentBinding();
            rez = eq.FilterByRoom(ROOM.Text);
            EquipmentUp.ItemsSource = rez;
        }
    }
    
}
