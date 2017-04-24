namespace Pomodoro.Models
{
    public class TaskModel
    {
        public int Id { get; set; }

        public int ProjectId { get; set; }

        public string Title { get; set; }

        public string Category { get; set;}

        public string Description { get; set; }

        public string Priority { get; set; }

        public string isFinish { get; set; }

        public int ExpectedWorkTime { get; set; }
    }
}