using System.IO;
using System.Reflection;
using Newtonsoft.Json;

namespace M12_Dzianis_Dukhnou.Utilities
{
    public static class Utility
    {
        public static T ReadJsonFile<T>(string pathToFile)
        {
            string body;
            string executableLocation = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

            using (StreamReader reader = new StreamReader(Path.Combine(executableLocation, pathToFile)))
            {
                body = reader.ReadToEnd();
            }

            return JsonConvert.DeserializeObject<T>(body);
        }
    }
}