using System;
namespace Pomodoro.Models
{
    public class SettingModel
    {
        public int Id { get; set; }

        public int WorkingTime { get; set; }

        public int ShortBreakTime { get; set; }

        public int LongBreakTime { get; set; }

        public int LongBreakTerms { get; set; }
    }
}
