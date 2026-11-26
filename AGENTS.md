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

Current phase: Phase 3 — Main warehouse environment assembly. The user explicitly authorized starting Phase 3 on 2026-11-26 while carrying the instructor's exact ambiguous word “lizards” forward as unresolved. Do not guess its meaning, do not claim it is complete, and do not let it block assembly of all known requirements. General storage cabinet and dedicated assembly table are approved as original procedural models at EUR 0. Use the verified assets already in Assets/Imported; do not repeat broad asset research. Read PROJECT_BRIEF.md and WAREHOUSE_LAYOUT.md fully before editing. Create Assets/Scenes/Warehouse_Final.unity by copying the Phase 1 baseline scene, keeping Warehouse_Blockout.unity and SampleScene unchanged. Use a new idempotent WarehouseAssemblyBuilder that only replaces its own WAREHOUSE_FINAL_ROOT; do not use the Phase 1 blockout builder on the baseline. Preserve 60×40 m internal dimensions and ~9 m clear height; set the final truck apron to 23–24 m clear depth (Z≈-24 to -1), place five north-south rack rows using the verified rack modules, three south-facing loading docks and correctly oriented full-size trucks, conveyor modules, receiving/sorting/packing/dispatch zones, office, cabinets and detailed assembly tables. Keep roof structure grouped separately for overview cutaway. Phase 3 is assembly only: do not implement the C# Generator (Phase 6), final camera controller (Phase 5), final lighting pass (Phase 4), or sound/animation system (Phase 7). Verify in the actual Unity Editor, take screenshots, test idempotency, inspect Console and Git diff, then commit/push verified work. EUR 0 remains non-negotiable.
