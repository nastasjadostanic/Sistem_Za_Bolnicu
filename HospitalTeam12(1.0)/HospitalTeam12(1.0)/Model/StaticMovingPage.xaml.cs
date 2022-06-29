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
    public partial class StaticMovingPage : Window
    {
        
        Equipment se = new Equipment();
        public StaticMovingPage()
        {  
            InitializeComponent();
            
            // EQUIPMENT TABLE

            this.DataContext = this;
            Equipment eq = new Equipment();
            EquipmentBinding eqb = new EquipmentBinding();
            Statics = new System.Collections.ObjectModel.ObservableCollection<EquipmentBinding>();
            string[] equip = eq.GetAll();


            for (int i = 0; i < equip.Length; i++)
            {
                string[] words = equip[i].Split();
                     if (words[3]=="Static")
                     {
                        Statics.Add(new EquipmentBinding { Id = words[0], Name = words[1], Quantity = words[2], Room = words[3] });
                     }
            }
            // ROOM TABLE

            this.DataContext = this;
            Room r = new Room();
            Roomsi = new ObservableCollection<Room>();
            string[] roo = r.GetAll();
            for (int i = 0; i < roo.Length; i++)
            {

                string[] words = roo[i].Split();

                Roomsi.Add(new Room { Id = words[0], Number = words[1], Floor = words[2], Description = words[3], RoomType = words[4] });


            }
        }

        public ObservableCollection<EquipmentBinding> Statics { get; }
        public ObservableCollection<Room> Roomsi { get; }

        private void StaticUp_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void RoomUp_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click_Schedule(object sender, RoutedEventArgs e)
        {
            EquipmentBinding se = (EquipmentBinding)StaticUp.SelectedItem;
            Room r = (Room)RoomUp.SelectedItem;
           
            if (se.Room == r.Id) 
            {
                MessageBox.Show("You cannot move equipment in th room where it already is.", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            
            Equipment s = new Equipment();
            s.Schedule(se.Id, se.Name, Qu.Text, r.Id, (DateTime)MoveDate.SelectedDate, TIME.Text );
            //Clear form of equipment
            Na.Text = "";
            Qu.Text = "";
            Ro.Text = "";
            //Clear form of room
            Num.Text = "";
            Des.Text = "";
            Fl.Text = "";
            Ty.Text = "";

            MoveDate.SelectedDate = null;
            TIME.Text = "";

        }
    }
}
