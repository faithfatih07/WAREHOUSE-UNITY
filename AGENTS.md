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

Current phase: Phase 8 — final QA and delivery. Phase 7A animation and Phase 7B audio are implemented and remote-pushed. The user has manually confirmed that the two audio loops are audible on the Mac: low-level warehouse hum and the spatial conveyor sound near the conveyor/pallet area; user accepted proceeding after the spatial/mute check. Do not add more audio. Read PROJECT_BRIEF.md sections 22, 24 and 25. CRITICAL VERIFIED ISSUE: committed ProjectSettings/EditorBuildSettings.asset currently includes only SampleScene.unity; add Warehouse_Final.unity as the first enabled build scene while retaining SampleScene as the second enabled scene. Inspect exact Warehouse_Final GUID from its .meta. Inspect local Git state before any work: prior reports identify pre-existing local changes in Phase 4 LED material, three settings files and Build Profiles. Preserve every such file; no reset, clean, stash, discard, blind checkout, blanket staging or destructive cleanup. Stage exact reviewed file paths only. Do not commit local-only Build Profiles or settings unless independently reviewed and intentionally required. Complete PDF coverage, dependency/reference checks, both camera modes, generator, animations, audio, interior lighting, Console and performance regression tests in actual Unity. The teacher has not specified final OS, delivery format or deadline; a temporary macOS smoke build is allowed only if macOS Build Support is already installed, but do not call it the final submission target. Prepare a source-project archive from verified committed files only, excluding caches and local-only files. Keep Roll-a-Ball completion and teacher email reply (individual/group status) separate and unclaimed unless user confirms. The source PDF item “lizards” is excluded by explicit user decision; never reopen it. No new features in Phase 8. EUR 0.

Preserve Phase 7A, Phase 6, both cameras, approved layout, imported original models, `Warehouse_Blockout.unity`, `SampleScene`, project settings and package versions. Budget EUR 0; never buy assets/services, use trials or add music. The user excluded the ambiguous “lizards” PDF term; do not research or reopen it.

Git safety: inspect status, HEAD, last commit and remotes before changes. Never run reset/clean, stash, discard user changes, overwrite remote history, or blanket stage (`git add .`). Stage exact paths only and keep pre-existing work out of Phase commits. If safe integration or push cannot be done without risking user changes, preserve the work and report the blocker.
