using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace Pomodoro.Views
{
    public partial class ProfilePage : ContentPage
    {
        public static int workingTime;
        public static int shortBreak;
        public static int longBreak;
        public static int longBreakTerms;
        
        public ProfilePage()
        {
            InitializeComponent();

            picker1.SelectedIndex = 4;
			picker2.SelectedIndex = 4;
			picker3.SelectedIndex = 2;
			picker4.SelectedIndex = 2;

            workingTime = Int32.Parse(picker1.SelectedItem.ToString());
            shortBreak = Int32.Parse(picker2.SelectedItem.ToString());
            longBreak = Int32.Parse(picker3.SelectedItem.ToString());
            longBreakTerms = Int32.Parse(picker4.SelectedItem.ToString());


        }

		private void Save_Clicked(object sender, EventArgs e)
		{
			
		}

        private void Logout_Clicked(object sender, EventArgs e)
		{
            //log out
		}
    }
}