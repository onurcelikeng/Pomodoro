using System;
using Pomodoro.Models;
using Xamarin.Forms;

namespace Pomodoro
{
    public partial class NewItemPage : ContentPage
    {

        public NewItemPage()
        {
            InitializeComponent();
        }

        public async void Save_Clicked(object sender, EventArgs e)
        {
            var model = new ProjectModel()
            {
                Title = ProjectName.Text,
                Category = CategoryName.Text,
                Priority = Priority.Text
            };
            var response = await App.Client.AddProject(model);

            App.GoToMainPage();
        }
    }
}