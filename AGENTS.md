# AGENTS.md — WAREHOUSE-UNITY

Before every task in this repository:
1. Read `PROJECT_BRIEF.md` completely. It is the authoritative project scope and decision record.
2. Read `WAREHOUSE_LAYOUT.md` before any scene/layout/blockout work.
3. Inspect the current Git status and actual Unity Editor state through MCP before editing.

Non-negotiable project decisions:
- Visual target: detailed, realistic quality comparable to the instructor's reference warehouse.
- Both camera modes are in scope: isometric overview and first-person exploration.
- A configurable C# Warehouse Generator is in scope.
- Preserve the existing Unity URP project and current package configuration.
- Keep the work aligned with the phase sequence in `PROJECT_BRIEF.md`; do not jump ahead or silently omit requirements.

Working rules:
- Use Unity MCP to inspect and modify the running Unity Editor where available. Do not assume access; verify the MCP tools and active project first.
- Do not invent successful imports, assets, animations, audio, tests, builds or visual results. Report only what was actually verified.
- Use ready-made assets for major props where practical, and verify asset licences. Do not redistribute unlicensed assets.
- Keep layout routes clear for forklifts and first-person movement.
- Keep generated objects grouped and make editor generation idempotent; never delete or replace unrelated scene objects.
- Preserve `SampleScene`; implement warehouse work in a dedicated scene.
- Do not change the render pipeline, project version, package versions, or project settings without a concrete reason and an explicit explanation.
- Do not overwrite remote Git history. Check branch/status and remote state before pushing.
- At the end of each task, report files changed, Unity verification performed, Console errors (if checked), remaining blockers, and Git commit/push status.

Current phase: Phase 1 — Layout and blockout only. Follow section 10 of `PROJECT_BRIEF.md` and `WAREHOUSE_LAYOUT.md`. Do not import a large asset pack, implement the final Warehouse Generator, or build the camera controller during Phase 1.
