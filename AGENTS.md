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

Current phase: Phase 5 — image-quality calibration preflight and camera modes. Phase 4 is complete and pushed. The user's close-up screenshot shows Unity Game View Scale 7x; this is a magnification of the existing rendered Game view, not higher-resolution output. In addition, Phase 4 builder sources are 512×512 albedo / 256×256 normal-metallic, with bilinear filtering and anisotropic level 1; original Warehouse Essentials atlases are 128×128. See PROJECT_BRIEF.md section 17. Before camera work, perform a bounded quality calibration: compare at 1x; regenerate Phase 4 source texture maps at genuinely higher resolution only where required (do not merely raise Max Size); use sensible trilinear/mipmaps and moderate floor anisotropic filtering; test light 2x/4x MSAA or low-cost camera AA separately; capture matched 1x before/after shots. Preserve M4 performance and do not change URP pipeline/package versions. Then implement BOTH approved camera modes in Warehouse_Final: default isometric overview (cutaway roof) and switchable first-person (full roof), V-key toggle plus on-screen hint/button, WASD/mouse look, Escape cursor unlock, CharacterController, and simple collision proxies for major walls/racks/equipment while keeping routes clear. Use an idempotent builder scoped to its own camera/controller/collision root only; preserve Warehouse_Blockout and SampleScene. Do not begin Phase 6 C# Generator or Phase 7 audio/animation integration. EUR 0 remains non-negotiable. Keep “lizards” unresolved until clarified by the lecturer.
