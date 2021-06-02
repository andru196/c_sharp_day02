
namespace d02_ex01.Configuration.Sources
{
    public interface IConfigurationSource
    {
         int Priority {get;}
        Configuration LoadData();
    }
}