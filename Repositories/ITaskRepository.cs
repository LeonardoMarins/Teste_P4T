using Tasks.Model;

namespace Tasks.Repositories
{
    public interface ITaskRepository
    {
        public void AddTask(MyTask task);
        public void RemoveTask(int id);
        public void UpdateTask(MyTask task);
        public List<MyTask> GetAllTasks();
    }
}
