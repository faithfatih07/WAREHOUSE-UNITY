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

Current phase: Phase 2 — Free asset research, import and validation (EUR 0). The Warehouse Essentials archive and the tevy GLB source files were licence-checked and SHA-256 verified; see `ASSET_RESEARCH.md` sections 11, 22 and 23. The project now contains 14 selected Warehouse Essentials FBX props, 17 separate animation-sample FBXs, and eight gap GLBs (seven tevy, one Grab3D). Unity 6000.6.10f1 URP 17.6.0 live previews verified the new modules and props; Play Mode validation showed transform changes for 13 of the 17 clips. See the reports in the imported asset Documentation folders. No downloaded code was executed and no antivirus scan was performed. Do not modify `Warehouse_Blockout` or `SampleScene` during asset validation. Phase 2 coverage remains unresolved only for the instructor's exact ambiguous word “lizards”; general storage cabinets and a dedicated assembly table need an explicit original-modelling decision. Audio and final interior lighting are still later-phase work. Do not begin Phase 3 until the “lizards” meaning is clarified or the requirement is explicitly resolved with the instructor.
