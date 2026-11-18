 namespace cvc.yaml;

public class Yaml {
  public string Version {get;set;}
  public Agent Agent {get;set;} 
}

public class Agent {
  public string Name {get;set;} 
  public string Description {get;set;} 
  public Model Model {get;set;} = null;
  public Context Context {get;set;} = null;
  public string SystemPrompt {get;set;} 
  public Tools[] Tools {get;set;} = null;
}
public class Model {
  public string Provider {get;set;}
  public string Name {get;set;}
  public string Endpoint {get;set;} 
  public double Temperature {get;set;}  
  public int MaxTokens {get;set;}
}
public class Context {
  public string EnvFile {get;set;} 
  public string InstructionsFile {get;set;} 
  public string[] TrackFiles {get;set;} 
  public string[] Ignore {get;set;} 
}
public class Tools {
  public string Name {get;set;}
  public bool Enabled {get;set;}
  public string[] Permissions {get;set;} 
  public string[] Allowlist {get;set;}
  public string AuthEnv {get;set;}
}
