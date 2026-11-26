# AGENTS.md — WAREHOUSE-UNITY

Before every task in this repository:
1. Read `PROJECT_BRIEF.md` completely. It is the authoritative project scope and decision record.
2. Read `WAREHOUSE_LAYOUT.md` before any scene/layout/blockout work.
3. Read `ASSET_RESEARCH.md` before Phase 2 asset selection or import.
4. Inspect the current Git status and actual Unity Editor state through MCP before editing.

Non-negotiable project decisions:
- Visual target: reference-level visual completeness, detail density and coherent industrial presentation. Photorealism is not required; avoid cartoonish style and avoid a primitive-looking final scene.
- Budget is EUR 0: never purchase assets, plugins, subscriptions, credits, paid trials or initiate checkout. Use legally free assets (prefer CC0; CC BY 4.0 with attribution is acceptable) and procedural/local modelling for gaps.
- Both camera modes are in scope: isometric overview and first-person exploration.
- A configurable C# Warehouse Generator is in scope.
- Preserve the existing Unity URP project and current package configuration.
- Keep the work aligned with the phase sequence in `PROJECT_BRIEF.md`; do not jump ahead or silently omit requirements. The user has explicitly excluded the ambiguous “lizards” source-PDF item from scope; do not reopen it.

Working rules:
- Use Unity MCP to inspect and modify the running Unity Editor where available. Do not assume access; verify the MCP tools and active project first.
- Do not invent successful imports, assets, animations, audio, tests, builds or visual results. Report only what was actually verified.
- Use zero-cost ready-made assets for major props where practical, and verify asset licences before download/import. Prefer CC0; maintain attribution for CC BY assets. Never purchase, enter checkout, use paid trials or download unauthorized copies of paid assets. Do not redistribute unlicensed assets.
- Keep layout routes clear for forklifts and first-person movement.
- Keep generated objects grouped and make editor generation idempotent; never delete or replace unrelated scene objects.
- Preserve `SampleScene`; implement warehouse work in a dedicated scene.
- Do not change the render pipeline, project version, package versions, or project settings without a concrete reason and an explicit explanation.
- Do not overwrite remote Git history. Check branch/status and remote state before pushing.
- At the end of each task, report files changed, Unity verification performed, Console errors (if checked), remaining blockers, and Git commit/push status.

Current phase: Phase 8A — BLOCKED by Unity Editor access, not a project regression. The latest Phase 8A attempt (2026-11-26) ran zero Unity tests: CUA timed out twice trying to connect to the Unity window, and no Unity MCP tools were exposed. Do not repeat the same UI automation attempts or claim any regression tests passed. The report says no files were edited/staged; prior local user changes (Phase 4 LED material, URP/render settings, Build Profiles) remain untouched. Local HEAD is `6f3d91c3000d21d5e2d2d32abc99a483d5d87bd9`, while remote `origin/main` is `729f142a509a954975cb8c972e22cb9848244228`; do not force-pull, reset, clean, stash or discard. First restore live Unity access manually: user should bring Unity Hub/Editor to front, make sure `Warehouse_Final` is fully loaded and not blocked by a modal dialog, then inspect `Window > MCP for Unity > Toggle MCP Window` for server/connection status. In the Codex app, verify the `unityMCP` MCP server is enabled and reconnect/reload it if needed. If it still fails, restart Unity Editor and reopen the existing project (do not create a new project), wait for import/compilation to finish, then reconnect the MCP server. Only after a live connection is visible should Phase 8A resume, in small test batches: (1) camera input/collisions, (2) generator tests in a temporary scene copy, (3) animations, (4) audio/lighting and Console. No batch build while Editor is open/unresponsive. User's prior manual Mac audio listening confirmation remains valid; Codex did not retest it during the blocked pass. Preserve Warehouse_Final and all pre-existing local changes. The build scene list fix is already committed remotely: Warehouse_Final first, SampleScene second. Phase 8B build and source archive verification follow only after Phase 8A tests or explicit documented blockers. No new features, no “lizards” work, EUR 0.

Preserve Phase 7A, Phase 6, both cameras, approved layout, imported original models, `Warehouse_Blockout.unity`, `SampleScene`, project settings and package versions. Budget EUR 0; never buy assets/services, use trials or add music. The user excluded the ambiguous “lizards” PDF term; do not research or reopen it.

Git safety: inspect status, HEAD, last commit and remotes before changes. Never run reset/clean, stash, discard user changes, overwrite remote history, or blanket stage (`git add .`). Stage exact paths only and keep pre-existing work out of Phase commits. If safe integration or push cannot be done without risking user changes, preserve the work and report the blocker.
