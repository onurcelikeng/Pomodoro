using System;
using System.Collections.Generic;
using Pomodoro.Models;
using Xamarin.Forms;
using Pomodoro.Services;

namespace Pomodoro.Views
{
    public partial class RegisterPage : ContentPage
    {
        public RegisterPage()
        {
            InitializeComponent();
        }

        async void Register_Clicked(object sender, EventArgs e)
        {
            var user = new RegisterModel()
            {
                Email = email.Text,
                Password = password.Text,
                Username = username.Text
            };

            var resultReqister = await App.Client.Register(user);
            if(resultReqister == true)
            {
				var model = new LoginModel()
				{
					grant_type = "password",
					Username = email.Text,
					Password = password.Text
				};

				var result = await App.Client.Login(model);
                if(result != null)
                {
                    App.Client.SetToken(result.access_token);
                    Application.Current.Properties.Add("Token", result.access_token);
                    var data = Application.Current.Properties.ContainsKey("Token");
                    GoToMainPage();
                }
            }
        }

        async void Cancel_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new Views.LoginPage();
        }

		public async void GoToMainPage()
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