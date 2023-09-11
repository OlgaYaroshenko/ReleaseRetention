namespace ReleaseRetentionSolution
{
    using System;
    using System.IO;
    using Newtonsoft.Json;
    using ReleaseRetentionSolution.Models;
    using Environment = ReleaseRetentionSolution.Models.Environment;

    static class Program
    {
        static void Main(string[] args)
        {
            // Deployments
            string filePath = "C:/Dev/Oc/ReleaseRetention/JsonFiles/Deployments.json";
            if (!PathExists(filePath)) return;
            var jsonContent = ReadFromJson(filePath);
            var deployments = CreateList<Deployment>(jsonContent);

            // Releases
            filePath = "C:/Dev/Oc/ReleaseRetention/JsonFiles/Releases.json";
            if (!PathExists(filePath)) return;
            jsonContent = ReadFromJson(filePath);
            var releases = CreateList<Release>(jsonContent);

            // Environments
            filePath = "C:/Dev/Oc/ReleaseRetention/JsonFiles/Environments.json";
            if (!PathExists(filePath)) return;
            jsonContent = ReadFromJson(filePath);
            var environments = CreateList<Environment>(jsonContent);

            // Projects
            filePath = "C:/Dev/Oc/ReleaseRetention/JsonFiles/Projects.json";
            if (!PathExists(filePath)) return;
            jsonContent = ReadFromJson(filePath);
            var projects = CreateList<Project>(jsonContent);
            
            //var numberOfReleasesToKeep = 10;
            var notDeployedReleases = new List<Release>();
            var deployedReleases = new List<Release>();


            foreach (var release in releases)
            {
                var deployment = deployments.Find(x => x.ReleaseId == release.Id);
                if (deployment == null)
                {
                    notDeployedReleases.Add(release);
                }
                else
                {
                    deployedReleases.Add(release);
                }
            }

            Console.WriteLine("**************DEPLOYED***********************");

            foreach (var release in deployedReleases)
            {
                release.Print();
            }

            Console.WriteLine("**************NOT DEPLOYED***********************");

            foreach (var release in notDeployedReleases)
            {
                release.Print();
            }
        }

        private static string ReadFromJson(string filePath)
        {
            try
            {
                string jsonContent = File.ReadAllText(filePath);
                return jsonContent;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }

            return string.Empty;
        }

        private static List<T> CreateList<T>(string jsonContent) where T : class, IPrintable
        {
            List<T> items = JsonConvert.DeserializeObject<List<T>>(jsonContent) ?? throw new InvalidOperationException();
            //PrintList(items);

            return items;
        }


        private static void PrintList<T>(List<T>? items) where T : IPrintable
        {
            if (items == null) return;

            foreach (var item in items)
            {
                item.Print();
            }
        }

        private static bool PathExists(string filePath)
        {
            if (File.Exists(filePath)) return true;
            Console.WriteLine($"File '{filePath}' not found.");
            return false;
        }
    }
}