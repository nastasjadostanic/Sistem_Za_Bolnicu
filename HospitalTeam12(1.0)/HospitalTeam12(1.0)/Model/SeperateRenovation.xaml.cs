using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
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
    
    public partial class SeperateRenovation : Window
    {
        public SeperateRenovation()
        {
            InitializeComponent();
           
            this.DataContext = this;
            Room r = new Room();
            Rooms = new System.Collections.ObjectModel.ObservableCollection<Room>();
            string[] tmp = r.GetAll();
            for (int i = 0; i < tmp.Length; i++)
            {

                string[] words = tmp[i].Split();
                Rooms.Add(new Room { Id = words[0], Number = words[1], Floor = words[2], Description = words[3], RoomType = words[4] });


            }

            Time.Items.Add("07:00 AM");
            Time.Items.Add("08:00 AM");
            Time.Items.Add("09:00 AM");
            Time.Items.Add("10:00 AM");
            Time.Items.Add("11:00 AM");
            Time.Items.Add("12:00 AM");
            Time.Items.Add("01:00 PM");
            Time.Items.Add("02:00 PM");
        }

        public ObservableCollection<Room> Rooms { get; private set; }

        private void RoomUp_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            

        }

        private void Button_Click_Seperate(object sender, RoutedEventArgs e)
        {

            Renovations ren = new Renovations();
            Room r = (Room)RoomUp.SelectedItem;

            if (ren.SeperateOrNot((DateTime)DateAndTime.SelectedDate, Time.Text, r) == true)
            {
                Model.SeperateInto win = new Model.SeperateInto();
                win.Show();

            }
            else
            {
                MessageBox.Show("One of the rooms is not free at that time.", "", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            RoomUp.SelectedItem = null;
            DateAndTime.SelectedDate = null;
            Time.SelectedItem = null;

            //provera da li je slobodna 
            /*Room r = new Room();
            r = (Room)RoomUp.SelectedItem;
            DateTime dt = new DateTime();
            dt = (DateTime)DateAndTime.SelectedDate;
            string time = Time.Text;


            if (r.CheckIfRoomIsOccupied2(r, dt, time) == true)
            {
                Model.SeperateInto win = new Model.SeperateInto();
                win.Show();
                File.AppendAllText("Seperate.txt", r.Id + " " + r.Floor + "\n");
                //ako bi pamtili i datum i vreme radi zakazivanja
                //File.AppendAllText("Seperate.txt", r.Id + " " + r.Floor + " " + dt + " " + time + "\n");
                //brisanje prethodne sobe da bi se napravile dve nove
                r.Delete(r.Id);
;            }
            else 
            {
                MessageBox.Show("Room is not free at that time.", "", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            */
           
            
          
        }

        private void Time_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
