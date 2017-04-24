using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Pomodoro.Models;

namespace Pomodoro.Views
{
    public partial class TaskPage : ContentPage
    {
        public static int ProjectId;
        public List<TaskModel> list1;

		public TaskPage()
		{
			InitializeComponent();
			Title = "Projects Tasks";

            GetData();
		}


		public async void GetData()
		{
			var list = await App.Client.GetTasks(ProjectId);
            for (int i = 0; i < list.Count; i++)
            {
                if(list[i].isFinish == "0")
                    list[i].isFinish = "ok_gray.png";
                else if(list[i].isFinish == "1")
                    list[i].isFinish = "ok_green.png";

                if(list[i].Priority == "1")
                {
                    list[i].Priority = "star_red.png";
                }
				else if (list[i].Priority == "2")
				{
                    list[i].Priority = "star_purple.png";
				}
				else if (list[i].Priority == "3")
				{
                    list[i].Priority = "star_blue.png";
				}
                else
                {
                    list[i].Priority = "star_green.png";
                }
            }
                 
			list1 = list;
            ItemsListView.ItemsSource = list;
		}

		async void AddTask_Clicked(object sender, EventArgs e)
		{
            await Navigation.PushAsync(new NewTaskPage());
		}

		async void DeleteTask_Clicked(object sender, EventArgs e)
		{
			var mi = ((MenuItem)sender);


			await App.Client.DeleteTask((int)mi.CommandParameter);

			App.GoToMainPage();
		}

		async void FinishTask_Clicked(object sender, EventArgs e)
		{
			var mi = ((MenuItem)sender);

            await App.Client.finishTask((int)mi.CommandParameter);

			App.GoToMainPage();
		}
    }
}