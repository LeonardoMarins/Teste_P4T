using Tasks.Model;
using Tasks.Repositories;

namespace Tasks.Services
{
    public class TaskService
    {
        private readonly ITaskRepository _taskRepository;

        // Regra de negocio
        public TaskService(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public void AddTask(MyTask task)
        {
            _taskRepository.AddTask(task);
        }

        public void RemoveTask(int id)
        {
            _taskRepository.RemoveTask(id);
        }

        public void UpdateTask(MyTask task)
        {
            _taskRepository.UpdateTask(task);
        }

        public List<MyTask> GetAllTasks()
        {
            return _taskRepository.GetAllTasks();
        }
    }
}
