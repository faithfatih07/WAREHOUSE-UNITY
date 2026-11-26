# WAREHOUSE-UNITY — Phase 1 Layout Plan

Status: Implemented, visually checked in Unity and committed in Phase 1 (2026-11-25).  
Coordinates: Unity X/Z plane; Y is height  
Origin: Southwest/front-left corner of the warehouse floor at (0, 0, 0)  
Units: metres  
Target footprint: 60 m (east-west, X) × 40 m (south-north, Z)  
Target clear internal height: approximately 9 m  
Pipeline: Existing URP project

This layout is an implementation decision for the project, not a dimension specified by the lecturer. Keep it as the baseline unless a real collision, usability issue or user-approved change requires revision.

## 1. Orientation

- South is the front/loading facade (Z = 0).
- North is the rear of the warehouse (Z = 40).
- West is X = 0; east is X = 60.
- Exterior truck apron is south of the building. After measuring the imported semi-truck in Unity, plan approximately 23–24 m of clear apron depth (roughly Z = -24 to -1) for a straight dock approach; do not scale down the truck to force it into the former 14–15 m apron.
- The overview camera should look from a raised south-west / south-east three-quarter angle and frame the complete facility.
- For later presentation, use a cutaway/hidden-front-wall/roof approach if necessary so the inside is readable from the isometric view. Do not build a permanently roofless final warehouse merely to make the overview visible.

## 2. Functional zones (approximate footprints)

All coordinates below are planning bounds, not wall thickness specifications.

| Zone | Approximate bounds (X, Z) | Intended use |
|---|---|---|
| Main storage / pallet racks | X 3–31, Z 7–30 | Five long rack rows with clear forklift aisles |
| Office / control room | X 2–13, Z 31–38 | Small enclosed administration room |
| Receiving / inspection buffer | X 14–30, Z 31–38 | Inbound pallet checking and temporary staging |
| Main north-south forklift spine | X 32–36, Z 3–37 | Clear circulation from dock side to rear buffer |
| Sorting / conveyor zone | X 38–56, Z 19–29 | Conveyor and sorting work cells |
| Packing / assembly zone | X 38–56, Z 12–18 | Assembly tables, packing stations and cabinets |
| Dispatch / outbound staging | X 37–58, Z 3–11 | Staged pallets, crates and access to dock doors |
| External truck apron | X 34–60, Z -24–0 | Three full-size truck/trailer positions aligned to loading doors (23–24 m clear depth) |

Maintain an unobstructed route between receiving, storage, sorting, packing and outbound staging. Keep first-person paths at least about 1.8 m clear; primary forklift aisles should be wider (target around 3.0 m or more).

## 3. Storage rack arrangement

Use five longitudinal rack rows oriented north-south (long axis along Z), approximately:
- Row centre X positions: 4.5, 10.0, 15.5, 21.0, 26.5.
- Rack length: approximately 19–20 m, from Z about 8 to 28.
- Rack footprint width: approximately 2.2–2.4 m.
- Target clear aisle between rows: approximately 3.1 m.
- Cross-aisle / turning clearance at north and south ends: preserve about 2–3 m.

These are blockout footprints. In Phase 2/3, adjust exact dimensions to the selected rack assets while preserving usable aisles and the zone logic. Do not pack boxes into the circulation aisles.

## 4. Loading doors and truck apron

- Provide three loading dock openings along the south facade, approximately centred at X = 40, 47 and 54.
- Each opening should be around 3.5–4 m wide with a loading platform / dock frame.
- Keep staging lanes inside each dock.
- Provide three exterior vehicle/trailer placeholders on the apron, aligned with the dock openings. Final trucks must use legal assets in later asset-import phase.
- Preserve a clear turning / reversing area; do not place walls or props across the apron.

## 5. Blockout geometry

Phase 1 should create a readable architectural blockout, not final art:
- Floor slab, perimeter wall segments, loading-dock gaps, simple roof/beam placeholder if useful.
- Clear colour-coded floor regions or simple labels for each functional zone.
- Rack footprint placeholders in the storage area.
- Sorting/conveyor footprint placeholders.
- Packing-table placeholders.
- Office and receiving partitions.
- Main forklift spine and visible circulation paths.
- Dock and truck placeholders outside the south facade.

Use simple geometry only for this phase. Do not import large asset packs, create detailed final materials, build the final C# stock generator, or implement first-person movement yet.

## 6. Suggested hierarchy

Use clear roots so later systems can replace blockout pieces safely:
- WAREHOUSE_ROOT
  - ARCHITECTURE_BLOCKOUT
  - ZONE_MARKERS
  - STORAGE_BLOCKOUT
  - LOGISTICS_BLOCKOUT
  - EXTERIOR_BLOCKOUT
  - CAMERA_MARKERS

Use readable, stable GameObject names. Keep generated blockout objects grouped under the root so the scene can be regenerated/cleared without touching unrelated objects.

## 7. Scene and file expectations

- Preserve the starter SampleScene.
- Create a dedicated scene such as Assets/Scenes/Warehouse_Blockout.unity.
- Save any blockout materials / scripts under clearly named folders in Assets.
- If using a generation script for the blockout, make it idempotent: running it again updates/replaces only WAREHOUSE_ROOT, not unrelated scene objects.
- Do not replace URP or alter package versions.
- Do not add the future WarehouseGenerator to this phase.

## 8. Phase 1 completion criteria

Phase 1 is complete only when:
1. The dedicated blockout scene exists and opens in Unity.
2. A top-down view clearly shows all zones, rack rows, loading doors, truck apron and routes.
3. A raised three-quarter overview makes the layout understandable.
4. The first-person circulation routes have no obvious blocked passages (full player controller comes later).
5. The scene is saved, no new Console errors are introduced, and the actual Unity Editor state is checked through MCP.
6. The project changes are committed and pushed.

At the end, report the real scene path, created scripts/materials, screenshots or visual checks actually performed, Console status, Git status, and any deviations from this layout.

## 9. Actual Phase 1 result

- Scene: Assets/Scenes/Warehouse_Blockout.unity
- Builder: Assets/Editor/WarehouseBlockoutBuilder.cs
- Materials: Assets/Materials/Blockout_*.mat (11 blockout materials)
- Commit on main: c5a387d (feat: add Phase 1 warehouse blockout)
- Verified through Codex/Unity MCP: two consecutive builder runs left one WAREHOUSE_ROOT and five rack rows; scene saved; SampleScene unchanged; URPProjectSettings had no diff; Unity Console reported no errors and one MCP WebSocket warning.
- Note: the blockout uses primitive geometry and coloured zones intentionally. Phase 2/3 will replace major placeholders with selected licensed assets.

## 10. Imported GLB fit and placement notes (verified 2026-11-26)

The six selected GLBs were imported and measured in the active Unity 6000.6.10f1 URP Editor with glTFast 6.21.0, KTX 3.8.0 and Meshopt Decompressor 0.3.0-exp.1. Their Unity bounds and import findings are recorded in `Assets/Imported/FreeWarehouseGapAssets/Documentation/UnityImportVerification.md`.

- Keep the 60 × 40 m internal warehouse footprint unchanged.
- Provide approximately 23–24 m of clear exterior truck apron depth south of the loading facade. The truck is 20.026 m long in Unity; do not scale it down to fit the old 14–15 m apron.
- The rack model has a vertically centred pivot and 5.0 m height; place its root at Y = +2.5 m for floor placement.
- Rotate the loading dock model 180° around Y so its facade faces south (toward negative Z).
- The semi-truck's rear doors are at its negative-Z end and its cab at positive Z. Rotate it 180° around Y so the rear doors face the south-facing dock when reversing from the south apron.
- These are implementation notes for later integration. They do not authorize changes to `Warehouse_Blockout.unity` or its builder in this asset-import task.
- Preserve clear apron turning space and dock alignment when layout geometry is updated in a separately scoped assembly task.

## 11. Phase 2 asset integration notes (verified 2026-11-26)

These are inventory and fit notes only. The Phase 1 blockout scene and builder were not changed during this review.

- The modular conveyor set now includes the four-metre straight roller GLB, 90-degree curve GLB and belt-transfer GLB. Their Unity bounds are respectively 0.876 × 0.995 × 4.000 m, 1.475 × 0.995 × 1.475 m and 0.966 × 0.995 × 1.519 m (X × Y × Z). Connect modules in the sorting area while keeping the north-south forklift spine clear.
- The project also has separate short Warehouse Essentials roller-conveyor FBX and sample animation clip. The FBX Legacy clip does not apply to the separate tevy GLB hierarchy; later conveyor motion will need the matching FBX model/clip or a project-authored animation for the GLBs.
- Additional tested stock props include small and medium boxes, a small crate and an open carton. Cabinet and table assets include a double locker, electrical cabinet, toolbox and wooden spool table. Their raw FBX imports have no Unity colliders or `LODGroup` components; add these only as part of a later gameplay/assembly need.
- Keep the rack +2.5 m Y placement, south-facing 180-degree dock/truck rotation and 23–24 m apron requirements above. No warehouse dimensions, zone bounds or object placement coordinates are changed by this asset review.


## 12. Phase 3 final-scene assembly decisions (authorized 2026-11-26)

### Scene safety
- Create Assets/Scenes/Warehouse_Final.unity as a copy of Assets/Scenes/Warehouse_Blockout.unity.
- Never edit or regenerate Warehouse_Blockout.unity during Phase 3. Preserve SampleScene.
- In the new final scene, keep the copied Phase 1 blockout root only as a disabled reference (rename it clearly, e.g. WAREHOUSE_BLOCKOUT_REFERENCE) and create the finished environment under a separate WAREHOUSE_FINAL_ROOT.
- Create a new Assets/Editor/WarehouseAssemblyBuilder.cs with an idempotent command. It may replace only WAREHOUSE_FINAL_ROOT in Warehouse_Final.unity; it must never delete unrelated scene objects or the blockout reference root.
- Do not call the Phase 1 WarehouseBlockoutBuilder.Regenerate method from the new assembly task.

### Final dimensions and vehicle apron
- Internal floor remains 60 m east-west (X) × 40 m south-north (Z); internal clear height approximately 9 m.
- Final exterior apron is X 34–60, Z approximately -24 to -1 (23–24 m clear depth). This supersedes the old Phase 1 placeholder label Z -15 to 0.
- Use three dock/truck positions centred approximately at X 40, 47 and 54, but inspect actual asset bounds/pivots and ensure no overlap.
- Full-size semi-truck measured at approximately 20.026 m long. Do not scale down. Its rear doors should face north (+Z) to reverse into the south-facing dock; place truck facing outwards to the south.
- Loading dock asset should face south (verified 180° Y orientation); inspect its pivot and integrate the rear face correctly into the south facade.

### Rack layout using verified GLB
- Five north-south rows, approximate centre X positions 4.5, 10.0, 15.5, 21.0, 26.5.
- Use two 8.7 m long rack modules per row (ten modules total), rotated to align the 8.7 m local X dimension along world Z.
- The verified rack is 8.7 × 5.0 × 1.5 m in its imported bounds. Apply the measured vertical pivot offset (+2.5 m when root is not rotated) and verify its base rests on the floor after rotation.
- Place the two modules in each row end-to-end with a small sensible joint/gap; keep approximately 3 m or more forklift aisles and 2–3 m cross-aisles.
- Populate racks with existing pallets, boxes and crates, but do not implement the configurable Warehouse Generator in Phase 3.

### Functional area assembly
- Use the current approved bounds in sections 1–4 as the base zone map.
- Use the straight, curve and belt-transfer GLB modules to create a legible conveyor/sorting route.
- Use existing FBX assets for boxes, crates, pallets, pallet jack, cabinets, lockers, toolbox, wooden spool table and workbench vise.
- Build a general warehouse storage cabinet and a dedicated assembly/production worktable from original, detailed procedural geometry in the project. These are explicitly approved zero-cost modelling decisions; avoid plain primitive placeholder boxes.
- Place the shipping container in a useful staging/storage position without blocking the forklift spine or dispatch routes.
- Place forklifts only in believable parking/operating positions and keep all pedestrian/forklift routes clear.

### Roof and overview presentation
- Build a proper roof structure and roof panels; do not leave the finished warehouse permanently roofless.
- Keep roof elements under their own named root/layer so the overview presentation can hide/cut away roof panels while the actual roof remains part of the scene. A future first-person camera should be able to show the full roof.
- Include an overview camera for Phase 3 visual review. Final isometric/first-person controller and toggle are still Phase 5 tasks.

### Deferred instructor term
- The user approved Phase 3 proceeding while the PDF's exact term “lizards” remains unresolved.
- Do not substitute ladders or any other item without source evidence or lecturer clarification.
- Keep the requirement in project documentation as “pending clarification”; do not claim full instructor-category coverage or Phase 2 final sign-off until it is answered.

### Phase 3 boundaries
- Build the assembled architecture and all known functional zones.
- Do not implement final lighting (Phase 4), camera controls (Phase 5), the configurable C# Warehouse Generator (Phase 6), or sound/animation integration (Phase 7).
- Basic temporary inspection lighting is acceptable; clearly label it as provisional.
- Test actual final scene in Unity; capture overview and representative close-up screenshots, run the builder twice to prove idempotency, verify no Console errors, then commit/push.

## 13. Phase 3 final-scene implementation and verification (2026-11-26)

- Final scene: `Assets/Scenes/Warehouse_Final.unity`, created as a copy of the blockout file. Its six-child `WAREHOUSE_BLOCKOUT_REFERENCE` root is inactive. The original `Assets/Scenes/Warehouse_Blockout.unity` and `Assets/Scenes/SampleScene.unity` were not edited.
- Builder: `Assets/Editor/WarehouseAssemblyBuilder.cs`. Menu: **Warehouse → Phase 3 → Regenerate Final Warehouse**. It opens only `Warehouse_Final.unity` and destroys/recreates only the root GameObject named `WAREHOUSE_FINAL_ROOT`; all other scene roots, including the disabled baseline reference, are preserved. Consecutive final runs each produced 1,405 transforms below the final root, 14 direct groups, two total scene roots and one inactive six-child reference.
- Interior remains 60 × 40 m with a 9 m wall/clearance datum. The apron slab covers X 34–60 and Z −24–0 (24 m south of the facade). Door openings and docks are centered at X 40, 47 and 54. Each full-scale truck has measured bounds 3.27 × 4.21 × 20.03 m; its rear doors face north, with rear bound at Z approximately −0.11 m. The dock models are rotated 180° Y to face south.
- Ten rack modules form five north-south rows at X 4.5, 10, 15.5, 21 and 26.5 m, with module centers near Z 15.3 and 24.3 m. After yaw 90°, measured bounds are 1.50 × 5.00 × 8.70 m and each base is on Y 0. Pallets, boxes and crates are placed on the rows; the rack-to-rack clear span between footprints is approximately 4 m. The X 32–36 m forklift spine stays free of parked vehicles; staged forklifts remain beside it.
- Existing verified props are used for racks, pallets, cartons, crates, lockers, electrical cabinets, toolboxes, pallet jacks, the spool table and vise. The sorting line has four straight rollers, one 90° curve and one belt transfer, with cartons/crates visibly staged on the belt. Original project-owned geometry forms the detailed general storage cabinet and production worktables. The shipping container is placed on an east-yard staging pad outside the spine.
- `WAREHOUSE_FINAL_ROOT` groups architecture, active roof structure, separate inactive `ROOF_PANELS_AND_SKYLIGHTS` cutaway, floor markings/signage, storage, operations, office, receiving, packing, dispatch, docks/vehicles, exterior, camera and provisional lighting. Roof panels/skylights are retained in the scene but disabled for the Phase 3 overview. The overview camera and directional light are provisional only.
- Unity 6000.6.10f1 / URP 17.6.0 checks: all 996 scene renderers had non-null material slots; major model bounds and orientations were queried in Editor; rack bottoms, truck apron placement and scene hierarchy were checked. Builder idempotency was checked with two consecutive final runs. Captures: `Assets/Screenshots/WarehouseFinal_Phase3_Overview.png` and `Assets/Screenshots/WarehouseFinal_Phase3_Operations.png`.
- Final Console check found zero errors and eight warning entries: four duplicated `MaterialLocation.External` obsolete-setting warnings from existing FBX imports (`Crate_Large`, `Pallet`, `Pallet_Jack`, `Workbench_Vise`). Their importer metadata was left unchanged. Baseline scene files, Packages and ProjectSettings had no Git diff at review time.
- Known remaining items: instructor term “lizards” is still pending clarification; do not guess. Final lighting is Phase 4, camera controls Phase 5, the configurable Warehouse Generator Phase 6, and sound/animation integration Phase 7. Imported models have no verified colliders or LODGroups; no colliders were invented here. Phase 3 scene assembly is complete; commit/push verification remains the delivery step.
