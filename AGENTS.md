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

Current phase: Phase 8A Test 2 generator regression PASS after a local-only fix in `Assets/Editor/WarehouseStockGeneratorEditor.cs`; preserve this uncommitted fix. Phase 7A animation regression PASS: office double locker, all 100 conveyor rollers, and exact production carton retest (prior carton failure not reproduced). Phase 8A Test 4 findings: existing audio setup PASS (exactly 2 AudioSources + 1 audio controller; ambience and spatial conveyor settings inspected; genuine M toggle changed both mute flags; user previously confirmed both sounds audible on Mac). Camera/audio independence PASS (V switched modes; same two sources/controller remained, one active camera and one listener). Background-audio observation BLOCKED because Unity lost focus during MCP profiling and `isPlaying=false` in Play Focused mode with `runInBackground=false`; this does not prove camera switching stopped playback. Lighting FAIL: all 15 high-bay spotlights enabled at y=9.86 but their world direction is (0,0,1), horizontal toward +Z rather than downward, causing uneven interior coverage; 3 dock wallpacks enabled at y=6.8, pointing down/outward, apron brightly lit; old blockout directional light disabled, separate provisional directional light remains active. Performance UNMEASURED: FrameTimingManager samples inconsistent; values not reliable FPS/frame-time evidence. Console PASS: 0 errors and 4 known obsolete MaterialLocation.External warnings for Crate_Large.fbx, Pallet.fbx, Pallet_Jack.fbx, Workbench_Vise.fbx; no audio/render errors. Preservation PASS: Play Mode exited, Warehouse_Final active and not dirty; no files changed in Test 4. Next task: focused lighting correction only. First inspect the exact 15 high-bay Light transforms and hierarchy, their range/spot angle/intensity/color/shadows, ceiling heights, warehouse dimensions, and current directional light roles. Correct only the high-bay spotlight orientation so each emits downward into the warehouse (do not assume a global Euler rotation without verifying each light's actual transform). Keep lights' positions and intentional settings unchanged unless measurement shows necessary; do not change dock wallpacks, the provisional directional light, post-processing, URP, project settings, materials, or other objects. Use actual live Editor/Play Mode in an isolated test or reversible in-memory change first; compare interior illumination in overview and first-person and verify dock/apron remains as before. Capture before/after evidence and Console. If directional light or fixture role is ambiguous, stop and report rather than toggle it. Only after lighting passes, rerun final Test 4 and then prepare a Windows standalone build (.exe) for the instructor. Do not make a macOS build; the user already inspects the project in Unity Editor. Performance remains unmeasured; profile the Windows standalone build with genuine profiler/frame stats if available, otherwise explicitly unmeasured. Keep background audio check documented as blocked unless user or reliable foreground runtime test establishes behavior. Preserve local generator fix and pre-existing local LED material/settings/Build Profiles changes. Local branch reported two commits behind origin/main, while remote docs updates continue; do not pull/rebase/reset/clean/stash/discard/blanket-stage or overwrite local work. Inspect exact divergence before any synchronization. No force operations. No new features, EUR 0, excluded “lizards” out of scope.

Preserve Phase 7A, Phase 6, both cameras, approved layout, imported original models, `Warehouse_Blockout.unity`, `SampleScene`, project settings and package versions. Budget EUR 0; never buy assets/services, use trials or add music. The user excluded the ambiguous “lizards” PDF term; do not research or reopen it.

Git safety: inspect status, HEAD, last commit and remotes before changes. Never run reset/clean, stash, discard user changes, overwrite remote history, or blanket stage (`git add .`). Stage exact paths only and keep pre-existing work out of Phase commits. If safe integration or push cannot be done without risking user changes, preserve the work and report the blocker.


## Delivery platform and optional feature scope (2026-11-27)
- Instructor uses Windows. Do not create a macOS build. The target deliverable is a Windows standalone player/build (.exe) and, if requested, a clean source-project archive suitable for opening in Unity on Windows.
- The user can inspect the project in Unity Editor and does not need a macOS executable.
- Do not start optional feature development automatically. Complete the known interior-lighting correction first. Then recommend at most one low-risk presentation enhancement; wait for the user's choice before implementing it. Preserve the current project scope and remaining token/time budget.
- Good candidate: a compact guided warehouse tour/presentation mode with a few fixed camera stops (storage racks, receiving, conveyor/sorting, packing/dispatch) and brief labels. Reuse existing scene content; no new asset pack or gameplay system.
- Other candidates only if specifically chosen: interactive zone information panels, or one simple package-on-conveyor demonstration. Do not implement all of these.
