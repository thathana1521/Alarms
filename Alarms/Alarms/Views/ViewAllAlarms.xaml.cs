using Alarms.Data;
using Alarms.Models;
using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Alarms.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ViewAllAlarms : ContentPage
    {
        public AlarmsDatabaseController database;
        
        public ViewAllAlarms()
        {
            InitializeComponent();
            database = new AlarmsDatabaseController();
            var alarms = database.GetAllAlarms();
            listAlarms.ItemsSource = alarms;

            Init();
        }

        public async void OnSelected(Object obj, ItemTappedEventArgs args)
        {
            var alarm = args.Item as Alarm;
            var isDeleteSelected = await DisplayAlert("Delete", "Do you want to delete the Alarm?", "Yes", "No");
            if (isDeleteSelected)
            {
                database.DeleteAlarm(alarm.Id);

                if (database.GetAlarmCount() == 0)
                {
                    await DisplayAlert("Users", "No Users to preview", "OK");
                    await Navigation.PushModalAsync(new SetAlarmPage());
                }
                else
                {
                    await Navigation.PushModalAsync(new ViewAllAlarms());
                }
            }
        }

        void DeleteAllAlarms(Object sender, EventArgs e)
        {
        
            App.AlarmDatabase.DeleteAllAlarms();
            DisplayAlert("Alarms", "All alarms deleted", "OK");
            Navigation.PushModalAsync(new SetAlarmPage());
        }
        void Init()
        {
            BackgroundColor = Constants.BackgroundColor;
            //UsersIcon.HeightRequest = Constants.LoginIconHeight;
        }

        protected override bool OnBackButtonPressed()
        {
            Navigation.PushModalAsync(new SetAlarmPage());
            return true;
        }
    }
}