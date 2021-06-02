using YamlDotNet.Serialization;

namespace d02_ex01.Configuration.Sources
{
    public class YamlSource : IConfigurationSource
    {
        public int Priority {get; init;}
        public string Path {get; init;}
        
        public YamlSource(int priority, string path)
        {
            var fi = new System.IO.FileInfo(path);
            if (!fi.Exists)
                throw new System.IO.FileNotFoundException("Fuck");
            if (fi.Extension.ToLower() != ".yaml")
                throw new System.IO.InvalidDataException("And your 'yaml'");
            Priority = priority;
            Path = path;
        }
        
        public Configuration LoadData()
        {
            try
            {
                var deser = new YamlDotNet.Serialization.Deserializer();
                using var fileStream = new System.IO.StreamReader(Path);
                var result = deser.Deserialize<Configuration>(fileStream);
                return result;
            }
            catch (System.Exception e)
            {
                throw new System.IO.FileLoadException("Fuuuuuuuuck", e);
            }
        }
    }
}