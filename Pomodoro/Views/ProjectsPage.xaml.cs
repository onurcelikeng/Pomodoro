using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Pomodoro.Models;

namespace Pomodoro
{
    public partial class ProjectsPage : ContentPage
    {
        
        public ProjectsPage()
        {
            InitializeComponent();
            this.GetData();
        }


        public async void GetData()
        {
            List<ProjectModel> projects = new List<ProjectModel>();
            projects = await App.Client.GetProjects();
            for (int i = 0; i < projects.Count; i++)
            {
				if (projects[i].Priority.Equals("1"))
				{
					projects[i].Priority = "priority_red.png";
				}
				else if (projects[i].Priority.Equals("2"))
				{
					projects[i].Priority = "priority_purple.png";
				}
				else if (projects[i].Priority.Equals("3"))
				{
					projects[i].Priority = "priority_blue.png";
				}
				else
				{
					projects[i].Priority = "priority_green.png";
				}
            }
            ItemsListView.ItemsSource = projects;
        }

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var item = args.SelectedItem as ProjectModel;
            if (item == null) return;

            Views.TaskPage.ProjectId = item.Id;
            await Navigation.PushAsync(new Views.TaskPage());
            ItemsListView.SelectedItem = null;
        }

        async void AddProject_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new NewItemPage());
        }

		async void DeleteProject_Clicked(object sender, EventArgs e)
		{
            var mi = ((MenuItem)sender); 
            
			
            await App.Client.DeleteProject((int)mi.CommandParameter);

			App.GoToMainPage();
		}
    }
}