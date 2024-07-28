using Tasks.Repositories;
using Tasks.Services;
using System;

class Program
{
    private static TaskService taskService;
    private static ITaskRepository repository;

    static void Main(string[] args)
    {
        repository = new TaskRepositoryInMemory();
        taskService = new TaskService(repository);
        var menuHandler = new MenuHandler(taskService);

        menuHandler.DisplayMenu();
    }
}
