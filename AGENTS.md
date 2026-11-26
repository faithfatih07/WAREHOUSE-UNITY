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

Current phase: final handoff and Windows source archive (2026-11-27). Phase 8A generator regression passed after the local fix in `Assets/Editor/WarehouseStockGeneratorEditor.cs`; Phase 7A locker, carton flap and 100/100 roller animation checks passed; the 15 high-bay spotlights were corrected and verified downward at Y=8.96, with their intensity reduced from 900 to 350. The user approved exactly one Phase 8 exception: the automatic straight-conveyor package-flow demonstration recorded in `PROJECT_BRIEF.md` section 37 and implemented with four existing loads. It runs at 1 m/s from X=41 to X=57 and uses endpoint reset; it is not a closed physical loop and does not connect to sorting/packing tables. The package flow, transform invariants, 4 m cyclic spacing, camera modes, roof behavior, carton flaps and roller rotation were checked in Play Mode. Audio setup and camera/audio independence passed; background audio observation remains blocked and performance remains unmeasured. Latest Unity check found no errors, four existing obsolete `MaterialLocation.External` FBX warnings, and a transient MCP WebSocket warning. The instructor uses Windows; deliver the Unity source project and README, with no macOS or Windows executable build. Preserve all local user work, use exact Git paths, do not use destructive Git commands, and report only verified Git synchronization and archive results.

Preserve Phase 7A, Phase 6, both cameras, approved layout, imported original models, `Warehouse_Blockout.unity`, `SampleScene`, project settings and package versions. Budget EUR 0; never buy assets/services, use trials or add music. The user excluded the ambiguous “lizards” PDF term; do not research or reopen it.

Git safety: inspect status, HEAD, last commit and remotes before changes. Never run reset/clean, stash, discard user changes, overwrite remote history, or blanket stage (`git add .`). Stage exact paths only and keep pre-existing work out of Phase commits. If safe integration or push cannot be done without risking user changes, preserve the work and report the blocker.


## Delivery platform and optional feature scope (2026-11-27)
- Instructor uses Windows. Do not create a macOS build. The target deliverable is a Windows standalone player/build (.exe) and, if requested, a clean source-project archive suitable for opening in Unity on Windows.
- The user can inspect the project in Unity Editor and does not need a macOS executable.
- Do not start optional feature development automatically. Complete the known interior-lighting correction first. Then recommend at most one low-risk presentation enhancement; wait for the user's choice before implementing it. Preserve the current project scope and remaining token/time budget.
- Good candidate: a compact guided warehouse tour/presentation mode with a few fixed camera stops (storage racks, receiving, conveyor/sorting, packing/dispatch) and brief labels. Reuse existing scene content; no new asset pack or gameplay system.
- Other candidates only if specifically chosen: interactive zone information panels, or one simple package-on-conveyor demonstration. Do not implement all of these.


## Optional feature direction selected by user (2026-11-27)
- User prefers automatic warehouse activity over manual box placement or a guided-tour feature, and has limited remaining Codex/token budget.
- Preferred single compact feature after the lighting correction: an automatic conveyor package-flow demonstration using existing conveyor geometry, the existing roller animation and existing box/carton assets. A small number of packages move continuously along a few explicit waypoints through the sorting/packing flow, with consistent spacing, brief pauses if needed, and smooth loop/reset. This is a visual operational demonstration, not a game, inventory system or full physics simulation.
- Keep implementation minimal: one focused controller, reuse existing assets, avoid paid/new assets, rigidbody/physics complexity, forklift AI, manual placement controls, extra UI, and broad architecture changes. Do not start implementation until current high-bay lighting is fixed/retested and the user has approved this bounded scope. If remaining budget is too low, stop after lighting and hand over the project rather than creating a half-finished feature.
