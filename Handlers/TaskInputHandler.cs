using System;
using Tasks.Model;
using Tasks.Enum;

public class TaskInputHandler
{
    public MyTask CreateTask(int nextId)
    {
        try
        {
            Console.WriteLine("Qual o título da tarefa:");
            var title = Console.ReadLine();
            Console.WriteLine("Qual a descrição da tarefa:");
            var description = Console.ReadLine();
            Console.WriteLine("Qual a data de vencimento da tarefa (dd/MM/yyyy):");
            var dueDateInput = Console.ReadLine();
            var dueDate = DateTime.Parse(dueDateInput);
            Console.WriteLine("Qual a prioridade da tarefa:");
            var priorityInput = Console.ReadLine();

            if (Enum.TryParse<PriorityType>(priorityInput, out var priorityType))
            {
                var task = new MyTask
                {
                    Id = nextId,
                    Title = title,
                    Description = description,
                    DueDate = dueDate,
                    Priority = priorityType
                };

                return task;
            }
        }catch(FormatException ex)
        {
            Console.WriteLine("A data precisa estar no formato (dd/MM/yyyy)");
        }
       

        Console.WriteLine("Dados inválidos. Tarefa não criada.");
        return null;
    }

    public void UpdateTask(MyTask task)
    {
        Console.WriteLine("Qual o título da tarefa:");
        var title = Console.ReadLine();
        Console.WriteLine("Qual a descrição da tarefa:");
        var description = Console.ReadLine();
        Console.WriteLine("Qual a data de vencimento da tarefa (yyyy-MM-dd):");
        var dueDateInput = Console.ReadLine();
        DateTime.TryParse(dueDateInput, out var dueDate);
        Console.WriteLine("Qual a prioridade da tarefa:");
        var priorityInput = Console.ReadLine();

        if (Enum.TryParse<PriorityType>(priorityInput, out var priorityType))
        {
            task.Title = title;
            task.Description = description;
            task.DueDate = dueDate;
            task.Priority = priorityType;
        }
        else
        {
            Console.WriteLine("Dados inválidos. Tarefa não atualizada.");
        }
    }
}
