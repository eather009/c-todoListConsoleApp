using Microsoft.Data.Sqlite;
using Program;


public class SqliteTaskStorage : IStorage
{
    private readonly string _connectionString = "";

    public SqliteTaskStorage(string dataSource = "todolist.db")
    {
        _connectionString = "Data Source=" + dataSource;

        InitializeDatabase();
    }

    private void InitializeDatabase()
    {
        using var connection = new SqliteConnection(_connectionString);
        connection.Open();

        string createTableQuery = @"
            CREATE TABLE IF NOT EXISTS tasks (
            Id INTEGER PRIMARY KEY AUTOINCREMENT,
            Description TEXT NOT NULL,
            CreatedAt TEXT NOT NULL
            );";

        using (var command = new SqliteCommand(createTableQuery, connection))
        {
            command.ExecuteNonQuery();
        };
    }

    public void AddTask(TaskItem task)
    {
        using var connection = new SqliteConnection(_connectionString);
        connection.Open();

        string insertQuery = @"
        INSERT INTO tasks (Description, CreatedAt) VALUES(
        @description, @created_at)
        ";
        try{
            using (var command = new SqliteCommand(insertQuery, connection))
            {
                command.Parameters.AddWithValue("@description", task.Description);
                command.Parameters.AddWithValue("@created_at", task.CreatedAt);
                command.ExecuteNonQuery();
            };
            Console.WriteLine($"Task is added!");
        }catch (Exception ex)
        {
            Console.WriteLine($"Error for adding: {ex.Message}");
        }
        

    }

    public void RemoveTask(int id)
    {
        using var connection = new SqliteConnection(_connectionString);
        connection.Open();

        string deleteQuery = @"
        DELETE FROM tasks where Id=@id";
        try{
            using (var command = new SqliteCommand(deleteQuery, connection))
            {
                command.Parameters.AddWithValue("@id", id);
                
                int affectedRows = command.ExecuteNonQuery();
                if (affectedRows == 0)
                {
                    throw new Exception($"No task found with ID {id}");
                }
                else
                {
                    Console.WriteLine($"Task is removed!");
                }
                command.ExecuteNonQuery();
            };
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error for removing: {ex.Message}");
        }
    }

    public List<TaskItem> ViewTasks()
    {
        var tasks = new List<TaskItem>();
        using var connection = new SqliteConnection(_connectionString);
        connection.Open();

        string selectQuery = @"
        SELECT * FROM tasks
        ";

        try
        {
            using var command = new SqliteCommand(selectQuery, connection);
            using var reader = command.ExecuteReader();

            while (reader.Read())
            {
                var task = new TaskItem(reader.GetString(1))
                {
                    Id = reader.GetInt32(0),
                    CreatedAt = DateTime.Parse(reader.GetString(2))
                };

                tasks.Add(task);
            }

        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error for list: {ex.Message}");
        }


        return tasks;
    }
}
