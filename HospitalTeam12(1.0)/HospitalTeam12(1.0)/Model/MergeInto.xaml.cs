using System;
using System.Collections.Generic;
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
    public partial class MergeInto : Window
    {
        public MergeInto()
        {
            InitializeComponent();
            TYPE.Items.Add("Office");
            TYPE.Items.Add("OpperationRoom");
            TYPE.Items.Add("HospitalRoom");
        }

        private void Button_Click_Merge(object sender, RoutedEventArgs e)
        {
            Renovations ren = new Renovations();
            int ID = ren.GenerateIdForNewRoom();

            ren.Merge(ID.ToString(), NUMBER.Text, ren.FindFloorOfRoomsBefore(), DESCRIPTION.Text, TYPE.Text);
            Equipment equip = new Equipment();
            equip.MoveWhenMerging(ID);

            ren.DeleteRoomsThatAreMerged();


            //KADA BI RADILI SA ZAKAZIVANJE<
            /*string dateNow = DateTime.Now.ToString();
            if (dateNow == ren.GetDate())
            { 
                ren.Merge(ID.ToString(), NUMBER.Text, ren.FindFloorOfRoomsBefore(), DESCRIPTION.Text, TYPE.Text); 
            
            
                Equipment equip = new Equipment();
                equip.MoveWhenMerging(ID);

                ren.DeleteRoomsThatAreMerged();
            }*/
            
            
             
            
           

            File.Create("Merge.txt");

            //ciscenje forme
            NUMBER.Text = "";
            DESCRIPTION.Text = "";
            TYPE.Text = "";

            /*Room r = new Room();
            Room r2 = new Room();
            //moved
            Room rNew = new Room();
            int rID = rNew.GenerateID();
            //moved 
            string[] lines = File.ReadAllLines("Merge.txt");
            string[] wordsM = lines[0].Split(); //da bismo nasli sprat prethodne sobe, jer nove sobe moraju biti na tom spratu
            
            //Equipment equip = new Equipment();
            string[] linesE = File.ReadAllLines("Equipment.txt");
            int i = 0;
            foreach (string eq in linesE)
            {
                string[] wordsE = linesE[i].Split();
                i++;
               
                
                Equipment equipWanted1 = equip.SearchByID(wordsE[0]);

                if (ren.GetRoom1Id() == wordsE[4]) //kada se nadje equipment koji je bio u sobi br 1 promeni mu samo da se nalazi u novoj sobi
                {
                    equipWanted1.Update(equipWanted1.Id, equipWanted1.Name, equipWanted1.Quantity, equipWanted1.Type, ID.ToString());
                }

                Equipment equipWanted2 = equip.SearchByID(wordsE[2]);

                if (ren.GetRoom2Id() == wordsE[4]) //kada se nadje equipment koji je bio u sobi br 2 promeni mu samo da se nalazi u novoj sobi
                {
                    equipWanted2.Update(equipWanted2.Id, equipWanted2.Name, equipWanted2.Quantity, equipWanted2.Type, ID.ToString());
                }
              
            }*/




        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
