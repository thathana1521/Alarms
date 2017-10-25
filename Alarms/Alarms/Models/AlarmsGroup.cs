using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alarms.Models
{
    public class AlarmsGroup : List<Alarm>
    {
        public int Hour{ get; set; }
        public int Minute { get; set; }

        private AlarmsGroup(int hour, int minute)
        {
            Hour = hour;
            Minute = minute;
        }

        
    }
}
