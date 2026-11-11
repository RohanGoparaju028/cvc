// This file is the place where you create an AI agent
using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using dotenv.net;
using YamlDotNet.Serialization;

namespace cvc;

public class Establish
{
    public bool flag = false; // flag indicates if the connection is successful or not
    private readonly string _aiAPi = ".cvc/.env";
    private readonly string _root = ".cvc";
    private readonly string _agentYaml = ".cvc/agents.yaml";

    // Holds the parsed agent configuration loaded from agents.yaml
    public AgentConfig? AgentConfig { get; private set; }

    public Establish()
    {
        // Configure the agent from agents.yaml, then connect to the model
        ConfigureAgent();
        ConnectAIModel().GetAwaiter().GetResult();
    }

    // Loads .cvc/agents.yaml into the AgentConfig class using YamlDotNet
    public void ConfigureAgent()
    {
        var configPath = Path.Combine(Directory.GetCurrentDirectory(), _agentYaml);

        if (!File.Exists(configPath))
        {
            Console.WriteLine("agents.yaml not found. Run 'cvc init' first.");
            return;
        }

        var yaml = File.ReadAllText(configPath);
        var deserializer = new DeserializerBuilder().Build();

        AgentConfig = deserializer.Deserialize<AgentConfig>(yaml);

        if (AgentConfig is null)
        {
            Console.WriteLine("agents.yaml is empty or could not be parsed.");
            return;
        }

        Console.WriteLine($"Agent configured: {AgentConfig.Agent.Name ?? "(unnamed)"}");
    }

    private async Task ConnectAIModel()
    {
        var rootPath = Path.Combine(Directory.GetCurrentDirectory(), _root);

        if (!Directory.Exists(rootPath))
        {
            Console.WriteLine("cvc is not initialized in the current directory please initialize it first and for any help use cvc help to see all supported command");
        }
        else
        {
            var envFilePath = Path.Combine(Directory.GetCurrentDirectory(), _aiAPi);
            
            // Load environment variables using DotEnv with proper options
            DotEnv.Load(options: new DotEnvOptions(envFilePaths: new[] { envFilePath }));
            var env = DotEnv.Read(options: new DotEnvOptions(envFilePaths: new[] { envFilePath }));
            
            if (env.TryGetValue("agent_ai_token", out var api))
            {
                await Call(api);
            }
        }
    }

    private async Task Call(string api)
    {
        // Implement your API call logic here
        await Task.CompletedTask;
    }
}
