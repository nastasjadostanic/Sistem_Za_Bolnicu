using System;
using System.IO;
using System.Collections;
using HospitalTeam12.Model;

namespace MainPackage.Model
{

    public class Examination : AppointmentInterface<Examination>
    {
        const int HOUR1 = 7;            //Radno vreme
        const int HOUR2 = 23;
        const int MIN1 = 0;
        const int MIN2 = 0;
        public String Id { get; set; }
        public Patient patient { get; set; }
        public Doctor doctor { get; set; }

        public int day { get; set; }
        public int mnth { get; set; }
        public int year { get; set; }
        public int hour { get; set; }
        public int min { get; set; }


        public void SetPatient(Patient p)
        {
            this.patient = p;
        }

        public Patient GetPatient()
        {
            return patient;
        }

        public void SetDoctor(Doctor d)
        {
            this.doctor = d;
        }

        public Doctor GetDoctor()
        {
            return doctor;
        }

        public override Boolean Schedule(Examination e)
        {
            string[] lines = File.ReadAllLines("Examinations.txt");
            int i = 0;
            Boolean foundFreeTime = true;
            String time = "";
            String timeFromFile = "";
            foreach (string exam in lines)
            {
                string[] words = lines[i].Split();
                i++;

                if (e.GetDoctor().GetRoom().Number == words[1])
                {
                    if (e.day == int.Parse(words[9]) && e.mnth == int.Parse(words[10]) && e.year == int.Parse(words[11]))
                    {
                        time = e.hour.ToString() + "." + e.min.ToString();
                        bool isNumber = Double.TryParse(time, out Double numericValue);
                        if (isNumber)
                        {
                            timeFromFile = words[12] + "." + words[13];
                            if (Math.Abs(Double.Parse(time) - Double.Parse(timeFromFile)) < 1)
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
                File.AppendAllText("Examinations.txt", e.Id + " " + e.GetDoctor().GetRoom().Number + " " + e.GetDoctor().GetRoom().Floor +
                " " + e.GetPatient().GetUser().FirstName + " " + e.GetPatient().GetUser().LastName + " " + e.GetPatient().HealthRecordNumber +
                " " + e.GetPatient().GetUser().Jmbg + " " + e.GetDoctor().GetUser().FirstName + " " + e.GetDoctor().GetUser().LastName +
                " " + e.day + " " + e.mnth + " " + e.year + " " + e.hour + " " + e.min + "\n");
                return true;
            }
            return false;

        }

        public Examination ViewExamination(String idOfExam)
        {
            string[] lines = File.ReadAllLines("Examinations.txt");
            int i = 0;
            foreach (string examination in lines)
            {
                string[] words = lines[i].Split();
                i++;

                if (idOfExam == words[0])
                {
                    var exam = new Examination();
                    exam.Id = words[0];
                    Room room = new Room();
                    room.Number = words[1];
                    room.Floor = words[2];
                    Doctor doctor = new Doctor();
                    doctor.SetRoom(room);

                    User userP = new User();
                    userP.FirstName = words[3];
                    userP.LastName = words[4];
                    userP.Jmbg = words[6];
                    Patient patient = new Patient();
                    patient.HealthRecordNumber = words[5];
                    patient.SetUser(userP);
                    exam.SetPatient(patient);

                    User userD = new User();
                    userD.FirstName = words[7];
                    userD.LastName = words[8];
                    doctor.SetUser(userD);
                    exam.SetDoctor(doctor);

                    exam.day = int.Parse(words[9]);
                    exam.mnth = int.Parse(words[10]);
                    exam.year = int.Parse(words[11]);
                    exam.hour = int.Parse(words[12]);
                    exam.min = int.Parse(words[13]);

                    return exam;
                }
            }

            return null;
        }

        public override ArrayList ViewAll()
        {
            string[] lines = File.ReadAllLines("Examinations.txt");
            int i = 0;
            ArrayList rez = new ArrayList();
            foreach (string examination in lines)
            {
                string[] words = lines[i].Split();
                i++;

                var exam = new Examination();
                exam.Id = words[0];
                Room room = new Room();
                room.Number = words[1];
                room.Floor = words[2];
                Doctor doctor = new Doctor();
                doctor.SetRoom(room);

                User userP = new User();
                userP.FirstName = words[3];
                userP.LastName = words[4];
                userP.Jmbg = words[6];
                Patient patient = new Patient();
                patient.HealthRecordNumber = words[5];
                patient.SetUser(userP);
                exam.SetPatient(patient);

                User userD = new User();
                userD.FirstName = words[7];
                userD.LastName = words[8];
                doctor.SetUser(userD);
                exam.SetDoctor(doctor);

                exam.day = int.Parse(words[9]);
                exam.mnth = int.Parse(words[10]);
                exam.year = int.Parse(words[11]);
                exam.hour = int.Parse(words[12]);
                exam.min = int.Parse(words[13]);

                rez.Add(exam);
            }

            if (rez.Count == 0)
            {
                return null;
            }
            return rez;
        }

        public override Boolean Reschedule(Examination e)
        {
            string tempFile = Path.GetTempFileName();
            int i = 0;

            File.AppendAllText("Examinations.txt", e.Id + " " + e.GetDoctor().GetRoom().Number + " " + e.GetDoctor().GetRoom().Floor +
                " " + e.GetPatient().GetUser().FirstName + " " + e.GetPatient().GetUser().LastName + " " + e.GetPatient().HealthRecordNumber +
                " " + e.GetPatient().GetUser().Jmbg + " " + e.GetDoctor().GetUser().FirstName + " " + e.GetDoctor().GetUser().LastName +
                " " + e.day + " " + e.mnth + " " + e.year + " " + e.hour + " " + e.min + "\n");
            int count = 0;
            using (var sr = new StreamReader("Examinations.txt"))
            using (var sw = new StreamWriter(tempFile))
            {
                String lines;

                while ((lines = sr.ReadLine()) != null)
                {
                    string[] words = lines.Split();

                    if (e.Id == words[0])
                    {
                        count++;
                    }

                    if (count == 2 || e.Id != words[0])
                    {
                        sw.WriteLine(lines);
                    }
                    i++;
                }
            }

            File.Delete("Examinations.txt");
            File.Move(tempFile, "Examinations.txt");


            return true;
        }

        public override Boolean Remove(String idOfExam)
        {
            //Boolean isItGood = false;
            string tempFile = Path.GetTempFileName();
            int i = 0;
            using (var sr = new StreamReader("Examinations.txt"))
            using (var sw = new StreamWriter(tempFile))
            {
                String lines;

                while ((lines = sr.ReadLine()) != null)
                {
                    string[] words = lines.Split();
                    if (idOfExam != words[0])
                    {
                        sw.WriteLine(lines);
                    }
                    i++;
                }
            }

            File.Delete("Examinations.txt");
            File.Move(tempFile, "Examinations.txt");
            return true;
        }

        // Patient control

        public Boolean ScheduleP(Examination e)
        {




            File.AppendAllText("Examinations.txt", Id + " " + doctor.room.Number + " " + doctor.room.Floor +
            " " + patient.GetUser().FirstName + " " + patient.GetUser().LastName + " " + patient.HealthRecordNumber + " " + patient.GetUser().Jmbg +
            " " + doctor.GetUser().FirstName + " " + doctor.GetUser().LastName + " " + day + " " + mnth + " " + year + " " + hour + " " + min + "\n");
            return true;



        }


        public string[] schedulePriortyDoctor(Doctor d, Patient p, int dd, int mm, int yyyy, int hh, int min, int dd2, int mm2, int yyyy2, int hh2, int min2, ref int cnt) {

            /*
             * 
             * ucitaj sve iz fajla
             * pretvori u int vreme
             * 
             *  if doktor je slobodan
             *      JESTE FREE idi na prvu stranicu i pitaj za podatke da selektuje iz tabele
             *      
             *      NIJE FREE idi na drugu stranicu i prikazi listu slobodnih termina tog doktora da korisnik selektuje
             */

            if (hh >= HOUR1 && hh2 <= HOUR2 && min >= MIN1 && min2 <= MIN2)
            {

                string[] lines = File.ReadAllLines("Examinations.txt");
                int i = 0;
                string[] scheduledArray = new string[1000];
                string[] unscheduledArray = new string[1000];
                string[] tmp = new string[1000];
                int j = 0;
                foreach (string exam in lines)
                {
                    string[] words = lines[i].Split();
                    i++;

                    if (words[7] == d.user.FirstName && words[8] == d.user.LastName)
                    {

                        int day = int.Parse(words[9]);
                        int mnth = int.Parse(words[10]);
                        int year = int.Parse(words[11]);
                        int hour = int.Parse(words[12]);
                        int minute = int.Parse(words[13]);

                        if (year >= yyyy && year <= yyyy2)
                        {
                            if (mnth >= mm && mnth <= mm2)
                            {
                                if (day >= dd && day <= dd2)
                                {
                                    if (hour >= hh && hour <= hh2)
                                    {
                                        if (minute >= min && minute <= mm2)
                                        {

                                            scheduledArray[j] = lines[i - 1];    //niz svih zauzetih termina u oznacenom periodu
                                            j++;
                                        }
                                    }
                                }
                            }
                        }






                    }


                }
                int amount = 0;
                tmp = AllExams(d, dd, mm, yyyy, hh, min, dd2, mm2, yyyy2, hh2, min2, ref amount);
                int c = 0;
                //print u bbb


                for (int b = 0; b < amount; b++)
                {


                    string[] words3 = tmp[b].Split();


                    bool NotEqual = true;
                    for (int a = 0; a < j; a++)
                    {

                        string[] words2 = scheduledArray[a].Split();
                        if (words2[9] == words3[9] && words2[10] == words3[10] && words2[11] == words3[11]) //isti datum
                        {
                            int aHour = int.Parse(words3[12]);
                            int bHour = int.Parse(words2[12]);
                            int aMin = int.Parse(words3[13]);
                            int bMin = int.Parse(words2[13]);

                            int sum = (bHour - aHour) * 60 + bMin - aMin;

                            if (sum < 30) //nema 30 min razmaka
                            {
                                NotEqual = false;
                            }
                        }


                    }

                    if (NotEqual == true)
                    {
                        unscheduledArray[c] = tmp[b];
                        c++;



                    }
                }


                cnt = c;
                return unscheduledArray;
            }

            string[] tmp1 = new string[0];
            return tmp1;
        }  //vraca niz slobodnih termina u zadatom periodu


        public string[] AllExams(Doctor dr, int day, int mnth, int year, int hour, int minute, int day2, int mnth2, int year2, int hour2, int minute2, ref int aa) {

            string[] tmp = new string[1000];
            int i = 0;
            int dd = day;
            int mm = mnth;
            int yyyy = year;
            int hh = hour;
            int min = minute;
            tmp[i] = "Empty Empty Empty Empty Empty Empty Empty " + dr.user.FirstName + " " + dr.user.LastName + " " + dd + " " + mm + " " + yyyy + " " + hh + " " + min;
            i++;
            while (difference(dd,mm,yyyy,hh,min,day2,mnth2,year2,hour2,minute2)>0)
            {
                if (min < 30) min += 30;
                else { min -= 30; hh++; }

                if (hh >= HOUR2 && min >= MIN2) { hh = HOUR1; min = MIN1; dd++; }
                if (dd == 31) { dd = 1; mm++; }
                if (mm == 13) { mm = 1; yyyy++; }
                tmp[i] = "Empty Empty Empty Empty Empty Empty Empty " + dr.user.FirstName + " " + dr.user.LastName + " " + dd + " " + mm + " " + yyyy + " " + hh + " " + min;
                i++;


            }
            aa = i;


            return tmp;
        } //vraca niz svih termina u zadatom periodu


        public Boolean reschedulePriortyDoctor(/*Doctor d, Patient p, string dd, string mm, string yyyy, string hh, string min*/)
        {
            /*
             * prikaz svih termina i selektovanje zeljenog
             * if termin je dalje od 24h moze
             *      koji je priority?
             *          schedulePriortyTime(za period od +-2 dana)
             *          schedulePriortyDoctor(za period od +-2 dana)
             * 
             * 
             */



            return true;
        }

        public string[] GetAllExamination() {
            string[] lines = File.ReadAllLines("Examinations.txt");

            return lines;
        }

        public void schedulePat(string Id, string Number, string Floor, string pFirstName, string pLastName, string HealthRecordNumber, string pJmbg, string dFirstName, string dLastName, int dd, int mm, int yyyy, int hh, int min)
        {
            File.AppendAllText("Examinations.txt", Id + " " + Number + " " + Floor + " " + pFirstName + " " + pLastName + " " + HealthRecordNumber + " " + pJmbg + " " + dFirstName + " " + dLastName + " " + dd + " " + mm + " " + yyyy + " " + hh + " " + min + "\n");


        }
      //KT 4
        public int difference(int day, int mnth, int year, int hour, int minute, int day2, int mnth2, int year2, int hour2, int minute2)
        {
            return (((((year2 - year) * 12 + (mnth2 - mnth)) * 30 + (day2 - day)) * 24 + (hour2 - hour)) * 60);
        }



    }

}