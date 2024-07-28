using System;
using Tasks.Services;

public class MenuHandler
{
    private readonly TaskService _taskService;
    private readonly TaskInputHandler _taskInputHandler;
    private int _nextId;

    public MenuHandler(TaskService taskService)
    {
        _taskService = taskService;
        _taskInputHandler = new TaskInputHandler();
        _nextId = 0;
    }

    public void DisplayMenu()
    {
        var continuar = true;

        while (continuar)
        {
            switch (ShowMenu())
            {
                case 1:
                    Console.Clear();
                    var task = _taskInputHandler.CreateTask(_nextId++);
                    if (task != null)
                    {
                        _taskService.AddTask(task);
                        Console.WriteLine("Tarefa cadastrada com sucesso \n");
                    }
                    Console.WriteLine("Aperte a tecla ENTER para voltar ao menu");
                    Console.ReadLine();
                    Console.Clear();
                    break;
                case 2:
                    Console.Clear();
                    Console.WriteLine("Tarefas Salvas:");
                    DisplayTasks();
                    Console.WriteLine("\n");
                    Console.WriteLine("Qual tarefa você quer excluir? Digite o título da tarefa:");
                    var titleToRemove = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(titleToRemove))
                    {
                        _taskService.RemoveTask(titleToRemove);
                    }
                    Console.WriteLine("Aperte a tecla ENTER para voltar ao menu");
                    Console.ReadLine();
                    Console.Clear();
                    break;
                case 3:
                    Console.Clear();
                    Console.WriteLine("Tarefas Salvas:");
                    DisplayTasks();
                    Console.WriteLine("\n");
                    Console.WriteLine("Qual tarefa você quer atualizar? Digite o ID da tarefa:");
                    if (int.TryParse(Console.ReadLine(), out var value))
                    {
                        var taskToUpdate = _taskService.GetAllTasks().Find(x => x.Id == value);
                        if (taskToUpdate != null)
                        {
                            _taskInputHandler.UpdateTask(taskToUpdate);
                            _taskService.UpdateTask(taskToUpdate);
                        }
                        else
                        {
                            Console.WriteLine("Tarefa não encontrada.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("ID inválido.");
                    }
                    Console.WriteLine("Aperte a tecla ENTER para voltar ao menu");
                    Console.ReadLine();
                    Console.Clear();
                    break;
                case 4:
                    Console.Clear();
                    Console.WriteLine("Tarefas Salvas:");
                    DisplayTasks();
                    Console.WriteLine("Aperte a tecla ENTER para voltar ao menu");
                    Console.ReadLine();
                    Console.Clear();
                    break;
                case 5:
                    continuar = false;
                    break;
            }
        }
    }

    private int ShowMenu()
    {
        Console.WriteLine("*** Bem-vindo ao MinhaTarefa. *** \n");
        Console.WriteLine("1- Adicionar uma tarefa");
        Console.WriteLine("2- Remover uma tarefa");
        Console.WriteLine("3- Atualizar uma tarefa");
        Console.WriteLine("4- Listar todas as tarefas");
        Console.WriteLine("5- Sair do programa \n");
        Console.Write("Escolha uma opção: ");
        if (int.TryParse(Console.ReadLine(), out var value))
        {
            return value;
        }
        return 0;
    }

    private void DisplayTasks()
    {
        var tasks = _taskService.GetAllTasks();
        foreach (var task in tasks)
        {
            Console.Write(task.Id + " Titulo: " + task.Title + " Descricao: " + task.Description + " Data de vencimento: " + task.DueDate + " Prioridade: " + task.Priority + "\n");
        }
    }
}
