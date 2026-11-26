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

Current phase: Phase 7 — animation and audio integration. Phase 6 C# Warehouse Generator is implemented and verified in Unity 6000.6.10f1; its Editor UI, configuration and validation are documented in `PROJECT_BRIEF.md` section 20. The verified Phase 6 implementation commit is `28feeef012716c17981b3411285436fd8cb06f55`. Read `PROJECT_BRIEF.md` section 21 and `Assets/Imported/FreeWarehouseEssentials/Documentation/AnimationPlaybackValidation.md`. Use existing matching Legacy animation clips and models; do not claim the Warehouse Essentials Roller_Conveyor clip is retargeted to the separate tevy GLB conveyor. Implement visible conveyor/prop motion and a small EUR 0 soundscape (legally free CC0 files if already accessible, otherwise original locally synthesized WAVs). Test actual visual motion and audible sound in Unity Play Mode. Do not introduce paid assets/services, random unlicensed audio or unnecessary packages. Preserve both camera modes, the generator and protected scenes. After Phase 7, proceed to Phase 8 final QA and delivery. The user explicitly excluded the ambiguous PDF term “lizards”; do not research, clarify, substitute, model or spend effort on it. The Phase 5 matched-1× texture comparison is a documented display evidence limitation and does not block Phase 7. EUR 0 and all other project decisions remain non-negotiable.
