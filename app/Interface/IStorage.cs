using Program;

public interface IStorage
{
    void AddTask(TaskItem task);
    List<TaskItem>ViewTasks();
    void RemoveTask(int id);
}