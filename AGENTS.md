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

Current phase: Phase 8A — Test 2 Warehouse Stock Generator regression is now PASS after a focused local fix. In an isolated, unsaved fixture: seed 12345 repeatability passed; seed 67890 variation passed; densities 25/50/75/100% produced 15/30/45/60 loads; renderer-bound overlaps were zero at every density; rack/operational keep-clear violations were zero; Clear removed only generated loads while preserving all 10 cloned racks and fixture objects; Regenerate restored the seed-12345 signature with zero overlaps. The original `Warehouse_Final` remained active, Edit Mode, not dirty; its hierarchy snapshot and 30 loads/21 storage children matched the pre-test snapshot. Local change is only `Assets/Editor/WarehouseStockGeneratorEditor.cs` (+103/-8 per Codex); it uses pallet local Y=0 and cargo local Y=0.2 instead of the impossible `slot.level == 0` condition. The validation now computes per-load combined renderer bounds and checks intersections across distinct loads on all three axes. Unity compilation succeeded with no errors; one MCP WebSocket informational warning appeared. No scenes were saved and no commit/push occurred. IMPORTANT: local branch main was reported 2 commits behind origin/main; do not pull, reset, rebase, clean, stash, discard or blanket-stage while local user material/settings/Build Profiles changes and the generator fix are uncommitted. Preserve the exact local generator diff. Next: Phase 8A Test 3 — animation regression in actual Unity Play Mode, no code or scene edits: verify four carton flaps, both locker doors, all 100 conveyor rollers, animation playback and stable parent/placement transforms; sample actual transforms at separate times; exit Play Mode and confirm Warehouse_Final is not dirty and all saved transforms/hierarchy return to baseline. Report PASS/FAIL/BLOCKED per element with evidence. Do not modify animation/controller code or generate/delete objects. After Test 3, Test 4 audio/lighting/Console/performance, then Phase 8B macOS build and archive verification. User-confirmed camera/movement and Mac audio listening remain accepted. Build scene order is already fixed remotely (Warehouse_Final first, SampleScene second). User-excluded “lizards” remains out of scope. EUR 0; no new features.

Preserve Phase 7A, Phase 6, both cameras, approved layout, imported original models, `Warehouse_Blockout.unity`, `SampleScene`, project settings and package versions. Budget EUR 0; never buy assets/services, use trials or add music. The user excluded the ambiguous “lizards” PDF term; do not research or reopen it.

Git safety: inspect status, HEAD, last commit and remotes before changes. Never run reset/clean, stash, discard user changes, overwrite remote history, or blanket stage (`git add .`). Stage exact paths only and keep pre-existing work out of Phase commits. If safe integration or push cannot be done without risking user changes, preserve the work and report the blocker.
