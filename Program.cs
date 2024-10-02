using System;

namespace Program
{

    public class TaskItem(string description)
    {
        public int Id { get; set; }
        public string Description { get; set; } = description;

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public override string ToString()
        {
            return $"{Id}. {Description} (Created: {CreatedAt})";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Choose Storage option: 1. File, 2. Database");
            var choice = Console.ReadLine();
            IStorage storage;

            if (choice == "1")
            {
                storage = new FileTaskStorage();
            }
            else
            {
                storage = new SqliteTaskStorage();
            }

            var taskManager = new TaskManager(storage);

            TaskActions(taskManager);
        }

        public static void TaskActions(TaskManager taskManager)
        {
            var exit = false;

            while (!exit)
            {
                Console.WriteLine("Choose Action option: 1. Add Task, 2. View Tasks, 3. Remove Task, 4: Exit");
                var choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        Console.WriteLine("Enter new Task:");
                        var task = Console.ReadLine();
                        if (!string.IsNullOrEmpty(task))
                        {
                            taskManager.AddTask(task);
                        }
                        break;
                    case "2":
                        Console.WriteLine("Yours all Tasks list:");
                        taskManager.ViewTasks();
                        break;
                    case "3":
                        Console.WriteLine("Enter the ID of the Task to remove:");
                        var input = Console.ReadLine();
                        if (!string.IsNullOrEmpty(input))
                        {
                            bool isValid = int.TryParse(input, out int id);
                            if (isValid)
                            {
                                taskManager.RemoveTask(id);
                            }
                        }
                        break;
                    case "4":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please select a valid option.");
                        break;
                }
            }

            NewKeyRequest();
        }
        static void NewKeyRequest()
        {
            Console.WriteLine("\nPress any key to Close the program.");
            Console.ReadKey();
        }
    }
}