using System;
using d02_ex01.Configuration.Sources;
using d02_ex01.Configuration;
using System.Linq;
using System.Collections.Generic;
using System.IO;
using System.Text;

if (args.Length != 4 || !int.TryParse(args[1], out var jsonPriority)
    || !int.TryParse(args[3], out var yamlPriority))
{
    Console.WriteLine("Invalid data. Check your input and try again.");
    return;
}
var jsonPath = args[0];
var yamlPath = args[2];
var results = new List<IConfigurationSource>();

foreach (var source in
        new Func<IConfigurationSource>[]{
            () => new JsonSource(jsonPriority, jsonPath),
            () => new YamlSource(yamlPriority, yamlPath)})
    try
    {
        results.Add(source());
    }
    catch (FileNotFoundException)
    {
        Console.WriteLine("File not found, skip");
    }
    catch (InvalidDataException)
    {
        Console.WriteLine("Bad extension, skip");
    }
if (results.Count < 1)
{
    Console.WriteLine("Bad parameters, exit");
    return;
}
results.Add(new EnvSource());


var finishresults = results.OrderBy(x => x.Priority).Select(x=>x.LoadData());
var res = MergerSet(finishresults);
PrintConfiguation(res);


Configuration MergerSet(IEnumerable<Configuration> _set)
{
    var res = new Configuration();
    var enumerator = _set.GetEnumerator();
    while ((res.Address == null || res.Port == null || res.SecretKey == null
        || res.TimeOfRun == null || res.User == null) && enumerator.MoveNext())
    {
        var current = enumerator.Current;
        if (res.Address == null && current.Address != null)
            res.Address = current.Address;
        if (res.Port == null && current.Port != null)
            res.Port = current.Port;
        if (res.SecretKey == null && current.SecretKey != null)
            res.SecretKey = current.SecretKey;
        if (res.TimeOfRun == null && current.TimeOfRun != null)
            res.TimeOfRun = current.TimeOfRun;
        if (res.User == null && current.User != null)
            res.User = current.User;
    }
    return res;
}

void PrintConfiguation(Configuration conf)
{
    var strBuilder = new StringBuilder();
    strBuilder.Append($"Address\t{conf.Address}");
    strBuilder.Append($"\nPort\t{conf.Port}");
    strBuilder.Append($"\nSecretKey\t{conf.SecretKey}");
    strBuilder.Append($"\nUser\t{conf.User}");
    strBuilder.Append($"\nTimeOfRun\t{conf.TimeOfRun}");
    Console.WriteLine(strBuilder);
}