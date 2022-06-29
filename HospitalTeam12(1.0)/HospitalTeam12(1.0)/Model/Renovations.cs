using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows;

namespace HospitalTeam12.Model
{
    class Renovations
    {   //osnovno renoviranje 
        public string[] ReadLinesExaminations()
        {
            string[] lines = File.ReadAllLines("Examinations.txt");
            return lines;
        }
        public string DateConvertor(DateTime dt)
        {
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

            string allTime = hour + " " + min;

            return allTime;
        }
        public Boolean CheckIfRoomIsOccupied2(Room r, DateTime dt, string time)
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
                if (words[1] == r.Number && words[2] == r.Floor && (words[9] + " " + words[10] + " " + words[11]) == allDate && (words[12] + " " + words[13]) == allTime)
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
        public Boolean ScheduleMoving(Room r, DateTime dt, string time)
        {
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
        public string DoctorNameLastNameFromRoom(Room r)
        {

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
            max = max + 200;
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

        //za spajanje
        
        public Boolean AreBothRoomsFree(DateTime dt, string time,Room r1, Room r2) {

            Room r = new Room();
            
            if (r1.CheckIfRoomIsOccupied2(r, dt, time) == true && r2.CheckIfRoomIsOccupied2(r, dt, time) == true)
            { 
                return true;
            }

            return false;
        }
        public Boolean AreBothOnSameFloor(Room r1, Room r2) {
            if (r1.Floor == r2.Floor)
            {
                return true;

            }
            else return false;
        }
        public Boolean MergeOrNot(DateTime dt, string time, Room r1, Room r2) {
            if (AreBothRoomsFree(dt, time, r1, r2) == true && AreBothOnSameFloor(r1, r2) == true)
            {
                ScheduleMerging(dt,time,r1,r2);
                return true;
            }
            else return false;   
        }
        public int GenerateIdForNewRoom() {
            Room rNew = new Room();
            int rID = rNew.GenerateID();
            return rID;
        }
        public string FindFloorOfRoomsBefore() {
            string[] lines = File.ReadAllLines("Merge.txt");
            string[] words = lines[0].Split();
            return words[1];
        }
        public void Merge(string Id, string Number, string Floor, string Description, string Type) {

            Room rNew = new Room();
            rNew.Create(Id, Number, Floor, Description, Type);

        }
        public string GetRoom1Id()
        {
            string[] lines = File.ReadAllLines("Merge.txt");
            string[] words = lines[0].Split();
            return words[0];
        }
        public string GetRoom2Id()
        {
            string[] lines = File.ReadAllLines("Merge.txt");
            string[] words = lines[0].Split();
            return words[2];
        }
        public void DeleteRoomsThatAreMerged() 
        {
            Room r = new Room();
            r.Delete(GetRoom1Id());
            r.Delete(GetRoom2Id());

        }
        public void ScheduleMerging(DateTime dt, string time, Room r1, Room r2) 
        {
            string[] date = dt.ToString().Split();

            File.AppendAllText("Merge.txt", r1.Id + " " + r1.Floor + " " + r2.Id  + "\n");
            File.AppendAllText("AdvancedRenovations.txt", r1.Id + " " + r2.Id + " " + date[0] + " " + time +  " " + "Merging" + "\n");
            
        }
        public string GetDate()
        {
            string[] lines = File.ReadAllLines("AdvancedRenovations.txt");
            string[] words = lines[0].Split();
            return words[3];
        }
       
        
        //za razdvajanje 
        
        public Boolean IsRoomFree(DateTime dt, string time, Room r1)
        {
            Room r = new Room();

            if (r1.CheckIfRoomIsOccupied2(r, dt, time) == true )
            {
                return true;
            }

            return false;
        }
        public Boolean SeperateOrNot(DateTime dt, string time, Room r)
        {
            if (IsRoomFree(dt, time, r) == true)
            {
                ScheduleSeparating(dt, time, r);
                return true;
            }
            else return false;
        }
        public string FindFloorOfRoomBefore()
        {
            string[] lines = File.ReadAllLines("Seperate.txt");
            string[] words = lines[0].Split();
            return words[1];
        }
        public void Seperate(string Id, string Number, string Floor, string Description, string Type) 
        {
            Room rNew = new Room();
            rNew.Create(Id, Number, Floor, Description, Type);
        }
        public string GetRoomId()
        {
            string[] lines = File.ReadAllLines("Seperate.txt");
            string[] words = lines[0].Split();
            return words[0];
        }
        public void DeleteRoomThatIsSeperated()
        {
            Room r = new Room();
            r.Delete(GetRoomId());
            
        }
        public void ScheduleSeparating(DateTime dt, string time, Room r)
        {
            string[] date = dt.ToString().Split();
            File.AppendAllText("Seperate.txt", r.Id + " " + r.Floor + "\n");
            File.AppendAllText("AdvancedRenovations.txt", r.Id + " " +  date + " " + time + " " + "Seperating" + "\n");
            
        }
    }
}
 