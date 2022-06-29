using MainPackage.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
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
    public partial class RoomsPage
    {

        public ObservableCollection<Room> Rooms { get; set; }

        public RoomsPage()
        {
            this.InitializeComponent();
            this.DataContext = this;
            Room r = new Room();
            Rooms = new System.Collections.ObjectModel.ObservableCollection<Room>();
            string[] tmp = r.GetAll();
            for (int i = 0; i < tmp.Length; i++)
            {

                string[] words = tmp[i].Split();
                
                Rooms.Add(new Room { Id = words[0], Number = words[1], Floor = words[2], Description = words[3], RoomType = words[4] });


            }


        }

        public void Button_Click_Create(object sender, RoutedEventArgs e)
        {
            //KAKO DA SA OVOG OTVORIM NESTO U FRAME NAZVAN MANAGER NA STRANICI MANAGER.PAGE
           // Model.ManagerPage.Manager = new CreateRoom();
           
            Model.CreateRoomPage win = new Model.CreateRoomPage();
            win.Show();
        }



        private void Button_Click_Update(object sender, RoutedEventArgs e)
        {
            var r = new Room();
            r.Update(Id.Text, Num.Text, Fl.Text, Des.Text, Ty.Text);
            Id.Text = "";
            Num.Text = "";
            Fl.Text = "";
            Des.Text = "";
            Ty.Text = "";

        }

        private void Button_Click_Delete(object sender, RoutedEventArgs e)
        {
            if (Rooms.Count > 0)
            {

                Room r = new Room();
                r = (Room)RoomUp.SelectedItem;
                r.Delete(r.Id);

            }
            else
            {
                MessageBox.Show("It is not possible to delete from empty table.", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            //this.Hide();
            //Model.AllRoomPage win = new Model.AllRoomPage();
            //win.Show();


        }

        
        private void RoomUp_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click_Reload(object sender, RoutedEventArgs e)
        {

        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click_Renovation(object sender, RoutedEventArgs e)
        {
            Model.ChooseRenovation win = new Model.ChooseRenovation();
            win.Show();
           // Model.RenovationDateAndTime win = new Model.RenovationDateAndTime();
            //win.Show();
        }

       
    }
}
