using Program;

public class FileTaskStorage : IStorage
{
    private readonly string _connectionString = "db.txt";

    public void AddTask(TaskItem task)
    {
        var tasks = ViewTasks();
        Console.WriteLine(tasks.Count);
        task.Id = tasks.Count > 0 ? tasks.Max(t => t.Id) + 1 : 1;
        try
        {
            tasks.Add(task);
            Console.WriteLine($"Task is added!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error for adding: {ex.Message}");
        }

        SaveToFile(tasks);
    }

    public void RemoveTask(int id)
    {
        var tasks = ViewTasks();
        var taskToRemove = tasks.SingleOrDefault(t => t.Id == id);

        if (taskToRemove != null)
        {
            try
            {
                tasks.Remove(taskToRemove);
                Console.WriteLine($"Task is removed!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error for removing: {ex.Message}");
            }
            SaveToFile(tasks);
        }else{
            Console.WriteLine($"No Task is found for ID: {id}");
        }
    }

    public List<TaskItem> ViewTasks()
    {
        var tasks = new List<TaskItem>();

        if (File.Exists(_connectionString))
        {
            var lines = File.ReadAllLines(_connectionString);
            foreach (var line in lines)
            {
                var parts = line.Split('|');

                if (parts.Length == 3)
                {
                    try
                    {

                        var task = new TaskItem(parts[1])
                        {
                            Id = int.Parse(parts[0]),
                            CreatedAt = DateTime.Parse(parts[2])
                        };

                        tasks.Add(task);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error parsing task: {ex.Message}");
                    }
                }
            }
        }

        return tasks;
    }

    public void SaveToFile(List<TaskItem> tasks)
    {
        var lines = tasks.Select(t => $"{t.Id}|{t.Description}|{t.CreatedAt}");
        File.WriteAllLines(_connectionString, lines);
    }
}