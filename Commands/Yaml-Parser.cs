namespace cvc.yaml;

public class Yaml
{
    public string Version { get; set; } = string.Empty;
    public Agent Agent { get; set; } = new();
}

public class Agent
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public Model Model { get; set; } = new();
    public Context Context { get; set; } = new();
    public string SystemPrompt { get; set; } = string.Empty;
    public Tools[] Tools { get; set; } = [];
}
public class Model
{
    public string Provider { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string Endpoint { get; set; } = string.Empty;
    public double Temperature { get; set; }
    public int MaxTokens { get; set; }
}
public class Context
{
    public string EnvFile { get; set; } = string.Empty;
    public string InstructionsFile { get; set; } = string.Empty;
    public string[] TrackFiles { get; set; } = [];
    public string[] Ignore { get; set; } = [];
}
public class Tools
{
    public string Name { get; set; } = string.Empty;
    public bool Enabled { get; set; }
    public string[] Permissions { get; set; } = [];
    public string[] Allowlist { get; set; } = [];
    public string AuthEnv { get; set; } = string.Empty;
}
