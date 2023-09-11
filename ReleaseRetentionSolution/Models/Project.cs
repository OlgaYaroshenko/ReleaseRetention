namespace ReleaseRetentionSolution.Models;

using Newtonsoft.Json;

public class Project : IPrintable
{
    [JsonConstructor]
    Project(string id, string name)
    {
        Id = id;
        Name = name;
    }

    public readonly string Id;
    public readonly string Name;
    public void Print()
    {
        Console.WriteLine($"Id: {Id}, Name: {Name}");
    }
}