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

Current phase: Phase 8A — Test 2 Warehouse Stock Generator regression found a real vertical cargo-placement defect. Seed 12345 determinism passed (two 50% runs each generated 30 loads with identical signatures); seed 67890 variation passed; density counts passed (25%=15, 50%=30, 75%=45, 100%=60); Clear Generated passed and preserved all 10 cloned rack modules and fixture objects; warehouse operational keep-clear-zone checks passed. Regenerate returned the same seed signature and 30 unique load positions but failed renderer-bounds overlap checks: 3 intersecting pairs at 25%, 5 at 50%, 13 at 75%, 25 at 100%. Source inspection confirms the defect: `GetSlots` emits one-based `slot.level = level + 1` (lines 290–292), while `Generate` checks `slot.level == 0` to choose the lower cargo offset (line 219); this can never match. Both shelf levels therefore use the upper cargo offset and cargo bounds overlap vertically. `LevelOffsets` is `{0f, 2.55f}`. Next: make a minimal, reviewed fix in `Assets/Editor/WarehouseStockGeneratorEditor.cs` so each cargo is positioned relative to its own pallet/load at both one-based shelf levels (avoid magic mismatched zero-based level checks; use the actual slot height/local offset correctly). Extend `RunGeneratorValidation` so it also checks the combined renderer bounds of each generated load against other loads, not just unique load-root positions; ensure the check handles child renderers under cargo model prefabs and avoids counting the same load's own renderers against itself. Rerun all seed/density/Clear/Regenerate and overlap tests in the isolated temporary fixture. Test all four density levels and confirm zero load-to-load renderer-bound intersections, while preserving clear aisles and keep-clear zones. Do not touch `Warehouse_Final.unity`, `SampleScene`, `Warehouse_Blockout.unity`, layout, imported source models, settings, or packages. No other generator behavior changes. Inspect local Git status/diffs first; preserve pre-existing local user changes; never reset, clean, stash, discard, blanket stage or force-pull. Commit only the exact reviewed generator script/editor test paths if safe; otherwise report blocker. After this passes, proceed to Phase 8A Test 3 animations. User-confirmed camera movement/collision test remains PASS. User-confirmed two-sound Mac listening remains valid. EUR 0; excluded “lizards” remains out of scope.

Preserve Phase 7A, Phase 6, both cameras, approved layout, imported original models, `Warehouse_Blockout.unity`, `SampleScene`, project settings and package versions. Budget EUR 0; never buy assets/services, use trials or add music. The user excluded the ambiguous “lizards” PDF term; do not research or reopen it.

Git safety: inspect status, HEAD, last commit and remotes before changes. Never run reset/clean, stash, discard user changes, overwrite remote history, or blanket stage (`git add .`). Stage exact paths only and keep pre-existing work out of Phase commits. If safe integration or push cannot be done without risking user changes, preserve the work and report the blocker.
