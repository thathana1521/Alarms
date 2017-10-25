using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alarms.Models
{
    public class AlarmID
    {
        public int ID { get; set; }

        public AlarmID() { }

        public AlarmID(int id)
        {
            this.ID = id;
        }
    }
}
