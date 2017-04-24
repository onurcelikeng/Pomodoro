namespace Pomodoro.Models
{
    public class ProjectModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Category { get; set; }

        public string Priority { get; set; }

        public string isFinish { get; set; }
    }
}