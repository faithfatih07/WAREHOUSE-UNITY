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

Current phase: Phase 7B — warehouse audio implementation. Phase 7A visible animation is complete and documented in PROJECT_BRIEF.md section 23 and AnimationPlaybackValidation.md. Keep audio isolated to the Phase 7B controller, its original generated WAV clips, the dedicated audio hierarchy in `Warehouse_Final.unity`, and required documentation. Preserve Phase 7A, Phase 6, both cameras, layout, imported source assets, `Warehouse_Blockout.unity`, `SampleScene`, project settings and packages. The current Phase 7B result and its audible-output limitation are documented in PROJECT_BRIEF.md section 24. The budget remains EUR 0; no paid asset or service is allowed. The ambiguous “lizards” item remains excluded by user decision. Do not begin Phase 8 until Phase 7B is reviewed and completed.
Phase 7B implementation status (2026-11-26): Two original PCM WAV loops, a compact M-key mute controller and an idempotent editor scene setup are implemented. Unity Play Mode confirmed both assigned clips playing, M mute/unmute, V mode-switch operation, Phase 7A visible motion and Phase 6 deterministic generator validation; Console errors were zero. Audible output still requires the user's listening check. See PROJECT_BRIEF.md section 24.
