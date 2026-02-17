using System;
using System.Security.Cryptography.X509Certificates;
using System.Text.Json;


public class Todotask
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public bool Iscompleted { get; set; }
}

public class TaskManager
{
    List<Todotask> tasks = new List<Todotask>();
    int nextId = 1;

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
    }

    public void ShowTasks(bool status)
    {


        foreach (var p in tasks.Where(t => t.Iscompleted == status))
        {
            Console.WriteLine($"{p.Id} - {p.Title} - {p.Description} - {(p.Iscompleted ? "✔️" : "✖️")}");
        }
    }

    public void CompleteTask(int id)
    {
        var selectedTask = tasks.Find(t => t.Id == id);
        if (selectedTask != null)
        {
            selectedTask.Iscompleted = true;
            Console.WriteLine("successfull");

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

        }
        else
        {
            Console.WriteLine("task not found");

        }
    }



    public void SaveData(string path)
    {
        string json = JsonSerializer.Serialize(tasks);
        File.WriteAllText(path, json);
    }
    public void LoadData(string path)
    {
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);

            if (!string.IsNullOrWhiteSpace(json))
            {
                tasks = JsonSerializer.Deserialize<List<Todotask>>(json) ?? new List<Todotask>();
                nextId = tasks.Count > 0 ? tasks.Max(t => t.Id) + 1 : 1;
            }
            else
            {
                tasks = new List<Todotask>();
                nextId = 1;
            }
        }

    }

    public class Program
    {
        public static void Main()
        {
            TaskManager manager = new TaskManager();
            string path = @"C:\Users\MSI\Desktop\Todo\DataBase\DataBase.json";

            manager.LoadData(path);

            while (true)
            {
                Console.WriteLine("1. afzodan task");
                Console.WriteLine("2. hame task ha");
                Console.WriteLine("3. anjam task");
                Console.WriteLine("4. hazf task");
                Console.WriteLine("5. exit");

                string choise = Console.ReadLine();

                if (choise == "1")
                {
                    Console.WriteLine("onvan:");
                    string title = Console.ReadLine();
                    Console.WriteLine("tozih:");
                    string description = Console.ReadLine();
                    manager.AddTask(title, description);
                    Console.WriteLine("sucess");
                    Console.ReadLine();
                    manager.SaveData(path);

                    Console.WriteLine("-----------------------");

                }

                else if (choise == "2")

                {
                    Console.WriteLine("1. anjam shode ha");
                    Console.WriteLine("2. anjam nashode ha");

                    string statuscode = Console.ReadLine();

                    bool status = false;


                    if (statuscode == "1")
                    {
                        status = true;
                    }
                    else if (statuscode == "2")
                    {
                        status = false;
                    }
                    else
                    {
                        Console.WriteLine("invalid value");
                        continue;
                    }


                    manager.ShowTasks(status);
                    Console.ReadLine();
                    manager.SaveData(path);

                    Console.WriteLine("-----------------------");

                }
                else if (choise == "3")
                {
                    Console.WriteLine("id hadaf:");
                    int id;

                    while (!int.TryParse(Console.ReadLine(), out id))
                    {
                        Console.WriteLine("adad vared konid");

                    }
                    manager.CompleteTask(id);
                    Console.ReadLine();
                    manager.SaveData(path);

                    Console.WriteLine("-----------------------");
                }
                else if (choise == "4")
                {
                    Console.WriteLine("id hadaf:");
                    int id;
                    while (!int.TryParse(Console.ReadLine(), out id))
                    {
                        Console.WriteLine("adad vared konid");

                    }
                    manager.RemoveTask(id);
                    Console.ReadLine();
                    manager.SaveData(path);

                    Console.WriteLine("-----------------------");
                }
                else if (choise == "5")
                {
                    manager.SaveData(path);

                    break;
                }
            }
        }
    }
}

