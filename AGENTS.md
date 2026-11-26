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
- Keep the work aligned with the phase sequence in `PROJECT_BRIEF.md`; do not jump ahead or silently omit requirements.

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

Current phase: Phase 4 — material, lighting and presentation work is implemented and visually verified in `Assets/Scenes/Warehouse_Final.unity`. The Phase 1 blockout reference and SampleScene remain untouched. `Assets/Editor/WarehousePhase4VisualBuilder.cs` regenerates only `WAREHOUSE_PHASE4_DETAIL_ROOT`, keeping the 60×40 m interior, approved functional layout, `WAREHOUSE_FINAL_ROOT` assembly and imported assets. Generated URP Lit surface materials and local texture maps improve concrete, cladding, steel and timber; added floor joints, traffic/safety paint, rack identifiers and foot plates, architectural base details, high-bay fixtures and dock lighting. The complete roof and skylights remain under `ROOF_PANELS_AND_SKYLIGHTS`; that root is inactive for the cutaway overview and can be re-enabled for the full-roof presentation. Unity 6000.6.10f1 / URP 17.6.0 captured actual overview, storage, operations and full-roof screenshots. The Phase 4 builder was run twice with 331 detail transforms after each run. The final Console check had zero errors and four existing FBX importer obsolescence warnings. The EUR 0 budget remains non-negotiable. Next: Phase 5 camera modes; do not start Phase 6 generator or Phase 7 audio/animation work ahead of sequence. Keep “lizards” unresolved until clarified by the lecturer.
