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

Current phase: Phase 7A — visible animation only. Phase 6 is complete; its configuration and verification are in PROJECT_BRIEF.md section 20. Read PROJECT_BRIEF.md section 21 and AnimationPlaybackValidation.md before coding. Do not combine audio with this task. Implement only three visible demonstrations: a matching Legacy Open_Carton flap clip, one matching Double_Locker OR Electrical_Cabinet door clip, and conveyor movement either by rotating verified separate GLB roller child transforms or moving one existing Conveyor_Load_* along the validated straight section. The active long conveyor is built from tevy GLBs; the Warehouse Essentials Roller_Conveyor Legacy clip belongs to a different FBX hierarchy and must not be retargeted to it. Use matching hierarchy paths, protect world placement from root-keyed clips with an unanimated placement parent, and skip unsafe pallet-jack/root motion. Test actual Unity Play Mode, visible transform changes, stable world placement, camera switching and generator regression; check Console, capture evidence, commit/push animation-only work. After Phase 7A is committed and verified, Phase 7B audio is a separate task. No audio work in this task. The EUR 0 budget and the user's exclusion of the ambiguous “lizards” PDF item remain in force. Phase 8 final QA follows Phase 7B.