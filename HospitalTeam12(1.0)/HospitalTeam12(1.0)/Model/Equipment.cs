using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows;

namespace HospitalTeam12.Model
{
    public class Equipment
    {
        public Equipment SearchByID(string ID)
        {
            string[] lines = File.ReadAllLines("Equipment.txt");
            int i = 0;
            foreach (string staticequipment in lines)
            {
                string[] words = lines[i].Split();
                i++;

                if (ID == words[0])
                {
                    var eq = new Equipment();
                    eq.Id = words[0];
                    eq.Name = words[1];
                    eq.Quantity = words[2];
                    eq.Type = words[3];


                    return eq;
                }


            }

            return null;
        }
        public string[] GetAll()
        {
            string[] lines = File.ReadAllLines("Equipment.txt");
            return lines;

        }
        public Boolean Create(string ID, string Name, string Quantity, string Type, string Room)
        {
            string[] lines = File.ReadAllLines("Equipment.txt");
            int i = 0;
            foreach (string room in lines)
            {
                string[] words = lines[i].Split();
                i++;

                if (ID == words[0])
                    return false;


            }
            File.AppendAllText("Equipment.txt", ID + " " + Name + " " + Quantity + " " + Type + " " + Room + "\n");
            return true;

        }
        public Boolean Delete(String id)
        {

            string tempFile = Path.GetTempFileName();
            int i = 0;
            using (var sr = new StreamReader("Equipment.txt"))
            using (var sw = new StreamWriter(tempFile))
            {
                String lines;

                while ((lines = sr.ReadLine()) != null)
                {
                    string[] words = lines.Split();
                    if (id != words[0])
                    {
                        sw.WriteLine(lines);
                    }
                    i++;
                }
            }

            File.Delete("Equipment.txt");
            File.Move(tempFile, "Equipment.txt");
            return true;
        }
        public Boolean Update(string ID, string Name, string Quantity, string Type, string Room)
        {
            if (SearchByID(ID) != null)
            {
                Delete(ID);
                Create(ID, Name, Quantity, Type, Room);
            }

            return false;

        }
        public Boolean Schedule(string Id, string Name, string Quantity, string RoomId, DateTime date, string time)
        {

            // READING EQUIPMENT AND CHECKING QUANTITY
            string[] linesE = File.ReadAllLines("Equipment.txt");
            int i = 0;
            int pom = 0;
            foreach (string dinamic in linesE)
            {
                string[] words = linesE[i].Split();

                if (words[1] == Name)
                {
                    if (int.Parse(words[2]) < int.Parse(Quantity))
                    {
                        MessageBox.Show("You cannot move more equpment items then you have.", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
                        return false;
                    }
                    pom = int.Parse(words[2]) - int.Parse(Quantity);


                }

                i++;

            }
            //CHEKING IF ROOM IS OCCUPIED 
            Room r = new Room();
            r.Id = RoomId;
            bool RoomNotOccupied = r.CheckIfRoomIsOccupied(r,date,time);
            //false znaci zauzeza

            //true znaci slobodna

            //WRITING IN FILE AND UPDATING WHEN THE DATES MATCH
            if (RoomNotOccupied == true)
            {
                
                File.AppendAllText("Examinations.txt", GenerateIDForMovingEquipment().ToString() + " " + r.Number + " " + r.Floor + " " + "MovingEquipment" + " " + "MovingEquipment" + " " + "MovingEquipment" + " " + "MovingEquipment" + " " + r.DoctorNameLastNameFromRoom(r) + " " + r.DateConvertor(date) + " " + r.TimeConvertor(time) + "\n");
                
                File.AppendAllText("ScheduleMovingEquipment.txt", Id + " " + Name + " " + Quantity + " " + RoomId + " " + date + "\n");
                Equipment se = new Equipment();
                if (DateTime.Now == date)
                {
                    se.Update(Id, Name, pom.ToString(), "Static", RoomId);
                }

            }
            else 
            {
                MessageBox.Show("Room is occupied that date and time.", "", MessageBoxButton.OK, MessageBoxImage.Error);
                Model.StaticMovingPage win = new Model.StaticMovingPage();
                win.Show();
            }
            
            
            return true;
        }
        public int GenerateID()
        {

            string[] lines = File.ReadAllLines("Equipment.txt");

            int i = 0;
            int max = 0;
            foreach (string equipment in lines)
            {
                string[] words = lines[i].Split();

                if (int.Parse(words[0]) > max)
                    max = int.Parse(words[0]);
                i++;
            }
            max++;
            return max;
        }
        public Boolean Deploy(string Id, string Name, string Quantity)
        {

            string[] lines = File.ReadAllLines("Equipment.txt");
            int i = 0;
            int pom = 0;
            foreach (string dinamic in lines)
            {
                string[] words = lines[i].Split();
                if (words[1] == Name)
                {
                    if (int.Parse(words[2]) < int.Parse(Quantity))
                    {
                        MessageBox.Show("You cannot deploy more equpment items then you have.", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
                        return false;
                    }
                    pom = int.Parse(words[2]) - int.Parse(Quantity);

                }

                i++;

            }
            Update(Id, Name, pom.ToString(), "Dinamic", "Stockroom");
            File.AppendAllText("DeployedEquipment.txt", Id + " " + Name + " " + Quantity + "\n");
            return true;
        }



        //ZA 4 KONTROLNU TACKU FILTRIRANJE I SEARCH

        public string GenerateIDForMovingEquipment()
        {
            string[] lines = File.ReadAllLines("Examinations.txt");
            int i = 0;
            int max = 0;
            foreach (string exam in lines)
            {
                string[] words = lines[i].Split();

                if (int.Parse(words[0]) > max)
                    max = int.Parse(words[0]);
                i++;
            }
            max = max + 200;
            return max.ToString();
        }
        public string[] ReadLinesEquipment()
        {
            string[] lines = File.ReadAllLines("Equipment.txt");
            return lines;
        }
        public ArrayList FilterByType(string InputByUser)
        {
            string[] lines = ReadLinesEquipment();
            
            int i = 0;
            ArrayList rez = new ArrayList();
          
            foreach (string equipment in lines)
            {
                string[] words = lines[i].Split();
                i++;

                if (InputByUser == words[3])
                {
                    Equipment eq = new Equipment();
                    eq.Id = words[0];
                    eq.Name = words[1];
                    eq.Quantity = words[2];
                    eq.Type = words[3];
                    rez.Add(eq);
                    
                }
            }
            return rez;  
        }
        public ArrayList FilterByRoom(string InputByUser)
        {
            string[] lines = ReadLinesEquipment();

            int i = 0;
            ArrayList rez = new ArrayList();
            foreach (string equipment in lines)
            {
                string[] words = lines[i].Split();
                i++;

                if (InputByUser == words[4])
                {
                    Equipment eq = new Equipment();
                    eq.Id = words[0];
                    eq.Name = words[1];
                    eq.Quantity = words[2];
                    eq.Type = words[3];
                    rez.Add(eq);
                }
            }
            return rez;
        }
        public ArrayList Search(string InputByUser)
        {
            string[] lines = ReadLinesEquipment();
            int i = 0;
            ArrayList rez = new ArrayList();
            foreach (string equipment in lines)
            {
                string[] words = lines[i].Split();
                i++;

                if (InputByUser == words[0] || InputByUser == words[1] || InputByUser == words[2])
                {
                    Equipment eq = new Equipment();
                    eq.Id = words[0];
                    eq.Name = words[1];
                    eq.Quantity = words[2];
                    eq.Type = words[3];
                    Room room = new Room();
                    room = room.SearchByID(words[4]);
                    eq.Room = room.Id;
                    rez.Add(eq);
                    return rez;
                }
            }
            return null;
        }

        //ZA 5 KONTROLNU TACKU
        public void MoveWhenMerging(int roomID) {

            string[] lines = ReadLinesEquipment();
            int i = 0;
            Renovations ren = new Renovations();
            foreach (string eq in lines)
            {
                string[] words = lines[i].Split();
                i++;

                Equipment equipWanted1 = SearchByID(words[0]);

                if (ren.GetRoom1Id() == words[4]) //kada se nadje equipment koji je bio u sobi br 1 promeni mu samo da se nalazi u novoj sobi
                {
                    equipWanted1.Update(equipWanted1.Id, equipWanted1.Name, equipWanted1.Quantity, equipWanted1.Type, roomID.ToString());
                }

                Equipment equipWanted2 = SearchByID(words[0]);

                if (ren.GetRoom2Id() == words[4]) //kada se nadje equipment koji je bio u sobi br 2 promeni mu samo da se nalazi u novoj sobi
                {
                    equipWanted2.Update(equipWanted2.Id, equipWanted2.Name, equipWanted2.Quantity, equipWanted2.Type, roomID.ToString());
                }

            }
        }
        public void MoveWhenSeperating(int room1ID, int room2ID)
        {
            string[] lines = File.ReadAllLines("Equipment.txt");
            Renovations ren = new Renovations();
            int i = 0;
            foreach (string eq in lines)
            {
                string[] words = lines[i].Split();
                i++;
                if (ren.GetRoomId() == words[4]) //kada se nadje equipment koji je bio u sobi koju razdvajamo
                {
                    Equipment equipWanted = SearchByID(words[0]);

                    //sad mu smanji kolicinu za pola i kazi da je u prvoj novoj sobi , i napravi novi equipment sa polovinom i kazi da je u drugoj novoj sobi
                    equipWanted.Update(equipWanted.Id, equipWanted.Name, (int.Parse(equipWanted.Quantity) / 2).ToString(), equipWanted.Type, room1ID.ToString());
                    // forsiran creade jer on ne radi iz nekog razloga
                    File.AppendAllText("Equipment.txt", GenerateID().ToString() + " " + equipWanted.Name + " " + (int.Parse(equipWanted.Quantity) / 2).ToString() + " " + equipWanted.Type + " " + (room1ID + 1).ToString() + "\n");


                }
            }
        }


        public String Id { get; set; }
        public String Name { get; set; }
        public String Quantity { get; set; }
        public String Type { get; set; }
        public String Room { get; set; }
       
    
    }
}
