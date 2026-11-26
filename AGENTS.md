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

Current phase: Phase 8A — Test 2 generator regression PASS after the local-only fix in `Assets/Editor/WarehouseStockGeneratorEditor.cs`; preserve this uncommitted fix. Phase 7A animation regression is now PASS/non-reproduced for all three systems: Office Double Locker both doors moved; conveyor 100/100 rollers rotated without position drift; exact production carton instance `P7A_Placement_Packing_Open_Carton_1` was retested in `Warehouse_Final` Play Mode with Game View focused and all four flaps changed rotation at every sample, `IsPlaying=True`. The earlier carton FAIL was not reproduced; close the investigation and do not change animation code/assets/import settings. After Play Mode, `Warehouse_Final` returned to Edit Mode, active and clean; no file changes, commits or pushes occurred. Console: 0 errors, 4 pre-existing obsolete FBX material-location warnings. Carton test's final sample requested at 2.5s arrived at measured 3.161s (report actual measured time, do not present as exact 2.5s). User has manually confirmed camera/movement/collisions and two warehouse sounds audible on Mac. Next: Phase 8A Test 4 — verify existing two audio sources and M toggle (do not create/add audio), ambience and spatial conveyor sound in both camera modes, high-bay and dock lighting in overview and first-person, current Console errors/warnings with old FBX warnings separately identified, and actual performance measurement (FPS/frame time) if available. Use Unity MCP/actual Play Mode evidence; do not invent measurements. Avoid unnecessary CUA if user input is needed; ask user to listen/observe specific checks. Do not modify scripts, audio assets, lights, scenes or settings. Exit Play Mode and confirm `Warehouse_Final` remains not dirty. After Test 4, proceed to Phase 8B: safe macOS standalone build and archive verification. Build scene order already fixed remotely with `Warehouse_Final` first and `SampleScene` second. Preserve local-only generator fix and pre-existing local LED material/settings/Build Profiles changes; local branch was reported two commits behind remote docs. No force-pull/reset/rebase/clean/stash/discard/blanket stage. Inspect exact local status and divergence safely before any sync or commit. No new features, EUR 0, excluded “lizards” stays out of scope.

Preserve Phase 7A, Phase 6, both cameras, approved layout, imported original models, `Warehouse_Blockout.unity`, `SampleScene`, project settings and package versions. Budget EUR 0; never buy assets/services, use trials or add music. The user excluded the ambiguous “lizards” PDF term; do not research or reopen it.

Git safety: inspect status, HEAD, last commit and remotes before changes. Never run reset/clean, stash, discard user changes, overwrite remote history, or blanket stage (`git add .`). Stage exact paths only and keep pre-existing work out of Phase commits. If safe integration or push cannot be done without risking user changes, preserve the work and report the blocker.
