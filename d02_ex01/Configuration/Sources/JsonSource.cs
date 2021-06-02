using System.Text.Json;

namespace d02_ex01.Configuration.Sources
{
    public class JsonSource : IConfigurationSource
    {
        public int Priority {get; init;}
        public string Path {get; init;}
        
        public JsonSource(int priority, string path)
        {
            var fi = new System.IO.FileInfo(path);
            if (!fi.Exists)
                throw new System.IO.FileNotFoundException("Fuck");
            if (fi.Extension.ToLower() != ".json")
                throw new System.IO.InvalidDataException("And your 'json'");
            Priority = priority;
            Path = path;
        }
        
        public Configuration LoadData()
        {
            try
            {
                var result = JsonSerializer.Deserialize<Configuration>(Path, new JsonSerializerOptions()
                {
                    PropertyNameCaseInsensitive = false
                });
                return result;
            }
            catch (System.Exception e)
            {
                throw new System.IO.FileLoadException("Fuuuuuuuuck", e);
            }
        }
    }
}