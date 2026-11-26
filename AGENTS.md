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

Current phase: Phase 8 — final QA and delivery, partially complete. Remote main is `6f3d91c3000d21d5e2d2d32abc99a483d5d87bd9`; the committed `ProjectSettings/EditorBuildSettings.asset` has already been fixed and verified to list enabled `Warehouse_Final` first and enabled `SampleScene` second. Do not repeat or revert this change. Codex's Phase 8 report is in PROJECT_BRIEF.md section 26. Static scene reference scan passed (65 unique GUID references resolved, no missing-script markers). Scene/build list passed. Remaining: manual WASD/mouse/collision/roof-switch checks; rerun generator matrix in a temporary scene copy; rerun Phase 7A animation placement checks; final two-camera lighting/audio-control checks; actual M4 performance measurement if available; safe macOS QA build and launch (Build Support exists, but the previous Unity Editor hung at the scene picker; do not run a concurrent batch build against an open Editor); inspect and verify the locally reported archive at `/private/tmp/WAREHOUSE-UNITY-Phase8-Source-6f3d91c.zip` (reported SHA256 `936ca3fc064297df855e56ac5301e2ed978a74e65221ea838c1bb6f213f767aa`), then copy it to a user-accessible location. This local archive path is not a GitHub attachment or chat download link. The user's earlier manual Mac listening check confirmed both ambience and spatial conveyor sounds were audible; Codex did not repeat listening in the latest run, so do not erase the user-confirmed result or claim a fresh retest. Preserve pre-existing local LED material, settings and Build Profiles changes; inspect local Git status and exact diffs before any commit. Never use reset, clean, stash, discard, blanket staging or overwrite remote history. No final delivery claim until outstanding tests and the build/archive handoff are complete or explicitly blocked. Roll-a-Ball and the teacher's individual/group email reply remain separate academic tasks. User-excluded “lizards” remains out of scope. EUR 0; no new features.

Preserve Phase 7A, Phase 6, both cameras, approved layout, imported original models, `Warehouse_Blockout.unity`, `SampleScene`, project settings and package versions. Budget EUR 0; never buy assets/services, use trials or add music. The user excluded the ambiguous “lizards” PDF term; do not research or reopen it.

Git safety: inspect status, HEAD, last commit and remotes before changes. Never run reset/clean, stash, discard user changes, overwrite remote history, or blanket stage (`git add .`). Stage exact paths only and keep pre-existing work out of Phase commits. If safe integration or push cannot be done without risking user changes, preserve the work and report the blocker.
