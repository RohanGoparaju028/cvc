## Overview
CVC is a command-line tool for tracking and managing the context supplied
to large language models. It applies version-control concepts to conversations:
save a useful state, explore an alternative on a branch, and deliberately combine
compatible results.
   
The goal is to give developers a traceable way to reuse context without repeatedly
reconstructing conversations or carrying irrelevant assumptions into new tasks.
CVC versions recorded messages and context selections, not a model's internal
state. Restoring the same context does not guarantee the same model response.
  
## Problem
Long conversations accumulate decisions, experiments, corrections, and abandoned
ideas. When these remain mixed together, it becomes difficult to determine which
information should inform the next request. Copying conversations manually also
makes their origin and changes hard to track.
  
CVC should let a user preserve a known context, isolate experiments, compare what
changed, and explicitly choose what to carry forward. Branching can reduce the
mixing of unrelated context; it cannot guarantee that model answers are correct
or prevent every form of context poisoning.
