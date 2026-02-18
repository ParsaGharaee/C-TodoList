using System;
using System.Collections.Generic;
using System.Linq;

public class TaskManager
{
    private List<Todotask> tasks;
    private ITaskRepository repository;
    private int nextId;

    public TaskManager(ITaskRepository repository)
    {
        this.repository = repository;
        tasks = repository.Load();
        nextId = tasks.Count > 0 
            ? tasks.Max(t => t.Id) + 1 
            : 1;
    }

    public void AddTask(string title, string description)
    {
        Todotask task = new Todotask()
        {
            Id = nextId++,
            Title = title,
            Description = description,
            Iscompleted = false
        };

        tasks.Add(task);

        repository.Save(tasks);
    }

    public void ShowTasks(bool status)
    {
        foreach (var p in tasks.Where(t => t.Iscompleted == status))
        {
            Console.WriteLine(
                $"{p.Id} - {p.Title} - {p.Description} - {(p.Iscompleted ? "✔️" : "✖️")}"
            );
        }
    }

    public void CompleteTask(int id)
    {
        var selectedTask = tasks.Find(t => t.Id == id);

        if (selectedTask != null)
        {
            selectedTask.Iscompleted = true;
            Console.WriteLine("successfull");

            repository.Save(tasks);
        }
        else
        {
            Console.WriteLine("task not found");
        }
    }

    public void RemoveTask(int id)
    {
        var selectedTask = tasks.Find(t => t.Id == id);

        if (selectedTask != null)
        {
            tasks.Remove(selectedTask);
            Console.WriteLine("sucess");

            repository.Save(tasks);
        }
        else
        {
            Console.WriteLine("task not found");
        }
    }
}
