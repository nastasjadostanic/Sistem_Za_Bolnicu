using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Text;
using System.Windows;

namespace HospitalTeam12.Model
{
    public class EquipmentBinding : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }
    
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

                if (ID == words[3])
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
                Create(ID, Name, Quantity,Type, Room);
            }

            return false;

        }

        public Boolean Schedule(string Id, string Name, string Quantity, string RoomId, string date)
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

            //WRITING IN FILE AND UPDATING WHEN THE DATES MATCH

            File.AppendAllText("ScheduleMovingEquipment.txt", Id + " " + Name + " " + Quantity + " " + RoomId + " " + date + "\n");
            Equipment se = new Equipment();
            if (DateTime.Now.ToString() == date)
            {
                se.Update(Id, Name, pom.ToString(),"Static", RoomId);
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
            Update(Id, Name, pom.ToString(),"Dinamic","Stockroom");
            File.AppendAllText("DeployedEquipment.txt", Id + " " + Name + " " + Quantity + "\n"); //nece ?
            return true;
        }
        public EquipmentBinding Search2(string InputByUser)
        {
            string[] lines = File.ReadAllLines("Equipment.txt");
            int i = 0;
            foreach (string equipment in lines)
            {
                string[] words = lines[i].Split();
                i++;

                if (InputByUser == words[0] || InputByUser == words[1] || InputByUser == words[2])
                {
                    var eq = new EquipmentBinding();
                    eq.Id = words[0];
                    eq.Name = words[1];
                    eq.Quantity = words[2];
                    eq.Type = words[3];
                    eq.Room = words[4];

                    return eq;
                }

            }
            return null;
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
                    
                    EquipmentBinding eq = new EquipmentBinding();
                    eq.Id = words[0];
                    eq.Name = words[1];
                    eq.Quantity = words[2];
                    eq.Type = words[3];
                    eq.Room = words[4];
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
                    EquipmentBinding eq = new EquipmentBinding();
                    eq.Id = words[0];
                    eq.Name = words[1];
                    eq.Quantity = words[2];
                    eq.Type = words[3];
                    eq.Room = words[4];
                    rez.Add(eq);
                    return rez;
                }
            }
            return null;
        }


        public EquipmentBinding() { }
        public String Id { get; set; }
        public String Name { get; set; }
        public String Quantity { get; set; }
        public String Type { get; set; }
        public String Room { get; set; }
    }
}
