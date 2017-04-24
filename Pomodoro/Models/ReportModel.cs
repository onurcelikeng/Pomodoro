namespace Pomodoro.Models
{
    public class ReportModel
    {
        public int Id { get; set; }

        public int ProjectId { get; set; }

        public int TotalBreakTime { get; set; }

        public int TotalWorkTime { get; set; }

        public int ExpectedWorkTime { get; set; }
    }
}
