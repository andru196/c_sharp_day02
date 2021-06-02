using System;

namespace d02_ex01.Configuration
{
    [Serializable]
    public class Configuration
    {
        public string Address {get; set;}
        public short? Port {get; set;}
        public string SecretKey {get; set;}
        public string User {get; set;}
        public DateTime? TimeOfRun {get; set;}
    }
}