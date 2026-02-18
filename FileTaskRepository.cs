using System.Text.Json;

public class FileTaskRepository : ITaskRepository
{
    private readonly string _path;

    public FileTaskRepository(string path)
    {
        _path = path;
    }

    public void Save(List<Todotask> tasks)
    {
        string json = JsonSerializer.Serialize(tasks);
        File.WriteAllText(_path, json);
    }

    public List<Todotask> Load()
    {
        if (!File.Exists(_path))
            return new List<Todotask>();

        string json = File.ReadAllText(_path);

        if (string.IsNullOrWhiteSpace(json))
            return new List<Todotask>();

        return JsonSerializer.Deserialize<List<Todotask>>(json)
               ?? new List<Todotask>();
    }
}
