namespace ReleaseRetentionSolution.Models;

using Newtonsoft.Json;

public class Environment : IPrintable
{
    [JsonConstructor]
    Environment(string id, string name)
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