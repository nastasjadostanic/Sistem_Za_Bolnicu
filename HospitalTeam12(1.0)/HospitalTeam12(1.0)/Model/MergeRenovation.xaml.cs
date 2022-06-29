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
    /// <summary>
    /// Interaction logic for MergeRenovation.xaml
    /// </summary>
    public partial class MergeRenovation : Window
    {
        public MergeRenovation()
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

        public ObservableCollection<Room> Rooms { get; }

        private void Button_Click_Merge(object sender, RoutedEventArgs e)
        {
            //provera da li su obe slobodne
            /*Room r = new Room();
            Room r2 = new Room();
            r = (Room)RoomUp.SelectedItem;
            r2 = (Room)RoomUp2.SelectedItem;
            DateTime dt = new DateTime();
            dt = (DateTime)DateAndTime.SelectedDate;
            string time = Time.Text;


            if (r.CheckIfRoomIsOccupied2(r, dt, time) == true && r2.CheckIfRoomIsOccupied2(r, dt, time) == true)
            {
                //provera da li su na istom spratu
                if (r.Floor==r2.Floor) 
                { 
                    Model.MergeInto win = new Model.MergeInto();
                    win.Show();
                    File.AppendAllText("Merge.txt", r.Id + " " + r.Floor + " " + r2.Id + "\n");
                    //brisanje prethodne dve da bi se napravila jedna
                    r.Delete(r.Id);
                    r2.Delete(r2.Id);  
                }
               
            }
            else
            {
                MessageBox.Show("One of the rooms is not free at that time.", "", MessageBoxButton.OK, MessageBoxImage.Error);
            }*/
          
            Renovations ren = new Renovations();
         
            Room r1 = (Room)RoomUp.SelectedItem;
            Room r2 = (Room)RoomUp2.SelectedItem;

            if (ren.MergeOrNot((DateTime)DateAndTime.SelectedDate, Time.Text, r1, r2) == true)
            {
                Model.MergeInto win = new Model.MergeInto();
                win.Show();
                
            }
            else
            {
                MessageBox.Show("One of the rooms is not free at that time.", "", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            RoomUp.SelectedItem = null;
            DateAndTime.SelectedDate = null;
            Time.SelectedItem = null;

            
        }

        private void RoomUp_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void RoomUp_SelectionChanged2(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Time_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
