using System.Collections.Generic;
using YamlDotNet.Serialization;

namespace cvc;

// Maps the structure of .cvc/agents.yaml
public class AgentConfig
{
    [YamlMember(Alias = "version")]
    public string Version { get; set; } = "1.0";

    [YamlMember(Alias = "agent")]
    public Agent Agent { get; set; } = new();
}

public class Agent
{
    [YamlMember(Alias = "name")]
    public string? Name { get; set; }

    [YamlMember(Alias = "description")]
    public string? Description { get; set; }

    [YamlMember(Alias = "model")]
    public ModelConfig Model { get; set; } = new();

    [YamlMember(Alias = "auth")]
    public AuthConfig Auth { get; set; } = new();

    [YamlMember(Alias = "system_prompt")]
    public string? SystemPrompt { get; set; }

    [YamlMember(Alias = "tools")]
    public List<string>? Tools { get; set; }
}

public class ModelConfig
{
    [YamlMember(Alias = "provider")]
    public string? Provider { get; set; }

    [YamlMember(Alias = "name")]
    public string? Name { get; set; }

    [YamlMember(Alias = "endpoint")]
    public string? Endpoint { get; set; }

    [YamlMember(Alias = "max_tokens")]
    public int? MaxTokens { get; set; }
}

public class AuthConfig
{
    [YamlMember(Alias = "token_env_var")]
    public string? TokenEnvVar { get; set; }
}
