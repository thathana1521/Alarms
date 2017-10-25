using Alarms.Data;
using Alarms.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace Alarms
{
    public partial class App : Application
    {
        static AlarmsDatabaseController alarmDatabase;
        public App()
        {
            InitializeComponent();

            MainPage = new SetAlarmPage();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }

        public static AlarmsDatabaseController AlarmDatabase
        {
            get
            {
                if (alarmDatabase == null)
                {
                    alarmDatabase = new AlarmsDatabaseController();

                }
                return alarmDatabase;
            }
        }

        
    }
}
