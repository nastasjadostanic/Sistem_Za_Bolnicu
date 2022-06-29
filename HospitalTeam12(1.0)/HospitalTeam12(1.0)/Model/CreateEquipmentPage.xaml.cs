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

namespace HospitalTeam12.Model
{
    /// <summary>
    /// Interaction logic for CreateEquipmentPage.xaml
    /// </summary>
    public partial class CreateEquipmentPage : Window
    {
        public CreateEquipmentPage()
        {
            InitializeComponent();
            TYPE.Items.Add("Static");
            TYPE.Items.Add("Dinamic");


            Room r = new Room();
            string[] rooms = r.GetAll();
            for (int i = 0; i < rooms.Length; i++)
            {
                string[] words = rooms[i].Split();
                ROOM.Items.Add(words[0]);

            }
            /*
            proci kroz sobe i dodati ih u combox ROOM
            onda spram toga ako je dinamicka room staviti da je magacin uvek
             */


        }

        private void ComboBox_SelectionChanged_TYPE(object sender, SelectionChangedEventArgs e)
        {

        }

        private void ComboBox_SelectionChanged_ROOM(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click_Create(object sender, RoutedEventArgs e)
        {
            Equipment eq = new Equipment();
            if (TYPE.Text == "Dinamic")
            {

                eq.Create(eq.GenerateID().ToString(), NAME.Text, QUANTITY.Text, TYPE.Text, "Stockroom");
                ROOM.Items.Clear();
                ROOM.Items.Add("Stockroom");

            }
            else
               
            eq.Create(eq.GenerateID().ToString(), NAME.Text, QUANTITY.Text, TYPE.Text, ROOM.Text);

            NAME.Text = "";
            QUANTITY.Text = "";
            TYPE.Text = "";
            ROOM.Text = "";
        }
    }
}
