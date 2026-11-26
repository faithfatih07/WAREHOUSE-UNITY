# WAREHOUSE-UNITY — Authoritative Project Brief

Version: 1.10  
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
- Models used to assemble the environment: rack, crates, container, cabinets, "lizards" (the PDF uses this exact word; its intended meaning is unclear and must not be guessed), assembly tables, conveyor, and pallet truck.
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

Phase 2 asset import and validation is complete for all categories with a known meaning under the EUR 0 budget. The project contains 14 selected CC0 Warehouse Essentials interactive FBX props, 17 separate Legacy animation samples, and eight CC0 GLB gap models. Added assets and clips were verified in the live Unity 6000.6.10f1 URP 17.6.0 Editor; see `ASSET_RESEARCH.md` section 23 and the imported asset reports. The installed official importer dependencies remain glTFast 6.21.0, KTX 3.8.0 and Meshopt Decompressor 0.3.0-exp.1. No downloaded code was executed and no antivirus scan was performed. The exact instructor word “lizards” remains unresolved. On 2026-11-26 the user explicitly approved proceeding with Phase 3 while carrying this one item forward as an unresolved requirement. Do not guess its meaning or silently substitute ladders/another model. Build all known warehouse categories now; keep a documented gap for “lizards” and ask the lecturer for clarification before final submission. The user has also approved original procedural modelling at EUR 0 for the remaining general storage cabinet and dedicated assembly table.

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
- Phase 2 is complete for identified model categories, but final sign-off is pending because the source PDF's exact term “lizards” is ambiguous. Do not guess. Also document a later original-modelling choice for a general storage cabinet and dedicated assembly table before assembly. Audio, final high-bay lighting, generator implementation and camera modes remain in their scheduled later phases.
- Concrete decision superseded on 2026-11-26: the user explicitly approved starting Phase 3 without waiting for “lizards” clarification. Carry the term as unresolved; do not interpret it. Proceed with known requirements, and add an original procedural general cabinet and dedicated assembly/production table using free in-project geometry. Do not mark the ambiguous requirement complete until the lecturer clarifies it.


## 14. Phase 3 authorization and implementation constraints (2026-11-26)

The user explicitly authorized starting Phase 3 even though the instructor's exact term "lizards" remains unresolved. This authorization means: proceed with all known requirements, keep the unknown item visible as a pending requirement, do not guess its meaning, and do not let it block construction of the rest of the warehouse. It does not mean "lizards" has been satisfied.

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

Phase 3 does not include final lighting/material polish, a switchable first-person camera, a configurable Warehouse Generator, or sound/animation integration. Imported models still have no colliders or LODGroups; collision/gameplay work remains for later phases. The instructor's exact word “lizards” remains pending clarification and is not represented by an invented object. The next implementation phase is Phase 4, followed by camera controls (Phase 5), the Warehouse Generator (Phase 6), and animation/audio integration (Phase 7). Phase 3 visual assembly was Editor-verified; final delivery commit/push state is reported with the task results.

## 16. Phase 4 materials, lighting and presentation (2026-11-26)

Phase 4 applies to `Assets/Scenes/Warehouse_Final.unity` only. The visual pass is implemented by `Assets/Editor/WarehousePhase4VisualBuilder.cs` (**Warehouse → Phase 4 → Regenerate Visual Transformation**), which preserves `WAREHOUSE_FINAL_ROOT` and replaces only its own `WAREHOUSE_PHASE4_DETAIL_ROOT`. Two consecutive Editor runs each produced 331 transforms below that detail root. The scene's 60×40 m interior, 24 m apron, zone positions, imported models, Package versions, URP pipeline, `Warehouse_Blockout.unity` and `SampleScene` are preserved.

The builder creates project-owned URP Lit materials and deterministic local texture maps for concrete, corrugated metal and sealed timber, plus metallic/smoothness and normal maps. It assigns these to the warehouse slab, apron, metal cladding, structure, roof panels and worktops. It adds fine expansion joints, aisle direction arrows, pedestrian crossing paint, loading-bay threshold marks, rack location cards, foot plates/anchor heads, column base plates/anchors, LED high-bay housings and spot lights, dock wall packs, and small packing-station bins/scales. Existing detailed imported rack, conveyor, truck, dock, forklift and furnishing assets remain in use; no asset was purchased or downloaded.

The full roof structure, roof panels and skylight material remain in the scene. `ROOF_PANELS_AND_SKYLIGHTS` stays disabled for the cutaway overview. It was temporarily enabled for the retained full-roof verification capture and restored to disabled before saving. The overview camera framing and scene ambient/directional lighting were tuned; no camera-mode controller was added. High-bay/dock lights are non-shadow-casting to limit render cost; the existing directional light retains soft shadows. The project settings and packages were not intentionally changed; `ProjectSettings/URPProjectSettings.asset` was restored byte-for-byte after Unity added an unrelated path field.

Actual Editor captures are `Assets/Screenshots/WarehouseFinal_Phase4_Overview.png`, `WarehouseFinal_Phase4_Storage_Closeup.png`, `WarehouseFinal_Phase4_Operations_Closeup.png` and `WarehouseFinal_Phase4_Roof_Complete.png`. The first three show the saved cutaway state; the final image documents the retained roof option. The Phase 3 overview/operations captures remain the before images. The final live scene query found 1,279 renderers, zero missing material/shader slots, 543 assigned Phase 4 material slots with 302 texture-backed assignments, and one 331-transform detail root. The final Console query returned zero errors and four existing obsolete `MaterialLocation.External` warnings from `Pallet.fbx`, `Pallet_Jack.fbx`, `Workbench_Vise.fbx` and `Crate_Large.fbx`; their importer settings were not changed. “Lizards” remains an unresolved instructor term. Phase 5 camera modes, Phase 6 generator and Phase 7 animation/audio remain future work.


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
