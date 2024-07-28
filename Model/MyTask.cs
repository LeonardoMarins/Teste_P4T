using Tasks.Enum;

namespace Tasks.Model
{
    public class MyTask
    {
        //Trabalhando com int no id ao inves de um Guid, pois nessa aplicacao nao vi necessidade de usar um Guid
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime DueDate { get; set; }
        public PriorityType Priority { get; set; }
    }
}
