# WAREHOUSE-UNITY — Authoritative Project Brief

Version: 1.13  
Status: Active project specification  
Unity project: WAREHOUSE-UNITY  
Unity pipeline: Universal Render Pipeline (URP)  
Repository: https://github.com/faithfatih07/WAREHOUSE-UNITY

## 0. Mandatory instruction for every AI agent

Before making any project change, read this file completely.

This document is the source of truth for scope and design decisions. Preserve the decisions below across sessions. Do not silently change the project type, camera plan, visual target, C# scope, scene structure, or delivery priorities. If a new request conflicts with this brief, explain the conflict and ask before changing the agreed scope.

Do not claim an operation succeeded unless it was actually run and verified in Unity or GitHub. Distinguish facts observed in the project from assumptions and recommendations. Never invent imported assets, working animations, sounds, screenshots, builds, or tests.

Keep the work efficient: prioritize a complete, coherent, reference-quality warehouse over unnecessary complexity. Use ready-made assets where practical instead of spending time custom-modelling ordinary warehouse props.

## 1. Instructor requirements — source-derived

The instructor's two-page DPVR_Specification.pdf asks for a 3D warehouse or manufacturing environment created in Unity 3D. Students are expected to research and find the models needed for the environment.

The specification explicitly lists:
- Models used to assemble the environment: rack, crates, container, cabinets, assembly tables, conveyor, and pallet truck. The PDF also contains the word “lizards”; the user explicitly excluded that item from project scope on 2026-11-26. It is not implemented and must not be researched or treated as a blocker.
- Sounds that fit the environment.
- Animation of some elements.
- Interior lighting.
- C# script only as an optional extension; the PDF gives a generator to fill a warehouse as an example.

The PDF shows an example warehouse with storage racks, pallets/boxes, operational areas, loading docks and trucks. It is an example, not an instruction to reproduce the exact image.

The PDF does NOT specify exact dimensions, required player controls, required camera type, assessment rubric, submission platform, executable format, or deadline. Do not present any of these as instructor requirements unless later confirmed.

Suggested asset sources named in the PDF include Unity Asset Store, Free3D and TurboSquid, as well as three additional asset-collection websites. Check individual asset licences before use. Prefer legitimate sources and assets that can be legally included in the submitted project.

## 2. Non-negotiable budget decision

The user explicitly requires a total project budget of EUR 0. No paid assets, plugins, subscriptions, AI services, credits, add-ons or trials that may become paid. Do not purchase or initiate checkout. Use free assets with verified licences (prefer CC0; CC BY 4.0 is acceptable with proper attribution), original procedural geometry, or models created locally with existing free tools. Do not use unauthorized copies of paid assets. The zero-budget constraint must not be used as a reason to silently lower the reference-quality target; instead, harmonize legal free assets and create missing props procedurally.

## 3. Agreed user decisions — fixed scope

These decisions were explicitly selected by the user:

1. **Visual target: reference quality.** Match the instructor example's overall visual completeness, detail density, functional clarity and polished three-quarter/isometric presentation. Photorealism is NOT a requirement. A coherent stylized-realistic / industrial visualization style is acceptable if it reaches the reference's level of detail. Avoid childish/cartoonish styling and avoid a bare primitive-looking final scene. It does not need to be an exact replica.
2. **Camera experience: BOTH.**
   - Isometric / elevated overview mode for presenting the complete warehouse.
   - First-person mode for walking around inside the warehouse.
   - Recommended default: isometric overview on scene start; provide a clear, reliable toggle (proposed key: V) between modes.
3. **C# scope: Warehouse Generator.** Implement a usable generator to populate storage areas with warehouse contents. It is a deliberate project feature even though C# scripting is optional in the instructor's specification.

Do not downgrade the visual target to a minimal blockout as the final result. A blockout is only an intermediate planning stage. Do not interpret 'reference quality' as a requirement for photorealism or expensive PBR assets; prioritize the instructor image's scene composition, functional detail and visual coherence.

## 4. Design direction and layout

Build a coherent medium-sized logistics / distribution warehouse inspired by the instructor's example.

Planned functional zones:
- Storage zone: industrial pallet racks, multiple rack rows and levels, pallets and cartons.
- Loading zone: loading docks / doors, staging space and truck or trailer props where suitable assets are available.
- Operations / sorting zone: conveyor belt and sorting or transfer area.
- Packing / assembly zone: assembly tables, work surfaces, crates and cabinets.
- Inventory / staging zone: pallets, containers and stacked goods.
- Small office / control area: optional but recommended if it fits the layout without distracting from the main warehouse.

Layout must read clearly from the isometric camera: distinguish circulation aisles, rack rows, loading and operational zones. Keep first-person routes navigable and avoid blocking aisles with randomly generated objects.

Exact dimensions are not specified by the instructor. Choose practical provisional dimensions during Phase 1, record them, and keep them consistent. Avoid repeatedly resizing the whole building later.

## 5. Visual and technical quality

- Use the existing Unity URP project; do not replace it with another render pipeline.
- Aim for a polished industrial/logistics look matching the instructor example: concrete floor, steel structure and racks, warehouse markings, believable materials, readable roof/ceiling structure and appropriate industrial lighting. The overall style may be stylized-realistic rather than photorealistic.
- Use one coherent asset family / art style where practical. Use imported models/prefabs for prominent assets (racks, forklifts or pallet trucks, conveyors, pallets, crates, trucks, etc.) whenever suitable licensed assets are available. PBR is preferred where it adds value, but a well-made shared texture atlas is acceptable if it produces a consistent reference-quality result.
- Use primitive or procedural geometry only for blockout, small supporting details, or a clearly justified fallback—not as a substitute for all major final assets.
- Keep scale, pivots, colliders and material assignments consistent.
- Prefer good composition, clean zone layout, readable aisles and adequate lighting over a large quantity of poorly placed props.
- Avoid unnecessary post-processing or expensive effects that reduce performance on the user's Mac.

## 6. Warehouse Generator — required project feature by user decision

Create a maintainable C# generator that can populate warehouse storage with reusable prefabs.

Minimum intended controls:
- Number of rack rows / rack bays or equivalent layout parameters.
- Number of shelf levels.
- Fill density / percentage.
- Deterministic random seed so the same seed reproduces the same layout.
- Clear / regenerate ability without duplicating previous generated contents.
- Respect rack positions, shelf bounds and aisle clearance.
- Use imported prefabs for boxes, crates and pallets when available; report missing prefab assignments rather than pretending assets exist.

The generator should be easy to run and configure (prefer an Editor Inspector component or custom editor workflow if that is the simplest reliable implementation). Do not build a complex inventory simulation; the goal is a convincing, controllable warehouse-population generator.

## 7. Two camera modes

### Isometric overview
- Starts as the default mode.
- Frames the warehouse as a whole, preferably with a raised three-quarter view.
- Use an orthographic camera if it gives the clearest presentation; otherwise use a carefully tuned perspective camera.
- Make the building readable. A removable/hidden roof or cutaway approach may be used if needed for visibility.

### First-person exploration
- Switchable from the overview mode (proposed V key).
- WASD movement and mouse look.
- Basic collision so the player cannot pass through walls and major equipment.
- Sensible movement speed and start position.
- Avoid adding unnecessary combat, scoring or unrelated game mechanics.

Both modes must be tested in the built scene.

## 8. Animation and sound

Instructor asks for sounds and animation of some elements. Implement a small number of visible, reliable examples:
- At least one clear moving element, preferably conveyor belt with boxes moving along it.
- A simple door, warning light, or other secondary animation if time allows.
- Appropriate warehouse ambience and/or machinery audio, with spatial placement where useful.
- Do not claim audio or animation is complete until tested in Play mode.

Prioritize a working conveyor animation and a small set of appropriate sounds over many unfinished effects.

## 9. Phased implementation plan

### Phase 0 — Foundation (completed / verify as needed)
- Unity URP project created.
- MCP for Unity installed and Codex connection verified by reading the active project, scene hierarchy and available tools.
- GitHub repository initial project commit pushed to main.
If any status changes, verify it rather than assuming.

### Phase 1 — Layout and blockout (completed)
- Inspect current project and active scene before editing.
- Create a clear warehouse layout with the functional zones above.
- Establish provisional dimensions, floor, perimeter walls, loading edge, main aisles and rack footprints.
- Create a top-down / isometric blockout or layout document and a simple in-Unity blockout scene.
- Keep the blockout visually understandable, but do not waste time polishing placeholder geometry.
- Save the scene and report exact files and what was verified.
- Verified completed on 2026-11-25: commit c5a387d on main; Warehouse_Blockout.unity and WarehouseBlockoutBuilder.cs are in the repository; SampleScene unchanged; URPProjectSettings diff clean; two consecutive builder runs preserved one WAREHOUSE_ROOT and five rack rows; Unity Console reported no errors and one MCP WebSocket warning.

### Phase 2 — Free asset research and import (zero budget)
- Use ASSET_RESEARCH.md as the current free-only shortlist.
- Find a compact, visually coherent set of legal free assets compatible with Unity 6 URP.
- Prefer CC0; CC BY 4.0 is acceptable with correct attribution. Free Unity Asset Store packages under their EULA are also acceptable.
- Never purchase assets or initiate checkout/trials. Never use unauthorized mirrors of paid assets.
- Inspect archive contents and licences before importing. Record source, creator, licence and attribution in CREDITS.md.
- Import a small representative set into a preview folder/scene first; verify scale, materials, pivots, colliders and URP rendering.
- Create missing props procedurally / locally using free tools rather than paying.
- Do not list assets as imported until they have been verified in Unity.

### Phase 3 — Main environment assembly
- Replace blockout placeholders with selected models.
- Complete racks, stock, operational areas, loading docks and exterior context.
- Preserve circulation paths and the layout decided in Phase 1.

### Phase 4 — Materials, lighting and presentation
- Apply a coherent material style; use PBR where supported and useful, or a consistent colour-atlas workflow for a stylized-realistic asset set.
- Add interior lighting and suitable exterior / loading-area lighting.
- Tune shadows and visual composition.
- Ensure the overview camera clearly presents the whole environment.

### Phase 5 — Camera modes
- Implement and test isometric overview and first-person exploration.
- Add the mode toggle and basic collision / movement.

### Phase 6 — C# Warehouse Generator
- Implement configurable, deterministic rack / shelf stock population.
- Test regeneration and clearing; ensure no aisle obstruction.

### Phase 7 — Animation and audio
- Implement working conveyor movement (and boxes if suitable), plus selected secondary animation.
- Add appropriate warehouse sound effects and ambience.
- Test them in Play mode.

### Phase 8 — QA and delivery
- Resolve Console errors and test both camera modes.
- Test generator, animations and audio in the actual Unity Editor.
- Confirm scenes and dependencies are included in the repository.
- Commit and push changes to GitHub.
- Produce an appropriate build and short walkthrough evidence once the lecturer's submission format is confirmed.

## 10. Working rules and anti-drift checklist

At the start of every new work session:
1. Read this brief.
2. Check the current Git branch and working tree.
3. Inspect the actual Unity scene and Console through MCP.
4. Identify the current phase and the next unfinished deliverable.
5. Do not redo completed phases unless a verified problem requires it.

For every completed phase, report:
- What was actually changed.
- Which files/scenes/assets were created or modified.
- What was tested in Unity.
- Any remaining blockers or assumptions.
- Whether the changes were committed and pushed.

Do not mark a phase complete based only on generated code or a successful MCP tool call; verify the resulting scene or behavior in Unity when possible.

## 11. Historical Phase 2 status and next requirement (see section 16 for current status)

Phase 2 asset import and validation is complete for all categories with a known meaning under the EUR 0 budget. The project contains 14 selected CC0 Warehouse Essentials interactive FBX props, 17 separate Legacy animation samples, and eight CC0 GLB gap models. Added assets and clips were verified in the live Unity 6000.6.10f1 URP 17.6.0 Editor; see `ASSET_RESEARCH.md` section 23 and the imported asset reports. The installed official importer dependencies remain glTFast 6.21.0, KTX 3.8.0 and Meshopt Decompressor 0.3.0-exp.1. No downloaded code was executed and no antivirus scan was performed. Historical note, superseded by the later user decision in section 19: the exact instructor word “lizards” was initially carried as unresolved during Phase 3. The user subsequently explicitly excluded it from scope. Do not research it or ask for clarification. Original procedural general storage cabinet and assembly table were approved at EUR 0 and are now built.

## 12. Phase 2 — GLB importer and gap assets (2026-11-26)

- The existing importer-support commit `c30f1ce` (`build: add official glTF import support`) was pushed to `origin/main` before creating any follow-up commit. The remote `main` ref was verified at `c30f1ce9ae2df12ee8fd92d8530aafe73cfde701`.
- Unity Editor: `6000.6.10f1`; URP: `17.6.0`. Official Unity packages retained: glTFast `6.21.0`, KTX `3.8.0`, Meshopt Decompressor `0.3.0-exp.1`.
- Six reviewed models are imported under `Assets/Imported/FreeWarehouseGapAssets/Models/`: `Steel_Pallet_Rack_L0.glb`, `Forklift_L0.glb`, `Loading_Dock_L0.glb`, `Semi_Truck_L0.glb`, `Shipping_Container.glb`, and `Conveyor_Roller_Straight_L0.glb`. Embedded materials and textures remain in the GLBs; source/license records and visual captures are in the sibling `Documentation` folder.
- Live Editor import verification exercised meshopt geometry and KTX2/BasisU texture decoding. All six models rendered with the glTFast PBR shader in URP, with no null material references. Measured bounds and component limitations are in `ASSET_RESEARCH.md` section 22. No animation clips/components, colliders or LODGroups were found in the imported instances.
- `WAREHOUSE_LAYOUT.md` now records the 23–24 m clear apron, +2.5 m rack placement, 180° Y dock rotation and 180° Y truck placement for its south-facing dock. The actual blockout scene and builder were not changed by this documentation/import task.
- Phase 2 completion review and current coverage decision are recorded in section 13 and `ASSET_RESEARCH.md` section 23. The GLB import did not add colliders or LODGroups; the added raw FBX props also have no Unity colliders or LODGroups. Do not infer these features from source hierarchies or separately supplied assets.

## 13. Phase 2 final asset coverage and animation review (2026-11-26)

- Added and verified `Conveyor_Roller_Curve_L0.glb` and `Conveyor_Belt_Transfer_L0.glb` from the already-reviewed tevy CC0 sources. Both project files match the source-review SHA-256 values. The modular conveyor now has straight, curve and transfer pieces.
- Added eight unique Warehouse Essentials interactive FBX props: `Box_Medium`, `Box_Small`, `Crate_Small`, `Double_Locker`, `Electrical_Cabinet`, `Open_Carton`, `Toolbox` and `Wooden_Spool_Table`. Their file hashes match the original archive. Added the exact referenced Blue, Rust and Sage atlases and assigned project-owned URP Lit materials.
- Retained all 17 separate Warehouse Essentials animation FBXs. In Play Mode every Legacy clip reported as playing; 13 changed transforms over the sampled interval, while `Industrial_Trash_Can`, `Lidded_Transit_Tote`, `Plastic_Barrel` and `Workbench_Vise` showed no pose change. The five moving priority clips and Toolbox have matching transform paths on their static imported FBX counterparts. Root transforms are keyed, so later instances need an unanimated placement parent.
- The added curve, transfer and eight FBX props rendered with resolved material/texture references in the actual Editor. No raw FBX/GLB instances had Unity colliders or `LODGroup` components. The temporary preview scenes were deleted; `Warehouse_Blockout.unity`, `SampleScene`, packages and project settings were preserved.
- Historical Phase 2 review: the source PDF's exact term “lizards” was initially treated as ambiguous. This status was later superseded by the user decision in section 19 to exclude it. The original general cabinet and dedicated assembly table have since been built; lighting, camera modes and generator are complete.
- Historical decision during Phase 3: proceed without clarifying “lizards”. This was subsequently superseded by section 19, where the user excluded the item from scope. The general cabinet and assembly/production table were built with original free geometry.


## 14. Phase 3 authorization and implementation constraints (2026-11-26)

Historical Phase 3 authorization. Superseded by the current scope decision in section 19: the user excluded the ambiguous “lizards” term from the project. It is not implemented, must not be researched or asked about, and is not a blocker.

Original modelling decisions under the EUR 0 budget:
- Create a coherent general warehouse storage cabinet using original procedural geometry in the project.
- Create dedicated assembly / production worktables using original procedural geometry, supplemented by the imported Wooden_Spool_Table and Workbench_Vise where appropriate.
- Do not purchase or import paid content.

Phase 3 scope:
- Build the final warehouse environment in a new dedicated scene Assets/Scenes/Warehouse_Final.unity, initially copied from Warehouse_Blockout.unity.
- Keep Warehouse_Blockout.unity and SampleScene unchanged as safe baselines.
- Use the verified imported FBX/GLB models already present in the repository. Do not perform another broad asset search.
- Replace the visible blockout placeholders with actual building architecture, industrial pallet racking, stock, office/control, receiving, sorting/conveyor, packing/assembly, dispatch, loading docks, trucks and exterior apron.
- Preserve the 60 × 40 m internal footprint and 9 m approximate clear height. Extend clear south apron depth to 23–24 m (Z approximately -24 to -1) to fit the measured 20.026 m truck.
- Racking: five north-south rows with two 8.7 m rack modules per row; use measured asset orientation, centre the model pivot correctly and place the rack base on the floor (the verified rack requires +2.5 m Y when its imported root is unrotated; verify after the 90-degree Y row rotation).
- Place dock/truck instances using verified pivots and orientations: loading docks face south; truck rear doors face north toward the dock when reversing from the south apron. Verify clearances; do not scale the truck down.
- Use the straight, curve and belt-transfer conveyor modules in a coherent sorting line. Preserve the main forklift spine and accessible pedestrian paths.
- Build the exterior shell/roof structure as actual warehouse architecture; keep roof elements grouped separately so the overview presentation can use a cutaway/hidden-roof view without permanently deleting the roof.
- Keep procedural cabinets and worktables visually detailed and consistent with the imported asset palette; avoid bare placeholder cubes.
- Phase 3 is assembly only. Do not implement the configurable C# Warehouse Generator (Phase 6), finished camera controller (Phase 5), final lighting pass (Phase 4), or sound/animation system (Phase 7) yet. Basic scene lighting needed to inspect the assembly is allowed, but do not claim final lighting/audio/animation completion.
- Preserve clear aisles, dock alignment and first-person navigation routes.
- Build through a new idempotent Editor assembly script that only regenerates its own WAREHOUSE_FINAL_ROOT; do not reuse the Phase 1 blockout builder in a way that modifies the baseline scene.
- Generate/save screenshots from the actual Unity Editor. Verify the scene, hierarchy, Console and Git diff. Test the assembly builder twice for idempotency.
- Commit and push only the verified Phase 3 scene, assembly script, project-owned materials and documentation. Never commit temp folders or unrelated Unity generated caches.

## 15. Phase 3 final warehouse assembly (2026-11-26)

The final environment was assembled and checked in the active Unity 6000.6.10f1 / URP 17.6.0 Editor. `Assets/Scenes/Warehouse_Final.unity` was created by copying the Phase 1 scene on disk; the copied blockout is an inactive `WAREHOUSE_BLOCKOUT_REFERENCE`, and all Phase 3 content is under a separate `WAREHOUSE_FINAL_ROOT`. `Assets/Editor/WarehouseAssemblyBuilder.cs` has a menu regeneration command that replaces only that exact final root.

The scene retains the 60 × 40 m interior and approximately 9 m clear height, a 24 m south apron (Z −24 to 0), the three loading openings, a separate roof structure and retained roof-panel/skylight hierarchy, industrial cladding and floor safety routes. Ten verified steel rack modules occupy five north-south rows; the measured rack bounds are 1.50 × 5.00 × 8.70 m after row rotation, with each base at Y = 0 and 4 m clear between row footprints. A 1.8 m marked pedestrian route remains clear between the west wall and the office partition. Three south-facing dock models align with three full-size 20.026 m trucks; their rear bounds end at approximately Z = −0.11 m and face the docks. One container is staged east of the warehouse. Four straight conveyor modules, one curve and one belt transfer are used, with visible carton/crate loads. The scene includes receiving, sorting, packing/assembly, dispatch, office/control and storage props, plus original detailed procedural general-storage cabinetry and assembly tables.

Unity verification observed two scene roots, 14 final hierarchy groups, 1,405 transforms below `WAREHOUSE_FINAL_ROOT`, 996 renderers, zero null material slots, 10 racks, three docks, three trucks and one inactive six-child blockout reference. A second consecutive builder run reproduced the same counts. Actual Editor captures are `Assets/Screenshots/WarehouseFinal_Phase3_Overview.png` and `Assets/Screenshots/WarehouseFinal_Phase3_Operations.png`. The protected baseline scene files, package manifest/lockfile and ProjectSettings have no diff. The Console had zero errors; it reported eight warning entries (four duplicated warnings) that the existing `MaterialLocation.External` FBX import setting is obsolete for `Crate_Large.fbx`, `Pallet.fbx`, `Pallet_Jack.fbx` and `Workbench_Vise.fbx`. No import settings were altered in this phase.

Phase 3 does not include final lighting/material polish, a switchable first-person camera, a configurable Warehouse Generator, or sound/animation integration. Imported models still have no colliders or LODGroups; collision/gameplay work remains for later phases. At that historical point, “lizards” was still pending clarification; the user later excluded it from project scope in section 19. The next implementation phase is Phase 4, followed by camera controls (Phase 5), the Warehouse Generator (Phase 6), and animation/audio integration (Phase 7). Phase 3 visual assembly was Editor-verified; final delivery commit/push state is reported with the task results.

## 16. Phase 4 materials, lighting and presentation (2026-11-26)

Phase 4 applies to `Assets/Scenes/Warehouse_Final.unity` only. The visual pass is implemented by `Assets/Editor/WarehousePhase4VisualBuilder.cs` (**Warehouse → Phase 4 → Regenerate Visual Transformation**), which preserves `WAREHOUSE_FINAL_ROOT` and replaces only its own `WAREHOUSE_PHASE4_DETAIL_ROOT`. Two consecutive Editor runs each produced 331 transforms below that detail root. The scene's 60×40 m interior, 24 m apron, zone positions, imported models, Package versions, URP pipeline, `Warehouse_Blockout.unity` and `SampleScene` are preserved.

The builder creates project-owned URP Lit materials and deterministic local texture maps for concrete, corrugated metal and sealed timber, plus metallic/smoothness and normal maps. It assigns these to the warehouse slab, apron, metal cladding, structure, roof panels and worktops. It adds fine expansion joints, aisle direction arrows, pedestrian crossing paint, loading-bay threshold marks, rack location cards, foot plates/anchor heads, column base plates/anchors, LED high-bay housings and spot lights, dock wall packs, and small packing-station bins/scales. Existing detailed imported rack, conveyor, truck, dock, forklift and furnishing assets remain in use; no asset was purchased or downloaded.

The full roof structure, roof panels and skylight material remain in the scene. `ROOF_PANELS_AND_SKYLIGHTS` stays disabled for the cutaway overview. It was temporarily enabled for the retained full-roof verification capture and restored to disabled before saving. The overview camera framing and scene ambient/directional lighting were tuned; no camera-mode controller was added. High-bay/dock lights are non-shadow-casting to limit render cost; the existing directional light retains soft shadows. The project settings and packages were not intentionally changed; `ProjectSettings/URPProjectSettings.asset` was restored byte-for-byte after Unity added an unrelated path field.

Actual Editor captures are `Assets/Screenshots/WarehouseFinal_Phase4_Overview.png`, `WarehouseFinal_Phase4_Storage_Closeup.png`, `WarehouseFinal_Phase4_Operations_Closeup.png` and `WarehouseFinal_Phase4_Roof_Complete.png`. The first three show the saved cutaway state; the final image documents the retained roof option. The Phase 3 overview/operations captures remain the before images. The final live scene query found 1,279 renderers, zero missing material/shader slots, 543 assigned Phase 4 material slots with 302 texture-backed assignments, and one 331-transform detail root. The final Console query returned zero errors and four existing obsolete `MaterialLocation.External` warnings from `Pallet.fbx`, `Pallet_Jack.fbx`, `Workbench_Vise.fbx` and `Crate_Large.fbx`; their importer settings were not changed. The earlier “lizards” status was superseded by the user scope decision in section 19. Phase 5 camera modes, Phase 6 generator and Phase 7 animation/audio remain future work.


## 17. Close-up pixelation finding and camera-phase handoff (2026-11-26)

The user's Phase 4 Unity screenshots show the Game view Scale slider at 2x for the overview capture and 7x for the close-up crop. Unity's Game View Scale slider zooms into the rendered Game view to inspect areas; it magnifies the existing displayed pixels rather than creating a higher-resolution render. Do not use a 7x Game view screenshot as the final evidence of texture quality. Re-capture comparisons at 1x/native display scale with a fixed Game view resolution.

The project also has objectively modest source texture sizes:
- Phase 4 builder source `Assets/Editor/WarehousePhase4VisualBuilder.cs` creates albedo maps at 512×512 and normal/metallic maps at 256×256.
- Phase 4 generated texture importer metadata currently uses bilinear filtering (`filterMode: 1`) and anisotropic level 1. Mipmaps are enabled.
- The original Warehouse Essentials FBX atlases are 128×128 according to the asset import report.
- Phase 4 textures are generated procedurally by code, so source resolution and noise-frequency settings—not the Warehouse layout algorithm—are the relevant code-controlled quality variables.
- URP anti-aliasing can improve geometry edge aliasing; MSAA does not solve shader/texture aliasing. Anisotropic filtering is useful for ground textures viewed at steep angles but has a performance cost. Tune these independently.

Required bounded correction during the next task:
1. First compare the same overview/close-up framing at Game view Scale 1x and 7x. Use 1x for quality decisions and saved screenshots.
2. Inspect texture source dimensions and import settings. Do not merely increase Max Size for an existing low-resolution source; regenerate source textures at a genuinely higher resolution if the texture is the confirmed limitation.
3. For Phase 4 generated materials, evaluate 1024–2048 albedo and at least 1024 normal/metallic maps for the largest surfaces, with sensible source noise detail, mipmaps, trilinear filtering and moderate anisotropic filtering on the floor. Preserve the existing coherent art style and avoid obvious noisy/high-frequency speckle.
4. Keep original low-res imported atlases for their asset use unless a visually consistent replacement is authored and verified; do not blindly upscale a 128×128 atlas and claim added detail.
5. Test modest URP edge anti-aliasing (e.g. 2x/4x MSAA or a suitable low-cost camera post-AA option) separately from texture filtering. Prefer the lightest result that visibly improves edges on the M4 MacBook Air. Do not change render pipeline or unrelated package versions.
6. Capture before/after images at identical 1x display scale and comparable scene framing. If the remaining pixelation appears only at 7x, document it as Game View magnification rather than a project defect.

Next phase remains Phase 5 camera modes. Complete the bounded image-quality calibration as a preflight, then implement both approved modes: default isometric overview and switchable first-person exploration (V key, with a clear on-screen hint/button). Include WASD + mouse-look, cursor escape/unlock, sensible speed, CharacterController movement and simple collision proxies for major walls/racks/large equipment while keeping the pedestrian route and forklift aisles traversable. Show the complete roof in first-person and retain the roof-panel cutaway for overview. Keep the new controller/collision objects grouped and the builder idempotent. Do not begin Phase 6 Warehouse Generator or Phase 7 audio/animation integration.


## 18. Phase 5 implementation and verification (2026-11-26)

Texture calibration updated the Phase 4 source builder and regenerated the six existing PNGs in place: concrete albedo 2048×2048; cladding and timber albedo, steel and concrete normals, and steel metallic/smoothness at 1024×1024. Existing paths and Unity GUIDs were preserved. No original 128×128 atlases were upscaled. Texture imports use mipmaps, Trilinear filtering, anisotropy 4 on concrete maps and 2 on other maps, with sRGB and normal-map roles retained. A separate `Warehouse/Phase 4/Regenerate Source Textures Only` menu command deterministically rewrites the exact source images even when they already exist.

`Assets/Scripts/WarehousePhase5CameraController.cs` switches the existing overview camera between an orthographic elevated three-quarter view and first-person. It provides WASD movement, mouse look, click-to-capture, Escape release, V switching, overview scroll zoom/right-drag pan, an on-screen controls banner, and runtime URP FXAA at medium quality. Overview hides `ROOF_PANELS_AND_SKYLIGHTS`; first-person enables the complete roof/skylights. `Assets/Editor/WarehousePhase5Setup.cs` is an idempotent `Warehouse_Final`-only setup action: it reuses the active camera, creates one player CharacterController and 30 invisible BoxCollider proxies for perimeter sections, five rack rows, structural columns, the conveyor and packing stations. South dock openings are retained. The scene already had a second inactive camera; setup created no duplicate camera.

Unity 6000.6.10f1 / URP 17.6.0 Play Mode checks began in overview. The V-key path was exercised and showed the first-person UI; five further runtime mode transitions confirmed the first-person/overview and roof-active states alternated as expected. A CharacterController collision check stopped against the west perimeter wall/colliders and first rack row, while movement along the west pedestrian route advanced from z=4.5 m to z=9.5 m. Running the setup menu twice retained one Phase 5 root, one player/controller and 30 collision proxies. Native Game View screenshots are `Assets/Screenshots/WarehouseFinal_Phase5_Overview_PlayMode.png` and `Assets/Screenshots/WarehouseFinal_Phase5_FirstPerson_PlayMode.png`; both display the control banner and show the correct roof state.

The final Console query after recompilation returned no entries. An earlier query showed no errors and four existing FBX `MaterialLocation.External` obsolescence warnings (`Crate_Large.fbx`, `Pallet.fbx`, `Pallet_Jack.fbx`, `Workbench_Vise.fbx`). The unrelated Unity serialization change to `P4_LED_Diffuser.mat` was restored. `SampleScene`, `Warehouse_Blockout.unity`, Packages and ProjectSettings have no diff.

### Required 1× visual comparison remains open

On this Retina macOS display the live Game View control reported 2× as its minimum, even after setting its internal scale to the minimum. The before capture was made at 7× and the after capture at that available minimum; both are 1920×1104, but their camera framing differs. These are not a matched, explicitly verified 1× comparison. The overview/first-person Play Mode screenshots are 1100×636 ScreenCapture outputs. Phase 5 implementation is in place, but **visual-quality sign-off is pending** a fixed-framing, verified 1× before/after capture. Do not claim the texture comparison requirement is complete until then.

The EUR 0 budget is unchanged. Phase 6 generator and Phase 7 audio/animation integration remain. The user has explicitly excluded the ambiguous “lizards” term from project scope; do not spend further effort on it.

## 19. User scope decision — exclude the ambiguous "lizards" term (2026-11-26)

The user explicitly instructed: "tamam o lizard ı siktir et kalan işlere odaklan" (ignore the lizard item and focus on the remaining work).

This supersedes every earlier note that treated "lizards" as an open clarification task or a Phase 3/Phase 2 sign-off blocker.

Rules from now on:
- Treat the source PDF's literal word "lizards" as an intentionally excluded / waived item for this project scope.
- Do not research it, ask the lecturer about it, substitute "ladders", build a model for it, or spend further Codex tokens on it.
- Do not state that the item was built or fulfilled. If the final coverage report must be exhaustive, label it "excluded by user decision / not implemented", not "complete".
- Continue with the remaining known project requirements only.

Current remaining technical sequence:
1. Phase 6 — implement the configurable deterministic C# Warehouse Generator, using the exact user-selected scope in section 6 of this brief.
2. Phase 7 — integrate working conveyor/selected prop animations and appropriate sound effects/warehouse ambience; test in Unity Play Mode.
3. Phase 8 — final QA, both camera modes, generator, animation/audio, Console, repository dependencies and a build/walkthrough. Do not claim the Roll-a-Ball course tutorial or email/group response is complete unless the user separately confirms it.

Phase 5 status:
- Both camera modes and texture source regeneration are implemented and Play Mode checked.
- A strict matched 1× before/after texture screenshot was not achievable on the current Retina Game View (2× was its reported minimum; captures also used different framing). This is a documented evidence limitation, not a reason to block Phase 6. Do not spend another long task chasing 1× unless a practical native-resolution capture method is available during final QA.
- Preserve truthful status: calibration is implemented; matched 1× comparative sign-off is not verified.

The EUR 0 budget and all other established design choices remain unchanged.

## 20. Phase 6 configurable warehouse stock generator (2026-11-26)

`Assets/Scripts/WarehouseStockGenerator.cs` stores the scene configuration. `Assets/Editor/WarehouseStockGeneratorEditor.cs` provides a direct Inspector UI (row count, bays per row, shelf levels, fill density, deterministic seed and relative pallet-only/box/crate distribution weights) plus Generate, Clear Generated Stock and Regenerate buttons. Its setup command is **Warehouse → Phase 6 → Configure Stock Generator in Warehouse_Final**. It binds the existing imported Pallet, Box_Small, Box_Medium, Crate_Small and Crate_Large models; no source model was edited and no project-owned model prefabs were needed.

The generator targets the 10 existing modules in `WAREHOUSE_FINAL_ROOT/STORAGE_RACKS_AND_STOCK`, using the assembly's measured row/module transforms and its proven three-bay spacing (2.65 m) and two shelf positions (Y 0 and 2.55 m). The default full rack capacity is 5 rows × 6 positions per row × 2 levels = 60 loads. One pallet and at most one aligned cargo model occupy each selected slot. Seeded `System.Random` shuffling and category selection make the same configuration repeatable. Clear and Regenerate destroy only children of `WAREHOUSE_GENERATED_STOCK_ROOT`; the editor validates required references before clearing.

The configure command created `WAREHOUSE_STOCK_GENERATOR_CONFIG` and the dedicated `WAREHOUSE_GENERATED_STOCK_ROOT`. It moved the existing 120 objects explicitly named `Stock_*` / `Stock_Pallet_*` under that root without replacing their instances, transforms or rack structures. Subsequent generation replaces only the contents of that owned root. The saved `Warehouse_Final.unity` ends with the default 50% density (30 loads), seed 12345; other scene objects, rack modules, routes, trucks, conveyor and architecture were not regenerated.

Actual Unity 6000.6.10f1 Editor validation passed: seed 12345 repeated to an identical arrangement; seed 67890 produced a different arrangement; densities 25/50/75/100 generated 15/30/45/60 unique in-rack slots; clear reduced the owned root to zero; regeneration returned 30 loads without duplicates. Slot checks bounded generated positions to the rack zone. Play Mode started in overview, V switched to first-person, repeated mode changes were exercised, the first-person view rendered the rack aisle, and a one-second W input advanced along the pedestrian route; V returned to overview. The current Console after the generator run showed 0 errors and 2 existing obsolete `MaterialLocation.External` warnings for `Workbench_Vise.fbx` and `Pallet_Jack.fbx`. Earlier Console history contained four obsolete FBX import warnings; these importer settings were not changed. No Phase 7 work was started.

The required Phase 5 matched 1× texture comparison remains pending as documented above. Phase 6 was completed under the user's explicit authorization. Phase 7 was not started in this task.

## 21. Phase 7 — staged implementation plan (authoritative, 2026-11-26)

Do NOT combine animation and audio into one long Codex task. Implement and verify the animation work first (Phase 7A), commit/push it, then implement audio (Phase 7B) in a separate task. This reduces debugging scope and makes failures attributable.

### Phase 7A — visible animation only

The active scene is `Assets/Scenes/Warehouse_Final.unity`. The Phase 3 assembly builder's actual scene objects include:
- Sorting conveyor straight/curve/transfer pieces built from the separate tevy GLB modules.
- `Conveyor_Load_01` through `Conveyor_Load_04` placed along the straight run near X 43/47/51/55, Z 24.
- `Sort_Open_Carton` and `Packing_Open_Carton_1`.
- `Office_Double_Locker`, `Packing_Locker`.
- `Office_Control_Cabinet`, `Packing_Electrical_Cabinet`.
- `Packing_Pallet_Jack`, `Dispatch_Pallet_Jack_1`, `Dispatch_Pallet_Jack_2`.

The previous Play Mode report is `Assets/Imported/FreeWarehouseEssentials/Documentation/AnimationPlaybackValidation.md`. It tested 17 Legacy clips, all 2.50 seconds; 13 showed transform changes and four showed no visible transform change. Seven static FBX hierarchies were checked for curve-path compatibility. The safe, directly relevant matching candidates are `Open_Carton`, `Double_Locker`, and `Electrical_Cabinet`. `Pallet_Jack` and `Roller_Conveyor` also matched in the hierarchy check, but clips include root-transform curves, so do not use root-keyed clips if they cause drift or placement changes.

Important conveyor distinction:
- The active long conveyor system is built from tevy GLB straight/curve/transfer modules.
- The Legacy `Roller_Conveyor` clip belongs to a separate Warehouse Essentials FBX hierarchy. It is NOT a retargeted animation for the tevy GLB modules.
- Inspect the real GLB hierarchy. If rollers are separate visible child transforms, rotating those roller meshes procedurally is acceptable. Otherwise demonstrate conveyance by moving one existing `Conveyor_Load_*` carton/crate along the existing straight belt path, after validating exact coordinates and clearance. Do not create a fake claim that the GLB roller clip is playing.

Minimum animation scope (sufficient for the PDF's “animation, some of the elements”):
1. One carton with visible flap movement using the matching `Open_Carton` Legacy clip.
2. One existing locker OR electrical-cabinet door with visible open/close movement using its matching Legacy clip.
3. The conveyor demonstration: either actual individual roller rotation, or one existing load moving smoothly along the real straight section. Prefer the option that is genuinely visible and does not alter the approved layout.

Use the imported Legacy Animation clips/components with their matching FBX hierarchy paths; do not invent Animator Controllers or retargeting unless truly required. Place root-keyed animations under an unanimated placement parent, preserving the world location of the existing object. Use gentle looping or ping-pong, reasonable delays, and a neutral/default pose. Do not animate all repeated locker/cabinet instances; use one or two clear examples. Skip the Pallet_Jack animation unless its root motion is demonstrably safe and useful.

Use one small runtime animation controller plus a minimal editor setup helper only if needed. Avoid multiple overlapping manager systems. Do not add audio in Phase 7A.

Phase 7A acceptance:
- In actual Unity Play Mode, visibly confirm the carton flap and selected door move, and verify conveyor roller/package movement.
- Record before/after child transform values or other reliable runtime evidence.
- Ensure animated roots stay in their original world locations and no scene object duplicates appear.
- Switch overview/first-person modes while animations are running.
- Check Console and test the Phase 6 generator still works.
- Capture an actual Unity Editor/Play Mode screenshot.
- Commit and push the verified animation-only work before Phase 7B.

### Phase 7B — audio only

No audio source files currently exist in the repository tree. Keep audio simple and zero-cost:
- One low-volume continuous warehouse ambience/HVAC loop (2D or very wide spatial source).
- One spatial conveyor operating loop, enabled only while the conveyor demonstration is active.
- One restrained carton/packing one-shot, triggered by a clear event such as a package reaching the end of the conveyor. Do not play it repeatedly at an irritating rate.
- Do NOT add a reversing alarm yet: the current forklifts/trucks are static props and there is no real reverse-driving event to synchronize with.

Prefer original locally generated WAV files using a small offline Editor utility; an already-available, verified CC0 source is acceptable but do not perform a new broad asset search, sign up, pay or use a trial. Do not add music. Avoid installing audio packages or building a full AudioMixer unless a real need is shown.

Use a compact audio controller with sensible gain, loop, spatial blend and rolloff. Add one simple mute/unmute input (M) if it does not conflict with camera controls. Keep ambience and conveyor sound subtle.

Phase 7B acceptance:
- Confirm clips are assigned, import/load correctly and AudioSources enter playback in Play Mode.
- Provide a manual listening checklist; do not claim “audibly verified” based only on `AudioSource.isPlaying` or source configuration. The user must confirm actual audible output on the Mac, or a genuine audio-output recording must be inspected.
- Check that M mutes and restores all Phase 7 audio.
- Check the two camera modes and generator still work.
- Check Console, capture screenshots of the audio setup, update docs, commit and push.

### Phase 7 exclusions

- No forklift driving or reversing alarm without a real driving/reverse event.
- No music, complex interaction framework, advanced audio middleware, paid assets or packages.
- No animation for the four samples that showed no visible transform change: `Industrial_Trash_Can`, `Lidded_Transit_Tote`, `Plastic_Barrel`, `Workbench_Vise`.
- Do not re-target the Warehouse Essentials `Roller_Conveyor` clip to the tevy GLB conveyor.
- Do not modify `SampleScene`, `Warehouse_Blockout.unity`, the approved warehouse layout, Phase 6 generator or camera system except to fix a verified regression.
- The ambiguous “lizards” item is excluded by user decision; never reopen it.

## 22. Phase 8 — final QA and course handoff

After Phase 7A and 7B:
- Open `Warehouse_Final.unity` from a clean repository checkout and verify both camera modes, stock generator, animation and audio.
- Test the scene and project compile with no new Console errors.
- Confirm all referenced assets, clips, generated WAVs and packages are included in Git.
- Confirm a clean Git working tree and remote `main` parity.
- Create a standalone build only after confirming the lecturer's required submission format and target OS; the email screenshots do not specify this format or a deadline.
- Capture an overview, first-person walkthrough and short evidence clip if supported.
- Keep the Roll-a-Ball tutorial as a separate teacher-requested course task; do not claim it complete unless the user confirms it.
- The teacher also requested an email reply stating whether the semester project is individual or a group of up to three students. Track that separately from the Unity repository.
- A short consultation and VR headset session are offered as optional, not mandatory.
- The user explicitly excluded “lizards”; mark it “excluded by user decision / not implemented” in any exhaustive coverage table.

## 23. Phase 7A implementation and verification results (2026-11-26)

Phase 7A adds visible motion to existing scene objects in `Assets/Scenes/Warehouse_Final.unity`; no audio or spatial-layout change was made. `Assets/Editor/WarehousePhase7ASetup.cs` provides idempotent configure, target inspection, binding verification and Play Mode motion-check commands under **Warehouse → Phase 7A**. `Assets/Scripts/WarehousePhase7AAnimationController.cs` rotates the individually modelled rollers in the four existing straight tevy conveyor modules. No imported source model, animation FBX or project settings were modified.

The existing `Packing_Open_Carton_1` uses its matching Warehouse Essentials `Open_Carton` Legacy `Warehouse_DAY` clip. The existing `Office_Double_Locker` uses the matching `Double_Locker` Legacy clip. Both use automatic Legacy `Animation` playback, PingPong wrapping and 0.45 playback speed. Each model is parented under an unanimated placement transform so root-keyed clip curves cannot overwrite the prop's world pose. The conveyor controller binds 25 individual roller transforms in each of four straight modules (100 total) and rotates them around local X at 135 degrees per second. The Warehouse Essentials `Roller_Conveyor` clip was not retargeted to the tevy GLBs.

Actual Unity Play Mode sampling over 3.2 seconds observed carton flap transforms `Open_Carton__Flap_1` through `_4`, locker-door transforms `Double_Locker__Door_L` and `_Door_R`, and rotation of all 100 rollers. Both placement parents retained their original world positions and orientations. Setup and binding verification found one automatic matching Legacy clip per selected prop and 100 unique roller references. Configuration was run twice; it retained one wrapper per prop and one controller. The other requested candidate objects and four conveyor loads were inspected; they were left unchanged.

Unity Play Mode showed overview and first-person modes; V switched into first-person and back to overview. The full roof was visible in first-person and the cutaway remained in overview. Phase 6 generator regression validation also passed in this task: seed 12345 was stable, seed 67890 differed, densities 25/50/75/100 yielded 15/30/45/60 loads, and clear/regenerate produced no duplicates. Final default output was 30 loads at seed 12345 and 50% density. The test temporarily rewrote broad scene serialization; that transient output was discarded by restoring the repository baseline and reapplying only the Phase 7A bindings. The final scene diff contains the animation additions only.

Final Console inspection showed zero errors. Unity displayed existing obsolete `MaterialLocation.External` warnings from Warehouse Essentials FBX import metadata during reload and generator validation; importer metadata was not modified. No Phase 7B audio was added. Runtime results and clip validation are in `Assets/Imported/FreeWarehouseEssentials/Documentation/AnimationPlaybackValidation.md`. The Unity Editor Game View and Console were captured through the desktop UI; no screenshot file was added to the repository.

## 24. Phase 7B original warehouse audio (2026-11-26)

Phase 7B adds two zero-cost, locally synthesized PCM WAV loops in `Assets/Audio/Generated/`: a 20-second, 22.05 kHz stereo HVAC/room-tone bed and an 8-second, 22.05 kHz mono conveyor motor/roller loop. These are original procedural recordings synthesized by `Assets/Editor/WarehousePhase7BAudioSetup.cs`; no downloaded audio, paid service, plugin or music is used. The loops have no external licence/attribution requirement. The WAV import and playback state were checked in Unity.

`Assets/Scripts/WarehousePhase7BAudioController.cs` is attached beneath `WAREHOUSE_FINAL_ROOT/WAREHOUSE_PHASE7B_AUDIO_ROOT`. The root owns one 2D ambience AudioSource and one spatial conveyor AudioSource placed at `(49, 1.35, 24)` m, at the existing conveyor. Their starting volumes are 0.12 and 0.18; both loop. The conveyor source starts and stops with the enabled/active Phase 7A roller-operation controller. Press `M` to mute or restore both sources; a small HUD label shows the state. This does not use or intercept `V` camera switching or Escape cursor release. The setup menu under **Warehouse → Phase 7B** generates the clips, configures the scene idempotently, checks the bindings, and checks Play Mode source state. It refuses duplicate named roots/children or duplicate AudioSources rather than deleting objects. There is no packing one-shot because the existing conveyor demonstration has no genuine package-completion event; there is no reversing sound because vehicles remain static.

Actual Unity Editor checks passed: the clips imported with the expected duration/channel/sample-rate values; setup verification found one dedicated root, exactly two assigned looping AudioSources, one active AudioListener and a valid Phase 7A operation reference. Play Mode reported ambience playing and the spatial conveyor clip playing while the Phase 7A operation component was active. A dedicated Play Mode gate test disabled the Phase 7A operation, confirmed conveyor audio stopped, re-enabled it and confirmed audio resumed. Pressing `M` changed the HUD to Off and logged mute, then restored On and logged unmute. `V` was pressed twice and the overview was again visible. The Phase 7A Play Mode motion check passed during this task (four carton flaps, both locker doors and 100/100 conveyor rollers moved; placement parents remained stable). The Phase 6 generator validation also passed (seed 12345 repeatable, changed seed differed, densities 25/50/75/100 generated 15/30/45/60 unique loads, and clear/regenerate made no duplicates). The generator test temporarily changes scene stock; the saved scene was restored immediately afterward, preserving the Phase 7B audio additions.

Unity Console showed zero errors throughout. During initial Play Mode/import and generator validation, eight warning entries appeared as two repeated batches of the same four existing `MaterialLocation.External` obsolete-setting warnings for `Pallet.fbx`, `Pallet_Jack.fbx`, `Crate_Large.fbx` and `Workbench_Vise.fbx`; their importer settings were not touched. After the gate test, the latest Console count was zero warnings and zero errors. The Editor Game View/Console screenshots were captured in the desktop task session; no screenshot files were added to the project. `AudioSource.isPlaying` confirms Unity playback state only, not audible output. Before final acceptance, listen on the Mac at a modest system volume: start in overview and check the subtle ambience; press `V`, approach the sorting conveyor and check that its spatial motor/roller loop becomes clearer and attenuates with distance; press `M` to confirm both sounds mute, and press `M` again to restore them. Report any clipping, loop seam, harshness or imbalance. Phase 8 has not started. The user has since manually confirmed hearing the ambient and spatial conveyor loops and instructed us to continue; see section 25.

## 25. Phase 7B user listening check and Phase 8 final QA (2026-11-26)

### User-confirmed audio check
The user ran `Warehouse_Final` in Unity Play Mode on the Mac and reported hearing the general warehouse hum and a second sound when approaching the conveyor/pallet area. When prompted to check spatial attenuation and M mute/unmute, the user replied “evet, devam et” and authorized Phase 8. Treat the manual listening check as accepted by the user. The project intentionally has exactly two sounds: (1) low-level warehouse ambience and (2) spatial conveyor operation. There is no packing one-shot or forklift reverse alarm, because no suitable genuine event exists. Do not add more sounds merely to increase sound count.

### Source PDF acceptance criteria
The two-page source file `DPVR – specification` (page 1, reread 2026-11-26) asks for:
- A virtual 3D warehouse or manufacturing environment in Unity.
- Models: rack, crates, container, cabinets, “lizards”, assembly tables, conveyor, pallet truck.
- Sounds that fit the environment.
- Animation of some elements.
- Interior lighting.
- A C# generator is suggested conditionally (“if you can write scripts in Csharp”); it was additionally selected by the user and is implemented.
The user explicitly excluded “lizards” from scope. In the coverage report show it as “excluded by user decision / not implemented”, not complete and not a blocker.

### Phase 8 — mandatory execution order
1. **Read-only Git safety audit.** Inspect `git status --short`, `git diff --stat`, `git diff --cached --stat`, exact local diffs, `git rev-parse HEAD`, `git log -1`, `git remote -v`, then fetch and compare against verified remote `main` (`e5cea13212e02adcea1ab6f3d8ad98eaf7d80c7a` at task handoff). Prior reports identify pre-existing local changes in the Phase 4 LED material, three settings files and Build Profiles. Preserve them. Never reset, clean, stash, discard, checkout over them, blanket stage, or overwrite remote history. Do not claim a clean local working tree unless directly verified.
2. **Build-scene configuration.** The committed `ProjectSettings/EditorBuildSettings.asset` currently lists only `Assets/Scenes/SampleScene.unity`. This is a verified release-blocking omission: `Warehouse_Final` is not in the committed build scene list. Add `Assets/Scenes/Warehouse_Final.unity` as the first enabled scene while retaining `SampleScene.unity` as a second enabled scene. Use the existing Warehouse_Final GUID from its .meta; do not delete, replace or rename either scene. Inspect any local Build Profiles changes before using them; preserve existing user files and do not commit them indiscriminately.
3. **Scene and dependency audit.** Open `Assets/Scenes/Warehouse_Final.unity`; check missing scripts, missing serialized references, missing materials/textures/audio clips, GUID resolution, import failures and package consistency. Verify all required project files and their .meta files are tracked. Confirm the Unity version and URP package remain the approved versions. Do not alter third-party FBX importer metadata just to silence old warnings.
4. **PDF functional coverage in actual Play Mode.**
   - 3D warehouse: `Warehouse_Final` opens and presents the complete warehouse and apron.
   - Models: rack, crates, container, cabinets, assembly tables, conveyor and pallet truck present. “Lizards” excluded by user decision.
   - Lighting: interior high-bay and dock lighting visible.
   - Animation: carton flap, locker doors and 100 conveyor rollers move in Play Mode; placement remains stable.
   - Sound: user manually confirmed the two sounds on Mac; ambience is audible and conveyor sound spatially clearer near the conveyor. M mute/unmute and V camera switching were checked.
   - C# generator: repeatable seed, changed-seed variation, 25/50/75/100% density and clear/regenerate work without duplicates or blocked aisles.
5. **Regression/performance.** Verify both overview/first-person modes, roof state per mode, V toggle, WASD/mouse, Escape cursor release, major collisions, M audio toggle, generator, animations and no duplicates. Assess frame rate/render load on the M4 MacBook Air and record actual measured data if available; do not invent FPS.
6. **Unity Console.** Require zero new errors. Existing old `MaterialLocation.External` importer warnings may recur for Warehouse Essentials FBXs; identify exact source and distinguish them from new regressions. Do not silently suppress warnings.
7. **Standalone smoke test.** Inspect available Build Profiles and installed platform modules. Because the instructor email does not specify target OS, delivery format or deadline, do not label any platform build the final submission target. If macOS Build Support is already available, create a temporary local macOS QA build outside tracked source folders, launch it and verify it opens `Warehouse_Final`; do not install new modules or alter paid services. If unavailable, record it as blocked. Do not create a Windows build unless the platform module is already installed and a reason is established.
8. **Project handoff.** Prepare a source-project archive from the verified committed files only (e.g. `git archive` after the necessary tracked fix is committed), excluding `.git`, `Library`, `Temp`, `Obj`, `Logs`, caches and local-only Build Profiles unless intentionally reviewed. Keep the archive outside the Git repository. Include a concise README with Unity version, scene name, controls (`V`, `WASD`/mouse, `Escape`, `M`), how to run the generator, and known limitations. Do not redistribute build binaries or third-party assets unless their licences permit it.
9. **Academic handoff.** Keep these separate from Unity scene completion: the teacher explicitly linked the Roll-a-Ball tutorial but no user confirmation of completion exists; the email also asked the student to reply whether working individually or in a group of up to three. Do not claim either is complete without confirmation. VR session and consultation were optional. No submission target/deadline is specified in the email screenshots.
10. **Final report.** Provide a PDF requirement coverage table, actual tests performed, Console state, build result/target, GitHub commit and remote parity, local uncommitted changes preserved, source archive path, and academic items still awaiting user action. Be explicit about tests not performed.

Do not add features during Phase 8. Do not reopen the excluded “lizards” term. Keep the EUR 0 budget.
