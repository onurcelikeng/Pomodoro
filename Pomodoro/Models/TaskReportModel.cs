namespace Pomodoro.Models
{
    public class TaskReportModel
    {
        public int Id { get; set; }

        public int ReportId { get; set; }

        public int TaskId { get; set; }

        public int TotalWorkTime { get; set; }

        public int TotalBreakTime { get; set; }

        public int ExpectedWorkTime { get; set; }
    }
}
