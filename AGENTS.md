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

Current phase: Phase 6 — the configurable C# Warehouse Generator is implemented and verified in the active Unity 6000.6.10f1 Editor in `Assets/Scenes/Warehouse_Final.unity`. Phase 5 camera modes and texture source calibration are implemented and Play Mode checked in `Assets/Scenes/Warehouse_Final.unity`; texture details are in `PROJECT_BRIEF.md` section 18. The strict matched 1× before/after comparison is an evidence limitation because the Retina Game View reported 2× minimum; do not block Phase 6 on this. The user explicitly excluded the PDF's ambiguous “lizards” item on 2026-11-26. Do not research, clarify, substitute, model or spend further tokens on it; if needed in a final coverage table, label it “excluded by user decision / not implemented”, never “complete”. The generator uses `WAREHOUSE_GENERATED_STOCK_ROOT`; its Editor validation is documented in `PROJECT_BRIEF.md` section 20. After Phase 6, continue Phase 7 animation/audio and Phase 8 final QA. EUR 0 and all other project decisions remain non-negotiable.
