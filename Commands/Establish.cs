// The file is used for establishing the connection to the LLM 
using cvc.yaml;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;
using System.IO;

namespace cvc.establish;

public class Establish
{
    private static string _agentYamlFile = ".cvc/agent.yaml";
    public static Yaml Connection()
    {
        var deserializer = new DeserializerBuilder()
                               .WithNamingConvention(UnderscoredNamingConvention.Instance)
                               .Build();
        string content = File.ReadAllText(_agentYamlFile);
        Yaml yamlconent = deserializer.Deserialize<Yaml>(content);

        return yamlconent;

    }
}
