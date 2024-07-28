using Tasks.Model;

namespace Tasks.Repositories
{
    public class TaskRepositoryInMemory : ITaskRepository
    {
        private List<MyTask> Model = new List<MyTask>();
        public void AddTask(MyTask task)
        {
            Model.Add(task);
        }

        public List<MyTask> GetAllTasks()
        {
            return Model;
        }

        public void RemoveTask(int id)
        {
            var existTask = Model.First(x => x.Id == id);

            Model.Remove(existTask); 
        }

        public void UpdateTask(MyTask task)
        {
            var existTask = Model.First(x => x.Id == task.Id);

            if(existTask != null) 
            {
                existTask.Id = task.Id;
                existTask.DueDate = task.DueDate;
                existTask.Description = task.Description;
                existTask.Title = task.Title;
                existTask.Priority = task.Priority;
            }
        }
    }
}
