// This file performs all the action for the init command
using System.IO;
namespace cvc.init;

public class Init
{
    public static string Folder = ".cvc";
    public static string AiYaml = "agent.yaml";
    public static string AgentMd = "AGENTS.md";
    public static string CurrentDirectory = Directory.GetCurrentDirectory();
    public static void Initialize()
    {
        if (Directory.Exists(Folder))
        {
            System.Console.WriteLine($"cvc already initialized at {CurrentDirectory}");
        }
        else
        {
            Directory.CreateDirectory(Folder);
            var file = new (string Name, string Content)[]
            {
          (AiYaml,"""
    version: "1.0"

    agent:
      name: ""
      description: ""

      model:
        provider: ""
        name: ""
        endpoint: ""
        temperature: 0.0
        max_tokens: 0

      context:
        env_file: ""
        instructions_file: ""
        track_files: []
        ignore: []

      system_prompt: ""

      tools:
        - name: ""
          enabled: false
          permissions: []
          allowlist: []
          auth_env: ""
    """),
          (AgentMd,@"# AGENTS.md

## Project Overview
- **Name:** `cvc` (Context Version Control)
- **Purpose:** Local-first, decentralized version control system for snapshotting, branching, and managing LLM context environments.
- **Directory Structure:**
  - `.cvc/agent.yaml` — Agent configuration, model endpoints, and tool permissions.
  - `.cvc/Agents.md` — Behavioral instructions, repository rules, and execution constraints.
  - `.cvc/snapshots/` — Immutable context state snapshots.

## Agent Guidelines
- **Context Isolation:** Read operational rules from `.cvc/Agents.md` and configuration from `.cvc/agent.yaml` before executing tasks.
- **State Integrity:** Treat `.cvc/snapshots/` as append-only; never manually mutate historical context blobs.
- **Secret Hygiene:** Reference secrets strictly via environment variable keys defined in `agent.yaml` (`auth_env`); never hardcode credentials in manifests or logs.
- **File Tracking:** Respect `track_files` and `ignore` glob patterns declared in `.cvc/agent.yaml` when computing context diffs or creating snapshots.

## Build & Verification Rules
- Verify builds and pass existing test suites before committing a new context snapshot.
- Keep dependencies minimal and deterministic so local execution remains portable.
- Do not modify files outside the workspace root unless explicitly permitted by `tools` in `agent.yaml`.

## Code Style & Conventions
- Prefer explicit, deterministic logic over implicit magic.
- Keep configuration schemas flat and easy to parse without heavy external dependencies.
- Document public CLI flags, subcommands, and manifest fields concisely.")
            };
            foreach (var filename in file)
            {
                File.WriteAllText(Path.Combine(Folder, filename.Name), filename.Content);
            }
            System.Console.WriteLine($"cvc initialized in {CurrentDirectory}");
        }
    }
}
