
using System;
using System.IO;
using HospitalTeam12.Model;
using MainPackage.Model;
using System.Threading.Tasks;


public class Patient
{
    const int TROLLCOUNTERPERIOD = 10080; //7 days in mins
    const int MAXTROLLCOUNTER = 10;

    public User user { get; set; }

    public bool isDisabled { get; set; }

    public TrollCounter trollCounter { get; set; }
    public string HealthRecordNumber { get; set; }

    public Patient SearchPatientByJMBG(string JMBG)
    {
        string[] lines = File.ReadAllLines("Patients.txt");
        int i = 0;
        foreach (string patient in lines)
        {
            string[] words = lines[i].Split();
            i++;

            if (JMBG == words[3])
            {
                var p = new Patient();
                var u = new User();

                u.FirstName = words[0];
                u.LastName = words[1];
                u.DateOfBirth = words[2];
                u.Jmbg = words[3];
                u.Email = words[4];
                u.Phone = words[5];
                u.Address = words[6];
                u.Username = words[7];
                u.Password = words[8];

                p.HealthRecordNumber = words[9];

                p.isDisabled = bool.Parse(words[10]);
               
                p.SetUser(u);


                return p;
            }


        }


        // ako ga nema vrati null

        return null;
    }

    public Patient SearchPatientByHRK(string HRK)
    {
        string[] lines = File.ReadAllLines("Patients.txt");
        int i = 0;
        foreach (string patient in lines)
        {
            string[] words = lines[i].Split();
            i++;

            if (HRK == words[9])
            {
                var p = new Patient();
                var u = new User();

                u.FirstName = words[0];
                u.LastName = words[1];
                u.DateOfBirth = words[2];
                u.Jmbg = words[3];
                u.Email = words[4];
                u.Phone = words[5];
                u.Address = words[6];
                u.Username = words[7];
                u.Password = words[8];

                p.HealthRecordNumber = words[9];

                p.isDisabled = bool.Parse(words[10]);

                p.SetUser(u);


                return p;
            }


        }


        // ako ga nema vrati null

        return null;
    }

    public Boolean CreateAccount(string fn, string ln, string dob, string jmbg, string email, string p, string a, string u, string pw, string hkn, string isdisabled)
    {
        string[] lines = File.ReadAllLines("Patients.txt");
        int i = 0;
        foreach (string patient in lines)
        {
            string[] words = lines[i].Split();
            i++;

            if (jmbg == words[3])
                return false;



        }
        File.AppendAllText("Patients.txt", fn + " " + ln + " " + dob + " " + jmbg + " " + email + " " + p + " " + a + " " + u + " " + pw + " " + hkn + " " + isdisabled + "\n");
        return true;
    }

    public Boolean DeleteAccount(string JMBG)
    {
        string[] lines = File.ReadAllLines("Patients.txt");

        int i = 0;
        foreach (string pat in lines)
        {
            string[] words = lines[i].Split();
            i++;
            if (JMBG != words[3])
                File.AppendAllText("Patients2.txt", lines[i - 1] + "\n");


        }

        File.Delete("Patients.txt");
        File.Move("Patients2.txt", "Patients.txt");
        return false;
    }

    public Boolean EditAccount(string fn, string ln, string dob, string jmbg, string email, string p, string a, string u, string pw, string hkn, string isdisabled)
    {
        if (SearchPatientByJMBG(jmbg) != null)
        {
            DeleteAccount(jmbg);
            CreateAccount(fn, ln, dob, jmbg, email, p, a, u, pw, hkn, isdisabled);
            return true;
        }
        return false;
    }


    public void SetUser(User u)
    {
        this.user = u;
    }

    public User GetUser()
    {
        return user;
    }


    //KT4

    public string CurrentTimeToString()
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


        string tmp = day.ToString() + " " + mnth.ToString() + " " + year.ToString() + " " + hour.ToString() + " " + minute.ToString();
        return tmp;
    }

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
    public int TimeDifferenceInMinutes(string[] lines, int i) 
    {
        int sum = 0;
        int[] currentTime = CurrentTimeToInt();
        
        
            string[] words = lines[i].Split();

            int day = int.Parse(words[1]);
            int mnth = int.Parse(words[2]);
            int year = int.Parse(words[3]);
            int hour = int.Parse(words[4]);
            int min = int.Parse(words[5]);
        //current date and time - TrollCounters date and time
           sum = (( currentTime[0] - day) * 24 * 60 + (currentTime[1]- mnth) * 30 * 24 * 60 + ( currentTime[2]-year) * 12 * 30 * 24 * 60 + (currentTime[3]- hour) * 60 + ( currentTime[4]- min));
        
        return sum;
    }
    public void deleteTrollCounter(string PatientJMBG,string day,string mnth,string year,string hour,string min) 
    
        {
            string[] lines = File.ReadAllLines("TrollCounters.txt");

            int i = 0;
            foreach (string tc in lines)
            {
                string[] words = lines[i].Split();
                i++;
                if (PatientJMBG != words[0] || day != words[1] || mnth != words[2] || year != words[3] || hour != words[4] || min != words[5] )
                    File.AppendAllText("TrollCounters2.txt", lines[i - 1] + "\n");


            }

            File.Delete("TrollCounters.txt");
            File.Move("TrollCounters2.txt", "TrollCounters.txt");
            
        }//force delete from trollcounters.txt
    public void updatePatientFile(Patient patient)
    { 
        EditAccount(patient.user.FirstName, patient.user.LastName, patient.user.DateOfBirth, patient.user.Jmbg, patient.user.Email, patient.user.Phone, patient.user.Address, patient.user.Username, patient.user.Password, patient.HealthRecordNumber, patient.isDisabled.ToString());
    }//force write to patients.txt
    public string[] getAllTrollCounters(Patient patient, ref int nubmerOfTrollCounters ) 
    {
        string[] lines = File.ReadAllLines("TrollCounters.txt");
        string[] tmp = new string[MAXTROLLCOUNTER];
        int j = 0;
        int i = 0;
        foreach (string p in lines)
        {
            string[] words = lines[i].Split();
            i++;

            if (patient.user.Jmbg == words[0])
            {
                tmp[j] = lines[i-1];
                j++;
            }


         }
        nubmerOfTrollCounters = j;
        return tmp;
    }//all patients TCs and number of them


    public void CleanOldTrollCounters(Patient patient)
    {

        int i = 0;
        string[] lines = getAllTrollCounters(patient, ref i);

        for (int j = 0; j < i; j++)
        {
            if (TimeDifferenceInMinutes(lines, j) > TROLLCOUNTERPERIOD)
            {
                string[] words = lines[j].Split();
                deleteTrollCounter(words[0], words[1], words[2], words[3], words[4], words[5]);
                

            }
            
        }

    }//check for 7 days old TCs
    public void disableAccount(Patient patient)
    {
        patient.isDisabled = true; updatePatientFile(patient);

    }//disabling with force write to patients.txt
    public void increaseTrollCounter(Patient patient)
    {


        File.AppendAllText("TrollCounters.txt", patient.user.Jmbg + " " + CurrentTimeToString() + "\n");

    }//force write to trollcounters.txt




    //KT3


    //Patient control

    public Boolean CreateAccountP(string fn, string ln, string dob, string jmbg, string email, string p, string a, string u, string pw, string hkn, string trollcounter, string isdisabled)
    {
        string[] lines = File.ReadAllLines("Patients.txt");
        int i = 0;
        foreach (string patient in lines)
        {
            string[] words = lines[i].Split();
            i++;

            if (jmbg == words[3])
                return false;



        }
        File.AppendAllText("Patients.txt", fn + " " + ln + " " + dob + " " + jmbg + " " + email + " " + p + " " + a + " " + u + " " + pw + " " + hkn + " " + trollcounter + " " + isdisabled + "\n");
        return true;
    }

    public Boolean DeleteAccountP(string JMBG)
    {
        string[] lines = File.ReadAllLines("Patients.txt");

        int i = 0;
        foreach (string pat in lines)
        {
            string[] words = lines[i].Split();
            i++;
            if (JMBG != words[3])
                File.AppendAllText("Patients2.txt", lines[i - 1] + "\n");


        }

        File.Delete("Patients.txt");
        File.Move("Patients2.txt", "Patients.txt");
        return false;
    }


    public Boolean EditAccountP(string fn, string ln, string dob, string email, string p, string a, string trollcounter, string isdisabled)
    {


        DeleteAccountP(/*this.user.Jmbg*/"123456789");
        CreateAccountP(fn, ln, dob, /*this.user.Jmbg,*/ "123456789", email, p, a, /*this.user.Username, this.user.Password, */ "korisnik123", "sifra123","987654321","0","false");
        return true;


    }


}

