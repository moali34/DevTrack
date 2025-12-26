namespace DevTrack.Models
{
    public class TaskItem
    {
        public int Id { get; set; }
        public string Title { get; set; } = "";
        public TaskStatus Status { get; set; }
        public int ProjectId { get; set; }
        public Project? Project { get; set; }
    }

}
