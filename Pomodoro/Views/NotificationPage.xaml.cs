using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;
using Pomodoro.Models;

namespace Pomodoro.Views
{
    public partial class NotificationPage : ContentPage
    {
        
        public NotificationPage()
        {
            InitializeComponent();
            Title = "Notifications";
            GetData();
        }


        public void GetData()
        {
            List<NotificationModel> notifications = new List<NotificationModel>();
            var model1 = new NotificationModel()
            {
                Id = 1,
                Description = "Projeyi Tamamla görevinizi zamanında tamamladınız.",
                Date = "23.04.2017"
            };
            notifications.Add(model1);

			var model2 = new NotificationModel()
			{
				Id = 2,
				Description = "Projeyi Tamamla görevinizin belirlenen süresinin dolmasına 5 dakika kaldı.",
				Date = "23.04.2017"
			};
			notifications.Add(model2);

            ItemsListView.ItemsSource = notifications;
        }
    }
}