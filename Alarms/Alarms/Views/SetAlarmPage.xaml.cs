using Alarms.Models;
using Plugin.LocalNotifications;
using System;
using System.Globalization;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace Alarms.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SetAlarmPage : ContentPage
    {
        public SetAlarmPage()
        {
            InitializeComponent();//Initializes all the components in the xaml file
            Init();
        }

        //Initializes colours and height of icon
        void Init()
        {
            BackgroundColor = Constants.BackgroundColor;
            L_PickTime.TextColor = Constants.MainTextColor;
            tP.TextColor = Constants.MainTextColor;
            tP.Time = DateTime.Now.TimeOfDay; 
            //tP.GetValue(DateTime.Now);
            //tP.BackgroundColor = Constants.MainTextColor;
            //ActivitySpinner.IsVisible = false;
            Logo.HeightRequest = Constants.LoginIconHeight;

            //E_Username.Completed += (s, e) => E_Password.Focus();
            //E_Password.Completed += (s, e) => SignUpProcedure(s, e);
        }

        //When sign in button clicked
        void SaveAlarmProcedure(Object sender, EventArgs e)
        {            
            var time = tP.Time;
            int hour = time.Hours;
            int minute = time.Minutes;
                        
            int alarmId = 0;
            
            Alarm alarm = new Alarm(hour,minute);
            AlarmID id = new AlarmID(alarmId);
            if (alarm.IsTimeValid())
            {
                DisplayAlert("Alarm", "Alarm Added Successfully", "OK");
                App.AlarmDatabase.SaveAlarm(alarm,id);

            }
            else
            {
                DisplayAlert("Sign Up", "Error: Empty Username or Password", "OK");
            }
        }

        void ShowAllAlarms(Object sender, EventArgs e)
        {
            
            if (App.AlarmDatabase.GetAllAlarms()==null)
            {
                DisplayAlert("Alarms", "No Alarms to preview", "OK");
            }
            else
            {
                int alarm_count = App.AlarmDatabase.GetAlarmCount();
                DisplayAlert("Alarms", "There are "+alarm_count+" Alarm.", "OK");

                ViewAlarmsPage(sender,e);

            }
        }

        void ViewAlarmsPage(object sender, EventArgs args) 
        {
            Navigation.PushModalAsync(new ViewAllAlarms());
        }

        protected override bool OnBackButtonPressed()
        {
            Navigation.PushModalAsync(new SetAlarmPage());
            return true;
        }
    }
}