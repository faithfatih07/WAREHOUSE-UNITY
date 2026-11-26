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

Current phase: Phase 7B — audio only. Phase 7A is committed and verified on GitHub main as `2f3fd5e1058fd24731649c4c2cbcaccd19fde061`. The verified Play Mode behaviour is: one existing packing carton plays the matching Open_Carton Legacy clip, one Office_Double_Locker plays the matching Double_Locker clip, and all 100 separate roller child transforms across the four existing straight tevy GLB conveyor modules rotate procedurally. No GLB clip was retargeted, no audio has been added, no props were duplicated, camera switching and Phase 6 generator regression passed, and the Console reported 0 errors plus 8 pre-existing FBX obsolescence warnings. See PROJECT_BRIEF.md section 21 and AnimationPlaybackValidation.md.

Implement Phase 7B audio only. IMPORTANT LOCAL GIT SAFETY: the prior Codex report explicitly said the local working tree still contained pre-existing changes. Start by inspecting `git status --short`, `git rev-parse HEAD`, `git log -1` and `git remote -v`. Do not run reset, clean, checkout of user files, stash, blanket add (`git add .`), or overwrite any pre-existing local changes. Do not commit unrelated files. Work only in the new Phase 7B script/audio paths and required documentation; stage those exact paths only. If the worktree state prevents a safe commit, preserve everything and report the blocker rather than trying to “fix” it destructively.

Keep audio zero-cost and minimal: locally synthesize original WAV assets if no existing verified CC0 source is already available; do not broaden asset research, purchase assets, use trials, install packages or add music. Implement a low-volume ambience loop, a spatial conveyor loop synchronized with the continuously rotating rollers, and at most one restrained packing/carton one-shot (only with a genuine low-frequency event/trigger; do not play it constantly). M toggles the Phase 7B audio without conflicting with V camera switching or Escape cursor release. Keep controller and AudioSources grouped in one idempotently created hierarchy. Do not change Phase 7A animation code, camera code, generator, scene layout, or protected scenes unless a verified audio integration issue absolutely requires it. Verify in actual Unity Play Mode, check Console, commit only scoped changes if safe, push and verify remote main. The user must manually confirm audible playback on the Mac; do not claim audibility from AudioSource.isPlaying alone. After Phase 7B, proceed to Phase 8 final QA. The ambiguous PDF term “lizards” is excluded by user decision and must not be researched or reopened.
