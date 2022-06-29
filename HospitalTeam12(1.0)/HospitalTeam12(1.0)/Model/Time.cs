using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalTeam12.Model
{
    public class Time
    {
        public int Day { get; set; }
        public int Mounth { get; set; }
        public int Year { get; set; }
        public int Hour { get; set; }
        public int Minute { get; set; }

        public Time(int day, int mnth, int year, int hour, int minute)
        {
            this.Day = day;
            this.Mounth = mnth;
            this.Year = year;
            this.Hour = hour;
            this.Minute = minute;
        }
        public string getTimeToString(Time time)
            {
            return (time.Day.ToString()+" "+ time.Mounth.ToString() + " " + time.Year.ToString() + " " + time.Hour.ToString() + " " + time.Minute.ToString());
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
    }
}
