using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alarms.Models
{
    public class Alarm
    {
        [PrimaryKey]
        public int Id { get; set; }
        public int Hour { get; set; }
        public int Minute { get; set; }

        //constructors
        public Alarm() { }
        public Alarm(int Hour, int Minute)
        {
            this.Hour = Hour;
            this.Minute = Minute;
        }

        public bool IsTimeValid()
        {
            if (true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
