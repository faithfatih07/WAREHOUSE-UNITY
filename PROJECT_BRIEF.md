# WAREHOUSE-UNITY — Authoritative Project Brief

Version: 1.8  
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

## 11. Current next task

Proceed with **Phase 2 — Free asset research and import (EUR 0 budget)**.

Read ASSET_RESEARCH.md before selecting assets. The 40-prop CC0 Warehouse Essentials archive has now been downloaded at zero cost and statically inspected. Read section 11 of ASSET_RESEARCH.md for the reported inventory, category gaps and security limitations. No antivirus scan was run, no code was executed, and no assets were imported. The first isolated preview copy imported six raw FBX files but Unity failed to start it with 'Licensing initialization failed after 74.83s'. See section 13 of ASSET_RESEARCH.md. First inspect the exact log and try normal GUI launch via Unity Hub without changing licence settings. If that fails, use the already-running licensed Editor for a reversible local preview in one temporary folder/scene, with no commit or push; leave Warehouse_Blockout, SampleScene, Packages and ProjectSettings untouched and delete only the exact temporary preview files afterwards. Do not import the nested Unity package or open the Blender project. Verify materials, scale, pivots, colliders and actual animation playback. No payment, checkout or paid trials. Do not begin Phase 3 until preview results are verified.
