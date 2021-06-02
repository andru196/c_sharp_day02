using System;

namespace d02_ex01.Configuration.Sources
{
    public class EnvSource : IConfigurationSource
    {
        public int Priority {get; init;}        
        public Configuration LoadData()
        {
            var res =  new Configuration()
            {
                Address = Environment.GetEnvironmentVariable("Address"),
                SecretKey = Environment.GetEnvironmentVariable("SecretKey"),
                User = Environment.GetEnvironmentVariable("Address"),
            };
            if (short.TryParse(Environment.GetEnvironmentVariable("Port"),
                out var  prt))
                res.Port = prt;
            if (DateTime.TryParse(Environment.GetEnvironmentVariable("TimeOfRun"),
                out var timeOfRun))
                res.TimeOfRun = timeOfRun;
            return res;
        }
    }
}