# cvc — Context Version Control

cvc is an open-source project building a **decentralised version control system for AI development context**. It will version the context, decisions, behavior patterns, standards, and issues that evolve as developers and AI coding agents work on a codebase.

The intended result is a context history that developers own and can carry between terminal sessions, collaborators, coding agents, and model providers. A new session should be able to pick up the task with the project's current decisions and rules, the problems already investigated, and the work that still standing.

**Status:** cvc is in early development. The capabilities and examples below describe what we are building, not functionality already available.

## What we want to do

We want to make the information guiding an AI coding agent an explicit, versioned part of a project. That includes five kinds of information:

| What cvc will version | What that means in practice | Example of a change worth recording |
| --- | --- | --- |
| **Context** | The task, relevant project background, constraints, and working assumptions. | A feature originally intended for one user must now support multiple users. |
| **Decisions** | Choices made during development, their reasons, and alternatives considered. | The team replaces local file storage with a database because concurrent writes are now required. |
| **Behavior patterns** | Recurring ways an agent approaches work, developer corrections, and agreed working practices. | An agent repeatedly edits unrelated files; the developer establishes that changes must stay within the active task. |
| **Standards** | Project conventions and requirements that should guide future changes. | The team adopts a shared error format and requires new endpoints to use it. |
| **Issues** | Known problems, reproduction details, attempted fixes, verified outcomes, and unresolved questions. | A timeout initially blamed on the network is traced to connection exhaustion. |

A **context snapshot** will represent this information at a particular development checkpoint. Later versions will record what was added, corrected, resolved, or superseded while preserving the earlier state and the reason for the change.

For behavior patterns, the records concern observable actions, feedback, and working instructions. Supplying those records to another agent can guide its work; it does not transfer a model's internal state or guarantee identical behavior.

## Why build a version control system for AI context?

During AI-assisted development, instructions and understanding change along with the code. A requirement is clarified in a conversation, a terminal command disproves an assumption, a developer corrects an agent's approach, or an investigation rules out a proposed fix. These changes affect what the agent should do next.

Git can version any of this information once it is written into files. The missing workflow cvc aims to provide is capturing and organizing it as development context: identifying the current decision, preserving the decision it replaced, separating assumptions from findings, tracking issue outcomes, and preparing relevant context for the next session.

For example, a code commit may show a retry loop being removed. The context history should explain that retries duplicated a payment operation, that the team requires an idempotency mechanism before retrying it, and that other affected call sites still need investigation. Those details should remain available when another agent later tries to “fix” the missing retries.

cvc is intended to work alongside source control. Code history records how the implementation changed; context history records how the instructions, understanding, and decisions guiding that implementation changed.

## How we want the workflow to work

1. **Start with the project's context.** A developer begins a terminal coding session with the relevant existing standards, decisions, and open issues available to the agent.
2. **Capture changes during the task.** Record new requirements, explicit decisions, developer corrections, observed behavior, and verified debugging results from the session.
3. **Save a context version.** Preserve a structured checkpoint containing the current state of those records and why they changed. Keep unresolved assumptions distinguishable from verified findings.
4. **Review the evolution.** Inspect which decisions changed, which standards were introduced, and which issues were resolved or reopened between checkpoints.
5. **Resume or share the work.** Make the relevant version available to another session, developer, or agent so they can continue from the recorded state.
6. **Keep updating the history.** When new evidence invalidates earlier context, record the correction and retain the earlier version so the change remains understandable.

Capture mechanisms, snapshot formats, comparison behavior, and agent integrations are still design work. This workflow defines the intended experience without prescribing commands that do not exist yet.

## Why decentralised?

The design goal is for each developer to retain a local context history and be able to record and inspect it without a mandatory central cvc service. Developers should be able to share that history with collaborators and move it between environments without making one AI provider's conversation storage the project's source of truth.

Decentralisation concerns ownership, storage, and exchange of context history. Model independence concerns whether that context can be supplied to different agents and providers. cvc aims to support both: locally owned history in a portable representation, with integrations for the agents that use it.

The storage and synchronisation mechanisms are not implemented yet. Using a hosted model may still require network access and provider authentication.

## Problems we are trying to solve

### 1. Repeating project instructions in every session

**Problem:** A developer repeatedly tells agents to use the existing logging library, avoid new dependencies without discussion, and follow the project's error format. A fresh session starts without those corrections and repeats the same mistakes.

**Intended cvc behavior:** Preserve those instructions as project standards and working practices. Make the applicable version available when a session starts, and record subsequent changes to those instructions.

### 2. Losing the reason behind a decision

**Problem:** An agent proposes caching a response that the team previously decided must always reflect live data. The implementation is visible, but the reason caching was rejected is buried in an earlier conversation.

**Intended cvc behavior:** Retain the decision, its freshness requirement, and its rationale. If the requirement later changes, record the new decision as a revision rather than leaving two contradictory instructions without explanation.

### 3. Repeating failed debugging attempts

**Problem:** One session tests a dependency upgrade and confirms that it does not fix a timeout. The next session suggests the same upgrade because it has no record of the attempt.

**Intended cvc behavior:** Keep the issue's reproduction details, attempted fix, observed result, and remaining hypotheses together. The next agent can continue from the unresolved questions.

### 4. Carrying outdated assumptions into new work

**Problem:** Early development assumes a single user. Later, the application becomes multi-user, but an agent continues proposing shared mutable state based on the old assumption.

**Intended cvc behavior:** Record the assumption changing from single-user to multi-user and identify the earlier context as superseded. Preserve its history while supplying the current constraint to subsequent work.

### 5. Losing developer corrections when switching agents

**Problem:** A developer has repeatedly corrected an agent for broad refactors during small bug fixes. Switching agents loses that feedback, and the same pattern starts again.

**Intended cvc behavior:** Record the observed pattern and the explicit working instruction: keep a bug fix scoped to the affected behavior and discuss broader refactoring separately. Carry that instruction into the next agent's context.

### 6. Handing off code without handing off understanding

**Problem:** A collaborator receives a branch with an unfinished authentication change but does not know which approach was selected, what was tested, or which issue is blocking completion.

**Intended cvc behavior:** Share a checkpoint containing the chosen approach, applicable standards, verified results, open issue, and next steps alongside the code handoff.

### 7. Reconstructing context by replaying entire conversations

**Problem:** A developer pastes a long conversation into a new session to recover a few important decisions. That conversation also contains abandoned approaches and outdated instructions.

**Intended cvc behavior:** Provide relevant current records with access to their history, reducing the need to repeatedly reconstruct the task from raw conversations. Reduced token consumption is an intended benefit and has not yet been measured.

## Example: context changing across two checkpoints

The following is an illustrative history, not a final storage format:

| Record | Checkpoint 1: initial implementation | Checkpoint 2: after investigation |
| --- | --- | --- |
| Context | Intermittent timeouts occur when creating an order; cause unknown. | A response can time out after the server has already created the order. |
| Decision | Retry timed-out order requests automatically. | Require an idempotency mechanism before enabling automatic retries. |
| Behavior pattern | The agent applies retries to errors without checking side effects. | Developer correction: check whether an operation can safely repeat before adding retries. |
| Standard | No retry standard has been recorded. | Retry policies for writes must account for duplicate side effects. |
| Issue | Order timeouts are under investigation. | Duplicate orders reproduced; idempotency implementation remains open. |

An agent resuming from checkpoint 2 should receive the updated decision and the open issue. Checkpoint 1 remains in the history so a developer can understand why retries were originally introduced and why the approach changed.

## Current implementation

cvc is being built as a C# command-line tool targeting .NET 10. The current CLI includes `help` and an `init` scaffold that creates a local `.cvc` directory with agent instructions, configuration, and an environment-file template.

Context capture, snapshot versioning, history comparison, decentralised sharing, and model-provider integrations are planned capabilities. There is no completed context versioning workflow yet.

## Key focus areas

AI Infrastructure · Agentic AI · Version Control Systems · Context Management · Developer Tools · Software Engineering
