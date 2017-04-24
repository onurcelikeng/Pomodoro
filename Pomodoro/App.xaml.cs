using System.Collections.Generic;
using Xamarin.Forms;
using Pomodoro.Views;

namespace Pomodoro
{
    public partial class App : Application
    {
		public static IDictionary<string, string> LoginParameters => null;
        public static bool UseMockDataStore = true;
        public static string BackendUrl = "https://localhost:5000";
        public static Services.DataClient Client = new Services.DataClient();


        public App()
        {
            InitializeComponent();

            if (UseMockDataStore)
                DependencyService.Register<MockDataStore>();
            else
                DependencyService.Register<CloudDataStore>();

            SetMainPage();
        }

        public static void SetMainPage()
        {
            if (!UseMockDataStore && !Settings.IsLoggedIn)
            {
                Current.MainPage = new NavigationPage(new Views.LoginPage())
                {
                    BarBackgroundColor = (Color)Current.Resources["Primary"],
                    BarTextColor = Color.White
                };
            }
            else
            {
                var data = Application.Current.Properties.ContainsKey("Token");
                if (data == false)
                {
                    Current.MainPage = new Views.LoginPage();
                }

                else
                {
                    GoToMainPage();
                }
            }
        }

        public static void GoToMainPage()
        {
            App.Current.MainPage = new TabbedPage
            {
                Children = {
                    new NavigationPage(new ProjectsPage())
                    {
                        Title = "Projects",
                        Icon = Device.OnPlatform("tab_projects.png", null, null)
                    },
                    new NavigationPage(new Views.ReportPage())
					{
						Title = "Reports",
						Icon = Device.OnPlatform("tab_report.png", null, null)
					},
                    new NavigationPage(new Views.TimerPage())
					{
						Title = "Timer",
						Icon = Device.OnPlatform("tab_timer.png", null, null)
					},
                    new NavigationPage(new Views.NotificationPage())
					{
						Title = "Notifications",
						Icon = Device.OnPlatform("tab_notification.png", null, null)
					},
                    new NavigationPage(new Views.ProfilePage())
                    {
                        Title = "Profile",
                        Icon = Device.OnPlatform("tab_profile.png", null, null)
                    },
                }
            };
        }
    }
}