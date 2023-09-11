namespace ReleaseRetentionSolution.Models;

using Newtonsoft.Json;

public class Release : IPrintable
{
    [JsonConstructor]
    public Release(string id, string projectId, string version, DateTime created)
    {
        Id = id;
        ProjectId = projectId;
        Version = version;
        Created = created;
    }

    public readonly string Id;
    public readonly string ProjectId;
    public readonly string Version;
    public readonly DateTime Created;
    public void Print()
    {
        Console.WriteLine($"Id: {Id}, ProjectId: {ProjectId}, Version: {Version}, Created: {Created}");
    }
}