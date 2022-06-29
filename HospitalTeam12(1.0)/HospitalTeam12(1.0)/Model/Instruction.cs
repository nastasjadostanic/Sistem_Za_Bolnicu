using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.IO;
using MainPackage.Model;

namespace HospitalTeam12.Model
{
    public class Instruction
    {
        public string ID { get; set; }
        public string patientJMBG { get; set; }
        public string doctorJMBG { get; set; }
        public string specialization { get; set; }
        public string endTime { get; set; }
        public string Explanation { get; set; }
        public string hospitalRoomNum { get; set; }
        public int Day { get; set; }
        public int Mounth { get; set; }
        public int Year { get; set; }
        public int Hour { get; set; }
        public int Minute { get; set; }


        public void getMatchingInstructions(string[] lines, ref int i, ref int j, Patient patient, ref string[] matchingInstructions)
        {
            string[] words = lines[i].Split();
            i++;
            if (words[1] == patient.user.Jmbg)
            {
                matchingInstructions[j] = lines[i - 1];
                j++;

            }
        }

        public void writeInstruction(Instruction instruction)
        {
            File.AppendAllText("Instructions.txt", instruction.ID + " " + instruction.patientJMBG + " " + instruction.specialization + " " + instruction.getTimeToString(instruction.Day, instruction.Mounth, instruction.Year, instruction.Hour, instruction.Minute) + "\n");
        }

        public string[] getAllInstructions(Patient patient, ref int numberOfInstructions)
        {
            string[] matchingInstructions = new string[100];
            string[] lines = File.ReadAllLines("Instructions.txt");
            int i = 0;
            int j = 0;
            foreach (string line in lines)
            {
                getMatchingInstructions(lines, ref i, ref j, patient, ref matchingInstructions);
            }


            numberOfInstructions = j;
            return matchingInstructions;
        }

        public Instruction searchByID(string Id)
        {
            string[] lines = File.ReadAllLines("Instructions.txt");
            int i = 0;
            foreach (string inst in lines)
            {
                string[] words = lines[i].Split();
                i++;

                if (Id == words[0])
                {
                    Instruction ins = new Instruction();


                    ins.ID = words[0];
                    ins.patientJMBG = words[1];
                    ins.doctorJMBG = words[2];
                    ins.specialization = words[3];
                    ins.Day = int.Parse(words[4]);
                    ins.Mounth = int.Parse(words[5]);
                    ins.Year = int.Parse(words[6]);
                    ins.Hour = int.Parse(words[7]);
                    ins.Minute = int.Parse(words[8]);




                    return ins;
                }


            }
            return null;
        }

        public void deleteInstruction(Instruction instruction)
        {
            string[] lines = File.ReadAllLines("Instructions.txt");
            int i = 0;
            foreach (string line in lines)
            {
                string[] words = lines[i].Split();
                i++;
                if (instruction.ID != words[0])
                    File.AppendAllText("Instructions2.txt", lines[i - 1] + "\n");

            }
            File.Delete("Instructions.txt");
            File.Move("Instructions2.txt", "Instructions.txt");
        }

        public string getTimeToString(int day, int mnth, int year, int hour, int minute)
        {
            return (day.ToString() + " " + mnth.ToString() + " " + year.ToString() + " " + hour.ToString() + " " + minute.ToString());
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


        // DOCTOR'S FEATURES ===================================================================================
        public void writeInstructionByDoctor(Instruction instruction)
        {
            string newExplanation = ignoreSpaceInText(instruction.Explanation);

            File.AppendAllText("InstructionsDoctor.txt", instruction.ID + 
                " " + instruction.patientJMBG + " " + instruction.doctorJMBG + " " + instruction.specialization +
                " " + instruction.endTime + " " + newExplanation + "\n");
        }

        public void updateInstructionByDoctor(Instruction instruction)
        {
            ArrayList OldInstructionValue = saveOldValuesOfRegular(instruction);
            RemoveInstruction(instruction.ID);

            var updatedInstruction = new Instruction();

            updatedInstruction.ID = OldInstructionValue[0].ToString();
            updatedInstruction.patientJMBG = OldInstructionValue[1].ToString();
            updatedInstruction.doctorJMBG = OldInstructionValue[2].ToString();
            updatedInstruction.specialization = OldInstructionValue[3].ToString();
            updatedInstruction.endTime = instruction.endTime;
            updatedInstruction.Explanation = OldInstructionValue[5].ToString();

            writeInstructionByDoctor(updatedInstruction);
        }

        public String ignoreSpaceInText(String explanation)
        {
            String[] splited = explanation.Split();
            String newExplanation = "";
            foreach (String word in splited)
            {
                newExplanation += word;
                newExplanation += "|";
            }
            return newExplanation;
        }

        public ArrayList saveOldValuesOfRegular(Instruction Instruction)
        {
            string[] lines = File.ReadAllLines("InstructionsDoctor.txt");
            int i = 0;

            ArrayList res = new ArrayList();
            foreach (string item in lines)
            {
                string[] words = lines[i].Split();
                i++;

                if (words[0] == Instruction.ID)
                {
                    res.Add(words[0]);
                    res.Add(words[1]);
                    res.Add(words[2]);
                    res.Add(words[3]);
                    res.Add(words[4]);
                    res.Add(words[5]);
                    return res;
                }
            }
            return null;
        }

        public Boolean RemoveInstruction(String id)
        {
            string tempFile = Path.GetTempFileName();
            int i = 0;
            using (var sr = new StreamReader("InstructionsDoctor.txt"))
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

            File.Delete("InstructionsDoctor.txt");
            File.Move(tempFile, "InstructionsDoctor.txt");
            return true;
        }

        public ArrayList ViewAllInstructions()
        {
            string[] lines = File.ReadAllLines("InstructionsDoctor.txt");
            int i = 0;

            ArrayList res = new ArrayList();
            foreach (string item in lines)
            {
                string[] words = lines[i].Split();
                i++;

                var instruction = new Instruction();
                instruction.ID = words[0];
                instruction.patientJMBG = words[1];
                instruction.doctorJMBG = words[2];
                instruction.specialization = words[3];
                instruction.endTime = words[4];
                res.Add(instruction);

            }
            return res;
        }

        public void writeHospitalInstructionByDoctor(Instruction instruction)
        {
            File.AppendAllText("HospitalInstructionsDoctor.txt", instruction.ID +
                " " + instruction.patientJMBG + " " + instruction.hospitalRoomNum +
                " " + instruction.endTime + " " + "\n");
        }

        public void updateHospitalInstructionByDoctor(Instruction instruction)
        {
            ArrayList OldInstructionValue = saveOldValuesOf(instruction);
            RemoveHospitalInstruction(instruction.ID);

            var updatedHospitalInstruction = new Instruction();

            updatedHospitalInstruction.ID = OldInstructionValue[0].ToString();
            updatedHospitalInstruction.patientJMBG = OldInstructionValue[1].ToString();
            updatedHospitalInstruction.hospitalRoomNum = OldInstructionValue[2].ToString();
            updatedHospitalInstruction.endTime = instruction.endTime;

            writeHospitalInstructionByDoctor(updatedHospitalInstruction);
        }

        public ArrayList saveOldValuesOf(Instruction HospitalInstruction)
        {
            string[] lines = File.ReadAllLines("HospitalInstructionsDoctor.txt");
            int i = 0;

            ArrayList res = new ArrayList();
            foreach (string item in lines)
            {
                string[] words = lines[i].Split();
                i++;

                if (words[0] == HospitalInstruction.ID)
                {
                    res.Add(words[0]);
                    res.Add(words[1]);
                    res.Add(words[2]);
                    return res;
                }
            }
            return null;
        }

        public Boolean RemoveHospitalInstruction(String id)
        {
            string tempFile = Path.GetTempFileName();
            int i = 0;
            using (var sr = new StreamReader("HospitalInstructionsDoctor.txt"))
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

            File.Delete("HospitalInstructionsDoctor.txt");
            File.Move(tempFile, "HospitalInstructionsDoctor.txt");
            return true;
        }

        public ArrayList ViewAllHospitalInstructions()
        {
            string[] lines = File.ReadAllLines("HospitalInstructionsDoctor.txt");
            int i = 0;

            ArrayList res = new ArrayList();
            foreach (string item in lines)
            {
                string[] words = lines[i].Split();
                i++;

                var instruction = new Instruction();
                instruction.ID = words[0];
                instruction.patientJMBG = words[1];
                instruction.endTime = words[3];
                res.Add(instruction);

            }
            return res;
        }


    }
}
