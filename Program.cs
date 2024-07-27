using Tasks.Repositories;
using Tasks.Services;
using Tasks.Model;
using Tasks.Enum;
using System.Threading.Tasks;

class Program
{
    private static TaskService taskService;
    private static ITaskRepository repository;

    static void Main(string[] args)
    {
        repository = new TaskRepositoryInMemory();
        taskService = new TaskService(repository);
        var tasks = taskService.GetAllTasks();

        Console.WriteLine("*** Bem vindo ao MinhaTarefa. *** \n");
        var continuar = true;

        while(continuar)
        {
            switch (Menu())
            {
                case 1:
                    Console.Clear();
                    taskService.AddTask(Create());
                    break;
                case 2:
                    Console.Clear();
                    foreach (var task in tasks)
                    {
                        Console.WriteLine(task.Title);
                    }
                    Console.WriteLine("Qual tarefa você quer excluir ?");
                    Console.ReadLine();
                    break;
                case 3:
                    Console.Clear();
                    foreach (var task in tasks)
                    {
                        Console.WriteLine(task.Title);
                    }
                    Console.WriteLine("Qual tarefa você quer atualizar ?");
                    Console.ReadLine();
                    break;
                case 5:
                    continuar = false;
                    break;
            }
        }
    }


    private static MyTask Create()
    {
        Console.WriteLine("Qual o titulo da tarefa:");
        var title = Console.ReadLine();
        Console.WriteLine("Qual a descricao da tarefa:");
        var description = Console.ReadLine();
        Console.WriteLine("Qual a data de vencimento da tarefa:");
        var dueDate = Console.ReadLine();
        Console.WriteLine("Qual a prioridade da tarefa:");
        var priority = Console.ReadLine();
        PriorityType priorityType = (PriorityType)Enum.Parse(typeof(PriorityType), priority);

        var task = new MyTask
        {
            Id = new Guid(),
            Title = title,
            Description = description,
            DueDate = DateTime.Parse(dueDate),
            Priority = priorityType
        };

        return task;

    }

    private static int Menu()
    {
        Console.WriteLine("1- Adicionar uma tarefa");
        Console.WriteLine("2- Remover uma tarefa");
        Console.WriteLine("3- Atualizar uma tarefa");
        Console.WriteLine("4- Listar todas as tarefas");
        Console.WriteLine("5- Para sair do programa \n");
        Console.Write("Escolha uma opção: ");
        var op = Console.ReadLine();
        Int32.TryParse(op, out var value);

        return value;
    }
}