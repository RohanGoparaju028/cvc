using System;
using System.IO;

namespace cvc;

public class Init {
  public Init() {
    string currentPath = Directory.GetCurrentDirectory();
    string secretFolder = Path.Combine(currentPath, ".cvc");
    Directory.CreateDirectory(secretFolder);

    CreateFileIfMissing(Path.Combine(secretFolder, "AGENTS.md"), AgentInstructions);
    CreateFileIfMissing(Path.Combine(secretFolder, "agents.yaml"), AgentConfiguration);
    CreateFileIfMissing(Path.Combine(secretFolder, ".env"), "agent_ai_token=\n");

    Console.WriteLine($"cvc initialized in {currentPath}");
  }

  private static void CreateFileIfMissing(string path, string content) {
    if (File.Exists(path)) {
      return;
    }

    using var stream = new FileStream(path, FileMode.CreateNew, FileAccess.Write);
    using var writer = new StreamWriter(stream);
    writer.Write(content);
  }

  private const string AgentConfiguration = """
    version: "1.0"
    agent:
      name:
      description:
      model:
        provider:
        name:
        endpoint:
        max_tokens:
      auth:
        token_env_var:
      system_prompt:
      tools:
    """ + "\n";

  private const string AgentInstructions = """
    # AGENTS.md

    ## Project

    cvc (Context Version Control) is a free and open-source software project focused on preserving, versioning, and retrieving development context across AI coding agents and sessions.

    The project is currently under active development. Do not assume that planned functionality has already been implemented.

    ## Development Instructions

    - Understand the existing codebase before making changes.
    - Follow the established project architecture and coding conventions.
    - Prefer simple, modular, maintainable implementations.
    - Avoid introducing unnecessary dependencies or abstractions.
    - Do not modify unrelated files without authorization.
    - Explain significant architectural changes before implementing them.
    - Do not claim that functionality works without testing it.

    ## Development Workflow

    Before implementing a feature:

    1. Identify the requirement and expected behavior.
    2. Inspect relevant source files and dependencies.
    3. Explain the proposed approach and any significant tradeoffs.
    4. Implement the requested changes.
    5. Build and test the implementation where possible.
    6. Report what changed, what was tested, and what remains incomplete.

    ## Context Management

    During development, document important information such as:

    - Architectural decisions and their rationale.
    - Assumptions and technical constraints.
    - Problems encountered during implementation.
    - Debugging attempts and verified solutions.
    - Changes to dependencies.
    - Unresolved issues and next steps.

    Clearly distinguish verified information from assumptions.

    Do not invent previous decisions, debugging results, or test outcomes.
    """ + "\n";
}
