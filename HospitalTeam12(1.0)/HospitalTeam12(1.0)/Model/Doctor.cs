using System;
using System.IO;
using System.Collections;


namespace MainPackage.Model
{
   public class Doctor
   {

      public Examination[] examination { get; set; }
        public Room room { get; set; }
        public User user { get; set; }

      //  public ArrayList Examination = new ArrayList();
        public ArrayList surgeries = new ArrayList();
        public String specialization { get; set; }


        public String[] IsItDoctorInTheSchedule(Doctor doctor)
        {
            string[] lines = File.ReadAllLines("Examinations.txt");
            int i = 0;
            String[] rez = new string[2];
            foreach (string examination in lines)
            {
                string[] words = lines[i].Split();
                i++;

                if (doctor.GetUser().FirstName == words[7] &&
                    doctor.GetUser().LastName == words[8])
                {
                    rez[0] = words[1];
                    rez[1] = words[2];
                    return rez;
                }
            }

            return null;
        }

        public int[] GetLastRoomAndFloorNumber()
        {
            string[] lines = File.ReadAllLines("Examinations.txt");
            int i = 0;
            int[] rez = new int[2];
            int maxRoom = 0;
            int maxFloor = 1;
            foreach (string examination in lines)
            {
                string[] words = lines[i].Split();
                i++;
                if (maxRoom < int.Parse(words[1]))
                {
                    maxRoom = int.Parse(words[1]);
                }
                if (maxFloor < int.Parse(words[2]))
                {
                    maxFloor = int.Parse(words[2]);
                }

            }
            rez[0] = maxRoom;
            rez[1] = maxFloor;

            return rez;
        }

        public void SetUser(User u)
        {
            this.user = u;
        }

        public User GetUser()
        {
            return user;
        }

        public void SetRoom(Room r)
        {
            this.room = r;
        }

        public Room GetRoom()
        {
            return room;
        }


        public string[] getAllRegularDoctors(ref int NumberOfRegularDoctors) {

            string[] tmp = new string[100];
            string[] lines = File.ReadAllLines("Doctors.txt");
            int i = 0;
            int j = 0;
            foreach (string line in lines)
            {
                string[] words = lines[i].Split();
                i++;
                if (words[9] == "OpstaPraksa")
                {
                    tmp[j] = lines[i-1];
                    j++;
                }
            }

            NumberOfRegularDoctors = j;
            return tmp;
        }

        public Doctor[] SearchDoctorsBySpecializastion(string Specialization, ref int nubmberOfDoctors) 
        
        {
            Doctor[] doctors = new Doctor[100];
            string[] lines = File.ReadAllLines("Doctors.txt");
            int i = 0;
            int j = 0;
            foreach (string drs in lines)
            {
                string[] words = lines[i].Split();
                i++;

                if (Specialization == words[9])
                {
                    var d = new Doctor();
                    var u = new User();
                    var r = new Room();

                    u.FirstName = words[0];
                    u.LastName = words[1];
                    u.DateOfBirth = words[2];
                    u.Jmbg = words[3];
                    u.Email = words[4];
                    u.Phone = words[5];
                    u.Address = words[6];
                    u.Username = words[7];
                    u.Password = words[8];


                    d.specialization = words[9];
                    r.Number = words[10];
                    r.Floor = words[11];
                    d.SetUser(u);
                    d.SetRoom(r);

                    doctors[j] = d;
                    j++;
                }


            }


            
            nubmberOfDoctors = j;
            return doctors;
        }
        public Doctor SearchDoctorByNameAndLastName(string FirstAndLast)
        {
            string[] lines = File.ReadAllLines("Doctors.txt");
            int i = 0;
            foreach (string drs in lines)
            {
                string[] words = lines[i].Split();
                i++;

                if (FirstAndLast == words[0]+ " " + words[1])
                {
                    var d = new Doctor();
                    var u = new User();
                    var r = new Room();

                    u.FirstName = words[0];
                    u.LastName = words[1];
                    u.DateOfBirth = words[2];
                    u.Jmbg = words[3];
                    u.Email = words[4];
                    u.Phone = words[5];
                    u.Address = words[6];
                    u.Username = words[7];
                    u.Password = words[8];

                    
                    d.specialization = words[9];
                    r.Number = words[10];
                    r.Floor = words[11];
                    d.SetUser(u);
                    d.SetRoom(r);


                    return d;
                }


            }


            // ako ga nema vrati null

            return null;
        }

        public void SetSpecialization(String s)
        {
            this.specialization = s;
        }

        public String GetSpecialization()
        {
            return specialization;
        }

        //KT4
        public int[] CurrentTimeToInt()
        {
            string timeNow = DateTime.Now.ToString();
            int day;
            int mnth;
            int year;
            int hour;
            int minute;
            string[] firstSplit = timeNow.Split();

            string[] secondSplit = firstSplit[0].Split('/');
            day = int.Parse(secondSplit[1]);
            mnth = int.Parse(secondSplit[0]);
            year = int.Parse(secondSplit[2]);

            string[] thirdSplit = firstSplit[1].Split(':');
            hour = int.Parse(thirdSplit[0]);
            minute = int.Parse(thirdSplit[1]);

            if (firstSplit[2] == "PM") hour += 12;


            int[] tmp = new int[5];

            tmp[0] = day;
            tmp[1] = mnth;
            tmp[2] = year;
            tmp[3] = hour;
            tmp[4] = minute;
            return tmp;

        }
        public int TimeDifferenceInMinutes(string line)
        {
            int sum = 0;
            int[] currentTime = CurrentTimeToInt();


            string[] words = line.Split();

            int day = int.Parse(words[9]);
            int mnth = int.Parse(words[10]);
            int year = int.Parse(words[11]);
            int hour = int.Parse(words[12]);
            int min = int.Parse(words[13]);
            //current date and time - the time
            sum = ((currentTime[0] - day) * 24 * 60 + (currentTime[1] - mnth) * 30 * 24 * 60 + (currentTime[2] - year) * 12 * 30 * 24 * 60 + (currentTime[3] - hour) * 60 + (currentTime[4] - min));

            return sum;
        }
        bool examInPast(string line)
        {
            int timeDifference = TimeDifferenceInMinutes(line);
            if (timeDifference >= 0)
                return true;
             return false;
        }
        public void writeDistinctDoctor(string[] lines, ref int i, ref int j, Patient patient, ref Doctor[] matchingDoctors)

        {
            string[] words = lines[i].Split();
            i++;
            if (words[6] == patient.user.Jmbg && examInPast(lines[i-1])==true)
            {
                
                Doctor dr = SearchDoctorByNameAndLastName(words[7] + " " + words[8]);
                bool dontWrite = false;
                for (int k = 0; k < j; k++)
                {

                    if (matchingDoctors[k].user.FirstName == dr.user.FirstName && matchingDoctors[k].user.LastName == dr.user.LastName)  dontWrite = true;
                }
                if (dontWrite == false)
                {
                    
                    matchingDoctors[j] = dr;
                    
                    j++;
                }
            }
        }
        public Doctor[] hadExamAtDoctors(Patient patient, ref int numberOfDoctors)
        {

            Doctor[] matchingDoctors = new Doctor[100];
            int i = 0;
            int j = 0;
            string[] lines = File.ReadAllLines("Examinations.txt");
            foreach (string line in lines)
            {
                writeDistinctDoctor(lines, ref i, ref j, patient, ref matchingDoctors);
            }
            numberOfDoctors = j;
            return matchingDoctors;
        }
    }
}