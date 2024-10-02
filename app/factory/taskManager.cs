using Program;

public class TaskManager(IStorage storage)
{
    private readonly IStorage _taskStorage = storage;

    public void AddTask(string description){
        var task = new TaskItem(description);
        _taskStorage.AddTask(task);
    }

    public void RemoveTask(int id){
        _taskStorage.RemoveTask(id);
    }

    public void ViewTasks(){
        var tasks = _taskStorage.ViewTasks();
        if (tasks.Count == 0)
        {
            Console.WriteLine("No tasks available.");
        }
        else
        {
            foreach (var task in tasks)
            {
                Console.WriteLine(task);
            }
        }
    }
}