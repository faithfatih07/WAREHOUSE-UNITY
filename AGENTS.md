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

Current phase: Phase 8A — Test 1 camera and movement is manually confirmed PASS by the user on 2026-11-26. Codex's live Unity MCP test visually confirmed the overview camera; physical V switching, WASD, mouse look, Escape cursor release, and wall/rack collisions were blocked for Codex because desktop input injection was unavailable. The user then tested the game and reported there was no meaningful difference from before and it works. Record these specific input/collision checks as user-confirmed PASS, not as Codex-injected tests. Scene was not modified or saved. Next task: Phase 8A Test 2 — Warehouse Stock Generator regression, isolated from the saved `Warehouse_Final` scene. First inspect `Assets/Scripts/WarehouseStockGenerator.cs`, `Assets/Editor/WarehouseStockGeneratorEditor.cs`, the component's serialized settings and its placement/cleanup scope. Build an in-memory or dedicated temporary-scene test fixture by cloning only the required generator/root dependencies; do not alter or save `Warehouse_Final`, `SampleScene` or `Warehouse_Blockout.unity`. Verify seed 12345 reproducibility, seed 67890 variation, 25/50/75/100% density, Clear and Regenerate, no duplicates, and aisle/keep-clear bounds. Record actual generated counts, stable hashes or transform manifests and any blockers. Do not assume 30/60 loads: read the generator implementation and actual configuration. Clean up only temporary objects/files created by this test, by their exact known paths/instance IDs; preserve all pre-existing user changes. No blanket cleanup. Do not commit unrelated changes. After generator tests, do a separate Phase 8A Test 3 animation regression, then Test 4 audio/lighting/Console and performance as possible. The user previously confirmed Mac audio audibility; retain that confirmation. Unity MCP is now connected and live read-only access was confirmed. Build scene order is already fixed remotely (Warehouse_Final first, SampleScene second). Local HEAD was previously behind remote and had pre-existing user changes; preserve them, never force-pull/reset/clean/stash/discard or blanket stage. No build until Phase 8A tests finish. No new features; EUR 0; user-excluded “lizards” stays out of scope.

Preserve Phase 7A, Phase 6, both cameras, approved layout, imported original models, `Warehouse_Blockout.unity`, `SampleScene`, project settings and package versions. Budget EUR 0; never buy assets/services, use trials or add music. The user excluded the ambiguous “lizards” PDF term; do not research or reopen it.

Git safety: inspect status, HEAD, last commit and remotes before changes. Never run reset/clean, stash, discard user changes, overwrite remote history, or blanket stage (`git add .`). Stage exact paths only and keep pre-existing work out of Phase commits. If safe integration or push cannot be done without risking user changes, preserve the work and report the blocker.
