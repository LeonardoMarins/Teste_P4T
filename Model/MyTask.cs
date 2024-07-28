using Tasks.Enum;

namespace Tasks.Model
{
    public class MyTask
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime DueDate { get; set; }
        public PriorityType Priority { get; set; }
    }
}
