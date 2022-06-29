using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using HospitalTeam12.Model;


namespace MainPackage.Model
{
    public class Surgery : AppointmentInterface<Surgery>
    {
        public String Id { get; set; }
        public Room room { get; set; }
        private ArrayList doctors;
        public Doctor doctor { get; set; }// pomocna promenljiva
        public Patient patient { get; set; }
        public int day { get; set; }
        public int mnth { get; set; }
        public int year { get; set; }
        public int hour { get; set; }
        public int min { get; set; }

        public String date { get; set; }
        public String time { get; set; }


        public override Boolean Schedule(Surgery s)
        {
            string[] lines = File.ReadAllLines("Surgeries.txt");
            int i = 0;
            Boolean foundFreeTime = true;
            String time = "";
            String timeFromFile = "";
            foreach (string surgery in lines)
            {
                string[] words = lines[i].Split();
                i++;

                if (s.GetRoom().Number == words[1])
                {
                    if (s.day == int.Parse(words[10]) && s.mnth == int.Parse(words[11]) && s.year == int.Parse(words[12]))
                    {
                        time = s.hour.ToString() + "." + s.min.ToString();
                        bool isNumber = Double.TryParse(time, out Double numericValue);
                        if (isNumber)
                        {
                            timeFromFile = words[13] + "." + words[14];
                            if (Math.Abs(Double.Parse(time) - Double.Parse(timeFromFile)) < 1 &&
                                Math.Abs(Double.Parse(time) - Double.Parse(timeFromFile)) != 0)
                            {
                                foundFreeTime = false;
                            }
                        }
                        else
                        {
                            return false;
                        }

                    }
                }

            }
            if (foundFreeTime == true)
            {
                File.AppendAllText("Surgeries.txt", s.Id + " " + s.GetRoom().Number + " " + s.GetRoom().Floor +
                " " + s.GetPatient().GetUser().FirstName + " " + s.GetPatient().GetUser().LastName +
                " " + s.GetPatient().HealthRecordNumber + " " + s.GetPatient().GetUser().Jmbg +
                " " + s.doctor.GetUser().FirstName + " " + s.doctor.GetUser().LastName + " " + s.doctor.GetSpecialization() +
                " " + s.day + " " + s.mnth + " " + s.year +
                " " + s.hour + " " + s.min + "\n");

                return true;
            }
            return false;
        }

        public ArrayList ViewSurgery(String idOfSurgery)
        {
            string[] lines = File.ReadAllLines("Surgeries.txt");
            int i = 0;
            ArrayList rez = new ArrayList();
            foreach (string surgery in lines)
            {
                string[] words = lines[i].Split();
                i++;

                if (idOfSurgery == words[0])
                {
                    var s = new Surgery();
                    s.Id = words[0];
                    Room room = new Room();
                    room.Number = words[1];
                    room.Floor = words[2];

                    User userP = new User();
                    userP.FirstName = words[3];
                    userP.LastName = words[4];
                    userP.Jmbg = words[6];
                    Patient patient = new Patient();
                    patient.HealthRecordNumber = words[5];
                    patient.SetUser(userP);
                    s.SetPatient(patient);
                    User userD = new User();
                    userD.FirstName = words[7];
                    userD.LastName = words[8];
                    var d = new Doctor();
                    d.SetUser(userD);
                    d.SetSpecialization(words[9]);
                    s.doctor = d;

                    s.day = int.Parse(words[10]);
                    s.mnth = int.Parse(words[11]);
                    s.year = int.Parse(words[12]);
                    s.hour = int.Parse(words[13]);
                    s.min = int.Parse(words[14]);
                    s.date = s.day.ToString() + "." + s.mnth.ToString() + "." + s.year.ToString();
                    s.time = s.hour.ToString() + ":" + s.min.ToString();
                    s.SetRoom(room);

                    rez.Add(s);
                }
            }

            return rez;
        }

        public override ArrayList ViewAll()
        {
            string[] lines = File.ReadAllLines("Surgeries.txt");
            int i = 0;
            ArrayList rez = new ArrayList();
            foreach (string surgery in lines)
            {
                string[] words = lines[i].Split();
                i++;

                var s = new Surgery();
                s.Id = words[0];
                Room room = new Room();
                room.Number = words[1];
                room.Floor = words[2];

                User userP = new User();
                userP.FirstName = words[3];
                userP.LastName = words[4];
                userP.Jmbg = words[6];
                Patient patient = new Patient();
                patient.HealthRecordNumber = words[5];
                patient.SetUser(userP);
                s.SetPatient(patient);
                User userD = new User();
                userD.FirstName = words[7];
                userD.LastName = words[8];
                var d = new Doctor();
                d.SetUser(userD);
                d.SetSpecialization(words[9]);
                s.doctor = d;

                s.day = int.Parse(words[10]);
                s.mnth = int.Parse(words[11]);
                s.year = int.Parse(words[12]);
                s.hour = int.Parse(words[13]);
                s.min = int.Parse(words[14]);
                s.date = s.day.ToString() + "." + s.mnth.ToString() + "." + s.year.ToString()+".";
                s.time = s.hour.ToString() + ":" + s.min.ToString()+"h";
                s.SetRoom(room);

                rez.Add(s);
            }

            if (rez.Count == 0)
            {
                return null;
            }
            return rez;
        }

        public override Boolean Reschedule(Surgery s)
        {
            string tempFile = Path.GetTempFileName();
            int i = 0;

            File.AppendAllText("Surgeries.txt", s.Id + " " + s.GetRoom().Number + " " + s.GetRoom().Floor +
                " " + s.GetPatient().GetUser().FirstName + " " + s.GetPatient().GetUser().LastName +
                " " + s.GetPatient().HealthRecordNumber + " " + s.GetPatient().GetUser().Jmbg +
                " " + s.doctor.GetUser().FirstName + " " + s.doctor.GetUser().LastName + " " + s.doctor.GetSpecialization() +
                " " + s.day + " " + s.mnth + " " + s.year +
                " " + s.hour + " " + s.min + "\n");

            int count = 0;
            using (var sr = new StreamReader("Surgeries.txt"))
            using (var sw = new StreamWriter(tempFile))
            {
                String lines;

                while ((lines = sr.ReadLine()) != null)
                {
                    string[] words = lines.Split();

                    if (s.Id == words[0])
                    {
                        count++;
                    }

                    if (count == 2 || s.Id != words[0])
                    {
                        sw.WriteLine(lines);
                    }
                    i++;
                }
            }

            File.Delete("Surgeries.txt");
            File.Move(tempFile, "Surgeries.txt");

            return true;
        }

        public override Boolean Remove(String idOfSurgery)
        {
            string tempFile = Path.GetTempFileName();
            int i = 0;
            using (var sr = new StreamReader("Surgeries.txt"))
            using (var sw = new StreamWriter(tempFile))
            {
                String lines;

                while ((lines = sr.ReadLine()) != null)
                {
                    string[] words = lines.Split();
                    if (idOfSurgery != words[0])
                    {
                        sw.WriteLine(lines);
                    }
                    i++;
                }
            }

            File.Delete("Surgeries.txt");
            File.Move(tempFile, "Surgeries.txt");
            return true;
        }


        public void SetPatient(Patient p)
        {
            this.patient = p;
        }

        public Patient GetPatient()
        {
            return patient;
        }

        public ArrayList GetDoctors()
        {
            if (doctors == null)
                doctors = new System.Collections.ArrayList();
            string[] lines = File.ReadAllLines("Surgeries.txt");
            int i = 0;
            foreach (string item in lines)
            {
                string[] words = lines[i].Split();
                i++;

                if (room.Number == words[1] && Id==words[0])
                {
                    var d = new Doctor();
                    var r = new Room();
                    r.Number = words[1];
                    d.GetUser().FirstName = words[2];
                    d.GetUser().LastName = words[3];
                    d.SetSpecialization(words[4]);
                    d.SetRoom(r);
                    doctors.Add(d);
                }
            }
            return doctors;
        }        

        public void SetDoctors(System.Collections.ArrayList newDoctors)
        {
            RemoveAllDoctors();
            foreach (Doctor oDoctor in newDoctors)
                AddDoctor(oDoctor);
        }

        public void AddDoctor(Doctor newDoctor)
        {
            if (newDoctor == null)
                return;
            if (this.doctors == null)
                this.doctors = new System.Collections.ArrayList();
            if (!this.doctors.Contains(newDoctor))
                this.doctors.Add(newDoctor);
        }

        public void RemoveDoctor(Doctor oldDoctor)
        {
            if (oldDoctor == null)
                return;
            if (this.doctors != null)
                if (this.doctors.Contains(oldDoctor))
                    this.doctors.Remove(oldDoctor);
        }

        public void RemoveAllDoctors()
        {
            if (doctors != null)
                doctors.Clear();
        }

        public void SetRoom(Room room)
        {
            this.room = room;
        }

        public Room GetRoom()
        {
            return room;
        }

        public void SetId(String id)
        {
            this.Id = id;
        }

        public String GetId()
        {
            return Id;
        }
    }
}
