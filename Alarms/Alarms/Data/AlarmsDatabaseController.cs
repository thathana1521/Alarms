
using Alarms.Models;
using Plugin.LocalNotifications;
using SQLite;
using SqliteDb_Users.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Alarms.Data
{
    public class AlarmsDatabaseController
    {
        static object locker = new object();

        SQLiteConnection database;
        

        public AlarmsDatabaseController()
        {
            database = DependencyService.Get<ISQLite>().GetConnection();
            
            database.CreateTable<Alarm>();
            database.CreateTable<AlarmID>();
            
        }

       
        public IEnumerable<Alarm> GetAllAlarms()
        {

            lock (locker)
            {
                if (database.Table<Alarm>().Count() == 0)
                {
                    return null;
                }
                else
                {
                    var alarms = (from alarm in database.Table<Alarm>() select alarm);
                    return alarms;
                }
            }
        }

        public int GetAlarmCount()
        {
            lock (locker)
            {
                return database.Table<Alarm>().Count();
            }
        }

       
        public int SaveAlarm(Alarm alarm, AlarmID id)
        {
            lock (locker)
            {
                database.Insert(id);
                alarm.Id = database.Table<AlarmID>().Count() + 1;
                DateTime alarmRingTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, alarm.Hour, alarm.Minute, 0);
                CrossLocalNotifications.Current.Show("Alarm", "Hour:"+alarm.Hour+" Minute:"+alarm.Minute, alarm.Id, alarmRingTime);
                return database.Insert(alarm);
      
            }
        }

        public int DeleteAllAlarms()
        {
            lock (locker)
            {

                return database.DeleteAll<Alarm>();
            }
        }
        public int DeleteAlarm(int id)
        {
            lock (locker)
            {
                CrossLocalNotifications.Current.Cancel(id);
                return database.Delete<Alarm>(id);
            }
        }
    }
}
