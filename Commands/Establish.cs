// The file is used for establishing the connection to the LLM 
using cvc.yaml;
using dotenv.net;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;
using System.IO;

namespace cvc.establish;

public class Establish
{
    private static string _envFilePath = ".cvc/.env";
    private static string _agentYamlFile = ".cvc/agent.yaml";
    public static Yaml Connection()
    {
        DotEnv.Load(new DotEnvOptions(envFilePaths: new[] { _envFilePath }));
        var environmentVariables = DotEnv.Read(new DotEnvOptions(envFilePaths: new[] { _envFilePath }));
        var apiToken = environmentVariables["ai_api_token"];
        return Yaml_Configure();
    }

    private static Yaml Yaml_Configure()
    {
        var deserializer = new DeserializerBuilder()
                               .WithNamingConvention(UnderscoredNamingConvention.Instance)
                               .Build();
        string content = File.ReadAllText(_agentYamlFile);
        Yaml yamlconent = deserializer.Deserialize<Yaml>(content);

        return yamlconent;

    }
}
