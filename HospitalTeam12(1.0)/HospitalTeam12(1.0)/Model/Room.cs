
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Windows;
using MainPackage.Model;
using System.Collections;

public class Room //: INotifyPropertyChanged
{
    //public Room(string I, string N, string F, string D, string T ) { Id = I; Number = N;Floor = F;Description = D;RoomType = T; }
    //public Room() { }
  /* public event PropertyChangedEventHandler PropertyChanged;
   protected virtual void OnPropertyChanged(string name)
    {
        if (PropertyChanged != null)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(name));
        }
    }*/


    public Boolean Create(string id, string numb, string fl, string desc, string typ)
    {
        string[] lines = File.ReadAllLines("Rooms.txt");
        int i = 0;
        foreach (string room in lines)
        {
            string[] words = lines[i].Split();
            i++;

            if (Id == words[3])
                return false;



        }
        File.AppendAllText("Rooms.txt", id + " " + numb + " " + fl + " " + desc + " " + typ + "\n");
        return true;

    }
    public int GenerateID()
    {
        string[] lines = File.ReadAllLines("Rooms.txt");

        int i = 0;
        int max = 0;
        foreach (string room in lines)
        {
            string[] words = lines[i].Split();

            if (int.Parse(words[0]) > max)
                max = int.Parse(words[0]);
            i++;
        }
        max++;
        return max;
    }
    public Room SearchByID(string ID)
    {
        string[] lines = File.ReadAllLines("Rooms.txt");
        int i = 0;
        foreach (string room in lines)
        {
            string[] words = lines[i].Split();
            i++;

            if (ID == words[0])
            {
                var r = new Room();
                r.Id = words[0];
                r.Number = words[1];
                r.Floor = words[2];
                r.Description = words[3];
                r.RoomType = words[4];
                
                return r;
            }


        }


        return null;
    }
    public string[] GetAll()
    {
        string[] lines = File.ReadAllLines("Rooms.txt");
        return lines;
    }
    public Boolean Update(string ID, string Number, string Floor, string Description, string RoomType)
    {
        if (SearchByID(ID) != null)
        {
            Delete(ID);
            Create(ID, Number, Floor, Description, RoomType);
        }

        return false;
    }
    public Boolean Delete(string ID)
    {
        string[] lines = File.ReadAllLines("Rooms.txt");

        int i = 0;
        foreach (string room in lines)
        {
            string[] words = lines[i].Split();
            i++;
            if (ID != words[0])
                File.AppendAllText("Rooms2.txt", lines[i-1] + "\n");


        }

        File.Delete("Rooms.txt");
        File.Move("Rooms2.txt", "Rooms.txt");
        return true;
    }


    //ZA KONTROLNU TACKU 4 ZAKAZIVANJE RENOVIRANJA
    
    public string[] ReadLinesExaminations() {
    string[] lines = File.ReadAllLines("Examinations.txt");
    return lines;
    }
    public string DateConvertor(DateTime dt) {
        string date = dt.ToString();
        int day;
        int month;
        int year;
        int hour;
        int min;
        string[] firstSplit = date.Split();

        string[] secondSplit = firstSplit[0].Split('/');
        day = int.Parse(secondSplit[1]);
        month = int.Parse(secondSplit[0]);
        year = int.Parse(secondSplit[2]);

        string[] thirdSplit = firstSplit[1].Split(':');
        hour = int.Parse(thirdSplit[0]);
        min = int.Parse(thirdSplit[1]);

        string allDate = day + " " + month + " " + year;
        // (firstSplit[2] == "PM") hour += 12;
        return allDate;
    }
    public string TimeConvertor(string time)
    {
        int hour;
        int min;
        string[] times = new string[2];
        times = time.ToString().Split();
        string[] times2 = new string[2];
        times2 = times[0].Split(':');
        hour = int.Parse(times2[0]);
        min = int.Parse(times2[1]);

        string allTime = hour + " " + min ;
        
        return allTime;
    }
    public Boolean CheckIfRoomIsOccupied2(Room r, DateTime dt, string time ) 
    {
        string[] lines = ReadLinesExaminations();
        string allDate = DateConvertor(dt);
        string allTime = TimeConvertor(time); 
        int i = 0;
        
        foreach (string exam in lines)
        {
            string[] words = lines[i].Split(); 
            i++;
            //if room occupied
            if (words[1] == r.Number && words[2] == r.Floor && (words[9] + " " + words[10] + " " +words[11]) == allDate  && (words[12] + " " + words[13]) == allTime)
            {
                return false;
            }
           
        }
            return true;      
    }
    public Boolean ScheduleMovingOrNot(Room r, DateTime dt, string time) 
    {
        if (CheckIfRoomIsOccupied(r, dt, time) == true)
        {
            ScheduleMoving(r, dt, time);
        }
        else DontScheduleMoving();

        return true;
    }
    public Boolean ScheduleMoving(Room r, DateTime dt, string time) {
        string[] date = new string[2];
        date = dt.ToString().Split();
        string dateAll = DateConvertor(dt);
        string timeAll = TimeConvertor(time);
        string doctorAll = DoctorNameLastNameFromRoom(r);
        File.AppendAllText("RoomRenovations.txt", r.Id + " " + date[0] + " " + time + "\n");
        File.AppendAllText("Examinations.txt", GenerateIDForRenovations().ToString() + " " + r.Number + " " + r.Floor + " " + "Renovation" + " " + "Renovation" + " " + "Renovation" + " " + "Renovation" + " " + doctorAll + " " + dateAll + " " + timeAll + "\n");
        
        return true;
    }
    public Boolean DontScheduleMoving()
    {
        MessageBox.Show("Room is occupied that date and time.", "", MessageBoxButton.OK, MessageBoxImage.Error);
        HospitalTeam12.Model.RenovationDateAndTime win = new HospitalTeam12.Model.RenovationDateAndTime();
        win.Show();

        return true;
    }
    public string DoctorNameLastNameFromRoom(Room r) {
       
        string NameLastName = null;
        string[] lines = ReadLinesExaminations();
        int i = 0;
        
        foreach (string exam in lines)
        {
            string[] words = lines[i].Split();
            i++;
            if (words[1] == r.Number && words[2] == r.Floor) 
            {
                NameLastName = words[7] + " " + words[8];
               
            }
        }
        return NameLastName; 
    }  
    public string GenerateIDForRenovations()
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
        max=max+200;
        return max.ToString();
    }
    public Boolean CheckIfRoomIsOccupied(Room r, DateTime dt, string time)
    {
        string[] lines = ReadLinesExaminations();
        string allDate = DateConvertor(dt);
        string allTime = TimeConvertor(time);
        int i = 0;
        bool examIsFree = true;
        foreach (string exam in lines)
        {
            string[] words = lines[i].Split();
            i++;
            //if room occupied
            if (words[1] == r.Number && words[2] == r.Floor && (words[9] + " " + words[10] + " " + words[11]) == allDate && (words[12] + " " + words[13]) == allTime)
            {
                MessageBox.Show("Room is occupied that date and time.", "", MessageBoxButton.OK, MessageBoxImage.Error);
                examIsFree = false;
                HospitalTeam12.Model.RenovationDateAndTime win = new HospitalTeam12.Model.RenovationDateAndTime();
                win.Show();

            }

        }
        //room not occupied you can schedule
        if (examIsFree == true)
        {
            ScheduleMoving(r, dt, time);
        }

        return true;
    }

    // START doctor features =========================================================

    public ArrayList ViewAllHospitalRooms()
    {
        string[] lines = File.ReadAllLines("Rooms.txt");
        int i = 0;

        ArrayList res = new ArrayList();
        foreach (string item in lines)
        {
            string[] words = lines[i].Split();
            i++;

            if(words[4]=="HospitalRoom")
            {
                var room = new Room();
                room.Id = words[0];
                room.Number = words[1];
                room.Floor = words[2];
                room.Description = words[3];
                room.RoomType = words[4];
                res.Add(room);
            }

        }
        return res;
    }

    // ENDED doctor features =========================================================

    public String Id { get; set; }
    public String Number { get; set; }
    public String Floor { get; set; }
    public String Description { get; set; }
    public String RoomType { get; set; }
    
}