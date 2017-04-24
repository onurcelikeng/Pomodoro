using System;
using System.Collections.Generic;
using Pomodoro.Models;
using Xamarin.Forms;

namespace Pomodoro.Views
{
    public partial class NewTaskPage : ContentPage
    {

        public NewTaskPage()
        {
            InitializeComponent();
            Title = "New Task";
        }


		public async void addButton_Clicked(object sender, EventArgs e)
		{
            var model = new AddTaskModel()
            {
                Category = category.Text,
                Description = description.Text,
                Title = task.Text,
                ProjectId = TaskPage.ProjectId.ToString(),
                Priority = priority.Text,
                ExpectedWorkTime = Int32.Parse(expectedWork.Text)
			};

			var result = await App.Client.AddTasks(model);
			App.GoToMainPage();
		}
    }
}