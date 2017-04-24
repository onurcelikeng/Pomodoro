using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Pomodoro.Models;

namespace Pomodoro.Views
{
    public partial class TimerPage : ContentPage
    {
        private List<ProjectModel> projects = new List<ProjectModel>();
        private List<TaskModel> tasks = new List<TaskModel>();
        private int shortbreak = 5;
        private int longbreak = 15;
        private int longbreakterms = 4;
        private int work = 24;
		private int count = 0;
        private bool flag = false;
        private bool isWorking = true;
		private int _minute = 24;
		private int _second = 59;
     

        public TimerPage()
        {
            InitializeComponent();
		
			GetProjects();
            Title = "Timer";
            project.Text = "Pomodoro";
            task.Text = "Sunum hazırla"; 
            Timer();
        }

       

        public async void GetProjects()
        {
            projects = await App.Client.GetProjects();
        }

        public async void GetTasks(int projectId)
        {
            tasks = await App.Client.GetTasks(projectId);
        }

        public async void FinishProject(int id)
        {
            await App.Client.FinishProject(id);
        }

        public void Timer()
        {
			Device.StartTimer(TimeSpan.FromSeconds(1), () =>
			{
				if (flag == true)
                {
					flag = false;
                    int finishedCount = 0;

                    for (int i = 0; i < tasks.Count; i++)
                    {
                        if(tasks[i].isFinish == "1")
                        {
                            finishedCount++;
                        }
                    }

                    if (finishedCount == tasks.Count)
                    {
                        //pass next project
                    }
                    else if (finishedCount < tasks.Count)
                    {
                        //pass next task
                    }
				}
                
                _second--;
                if(_second < 10)
                {
                    second.Text = "0" + _second.ToString();
                }
                else if(_second >= 10)
                    second.Text = _second.ToString();

                if (_second == 0)
                {
                    _minute--;
                    if (_minute > 0)
                    {
                        _second = 59;
                        if (_minute < 10)
                            minute.Text = "0" + _minute.ToString();
                        else
                            minute.Text = _minute.ToString();
                    }

                    if (_minute == 0 && _second == 0)
                    {
                        //push notification;
                        if (isWorking == true)
                        {
                            isWorking = false;
                            count++;
                            if (count == longbreakterms)
                                _minute = longbreak;
                            else if (count < longbreakterms)
                                _minute = shortbreak;
                        }
                        else if (isWorking == false)
                        {
                            isWorking = true;
                            _minute = work;
                        }
                    }
                }

                minute.Text = _minute.ToString();
                second.Text = _second.ToString();

                return true;
            });
        }

		public void Button_Clicked(object sender, EventArgs e)
		{
            flag = true;
		}
    }
}