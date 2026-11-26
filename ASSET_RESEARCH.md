# WAREHOUSE-UNITY — Phase 2 Free-Only Asset Research

Research date: 2026-11-25  
Budget policy: **EUR 0 — no purchases, paid plugins, subscriptions, credits or paid AI asset services.**  
Current Unity project: Unity 6.6.10f1 (6000.6.10f1), URP  
Current scene: Assets/Scenes/Warehouse_Blockout.unity  
Status: Phase 2 imports and live Editor verification completed for the identified asset categories. The user explicitly excluded the PDF's ambiguous “lizards” item from scope on 2026-11-26; it is not implemented and is not a blocker. The latest results and authoritative scope decisions are in sections 23, 28–30.

## 1. Non-negotiable budget and licence rules

- Total project asset budget is EUR 0.
- Do not purchase any asset, plugin, model, sound, subscription, service, credit or upgrade.
- Do not begin a checkout flow, subscription trial or paid licence flow.
- Prefer CC0 assets; CC BY 4.0 assets are acceptable if we add correct attribution to project credits/documentation.
- Unity Asset Store free assets may be used under the applicable Standard Unity Asset Store EULA; verify the listing is actually free and compatible at import time.
- Do not use "free download" sites that redistribute paid marketplace assets without clear authorization.
- Do not treat a free preview/sample as permission to use the complete paid pack.
- Do not commit unlicensed or restricted assets to GitHub.
- Before import, record the author, source URL, licence and required attribution. Keep an asset credits register.
- Free assets may be mixed only when visually harmonized (scale, palette, roughness, light and presentation). Prefer a consistent stylized-realistic industrial look.
- The visual target remains the instructor's reference-level scene completeness and presentation. Photorealism is not required. Do not lower the detail target; build missing items with procedural geometry or original Blender/C# models where necessary.

## 2. Strongest current free candidate — coordinated warehouse prop set

**Warehouse Essentials — 40 Stylized 3D Props**  
Creator: Akash Jikadra  
Source: https://akashjikadra.itch.io/warehouse-essentials-40-stylized-3d-props

Search result checked 2026-11-25:
- Described as 40 coordinated stylized props for storage, packing, maintenance and loading bays.
- Free / name-your-own-price; download at zero only. Do not enter a paid amount.
- CC0 1.0 Universal according to the creator page summary: personal/commercial use, modification and redistribution permitted; credit optional.
- Formats include interactive FBX/GLB models, joined static FBX models, simplified LOD meshes and simple collision boxes.
- Claims 40 interactive Unity prefabs, 40 static LOD prefabs and 17 optional animation sample prefabs.
- Coordinated navy steel, rusty orange, sage, cream, blue and warm timber palette.

Assessment:
- Promising as the first free sample to inspect because it is coordinated and designed for warehouse zones.
- The listing is newly published and has not been independently tested in our Unity project.
- Do not assume it contains every instructor-requested category until its actual downloaded contents are inspected.
- Download at zero only; if the page requires payment or an account fee, skip it.

## 3. Free warehouse-specific model set — CC BY 4.0

**Free Warehouse 3D Models — vinish.dev**  
Source: https://vinish.dev/free-3d-models/warehouse

Search result checked 2026-11-25:
- 12 warehouse models, reportedly downloadable without login.
- Categories include pallet racking bay, counterbalance forklift, manual pallet jack, shrink-wrapped pallet, wooden pallet stack, roller conveyor section, loading dock door, mobile platform ladder, packing bench, sack truck, plastic tote stack and steel safety barrier.
- Formats: GLB, glTF, OBJ and STL.
- Reported licence: CC BY 4.0; free commercial use with attribution.
- The source provides model-specific attribution lines and a CREDITS.txt in each ZIP.
- Reported model sizes 40 KB–1.9 MB; triangle counts 1,112–25,748.

Assessment:
- Excellent coverage of several instructor-required categories (rack, crates/stock proxies, conveyor, pallet truck/pallet jack, assembly/packing table) plus forklift and dock props.
- CC BY attribution is mandatory. Add author/model/source/licence lines to the project's CREDITS.md or in-app credits as appropriate.
- Verify each file's included licence and CREDITS.txt before adding it to the project.
- These may be visually different from other packs; harmonize their materials and palette if mixing.

## 4. Free forklift with separated moving components — CC0

**Forklift — tevy.dev**  
Source: https://tevy.dev/models/forklift

Search result checked 2026-11-25:
- CC0 1.0 according to the source.
- GLB with LOD0/LOD1/LOD2 options.
- Moving parts listed separately: wheels, mast, inner mast, carriage, left/right forks, tilt and lift ram parts.
- Reported size about 2.8 MB; LOD0 35,888 triangles.

Assessment:
- Useful if the coordinated warehouse sets do not include a suitable forklift, or if we want a more convincing fork/mast animation.
- Verify download, scale, pivots and LODs in Unity before use.

## 5. Free Unity Asset Store supplementary pack

**Warehouse Pack (Free) — Low-Poly Warehouse Essentials — FromQCWithGameDev**  
Unity Asset Store: https://assetstore.unity.com/packages/3d/environments/warehouse-pack-free-low-poly-warehouse-essentials-407032

Search result checked 2026-11-25:
- Listed FREE, under Standard Unity Asset Store EULA.
- URP compatible; listing's original Unity version 6000.3.13f1.
- 15 props / approx. 612 KB.
- Includes rack start/add-on bays, overhead door with separate panels, dock bumper, pallet, hand pallet jack, packing table, boxes, floor line kit and high-bay light.
- Includes a sample scene with a pick-pack-ship loop and lighting.
- Listing says not enough ratings and includes an AI-created disclosure.

Assessment:
- Strong supplementary set and useful for inspecting a ready-made sample scene.
- Limited to 15 props and a low-poly style; insufficient alone for the complete final environment.
- Use only if it is still free at the actual download point and its contents work in our Unity project.

## 6. Free CC0 scene / structural reference

**Warehouse with pallet racking — Innerscene 3D Parts Library**  
Source: https://www.innerscene.com/tools/library/3d-parts/warehouse-with-pallet-racking-ef1ee7fb

Search result checked 2026-11-25:
- IFC model, reported 347 KB.
- CC0 public-domain dedication according to the listing.
- Describes steel portal-frame warehouse, four loading doors, dock canopy, eight rows of pallet racking and a two-level office block.

Assessment:
- Useful as a layout/structural reference or for testing IFC conversion.
- Not a Unity-ready FBX/GLB prefab by default; conversion may cost time. Do not prioritize it over ready-to-import GLB/FBX assets.

## 7. Other free CC0 asset candidates

- Grab3D Warehouse Interior: https://grab3d.com/models/buildings/warehouse-interior/ — search result describes a CC0 isometric interior with rack, pallet jack, roller door, wire-mesh box, pallets and floor markings. GLB/FBX/BLEND/OBJ formats reportedly available. Third-party aggregator; inspect the actual source and licence metadata before use.
- Grab3D Warehouse: https://grab3d.com/models/buildings/warehouse/ — search result describes CC0 warehouse shell with loading dock, roller doors, roof light strips and marked yard. Treat as unverified until source file and CC0 declaration are checked.
- Grab3D Pallet Rack: https://grab3d.com/models/tools/pallet-rack/ — search result describes CC0 rack model with loaded pallets and cartons. Verify licence in the downloaded asset and model scale.
- Grab3D Storage Box: https://grab3d.com/models/props/storage-box/ — search result describes CC0 storage box / steel mesh stillage with a movable part. Verify licence.
- Grab3D Pallet Jack: https://grab3d.com/models/tools/pallet-jack/ — search result describes CC0 manual pallet jack with separate movable parts. Verify licence.
- 3DAssets.dev Factory Conveyor Network: https://3dassets.dev/assets/factory-conveyor-network-factory-conveyor-network-logi-48a6b6d0 — search result describes a CC0 rack element in a larger 105-model kit and starter scene. Evaluate actual quality and provenance before use.

## 8. Assets explicitly excluded

- Any paid kit previously mentioned in this repository, including Low Poly Warehouse Modular Kit paid full pack, Warehouse Distribution Centre paid pack and Warehouse Pack Full paid pack. These are not permitted under the zero-budget decision.
- Any asset whose download requires a payment, subscription, credit purchase or trial that may convert to paid.
- Any asset with unclear provenance, a licence that prohibits the intended use, or a "personal use only" limitation where project submission/sharing is not covered.
- Any unauthorized mirror of a paid pack.

## 9. Recommended Phase 2 workflow

1. Start with the coordinated 40-prop CC0 Warehouse Essentials pack, downloading at zero only if possible.
2. Inspect actual archive contents before import: file names, formats, prefabs, textures, LODs, colliders, sample scenes and licence file.
3. If that pack is incomplete, fill gaps using vinish.dev's 12 CC BY 4.0 warehouse models and retain attribution.
4. Use the free Unity Asset Store 15-prop pack only as supplementary content if helpful and compatible.
5. Add tevy.dev CC0 forklift only if the selected set lacks a suitable forklift or if separated moving parts are needed.
6. Import assets into a dedicated folder such as Assets/Imported/FreeWarehouseAssets; do not overwrite the Phase 1 blockout.
7. Build a small test scene / asset preview first; verify scale, materials, pivots, colliders, performance and URP rendering.
8. Harmonize materials and lighting so mixed free assets read as one coherent industrial environment.
9. Create CREDITS.md listing all CC BY assets and their attribution; keep CC0 sources recorded for traceability too.
10. Only after successful visual and technical checks, use selected assets to replace major placeholders in the warehouse scene.

## 10. Historical next task — initial free asset verification

Phase 2 — Free asset acquisition and validation only:
- Download zero-cost samples/candidates only.
- Check exact licences and actual archive contents.
- Import a small representative sample into a dedicated preview folder/scene.
- Compare the preview with the instructor's reference and the Phase 1 layout.
- Do not pay, do not start checkout, do not use paid trials, and do not import unverified asset packs.
- Report verified findings and remaining missing categories before assembling the final warehouse.

## 11. Actual static inspection report — Warehouse Essentials archive (2026-11-25)

Source of this section: Codex's report after static inspection of the downloaded archive at:
`/private/tmp/WarehouseAssetReview/WarehouseEssentials_v1.0_CC0.zip`

This is a record of the reported inspection, not an independent antivirus certification.

### Download and licence evidence
- Download was available using the creator's zero-cost option; no payment, donation or email entry was made.
- Actual archive size reported: 25,442,024 bytes (about 24.3 MiB).
- The archive includes a `LICENSE.txt` applying CC0 1.0 to the creator's original assets, to the extent of rights held by the creator. Attribution is optional. The licence does not waive third-party trademark or patent rights beyond the creator's control.
- The included README and credits documentation repeat the licence information.
- ZIP CRC checks passed; the 292 entries covered by the included SHA256SUMS.txt matched.
- Static inspection found no executable files, symlinks, installer paths or source-script paths in the outer archive.
- Static inspection of the nested Unity package reported zero C# scripts, DLLs, MonoBehaviour records or m_Script references.
- No downloaded code was executed, no Blender file was opened, no Unity package was imported, and no antivirus scanner was run. **This is not a malware-free guarantee.**

### Archive structure reported
- 293 outer archive files: 227 FBX, 40 GLB, 1 Blender project, 1 Unity package, 9 PNG, 6 JSON and 9 text/documentation files.
- The collection contains 40 prop types, interactive FBX/GLB models, static and lower-detail LOD FBX models, 90 individual-part FBXs, 17 animation FBXs, nine PNGs, six JSON files, documentation and a nested Unity package.
- The archive contains material atlases/maps and per-prop metadata including filenames, formats, sizes, LOD and collider evidence.
- All of these counts are from the static inspection report; they have not yet been confirmed by import into Unity.

### Instructor requirement coverage based on the reported inventory

| Instructor / project category | Reported matching props | Assessment |
|---|---|---|
| Rack | `Storage_Shelf` (reported approx. 1.45 × 1.90 × 0.62 m) | Partial: a shelf unit, not the tall pallet-rack system needed for five planned rows |
| Crates / stock | `Crate_Large`, `Crate_Long`, `Crate_Small`, `Box_Medium`, `Box_Small`, `Box_Tall`, `Open_Carton`, `Sack`, `Pallet`, `Lidded_Transit_Tote`, `Storage_Bin`, `Wire_Basket` | Good small-prop coverage; no shrink-wrapped pallet reported |
| Container | `Lidded_Transit_Tote`, `Storage_Bin`, `Plastic_Barrel`, `Steel_Drum`, `Jerry_Can`, `Gas_Cylinder` | Partial: storage containers and drums, no freight/shipping container |
| Cabinets | `Double_Locker`, `Electrical_Cabinet`, `Toolbox` | Partial: these do not replace a general warehouse storage cabinet |
| "Lizards" | Excluded by user decision / not implemented | PDF wording preserved; no interpretation made |
| Assembly tables | `Wooden_Spool_Table`, `Workbench_Vise` | Partial: table/workbench props, no dedicated assembly-line table |
| Conveyor | `Roller_Conveyor` | One short roller-conveyor section; not a complete multi-section powered conveyor system |
| Pallet truck | `Pallet_Jack` | Present |
| Forklift | None reported | Missing |
| Delivery truck / trailer | None reported | Missing |
| Loading dock door / dock structure | None reported | Missing |

The pack does not provide the project's two camera modes or the future C# Warehouse Generator. Those remain our own implementation tasks.

### Animation sample report

The 17 animation FBX files and corresponding `AnimatedSamples` prefabs are reported as:
- `Caution_Sign` — folding frames
- `Double_Locker` — two doors
- `Electrical_Cabinet` — door
- `Floor_Fan` — blades/rotor
- `Furniture_Dolly` — four wheels
- `Gas_Cylinder` — valve
- `Hand_Trolley` — two wheels
- `Industrial_Trash_Can` — lid
- `Lidded_Transit_Tote` — lid
- `Open_Carton` — four flaps
- `Pallet_Jack` — handle and four wheels
- `Plastic_Barrel` — lid
- `Roller_Conveyor` — 14 rollers
- `Step_Ladder` — two frames and four spreaders
- `Toolbox` — lid
- `Utility_Cart` — four wheels
- `Workbench_Vise` — drawer and vise jaw

The report derived these moving parts from FBX animation/keyframe data and the manifest. The package describes 17 clips sampled at 0%, 25%, 50% and 100%. It also notes sample prefab playback is disabled by default and uses a legacy Animation component/list. **These animations have not yet been played in Unity; this is static content inspection, not playback verification.** They are object-motion examples, not complete vehicle physics or gameplay systems.

### Unity / URP compatibility

- The creator reports testing the nested Unity package in Unity 6000.6.5f1 with the Built-in Render Pipeline and Standard shader.
- URP compatibility is explicitly unverified by the creator.
- Our project is Unity 6000.6.10f1 with URP. Therefore the pack remains untested in our actual render pipeline; material/shader conversion may be needed.
- Standalone raw files are reported under `Models/Interactive_FBX`, `Models/Static_FBX_UCX`, `Models/Static_LOD1_FBX`, `Models/Unreal_Parts`, `Models/Interactive_GLB` and `Animations`. They can be inspected without importing the nested Unity package.

### Recommended minimal preview subset

For a **separate temporary Unity URP preview project**, test only these six interactive FBX assets first:
- `Storage_Shelf`
- `Crate_Large`
- `Pallet`
- `Pallet_Jack`
- `Roller_Conveyor`
- `Workbench_Vise`

Copy only their referenced materials/textures:
- `Warehouse_Navy_Atlas`
- `Warehouse_Cream_Atlas`
- `Warehouse_BaseColor`
- the shared metallic/smoothness and roughness maps
- `MaterialMap.json`
- `LICENSE.txt` and relevant creator credit/documentation

Do not open the Blender project or import the nested Unity package. Do not copy any of these assets into the main project until the temporary URP preview succeeds.

### Current project / repository state at time of report
- Active Unity project reported as Unity 6000.6.10f1 with `Warehouse_Blockout.unity` active.
- Unity Console: zero errors; one warning, `WebSocket is not initialised`.
- Editor reported `external_changes_dirty=true` from an earlier timestamp; assets were not refreshed and editor state was not cleared. Recheck before preview.
- Repository was clean at `main...origin/main`; no assets were copied to the main project, and no import, scene change, commit or push was performed.
- Phase 3 has not started.

## 12. Historical next task — isolated URP preview (completed; see sections 14 and 23)

1. Recheck local repository status and the actual Unity Editor state.
2. Preserve the downloaded review archive and the completed Phase 1 scene.
3. Create a temporary preview project outside the main repository, based on the same Unity 6000.6.10f1 and URP package versions.
4. Extract only the six listed raw interactive FBX models and their referenced texture/material files to that temporary project.
5. Do not import the nested Unity package, open the Blender project, or execute downloaded scripts.
6. Open the preview project in Unity and check for URP shader/material issues, scale, orientation, pivots, LODs and colliders. Test only the sample animations whose FBX data is present, and report whether playback actually works.
7. Capture a preview image and report any manual material conversion required.
8. Do not change the main warehouse project or start Phase 3 until the preview is reviewed.

## 13. Isolated preview attempt — blocked by Unity licensing initialization (2026-11-25)

Codex reported the following:
- A copy of the Unity project was made at `/private/tmp/WarehouseAssetPreviewProject`.
- Six raw FBX assets and their referenced texture/material files, `MaterialMap.json`, licence and credits files were staged/imported into that temporary project.
- The temporary project uses Unity 6000.6.10f1; its URP and Packages/manifest.json were reported as matching the source project.
- The temporary Editor later failed during startup with `Licensing initialization failed after 74.83s`, recorded in `PreviewBatch.log`.
- Unity MCP remained connected to the main project's Editor, so it could not inspect the temporary project.
- `AssetPreview.unity`, the import-results report and the requested screenshot were not produced.
- `WarehouseAssetPreviewBuilder.cs` was left inside the temporary copy but was not executed.
- No material rendering, texture assignment, model scale/orientation, pivots, colliders, LODs or animation playback have been verified in Unity.
- Static inspection of the FBXs found no embedded animation stacks or key times; the 17 animation samples are separate assets and remain untested.
- Codex reported the main repository clean on `main` at `1a3c31b`; no main project scenes, assets or settings were modified; no commit or push occurred for the preview attempt.

This is a Unity Editor licensing/startup blocker, **not evidence that the FBX assets are defective**. Do not deactivate, replace, or alter the user's Unity licence to work around this.

### Revised next action

1. Inspect the exact licensing error context in `PreviewBatch.log`; do not infer its cause from the summary alone.
2. Try opening the existing temporary project through Unity Hub / normal GUI mode using the already-installed Unity 6000.6.10f1 Editor. Do not request a new licence, deactivate the current licence, or change account/licence settings.
3. If GUI launch also fails, use the already-running, already-licensed main Unity Editor for a **reversible local preview only**:
   - verify the main repository is clean and on main first;
   - create one temporary folder and one temporary preview scene only (e.g. `Assets/__AssetPreviewTemp/`);
   - copy only the six already-reviewed raw FBX files and exact referenced textures/material maps into that folder;
   - do not import the nested Unity package, open the Blender project, or execute downloaded code;
   - leave `Warehouse_Blockout.unity`, `SampleScene`, all project settings and Packages unchanged;
   - do not commit or push preview assets;
   - capture and inspect the temporary scene in the existing Unity Editor;
   - after verification, remove only the exact temporary preview folder/scene and confirm the original repository returns to a clean state.
4. If both launch routes fail, stop and report the exact licence error and ask the user for the Unity Hub state screenshot. Do not start Phase 3.

No Unity preview is considered complete until assets have visibly rendered and their actual properties have been checked in Unity.

## 14. Successful isolated preview — six raw FBX models (2026-11-26)

The follow-up Codex report and screenshots show that the preview was ultimately completed by using the already-running, licensed main Unity Editor after Unity Hub had successfully opened the temporary project but the separate MCP/batch startup route failed to initialize licensing. No licence was changed or deactivated.

### What was actually verified
- Unity rendered six selected models in the connected Unity 6000.6.10f1 Editor using custom URP Lit materials.
- Models: `Storage_Shelf`, `Crate_Large`, `Pallet`, `Pallet_Jack`, `Roller_Conveyor`, `Workbench_Vise`.
- The 128×128 colour atlases were assigned to scene instances. The metallic map and inverted roughness were combined for smoothness. Several original FBX materials had URP Lit shaders but no base texture assigned; the preview supplied explicit texture assignments.
- The preview visually showed a coherent stylized low-poly prop set. This is suitable for asset inspection but is not itself a final warehouse scene or proof that the assets alone achieve the instructor reference's complete visual density.
- FBX importer root transform was approximately 270° about X with scale 100; preserving it produced upright models with metre-scale bounds. The six models were positioned at floor level.
- All selected textures and `MaterialMap.json` loaded; no selected texture was reported missing.

### Measured model bounds and limitations

| Model | Imported bounds (m) | Colliders | LODGroups | Embedded clips |
|---|---:|---:|---:|---:|
| Storage_Shelf | 1.45 × 1.90 × 0.62 | 0 | 0 | 0 |
| Crate_Large | 1.01 × 0.90 × 0.93 | 0 | 0 | 0 |
| Pallet | 1.20 × 0.20 × 1.00 | 0 | 0 | 0 |
| Pallet_Jack | 0.65 × 1.23 × 1.47 | 0 | 0 | 0 |
| Roller_Conveyor | 1.18 × 0.88 × 1.80 | 0 | 0 | 0 |
| Workbench_Vise | 1.50 × 1.11 × 0.88 | 0 | 0 | 0 |

- These six interactive FBX assets have no embedded animation clips. Conveyor or pallet-jack motion was not possible or claimed from this subset. The separate 17 animation-sample FBXs remain untested.
- These raw interactive models contain no colliders or LODGroups. Add suitable simple colliders/project LODs later only where justified by gameplay, visibility or performance.
- The preview confirmed a stylized low-poly aesthetic. The final target remains a coherent scene with reference-level composition and detail density, not photorealism.

### Licensing startup and cleanup
- The initial batch startup path failed because it could not find `LicenseClient-trade-1.19.0`; a later attempt timed out with `Licensing initialization failed after 74.83s`.
- Unity Hub subsequently opened the temporary project in Unity 6000.6.10f1 and logged successful connection to the existing `LicenseClient-trade`. No licence was changed or deactivated.
- That Hub-launched Editor was not connected to the existing Unity MCP session, so the preview was performed in the already-connected main Editor.
- During preview, Unity added one field to `ProjectSettings/URPProjectSettings.asset`; Codex inspected the exact diff and restored the file byte-for-byte to HEAD.
- The temporary preview folder and scene were deleted after screenshot capture. `Warehouse_Blockout.unity`, `SampleScene`, `Packages`, and other project settings were reported unchanged.
- Unity Console: zero errors; one warning, `WebSocket is not initialised` from MCP.
- Git reported clean `main...origin/main`; no preview assets were committed. Screenshot retained outside the repository at `/private/tmp/WarehouseAssetPreview_UnityMCP.png`.
- Phase 3 has not started.

## 15. Historical next task — import the six verified free props into the main project (completed in section 16)

The isolated visual preview is now successful. The next safe step is to copy only the six approved raw FBX files and their exact referenced textures/material maps from the existing review archive into a dedicated folder in the main project, without importing the nested Unity package.

Suggested target:
- `Assets/Imported/FreeWarehouseEssentials/Models/`
- `Assets/Imported/FreeWarehouseEssentials/Textures/`
- `Assets/Imported/FreeWarehouseEssentials/Materials/`
- `Assets/Imported/FreeWarehouseEssentials/Documentation/`

Requirements:
1. Read current project docs and verify clean Git status and active project first.
2. Copy only the six models and dependencies listed in section 12; do not copy the nested Unity package or Blender project.
3. Preserve the FBX root rotation/scale that produced correct metre-scale upright models in the preview.
4. Create project-owned URP Lit materials with the verified texture assignments. Do not depend on editor-only temporary materials.
5. Add a `CREDITS.md` noting the creator, source URL and CC0 1.0 licence, and retain the included `LICENSE.txt` and relevant asset documentation.
6. Keep assets grouped in the dedicated folder. Do not modify `Warehouse_Blockout.unity`, `SampleScene`, `Packages`, or project settings unless a specific, explained import requirement arises.
7. Do not add colliders/LODs or create new gameplay features yet. Record that the imported raw assets have none; these can be added later only where required.
8. Refresh/verify the actual six imported assets in Unity URP and confirm no missing textures or import errors.
9. Commit and push only after verifying the cleanly scoped changes.
10. Do not begin Phase 3 assembly yet. Next, inspect the remaining free model categories and the separate animation FBXs to close the missing forklift, high-bay pallet rack, truck, dock, freight container and other instructor-category gaps.

## 16. Main-project asset import — six approved props (2026-11-26)

Codex's report and screenshot confirm that Phase 2's first six approved raw FBX props were copied into the main Unity project, rendered in the actual Unity Editor with URP Lit materials, and pushed to GitHub.

### Imported content
Dedicated folder: `Assets/Imported/FreeWarehouseEssentials/`

Models:
- `Storage_Shelf.fbx`
- `Crate_Large.fbx`
- `Pallet.fbx`
- `Pallet_Jack.fbx`
- `Roller_Conveyor.fbx`
- `Workbench_Vise.fbx`

Also imported:
- Warehouse navy, cream and base-colour texture maps.
- Metallic and roughness maps plus the combined metallic/smoothness map.
- Three Unity URP Lit materials.
- FBX-generated `.fbm` texture dependency folders next to models.
- Original `LICENSE.txt`, `CREDITS.md`, creator credits, `MaterialMap.json`, manifest, README and supplied Unity import/validation reports.
- A visual verification image named `ImportPreview.png`.

### Verification reported
- All six models rendered in the connected Unity Editor preview with assigned URP Lit materials and expected textures.
- Imported orientation, scale and bounds matched the previously reviewed preview.
- No selected texture was missing.
- No collider, LODGroup or embedded animation clip exists in these six raw FBX models; do not assume otherwise.
- The temporary preview scene was deleted after capture.
- `Warehouse_Blockout` remained active and clean; `SampleScene` and `Warehouse_Blockout` had no changes in the asset-import commit diff.
- URP settings and package files were reported unchanged.
- Unity Console: zero errors; one MCP WebSocket warning ("WebSocket is not initialised").
- Git whitespace check reported trailing whitespace in Unity-generated metadata and CRLF documentation; these were left unchanged to avoid unnecessary modifications.
- Commits pushed: `a03cd2a` (asset import) and `00be74e` (Unity folder metadata). Working tree reported clean; `main` and `origin/main` both point to `00be74e`.
- This verifies the first six props are imported; it does NOT complete all instructor categories or Phase 2.

### Remaining asset gaps
Based on the previously inspected 40-prop inventory, further free assets are still needed or must be modelled:
- Proper tall pallet racking for the planned rack rows (current Storage_Shelf is only a shelf unit).
- Forklift.
- Freight/shipping container.
- Delivery truck/trailer and loading dock door/structure.
- More complete warehouse storage cabinets.
- Dedicated assembly table (current workbench props are partial coverage).
- Expanded powered conveyor system (current Roller_Conveyor is one short section).
- Historical note: the PDF's exact term "lizards" was unresolved at the time; the user later excluded it from project scope.
- No sound asset pack has yet been tested or imported.
- Separate 17 animation-sample FBXs have not yet been tested for playback.

## 17. Historical next task — complete free asset gap research and animation review (superseded by section 23)

Phase 2 remains open. Before full scene assembly (Phase 3):
1. Read current project docs and verify Git status/Unity project state.
2. Research zero-cost assets only for the gaps above. Prefer CC0; CC BY 4.0 is acceptable with proper attribution. Do not purchase, enter checkout or use paid trials.
3. Inspect actual downloaded file licences and archive contents statically before import.
4. Prioritize proper pallet racking, forklift, freight container, truck/trailer, dock door, general cabinets and an assembly table.
5. Review the separate 17 animation-sample FBX assets identified in section 11. Determine which actual animation clips exist from metadata/keyframes; do not claim playback until tested in Unity. Make a small reversible preview for suitable samples using the already licensed Unity Editor, preserving existing scenes/settings.
6. Historical instruction at the time: resolve the ambiguous "lizards" term only from instructor clarification or source evidence. This is superseded by the user's later explicit decision to exclude it from scope.
7. Add source and licence records to CREDITS.md.
8. Only when the essential visual categories are covered (by licensed free assets or clearly documented original procedural models), begin Phase 3 and replace blockout placeholders with final scene assets.

## 18. Follow-up zero-cost gap research — candidates, not yet downloaded (2026-11-26)

The following candidates were found through current source-page research. Their pages identify them as CC0 1.0; however, no files have yet been downloaded from these individual pages, no archives inspected, and no models imported or tested. Treat them as **research candidates only** until the exact download and included provenance/licence are verified.

### Priority A — large missing warehouse structures and equipment

1. **Steel Pallet Rack — tevy**
   - Page: https://tevy.dev/models/steel-pallet-rack
   - CC0 1.0 according to the model page.
   - Three-bay steel pallet rack, three beam levels; source describes about 8.3 m long, 1.2 m deep and 5 m tall. The listed bounds field uses a different axis ordering; confirm orientation and dimensions after download.
   - LOD0/LOD1/LOD2 listed; 32,100 / 13,290 / 2,960 triangles.
   - GLB, 1.8 MB for LOD0.
   - Candidate to replace the small Storage_Shelf with proper high-bay pallet rack rows.

2. **Pallet Racking Bay with Pallets — Innerscene**
   - Page: https://www.innerscene.com/tools/library/3d-parts/pallet-racking-bay-with-pallets-821e591f
   - CC0 public domain according to the source.
   - GLB, about 574 KB; listed overall dimensions 2.7 × 1.1 × 3.0 m.
   - Alternative modular single-bay rack if the tevy three-bay model does not fit the planned rack footprint or has awkward orientation.

3. **Forklift — tevy**
   - Page: https://tevy.dev/models/forklift
   - CC0 1.0; LOD0/1/2 listed; 35,888 triangles at LOD0; GLB 2.8 MB.
   - Separate moving parts listed for wheels, mast, carriage, forks and hydraulic rams.
   - Candidate for both warehouse dressing and later simple lift/fork animation. The page's dimension field has ambiguous axis order; measure after import.

4. **Loading Dock — tevy**
   - Page: https://tevy.dev/models/loading-dock
   - CC0 1.0; LOD0/1/2 listed; GLB 2.5 MB.
   - Includes 6 m loading bay wall section, 1.2 m high concrete dock, hydraulic dock leveller, bumpers, dock shelter, light and traffic signal; separate moving parts are listed.
   - Strong candidate for the three loading bays in the 60 × 40 m layout. Check wall integration and exact footprint before duplicating.

5. **Semi Truck and Trailer — tevy**
   - Page: https://tevy.dev/models/semi-truck
   - CC0 1.0; three LODs listed; GLB LOD0 2.6 MB.
   - Generic tractor and 13.6 m box semi-trailer, about 20 m overall; separate trailer, rear doors, landing legs and wheels are listed.
   - Candidate for the exterior truck apron and dock presentation. Confirm it physically fits the apron and is oriented correctly.

6. **20 ft Shipping Container — Grab3D**
   - Page: https://grab3d.com/models/city/shipping-container-proz/
   - Page states CC0 1.0 and offers GLB/FBX/BLEND/OBJ; GLB listed at about 1.3 MB with 2K textures.
   - Weathered blue 20-ft container with corrugated walls and cargo doors.
   - Alternative source: Innerscene's CC0 20 ft container is currently offered as STEP, about 2 MB, with GLB/OBJ export through the viewer: https://www.innerscene.com/tools/library/3d-parts/20-ft-standard-shipping-container-cb602209
   - Prefer the direct GLB candidate only after inspecting its included licence and provenance; otherwise export the Innerscene source to GLB without paid features.

### Priority B — extend conveyor and work areas

7. **Roller Conveyor Straight — tevy**
   - Page: https://tevy.dev/models/conveyor-roller-straight
   - CC0 1.0; four-metre powered roller conveyor straight; 3 LODs; LOD0 16,212 triangles and GLB 2.2 MB; 25 separately listed roller parts.

8. **Roller Conveyor Curve — tevy**
   - Page: https://tevy.dev/models/conveyor-roller-curve
   - CC0 1.0; 90-degree conveyor curve; 3 LODs; GLB 2.2 MB; separate roller parts.

9. **Belt Conveyor Transfer — tevy**
   - Page: https://tevy.dev/models/conveyor-belt-transfer
   - CC0 1.0; powered 1.5 m belt transfer between roller sections; 3 LODs; GLB about 904 KB; head/tail drums separately listed.

10. **Conveyor End Stop — tevy**
    - Page: https://tevy.dev/models/conveyor-end-stop
    - CC0 1.0; one-metre roller conveyor end section with stopper; 3 LODs; GLB about 735 KB; separate rollers listed.

    Together these modular parts can form a longer, more convincing line than the existing 1.18 m Roller_Conveyor prop. Their listed moving parts are not proof of ready-to-play animation clips; playback must be tested or animated by our own script.

11. **Workbench — Grab3D**
    - Page: https://grab3d.com/models/tools/workbench/
    - CC0 1.0 according to the model page; GLB listed about 1 MB, FBX about 1.8 MB, 2K textures, 8,902 triangles.
    - Listed size 1.50 × 0.75 × 0.90 m; separate drawer object.
    - Candidate for an assembly/packing table; harmonize materials to match the existing Warehouse Essentials props.

12. **Lockable Steel Filing Cabinet — Innerscene**
    - Page: https://www.innerscene.com/tools/library/3d-parts/lockable-steel-filing-cabinet-with-glass-doors-787d3529
    - CC0 public domain according to source; GLB about 554 KB; listed 0.8 × 0.491 × 1.3 m.
    - Office/file cabinet with glass doors; not a heavy-duty warehouse cabinet. Use only in the office zone if useful; warehouse equipment cabinets may need procedural modelling.

### Source caveats
- The pages above state CC0, but the exact downloaded files and their embedded/source licence notices have not yet been inspected. Verify the downloaded file's included licence, creator/provenance and any third-party content before project import.
- CC0 does not eliminate all trademark, patent, personality or third-party rights. Avoid logos and brand marks in final presentation.
- Some sources provide GLB with materials and textures embedded; inspect actual import into Unity 6000.6.10f1 URP before selecting.
- Grab3D is an aggregator-style catalogue; check the underlying model origin, manifest and CC0 notice with the actual file. Prefer direct original creator sources when equivalent quality is available.
- Tevy pages list CC0 glTF/GLB models and LOD variants; still retain source/asset manifest and check actual file integrity after download.
- No candidate above is yet counted as imported or verified in Unity.

## 19. Proposed minimal next batch

For the next validation round, prioritize a small number that closes the largest visual gaps:
- Steel Pallet Rack (tevy) OR Pallet Racking Bay with Pallets (Innerscene) — test one first, not both unless the first fails.
- Forklift (tevy).
- Loading Dock (tevy).
- Semi Truck and Trailer (tevy).
- 20 ft Shipping Container (prefer a direct GLB with verified CC0 source).
- Roller Conveyor Straight + Roller Conveyor Curve + Belt Conveyor Transfer (tevy).

Treat the cabinet and workbench as lower priority because the first Warehouse Essentials pack already contains partial cabinet/workbench props.

Do not download everything at once. Verify individual licences/provenance and file formats first, then download this small batch at zero cost. Statically inspect files and import only a representative sample into the existing licensed Unity Editor using a reversible preview. Keep the main project and Git history safe; no paid content or trials.

Historical note, superseded by the user's later scope decision: the instructor's exact word "lizards" was unresolved. It is now excluded; do not ask about it or assign an asset.

## 20. Downloaded GLB gap-asset batch — static inspection only (2026-11-26)

Codex reports that eight GLB 2.0 models were downloaded directly from the listed source pages into `/private/tmp/WarehouseGapAssetReview/`. All eight files were SHA-256 verified. No payment or checkout was used, no code was executed, nothing was imported into Unity, and no main-project files changed.

Detailed file inventory, source records and hashes are retained locally in `Review_Report.md`, `SOURCES.md` and `SHA256SUMS.txt` within the review folder. Those files are not yet committed to GitHub because they are external review records and the models have not passed Unity import/visual review.

### Download inventory reported by Codex

| Asset | Downloaded file | Size | Source-reported dimensions* | Static findings |
|---|---|---:|---:|---|
| Steel pallet rack | `Steel_Pallet_Rack_L0.glb` | 1,874,364 B | 8.7 × 5 × 1.5 m | 3 LODs advertised; embedded PBR maps; no collider or animation data detected |
| Forklift | `Forklift_L0.glb` | 2,912,328 B | 1.41 × 2.4 × 4.12 m | 3 LODs advertised; wheel, mast, fork and ram nodes; no animation clips/channels |
| Loading dock | `Loading_Dock_L0.glb` | 2,601,352 B | 6.6 × 6.22 × 6 m | 3 LODs advertised; leveller and light-arm nodes; no animation clips/channels |
| Semi truck and trailer | `Semi_Truck_L0.glb` | 2,686,428 B | 3.27 × 4.21 × 20.03 m | 3 LODs advertised; trailer, door, leg and wheel nodes; no animation clips/channels |
| Conveyor straight | `Conveyor_Roller_Straight_L0.glb` | 2,281,796 B | 0.88 × 0.99 × 4 m | 3 LODs advertised; 25 roller nodes; no animation clips/channels |
| Conveyor curve | `Conveyor_Roller_Curve_L0.glb` | 2,334,236 B | 1.48 × 0.99 × 1.48 m | 3 LODs advertised; 12 roller nodes; no animation clips/channels |
| Belt conveyor transfer | `Conveyor_Belt_Transfer_L0.glb` | 925,636 B | 0.97 × 0.99 × 1.52 m | 3 LODs advertised; two drum nodes; no animation clips/channels |
| Shipping container | `Shipping_Container.glb` | 1,315,132 B | 6.128 × 2.591 × 2.440 m | One mesh, closed doors; embedded PBR maps; no LOD or animation data detected |

*The rack, forklift and truck source pages contain mismatches between descriptive prose and dimension fields; Codex recorded both where available. These are source-reported values, not measured Unity import bounds. Verify actual dimensions, axis orientation and pivot placement in the Unity preview before changing the layout.*

### Source and licence checks
- Tevy rack, forklift, dock, truck and conveyor pages state CC0 1.0; their downloaded GLBs embed `tevy.dev` and CC0 metadata.
- The Grab3D shipping-container download included `LICENSE.txt` stating CC0 1.0. Its manifest identifies Grab3D as source/creator and describes procedural creation.
- The review folder retains the model files, Grab3D licence/manifest, source notes, inventory report and SHA-256 checksum list.
- Treat these as licence/source records from the downloaded files and webpages; CC0 only applies to rights held by the named creator and does not clear third-party trademark/patent rights.

### Static security inspection and limitations
- Static inspection found no scripts, executable payloads, external resource URLs, collider declarations or animation clips/channels in the eight GLBs.
- Separate moving-part nodes are present on some models, but moving nodes alone are not working animations.
- No downloaded code was executed.
- **No antivirus scan was performed.** Hash verification and static inspection do not prove that a file is malware-free.

### Unity import compatibility blocker
- The current project's package manifest has no glTF/GLB importer dependency.
- The Tevy GLBs use meshopt-compressed geometry and BasisU/KTX2 textures. A compatible preview importer must support both `EXT_meshopt_compression` and `KHR_texture_basisu`.
- Official Unity glTFast is a free Unity Package Manager package identified as `com.unity.cloud.gltfast`; its docs describe GLB Editor import and support for URP. Unity's installation documentation names optional support packages `com.unity.meshopt.decompress` for meshoptimizer and `com.unity.cloud.ktx` for KTX/BasisU. glTFast is Apache-2.0 licensed.
- The official documentation confirms Editor import of GLB and URP, but the extension support requires the optional packages above. None of these packages has been installed in this project yet. Package version compatibility and resulting project dependency changes must be checked before adding them.
- This gives us a zero-cost importer path; do not use a paid importer or change render pipelines.

### Fit and layout warning
- The semi-truck source-reported overall length is about 20.03 m, while the current south truck apron in `WAREHOUSE_LAYOUT.md` is about 14–15 m deep.
- Do not force the truck into the existing apron or arbitrarily scale it down. First measure the imported bounds and orientation. If they confirm approximately 20 m length, revise the apron depth/vehicle positioning in `WAREHOUSE_LAYOUT.md` and then update the blockout through the builder in a separately verified task.
- The truck, rack and dock dimensions remain unverified in Unity and must not yet be used to change the main scene.

### Main project state
- No GLB files were imported.
- No Unity package was installed.
- No scene, package, project setting or main-project file was changed.
- Phase 3 has not started.
- Eight candidate files are downloaded and statically inspected only.

## 21. GLB importer validation plan (completed; see section 22)

1. Read all current project documents and verify clean Git status and active Unity project.
2. Inspect `Packages/manifest.json` and `Packages/packages-lock.json`; record existing versions and make a backup before package changes.
3. Confirm registry versions of `com.unity.cloud.gltfast`, `com.unity.meshopt.decompress` and `com.unity.cloud.ktx` compatible with Unity 6000.6.10f1. Inspect their package licences and dependencies. Use only the free official Unity registry packages.
4. If any dependency is incompatible, requires payment, or would force unrelated package upgrades/render-pipeline changes, stop and report before installing.
5. Add the importer and its two required extension packages only if compatible. Keep a minimal, reversible manifest diff.
6. Use the existing licensed Unity Editor/MCP to import a limited preview set from `/private/tmp/WarehouseGapAssetReview/`: Steel Pallet Rack, Forklift, Loading Dock, Semi Truck and Trailer, Shipping Container, and Conveyor Roller Straight. Do not import all eight yet; curve and transfer modules can follow once the first test works.
7. Test GLB mesh decoding, KTX2/BasisU textures, URP materials, scale, axis orientation, pivots, separate moving-part hierarchy and visible model quality. Record actual Unity bounds; do not treat source dimensions as measured.
8. If successful, create a temporary preview scene. Do not modify `Warehouse_Blockout.unity` until the imported models have been inspected and the truck-apron mismatch resolved.
9. If preview fails, revert only the package/test changes made during this task, preserve unrelated project work, and report the exact error.
10. Do not commit until all selected GLBs render correctly and the package diff is reviewed. Then commit the importer, required GLB assets and licences if they are needed for the project, while keeping the no-payment rule and attribution records.

## 22. GLB gap-model import and live Unity verification (2026-11-26)

The importer-support commit `c30f1ce` (`build: add official glTF import support`) was pushed to `origin/main` before any new commit was created. The remote branch was verified at `c30f1ce9ae2df12ee8fd92d8530aafe73cfde701`.

### Imported models and retained provenance

Six reviewed GLBs were copied from `/private/tmp/WarehouseGapAssetReview/Models/` into `Assets/Imported/FreeWarehouseGapAssets/Models/`. Their destination SHA-256 values were compared to the reviewed `SHA256SUMS.txt` and matched:

| Model | Creator/source | Source size | SHA-256 verified |
|---|---|---:|---|
| `Steel_Pallet_Rack_L0.glb` | tevy.dev — https://tevy.dev/models/steel-pallet-rack | 1,874,364 B | Yes |
| `Forklift_L0.glb` | tevy.dev — https://tevy.dev/models/forklift | 2,912,328 B | Yes |
| `Loading_Dock_L0.glb` | tevy.dev — https://tevy.dev/models/loading-dock | 2,601,352 B | Yes |
| `Semi_Truck_L0.glb` | tevy.dev — https://tevy.dev/models/semi-truck | 2,686,428 B | Yes |
| `Shipping_Container.glb` | Grab3D — https://grab3d.com/models/city/shipping-container-proz/ | 1,315,132 B | Yes |
| `Conveyor_Roller_Straight_L0.glb` | tevy.dev — https://tevy.dev/models/conveyor-roller-straight | 2,281,796 B | Yes |

Tevy source and CC0 notes were retained in `Documentation/SOURCES.md`. The Grab3D `LICENSE.txt` and `manifest.json` were retained unchanged. `CREDITS.md` records the source URLs and CC0 1.0 status. Embedded GLB textures and material definitions were preserved; no external texture package was added. `Documentation/GLB_ImportPreview.png` is the screenshot captured from the actual Unity Editor. Detailed per-model observations are in `Documentation/UnityImportVerification.md`.

### Unity and rendering verification

- Unity Editor: 6000.6.10f1; URP: 17.6.0.
- Installed official Unity importer packages: glTFast 6.21.0, KTX 3.8.0 and Meshopt Decompressor 0.3.0-exp.1. These are the compatible versions retained by the pushed importer-support commit. No render-pipeline change was made.
- The live Editor loaded and instantiated all six GLBs in a separate temporary scene. All six rendered. Every model's materials used `Shader Graphs/glTF-pbrMetallicRoughness`; inspection found no null material references and populated texture slots. The selected tevy meshopt geometry and BasisU/KTX2 texture path rendered; the KTX2 decode path had also been exercised in the successful prior GLB preview (`/private/tmp/WarehouseGapAssetReview/Unity_Importer_Preview_Report.md`). The temporary scene was saved as `Assets/AssetPreview_TEMP.unity` for capture and later removed.
- Actual Unity renderer bounds were: rack 8.700 × 5.000 × 1.500 m; forklift 1.410 × 2.397 × 4.120 m; dock 6.600 × 6.220 × 6.000 m; truck 3.270 × 4.207 × 20.026 m; container 6.128 × 2.591 × 2.440 m; straight conveyor 0.876 × 0.995 × 4.000 m (X × Y × Z).
- Separate object hierarchies were retained: forklift (9 direct child nodes), dock (5), truck (11), container (1) and conveyor (27); rack is a single renderer root. These child objects are not evidence of animation.
- No colliders, LODGroups, Animation components or Animator components were found in the imported instances. Do not claim these six assets animate. Source-advertised LOD variants were not imported as LODGroups.
- No source-scale correction was applied. The rack pivot is vertically centered; use a +2.5 m Y translation to place its 5 m height on the floor. The loading dock needs a 180° Y rotation to face south. The truck has length along Z, rear doors at negative Z and cab at positive Z; rotate 180° around Y for its rear doors to face the south-facing dock.
- The 20.026 m measured truck requires approximately 23–24 m clear apron depth for a straight approach. This is recorded in `WAREHOUSE_LAYOUT.md`; the 60 × 40 m internal footprint remains unchanged.
- The temporary preview scene and its `.meta` file were removed after capture. `Warehouse_Blockout.unity`, `SampleScene`, the blockout builder and URP settings were not modified for this import.
- Console check limitation: the first attempted save path generated one Unity error (`Parent directory must exist before creating asset at: Assets/__GLBPreviewTemp/AssetPreview.unity`). After creating that path, the scene was saved under the temporary root path above and deleted after capture. The Editor log also recorded MCP WebSocket transport warnings when the connection closed. No GLB/model-specific import errors appeared in the inspected log. The Unity Editor/MCP stopped responding before a final live `read_console` call could complete; the Console is not being reported as clean.

### Status at the time of the original six-GLB import

At that point the curve and belt-transfer modules were outside the project and the animation samples were untested. Those tasks were completed in section 23 below. The original console limitation and preview results above remain historical records for that earlier import task.

## 23. Final Phase 2 asset coverage and Play Mode animation validation (2026-11-26)

### Source, licence and hash checks

- The eight added Warehouse Essentials interactive FBX files (`Box_Medium`, `Box_Small`, `Crate_Small`, `Double_Locker`, `Electrical_Cabinet`, `Open_Carton`, `Toolbox`, `Wooden_Spool_Table`) and all 17 animation-sample FBXs were extracted from the already-reviewed `WarehouseEssentials_v1.0_CC0.zip`. Their SHA-256 values matched the exact entries in that archive. The added Blue, Rust and Sage atlas PNGs also matched the archive. The project's `Documentation/LICENSE.txt` is a byte-for-byte copy of the archive's `LICENSE.txt`, which names Akash Jikadra and grants CC0 1.0 for original assets to the extent of the creator's rights.
- The curved conveyor and belt-transfer GLBs came from the already-downloaded review folder; project file SHA-256 values match the review copies. The official creator pages identify both as free CC0 1.0: [Roller Conveyor Curve](https://tevy.dev/models/conveyor-roller-curve) and [Belt Conveyor Transfer](https://tevy.dev/models/conveyor-belt-transfer). The two digests and detailed Editor measurements are recorded in `Assets/Imported/FreeWarehouseGapAssets/Documentation/UnityImportVerification.md`; source/version records remain in `SOURCES.md`.
- No purchase, checkout or paid trial occurred. No new package was installed; the nested Warehouse Essentials Unity package and Blender project were not opened or imported. No downloaded code was executed and no antivirus scan was performed.

### Files added to the project

- `Assets/Imported/FreeWarehouseGapAssets/Models/Conveyor_Roller_Curve_L0.glb`
- `Assets/Imported/FreeWarehouseGapAssets/Models/Conveyor_Belt_Transfer_L0.glb`
- Eight distinct Warehouse Essentials FBXs under `Assets/Imported/FreeWarehouseEssentials/Models/`: `Box_Medium.fbx`, `Box_Small.fbx`, `Crate_Small.fbx`, `Double_Locker.fbx`, `Electrical_Cabinet.fbx`, `Open_Carton.fbx`, `Toolbox.fbx`, `Wooden_Spool_Table.fbx`
- All 17 separate animation-sample FBXs under `Assets/Imported/FreeWarehouseEssentials/Animations/`.
- Three referenced colour atlas PNGs (`Warehouse_Blue_Atlas.png`, `Warehouse_Rust_Atlas.png`, `Warehouse_Sage_Atlas.png`) and three corresponding project-owned URP Lit materials.
- Updated attribution/import documentation and actual Unity preview captures in the two imported asset Documentation folders.

No duplicate model files were imported. Existing six FBX props and six prior GLBs remain in place.

### Unity 6.6 URP verification

- Unity Editor: 6000.6.10f1, actual project; URP 17.6.0; existing package versions retained.
- The two added GLBs rendered with `Shader Graphs/glTF-pbrMetallicRoughness`; their base-colour, normal and metallic/roughness texture properties were populated. Unity bounds: curve 1.47 × 0.99 × 1.47 m; transfer 0.97 × 0.99 × 1.52 m.
- All eight added FBXs rendered with `Universal Render Pipeline/Lit`; every material had a texture assigned. Their measured bounds and renderer counts are in the imported asset verification report. The models read at plausible scale and upright orientation in the captured preview.
- No null materials or missing texture references were found for these previewed models. The raw FBX and GLB instances had no Unity `Collider` or `LODGroup` components. The tevy pages list three downloadable LOD files, but only LOD0 was imported. The Warehouse Essentials archive's separate collision meshes and LOD files were not imported.
- The preview shows a readable, coordinated stylized-industrial palette. This isolated asset lineup does not establish that the final scene meets the reference-level detail target; composition, stock density, high-bay lighting and layout integration remain to be reviewed in later phases.
- The active preview scene `Assets/__Phase2FinalPreview/` was deleted after capture. `Assets/Scenes/Warehouse_Blockout.unity` was reloaded and was clean. `SampleScene`, Packages, ProjectSettings and the blockout builder were not changed by this asset task. The Unity Console returned zero current error or warning entries after preview and animation validation.

### Animation playback findings

All 17 imported animation FBXs exposed one 2.50-second `Warehouse_DAY` clip. Their import type was changed to Legacy. Each preview model used an `Animation` component with the clip explicitly assigned and `Play` called in Play Mode. The Editor was set to run in the background for this test because it was unfocused; Unity frame count and animation state time advanced. Local transform snapshots were compared at two different runtime times.

| Play Mode result | Samples |
|---|---|
| Pose changed (13) | `Caution_Sign`, `Double_Locker`, `Electrical_Cabinet`, `Floor_Fan`, `Furniture_Dolly`, `Gas_Cylinder`, `Hand_Trolley`, `Open_Carton`, `Pallet_Jack`, `Roller_Conveyor`, `Step_Ladder`, `Toolbox`, `Utility_Cart` |
| Clip played, but no pose change observed in sampled interval (4) | `Industrial_Trash_Can`, `Lidded_Transit_Tote`, `Plastic_Barrel`, `Workbench_Vise` |

The seven matching static FBX assets (`Double_Locker`, `Electrical_Cabinet`, `Open_Carton`, `Pallet_Jack`, `Roller_Conveyor`, `Toolbox`, `Workbench_Vise`) had zero missing transform paths when compared with their animation clips. Therefore the clips for the first six listed assets are reusable candidates on the matching Warehouse Essentials models; `Workbench_Vise` is not a demonstrated visible animation. Root transforms are animated, so future scene placement needs an unanimated parent. The `Roller_Conveyor` FBX clip is not a clip for the separate tevy GLBs; those models have moving-part nodes but no clips were imported.

Full per-clip result and setup: `Assets/Imported/FreeWarehouseEssentials/Documentation/AnimationPlaybackValidation.md`. Play Mode images: `AnimationSamples_All17_PlayMode.png` and `AnimationPriority_PlayMode.png`.

### Instructor requirement coverage

| Instructor requirement | Coverage | Verified assets / status | Remaining work |
|---|---|---|---|
| Rack | Fully covered | Tevy steel pallet rack GLB | Arrange repeated rack bays and test scene fit in Phase 3 |
| Crates / stock | Fully covered | Large/small crates, medium/small boxes, open carton, pallets, totes and bins | Populate visually in the generator/assembly phases |
| Container | Fully covered | Shipping container GLB plus storage containers from Warehouse Essentials | Layout/stacking decision later |
| Cabinets | Partially covered | Double locker, electrical cabinet, toolbox | A general warehouse storage cabinet is missing; use original procedural modelling if required |
| “lizards” | Excluded by user decision / not implemented | The PDF's exact wording is preserved; no interpretation has been assumed | No further work; not a blocker |
| Assembly tables | Partially covered | Wooden spool table and Workbench Vise | No dedicated assembly/production table; create a project-original procedural model if needed |
| Conveyor | Structurally covered | Straight roller, 90° curve and belt-transfer modules, plus Essentials short roller prop | Animate the chosen line in a later phase; GLB parts have no imported clip |
| Pallet truck | Fully covered | Warehouse Essentials Pallet_Jack FBX | Use its verified matching Legacy clip only if desired |
| Sounds | Missing | No project audio collection was acquired or tested | Source legal free sounds or record/create original foley in Phase 7 |
| Animation of some elements | Partially covered | 13 of 17 clips showed transform change in Play Mode; useful candidates listed above | Integrate a small number into the final scene and verify there |
| Interior lighting | Missing | No final high-bay warehouse light rig is part of this asset set | Implement and review lighting in Phase 4 |

The instructor PDF's example also depicts a forklift, loading dock and delivery vehicle; the collection has a verified forklift, dock and semi-truck/trailer GLB. The user-selected project features (both camera modes and a configurable C# Warehouse Generator) remain future implementation work, as scheduled in `PROJECT_BRIEF.md`.

### Phase completion decision

Historical Phase 2 decision, superseded by section 28: asset acquisition and technical verification were initially treated as pending “lizards” clarification. The user later excluded that item. General cabinet and assembly-table gaps were assigned to original procedural modelling and completed in Phase 3. Sound remained a later scheduled task. `Warehouse_Blockout.unity` remained untouched.


## 24. Phase 3 handoff — approved to assemble known requirements (2026-11-26)

Historical Phase 3 handoff: the user approved starting before clarifying "lizards". A later decision in section 28 excluded that item from scope; do not treat it as pending. The known requirements and model categories are sufficiently covered to assemble the main warehouse. General storage cabinet and dedicated assembly table are approved as original procedural geometry under the EUR 0 budget. Do not perform another broad asset search. Follow WAREHOUSE_LAYOUT.md section 12 and PROJECT_BRIEF.md section 14. Build in a new Warehouse_Final.unity scene, preserve the Phase 1 blockout baseline, use only verified imported assets already in the repository, and implement Phase 3 assembly only. Do not start camera controller, C# generator, final lighting, or audio/animation integration yet.

## 25. Phase 3 asset integration results (2026-11-26)

All Phase 3 scene placement used the already-reviewed assets documented in section 23. No assets were downloaded, paid for, or newly imported. The final scene uses the eight gap GLBs already in the project (rack, forklift, dock, truck, container and all three conveyor modules) plus existing Essentials FBXs (pallets, boxes, crates, locker, electrical cabinet, toolbox, pallet jack, spool table, vise and cartons). The editor script preserves each imported model's original root unit scale and FBX 270° X-axis import correction, then composes only the requested world Y orientation. In the live scene the rack measures 1.50 × 5.00 × 8.70 m after yaw 90°, with base at Y=0; full truck measures 3.27 × 4.21 × 20.03 m at scale 1.

`Assets/Scenes/Warehouse_Final.unity` contains the final warehouse assembly, with imported materials left assigned and project-owned procedural construction materials under `Assets/Materials/WarehouseFinal/`. The overall renderer check found no null material slots; actual Unity screenshots show the models and materials rendering in URP. No colliders or LODGroups were added to models because none were present in the verified imports. No animation playback or audio work was performed in this phase.

At the time of this Phase 3 report, “lizards” was still unresolved; it was later excluded by user decision in section 28. Other later scheduled work remains: final lighting (Phase 4), camera modes/controller (Phase 5), configurable C# Warehouse Generator (Phase 6), and selected animation/audio integration (Phase 7). The two phase captures are `Assets/Screenshots/WarehouseFinal_Phase3_Overview.png` and `Assets/Screenshots/WarehouseFinal_Phase3_Operations.png`.

## 26. Phase 4 material and visual review (2026-11-26)

No external assets were acquired or imported for Phase 4. The visual treatment uses the already-verified warehouse assets plus local deterministic maps and project-owned URP Lit materials under `Assets/Materials/WarehousePhase4/`. Textures cover concrete albedo/normal, corrugated cladding albedo, steel normal and metallic/smoothness, and sealed timber albedo. Asset authoring uses no runtime script or downloaded code.

The editor builder `Assets/Editor/WarehousePhase4VisualBuilder.cs` operates only in `Warehouse_Final.unity`; it keeps the existing Phase 3 assembly intact and replaces only `WAREHOUSE_PHASE4_DETAIL_ROOT`. It assigned the generated PBR materials to the slab/apron, wall cladding and ribs, roof/structural steel, and wooden worktops. Added scene details include floor joints and traffic paint, rack location cards/foot plates/anchors, column base plates/anchors, high-bay fixtures/lights, dock wall lights, and packing scales/parts bins. The verified imported props/models remain intact. Two consecutive runs each generated 331 transforms under one detail root.

Unity 6000.6.10f1 / URP 17.6.0 actual Editor verification: the final scene had 1,279 renderers and zero missing material/shader slots; 543 renderer material slots use Phase 4 materials and 302 assignments reference generated textures. The visual builder generated URP Lit materials with concrete, cladding, steel and timber maps. Full roof panels and translucent tinted skylights were temporarily shown, captured, then returned to the saved cutaway state. Local high-bay and dock spots are non-shadow-casting; existing soft directional shadows remain. The final project settings diff is empty after restoring Unity's unrelated auto-added URP folder path. Neither `Warehouse_Blockout.unity` nor `SampleScene` was changed. Final Console check returned zero errors and four existing obsolete `MaterialLocation.External` warnings from `Pallet.fbx`, `Pallet_Jack.fbx`, `Workbench_Vise.fbx` and `Crate_Large.fbx`; their importer settings were left unchanged. An earlier builder compilation warning from the obsolete object-finding API was fixed and the script recompiled successfully.

Visual evidence from the Unity Editor: `Assets/Screenshots/WarehouseFinal_Phase4_Overview.png`, `WarehouseFinal_Phase4_Storage_Closeup.png`, `WarehouseFinal_Phase4_Operations_Closeup.png`, and `WarehouseFinal_Phase4_Roof_Complete.png`. Compare with the retained Phase 3 overview and operations images for the before state. No before image was altered. The 60×40 m interior, layout, rack rows, truck positions and 24 m apron remain as approved. No camera controller, generator, animation or audio implementation was started. The unresolved instructor term “lizards” remains pending clarification.


## 27. Image-quality diagnosis from Phase 4 screenshots (2026-11-26)

The user's close-up screenshot has the Unity Game view Scale slider set to 7x. Unity's Game view documentation defines this slider as zooming into the Game screen to examine areas; do not mistake enlarged on-screen pixels for native output quality. Use 1x Game view scale for visual verification captures.

The actual source assets also have modest resolution:
- Phase 4 builder creates concrete/cladding/timber albedo maps at 512×512 and steel/concrete normal plus metallic-smoothness maps at 256×256.
- Their current importer metadata enables mipmaps, uses bilinear filtering, and Aniso Level 1.
- The original Warehouse Essentials atlases are 128×128.
This combination can look soft/blocky in extreme close-up even when the geometry/materials are correctly assigned.

For a bounded correction, assess native 1x captures, regenerate Phase 4 source maps at higher genuine source resolution if needed (do not only increase importer Max Size), use mipmaps/trilinear and moderate anisotropy for floor textures, and test geometry anti-aliasing independently. Do not assume MSAA fixes texture aliasing. Keep the art style and M4 performance.

## 28. User explicitly excludes "lizards" from remaining work (2026-11-26)

The user directed us to ignore the ambiguous "lizards" word in the source PDF and focus on the remaining tasks. Do not research the term, ask the lecturer, reinterpret it as "ladders", search for a replacement, or build anything for it. It is excluded by user decision and was not implemented. If referenced in a final exhaustive coverage report, label it "excluded by user decision / not implemented".

No further broad asset research is needed for the remaining scope. At the time this scope decision was recorded, the next work was the configurable C# Warehouse Generator; its Phase 6 implementation is recorded in section 29. Selected animation/audio integration and final QA remain later work.

## 29. Phase 6 use of verified stock assets (2026-11-26)

The configurable stock generator uses only already imported, reviewed Warehouse Essentials assets: `Pallet.fbx`, `Box_Small.fbx`, `Box_Medium.fbx`, `Crate_Small.fbx` and `Crate_Large.fbx`. It keeps their importer assets unchanged and uses them as model prefab sources in scene instances. No additional assets, licences, attribution records or packages were introduced. Existing raw assets remain under `Assets/Imported/FreeWarehouseEssentials/Models/` and retain the previously documented CC0 provenance.

Unity editor validation placed mixed pallet-only, box and crate loads in unique rack positions with repeatable seed behavior. The generator does not add collider, LOD or animation claims to these assets. Source importer warnings about obsolete `MaterialLocation.External` metadata remain an existing Unity-version compatibility notice and were not addressed by changing import settings.


## 29. Phase 7 animation/audio handoff (2026-11-26)

The asset research phase is closed. Do not perform another broad asset search. The existing Legacy animation samples are retained in `Assets/Imported/FreeWarehouseEssentials/Animations/`; their detailed 17-clip Play Mode evidence and exact matching-hierarchy limitations are in `Documentation/AnimationPlaybackValidation.md`. Use only matching clip/model hierarchy combinations. The tested `Roller_Conveyor` clip maps to the Warehouse Essentials FBX hierarchy, not the separate tevy GLB conveyor modules.

No audio source files are currently present in the repository tree. For Phase 7 use a legally free CC0 audio source only if already available without signup/payment; otherwise author small original procedural WAVs locally with an Editor utility. Do not install audio packages or use paid/unlicensed content. The next phase after animation/audio is Phase 8 final QA and delivery.


## 30. Phase 7 implementation is split into two verified tasks (2026-11-26)

Animation evidence is in `Documentation/AnimationPlaybackValidation.md`. The active Warehouse Final scene already contains the relevant static model instances: `Sort_Open_Carton`, `Packing_Open_Carton_1`, `Office_Double_Locker`, `Packing_Locker`, `Office_Control_Cabinet`, `Packing_Electrical_Cabinet`, plus conveyor loads `Conveyor_Load_01`–`Conveyor_Load_04`. The exact assembly coordinates and hierarchy names are in `Assets/Editor/WarehouseAssemblyBuilder.cs`.

Phase 7A should animate only one carton, one locker or electrical-cabinet door, and the conveyor demonstration. Use only matching Legacy clips proven by the report. The long operational conveyor is composed from separate tevy GLB modules, not the Warehouse Essentials `Roller_Conveyor` FBX. Do not retarget the latter. Inspect the GLB's roller hierarchy first; if it does not expose individual rollers, move one existing conveyor load along the validated straight segment. Avoid root-motion drift and unnecessary pallet-jack animation.

Phase 7B audio is separate. The repository contains no pre-existing WAV/MP3/OGG audio sources. Use a small original locally generated WAV soundscape or already-available verified CC0 audio only. Do not perform broad new asset research or use paid/unlicensed files. The user must listen in Play Mode to confirm audible output; source configuration alone is not audibility proof.

The ambiguous “lizards” item is excluded by user decision; no further work is allowed on it.

## 31. Phase 7A animation integration results (2026-11-26)

No new assets were downloaded or imported for Phase 7A. The existing Warehouse Essentials `Open_Carton` and `Double_Locker` Legacy clips were applied only to matching existing scene models; the existing tevy GLB straight-conveyor roller transforms were driven procedurally. The Warehouse Essentials `Roller_Conveyor` clip was not applied to tevy models. In actual Unity Play Mode, carton flaps and double-locker doors changed transforms, and all 100 GLB rollers rotated during sampling. See `Assets/Imported/FreeWarehouseEssentials/Documentation/AnimationPlaybackValidation.md` for clip validation and `PROJECT_BRIEF.md` section 23 for final-scene bindings. No audio work was performed.
