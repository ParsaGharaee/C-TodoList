public class Program
{
    public static void Main()
    {
        string path = @"C:\Users\MSI\Desktop\Todo\DataBase\DataBase.json";

        ITaskRepository repository = new FileTaskRepository(path);

        TaskManager manager = new TaskManager(repository);

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
                Console.WriteLine("-----------------------");
            }

            else if (choise == "2")
            {
                Console.WriteLine("1. anjam shode ha");
                Console.WriteLine("2. anjam nashode ha");

                string statuscode = Console.ReadLine();

                bool status;

                if (statuscode == "1")
                    status = true;
                else if (statuscode == "2")
                    status = false;
                else
                {
                    Console.WriteLine("invalid value");
                    continue;
                }

                manager.ShowTasks(status);
                Console.ReadLine();
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
                Console.WriteLine("-----------------------");
            }

            else if (choise == "5")
            {
                break;
            }
        }
    }
}
