namespace ReleaseRetentionSolution.Models;

using Newtonsoft.Json;

public class Deployment : IPrintable
{
    [JsonConstructor]
    Deployment(string id, string releaseId, string environmentId, DateTime deployedAt)
    {
        Id = id;
        ReleaseId = releaseId;
        EnvironmentId = environmentId;
        DeployedAt = deployedAt;
    }

    public readonly string Id;
    public readonly string ReleaseId;
    public readonly string EnvironmentId;
    public readonly DateTime DeployedAt;
    
    public void Print()
    {
            Console.WriteLine($"Id: {Id}, ReleaseId: {ReleaseId}, EnvironmentId: {EnvironmentId}, DeployedAt: {DeployedAt}");
    }  
}