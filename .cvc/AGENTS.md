# AGENTS.md

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
- Document public CLI flags, subcommands, and manifest fields concisely.