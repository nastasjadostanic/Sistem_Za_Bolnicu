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

    public partial class SeperateInto : Window
    {
        public SeperateInto()
        {
            InitializeComponent();
            TYPE.Items.Add("Office");
            TYPE.Items.Add("OperationRoom");
            TYPE.Items.Add("HospitalRoom");

            TYPE2.Items.Add("Office");
            TYPE2.Items.Add("OperationRoom");
            TYPE2.Items.Add("HospitalRoom");
        }

        private void Button_Click_Schedule(object sender, RoutedEventArgs e)
        {
            Renovations ren = new Renovations();
            int ID1 = ren.GenerateIdForNewRoom();
            int ID2 = ren.GenerateIdForNewRoom();

            ren.Seperate(ID1.ToString(), NUMBER.Text,ren.FindFloorOfRoomBefore(), DESCRIPTION.Text, TYPE.Text);
            ren.Seperate(ID2.ToString(), NUMBER.Text,ren.FindFloorOfRoomBefore(), DESCRIPTION.Text, TYPE.Text);

            Equipment equip = new Equipment();
            equip.MoveWhenSeperating(ID1, ID2);

            ren.DeleteRoomThatIsSeperated();


            //KADA BI RADILI SA ZAKAZIVANJEM
           /* string dateNow = DateTime.Now.ToString();
            if (dateNow == ren.GetDate())
            {
                ren.Seperate(ID1.ToString(), NUMBER.Text, ren.FindFloorOfRoomBefore(), DESCRIPTION.Text, TYPE.Text);
                ren.Seperate(ID2.ToString(), NUMBER.Text, ren.FindFloorOfRoomBefore(), DESCRIPTION.Text, TYPE.Text);

                Equipment equip = new Equipment();
                equip.MoveWhenSeperating(ID1, ID2);

                ren.DeleteRoomThatIsSeperated();
            }*/

           

            //resetovanje fajla da bi bio prazan za novo razdvajanje
            File.Create("Seperate.txt");
            //ciscenje forme
            NUMBER.Text = "";
            DESCRIPTION.Text = "";
            TYPE.Text = "";
            NUMBER2.Text = "";
            DESCRIPTION2.Text = "";
            TYPE2.Text = "";


            /*string[] lines = File.ReadAllLines("Seperate.txt");
            string[] wordsS = lines[0].Split(); //da bismo nasli sprat prethodne sobe, jer nove sobe moraju biti na tom spratu
            
            // kreiranjedve sobe uzimajuci podatke sa formi
       
            Room r = new Room();
            Room r2 = new Room(); 
            int rID = r.GenerateID();
            int r2ID = r2.GenerateID();
            r.Create(rID.ToString(), NUMBER.Text, wordsS[1], DESCRIPTION.Text, TYPE.Text);
            r2.Create(r2ID.ToString(), NUMBER2.Text, wordsS[1], DESCRIPTION2.Text, TYPE2.Text);

            //rasporedjivanje opreme. svu opremu iz prethodne sobe podeliti na dva dela i staviti u nove sobe
            //dakle prvo ucitamo iz equipment.txt pronadjemo svu opremu koja je u sobi upisanoj u seperate.txt onda uzmemo njihovu kolicinu podelimo 
            //na dva dela i razmestimo u nove sobe
            Equipment equip = new Equipment();
            string[] linesE = File.ReadAllLines("Equipment.txt");
            int i = 0;
            foreach (string eq in lines)
            {
                string[] wordsE = linesE[i].Split();
                i++;
                if (wordsS[0] == wordsE[4]) //kada se nadje equipment koji je bio u sobi koju razdvajamo
                {
                    Equipment equipWanted = equip.SearchByID(wordsE[0]);
                    //sad mu smanji kolicinu za pola i kazi da je u prvoj novoj sobi , i napravi novi equipment sa polovinom i kazi da je u drugoj novoj sobi
                    equipWanted.Update(equipWanted.Id, equipWanted.Name, (int.Parse(equipWanted.Quantity) / 2).ToString(), equipWanted.Type, rID.ToString());
                    equip.Create(equip.GenerateID().ToString(), equip.Name, (int.Parse(equip.Quantity) / 2).ToString(), equip.Type, r2ID.ToString());

                    
                }
            }*/


        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void ComboBox_SelectionChanged2(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
