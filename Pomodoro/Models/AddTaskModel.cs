namespace Pomodoro.Models
{
    public class AddTaskModel
    {
        public string Title { get; set; }

        public string Category { get; set; }

        public string Description { get; set; }

        public string ProjectId { get; set; }

        public string Priority { get; set; }

        public int ExpectedWorkTime { get; set; }
    }
}