using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace HospitalTeam12.Model
{
   public class Grades
    {
        public int kindnessGrade { get; set; }
        public int professionalismGrade { get; set; }
        public int generalGrade { get; set; }
        public string doctorID { get; set; }

        public Grades(int kindness,int profesionalism,int general,string drID) 
        {
            this.kindnessGrade = kindness;
            this.professionalismGrade = profesionalism;
            this.generalGrade = general;
            this.doctorID = drID;
        }
        public void writeGrades(Grades grades) 
        {
            File.AppendAllText("Grades.txt",kindnessGrade+" " +professionalismGrade + " " +generalGrade + " " +doctorID + "\n");
        }


        public bool hadExam(Patient patient)
        {
            string[] lines = File.ReadAllLines("Examinations.txt");
            int i = 0;
            foreach (string line in lines)
            {
                string[] words = lines[i].Split();
                i++;
                if (patient.user.Jmbg == words[6]) return true;
            }

            return false;
        }

    }
}
