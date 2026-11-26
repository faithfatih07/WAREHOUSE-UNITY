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
- Historical Phase 3 note: the term “lizards” was carried as unresolved at the time. This was superseded by the user's later explicit scope decision: the item is excluded, must not be interpreted or researched, and is not a blocker.

### Phase 3 boundaries
- Build the assembled architecture and all known functional zones.
- Do not implement final lighting (Phase 4), camera controls (Phase 5), the configurable C# Warehouse Generator (Phase 6), or sound/animation integration (Phase 7).
- Basic temporary inspection lighting is acceptable; clearly label it as provisional.
- Test actual final scene in Unity; capture overview and representative close-up screenshots, run the builder twice to prove idempotency, verify no Console errors, then commit/push.

## 13. Phase 3 final-scene implementation and verification (2026-11-26)

- Final scene: `Assets/Scenes/Warehouse_Final.unity`, created as a copy of the blockout file. Its six-child `WAREHOUSE_BLOCKOUT_REFERENCE` root is inactive. The original `Assets/Scenes/Warehouse_Blockout.unity` and `Assets/Scenes/SampleScene.unity` were not edited.
- Builder: `Assets/Editor/WarehouseAssemblyBuilder.cs`. Menu: **Warehouse → Phase 3 → Regenerate Final Warehouse**. It opens only `Warehouse_Final.unity` and destroys/recreates only the root GameObject named `WAREHOUSE_FINAL_ROOT`; all other scene roots, including the disabled baseline reference, are preserved. Consecutive final runs each produced 1,405 transforms below the final root, 14 direct groups, two total scene roots and one inactive six-child reference.
- Interior remains 60 × 40 m with a 9 m wall/clearance datum. The apron slab covers X 34–60 and Z −24–0 (24 m south of the facade). Door openings and docks are centered at X 40, 47 and 54. Each full-scale truck has measured bounds 3.27 × 4.21 × 20.03 m; its rear doors face north, with rear bound at Z approximately −0.11 m. The dock models are rotated 180° Y to face south.
- Ten rack modules form five north-south rows at X 4.5, 10, 15.5, 21 and 26.5 m, with module centers near Z 15.3 and 24.3 m. After yaw 90°, measured bounds are 1.50 × 5.00 × 8.70 m and each base is on Y 0. Pallets, boxes and crates are placed on the rows; the rack-to-rack clear span between footprints is approximately 4 m. The X 32–36 m forklift spine stays free of parked vehicles; staged forklifts remain beside it. A 1.8 m marked west pedestrian route fits in the 2.6 m corridor between the interior west wall and the shifted office partition.
- Existing verified props are used for racks, pallets, cartons, crates, lockers, electrical cabinets, toolboxes, pallet jacks, the spool table and vise. The sorting line has four straight rollers, one 90° curve and one belt transfer, with cartons/crates visibly staged on the belt. Original project-owned geometry forms the detailed general storage cabinet and production worktables. The shipping container is placed on an east-yard staging pad outside the spine.
- `WAREHOUSE_FINAL_ROOT` groups architecture, active roof structure, separate inactive `ROOF_PANELS_AND_SKYLIGHTS` cutaway, floor markings/signage, storage, operations, office, receiving, packing, dispatch, docks/vehicles, exterior, camera and provisional lighting. Roof panels/skylights are retained in the scene but disabled for the Phase 3 overview. The overview camera and directional light are provisional only.
- Unity 6000.6.10f1 / URP 17.6.0 checks: all 996 scene renderers had non-null material slots; major model bounds and orientations were queried in Editor; rack bottoms, truck apron placement and scene hierarchy were checked. Builder idempotency was checked with two consecutive final runs. Captures: `Assets/Screenshots/WarehouseFinal_Phase3_Overview.png` and `Assets/Screenshots/WarehouseFinal_Phase3_Operations.png`.
- Final Console check found zero errors and eight warning entries: four duplicated `MaterialLocation.External` obsolete-setting warnings from existing FBX imports (`Crate_Large`, `Pallet`, `Pallet_Jack`, `Workbench_Vise`). Their importer metadata was left unchanged. Baseline scene files, Packages and ProjectSettings had no Git diff at review time.
- Historical Phase 3 status: at that time “lizards” was pending; the user later excluded it from scope. Final lighting is Phase 4, camera controls Phase 5, the configurable Warehouse Generator Phase 6, and sound/animation integration Phase 7. Imported models have no verified colliders or LODGroups; no colliders were invented here. Phase 3 scene assembly is complete; final Git delivery status is reported with the task results.

## 14. Phase 4 visual treatment (2026-11-26)

- The approved 60×40 m interior, functional zone locations, rack rows, forklift spine, pedestrian route, three loading positions and 24 m apron remain unchanged by the visual pass.
- `Warehouse_Final.unity` adds a separate `WAREHOUSE_PHASE4_DETAIL_ROOT`; `Assets/Editor/WarehousePhase4VisualBuilder.cs` regenerates only this exact root. Do not use the Phase 3 assembler to refresh the final scene after Phase 4 without first reapplying the visual builder.
- The floor and exterior apron use a tiled local concrete albedo/normal treatment, with fine 6 m saw-cut joint spacing. Additional markings identify forklift direction, pedestrian crossing and loading thresholds. Racks retain their verified imported geometry and stock, with added compact bay identifiers, foot plates and anchor heads.
- Corrugated wall skins use a project-generated industrial metal map; the existing steel framing receives matching coated-steel material. Column bases have plates and visible anchor points. The existing roof structure stays active; complete roof panels and tinted skylight panels remain grouped in `ROOF_PANELS_AND_SKYLIGHTS` and disabled for cutaway screenshots.
- High-bay spots and dock wall packs provide interior/exterior accents. The existing directional light is reduced to a neutral warm daylight level and remains the only soft-shadow source. Added local lights do not cast shadows to limit cost on the MacBook Air M4. Presentation cameras are still static; first-person/isometric switching remains Phase 5.
- Screenshots from the actual Unity Editor: `Assets/Screenshots/WarehouseFinal_Phase4_Overview.png`, `WarehouseFinal_Phase4_Storage_Closeup.png`, `WarehouseFinal_Phase4_Operations_Closeup.png`, and `WarehouseFinal_Phase4_Roof_Complete.png`. The before captures remain the Phase 3 screenshots.
- No layout, blockout or SampleScene changes are authorized by this visual pass. Historical status: “lizards” was pending then but is now excluded by user decision; camera controls, generator and animation/audio were still later phases.


## 13. Phase 5 camera and navigation decisions (2026-11-26)

- Default view on scene start: raised three-quarter / isometric overview camera framing the full 60×40 m interior and 24 m apron. Prefer orthographic projection if it preserves a clear full-scene composition; otherwise tune perspective deliberately.
- Toggle modes with V; expose a compact on-screen hint/control so the lecturer can discover the mode switch.
- First-person mode: WASD + mouse look, sensible walking speed, CharacterController, cursor locked on entry and Escape to release. Press V to return to overview.
- First-person uses the full roof and skylight panels. Isometric overview uses the established roof-panel cutaway state; toggle `ROOF_PANELS_AND_SKYLIGHTS` accordingly without deleting roof assets.
- Add simplified invisible collision proxies under a dedicated hierarchy for the floor/boundaries, major walls, rack rows, columns, loading-dock structures and large fixed machinery. Do not create unnecessary colliders for each small carton/crate. Test that the player cannot pass through major structures but can traverse the west pedestrian route, forklift spine, rack aisles and door openings.
- Reuse existing presentation/overview cameras where possible. Keep controller, player and collision proxies grouped and make creation idempotent; do not duplicate cameras or colliders on every builder run.
- The pixelated close-up screenshot was taken at Game View Scale 7x. This magnifies the rendered image. Use Game View Scale 1x and a fixed resolution for quality captures. Phase 4 generated source maps are 512×512 albedo / 256×256 normal-metallic and original FBX atlases are 128×128; assess and improve those source textures separately from edge anti-aliasing. MSAA helps geometric edges but does not fix texture aliasing. Refer to PROJECT_BRIEF.md section 17.


## 14. Phase 5 implementation status (2026-11-26)

- Overview opens by default in an elevated orthographic three-quarter composition; the roof-panel/skylight group is hidden to retain the established cutaway. The first-person mode begins at `(1.7, 0.05, 4.5)` m, follows the west pedestrian route, uses a 1.62 m eye height and 4.5 m/s walk speed, and enables the full roof.
- V switches camera modes. WASD moves, mouse look operates while captured, click captures the cursor, and Escape releases it. The on-screen banner describes the controls. The overview adds scroll zoom and right-drag pan.
- `WAREHOUSE_PHASE5_CAMERA_AND_COLLISION_SYSTEM` groups a single CharacterController and `INVISIBLE_COLLISION_PROXIES`. The setup preserves south dock openings and provides box proxies for perimeter walls, five rack rows, portal columns, fixed conveyor and packing stations. It does not add colliders to small crates or cartons.
- Play Mode checks verified the west perimeter and rack collisions, continued movement through the west route, and five mode/roof-state transitions. The setup menu was run twice without duplicating the Phase 5 root, player, controller or collider set.
- Texture generation/import settings and the incomplete matched 1× comparison are recorded in `PROJECT_BRIEF.md` section 18. Retina Game View reported 2× minimum; before/after captures therefore do not yet constitute a verified 1× matched-framing comparison.

## 15. Remaining scope decision (2026-11-26)

The user explicitly excluded the source PDF's ambiguous "lizards" item from this project. Do not research, clarify, substitute "ladders", model it, or treat it as a blocker. It is not implemented; if mentioned in a final exhaustive coverage table, mark "excluded by user decision / not implemented".

At the time this scope decision was recorded, remaining work after Phase 5 was:
- Phase 6: configurable deterministic C# Warehouse Generator for shelf/rack stock population.
- Phase 7: integrate/test selected animations and warehouse audio/ambience.
- Phase 8: final QA and delivery.
The strict matched 1× texture before/after screenshot was not verifiable on this Retina Game View (2× minimum); treat as a documented evidence limitation and do not block further implementation on it.


## 16. Phase 6 stock generator placement and ownership (2026-11-26)

- The existing rack modules remain at their Phase 3 positions: five rows centered on X = 4.5, 10, 15.5, 21 and 26.5 m; two modules per row centered on Z = 15.3 and 24.3 m. Each module provides three bay centers at module Z offsets −2.65, 0 and +2.65 m. The generator sorts the existing rack transforms and maps them to six row bays while respecting the gap between modules.
- The current assembled stock tiers use pallet bases at Y = 0 and Y = 2.55 m. The configurable generator exposes 1–2 levels and 1–6 bay positions per row, defaulting to the actual 5×6×2 capacity (60 positions). It uses imported pallet, small/medium box and small/large crate models at the established yaw and offsets from `WarehouseAssemblyBuilder.BuildStorage`.
- Generated loads belong only under `STORAGE_RACKS_AND_STOCK/WAREHOUSE_GENERATED_STOCK_ROOT`. Generator configuration lives on sibling `WAREHOUSE_STOCK_GENERATOR_CONFIG`. The editor setup adopts only previously assembled children whose names begin `Stock_`, reparenting the existing object instances without deleting/recreating them; later clearing/replacing is restricted to the dedicated generated-stock root. Rack modules and all unrelated objects stay outside that root.
- Deterministic tests in Unity produced 15/30/45/60 occupied rack positions at 25/50/75/100% fill; the seeded arrangement is repeatable and changing seed varies the layout. Routes at west (X≈1.7), rack access and forklift spine (X≈32–36) remain outside the generated x/z slot region. See `PROJECT_BRIEF.md` section 20.


## 16. Phase 7 animation/audio placement notes (2026-11-26)

Use the reviewed Legacy animations only on matching Warehouse Essentials FBX hierarchy paths. The `Roller_Conveyor` clip does not target the separate tevy GLB modules. An animated matching FBX conveyor segment may be placed as a clear demonstration at the sorting/packing line, or the GLB roller nodes can be rotated procedurally after inspection. Keep animated, root-keyed props beneath unanimated placement parents. Prioritize the existing matching locker, electrical cabinet, open carton and pallet-jack models where visually useful; do not force clips that showed no motion.

Audio should be a small zero-cost warehouse soundscape: low-level room ambience/HVAC, spatial conveyor operation, restrained packaging/metal handling effects, and a reversing alert only during an actual vehicle/reverse event. Use existing licensed audio if available, otherwise synthesize original WAV assets locally; no unlicensed samples or paid services. Keep levels subtle and include mute/volume control if practical.


## 17. Current animation/audio sequence (2026-11-26)

Phase 7 is deliberately split into two small Codex tasks. First animate a matching Open_Carton and one Double_Locker or Electrical_Cabinet, plus one real conveyor movement demonstration. Do not add sound during that task. The long conveyor is built from separate tevy GLBs; the Legacy Roller_Conveyor clip targets the Warehouse Essentials FBX hierarchy and must not be retargeted. If GLB roller children are not individually exposed, move one existing conveyor load along the validated straight section instead. Then commit and verify 7A before beginning 7B audio.

Phase 7B audio should stay minimal: low-volume warehouse ambience, one spatial conveyor loop and one restrained packing one-shot; no reversing alarm while vehicles are static, no music, no paid packages. Prefer original locally generated WAVs at EUR 0. Ask the user to confirm audible playback on the Mac rather than claiming audibility from configuration alone.

The user has explicitly excluded “lizards”; it is not implemented and is not a blocker. Roll-a-Ball completion and the teacher's requested group/individual email reply are separate course handoff tasks, not warehouse-scene tasks.

## 18. Phase 7A animation integration results (2026-11-26)

Phase 7A adds animation behavior without changing the approved 60×40 m interior, 24 m truck apron, zone positions, rack rows, conveyor route, camera setup or stock layout. The existing packing carton and office double locker each use a root-keyed matching Legacy clip beneath a placement parent that retains its original world pose. The four existing straight conveyor modules expose 100 separate roller transforms controlled by one runtime component. Rollers rotate in place; conveyor loads are not translated and no conveyor models are replaced. Full Play Mode results are recorded in `PROJECT_BRIEF.md` section 23 and `Assets/Imported/FreeWarehouseEssentials/Documentation/AnimationPlaybackValidation.md`.

## 19. Phase 8 delivery checks (2026-11-26)

The committed `ProjectSettings/EditorBuildSettings.asset` was checked directly on GitHub and currently lists only `Assets/Scenes/SampleScene.unity`. This omits the actual deliverable scene. Before any standalone build, add `Assets/Scenes/Warehouse_Final.unity` first and enabled, retaining `SampleScene.unity` second and enabled. Preserve both scenes and inspect the existing scene GUID.

The user manually confirmed the two Phase 7B sounds on the Mac: a low ambient warehouse hum and spatial conveyor audio near the conveyor/pallet area. Exactly two sounds are intentional. No pack one-shot or reversing alarm is required.

Phase 8 must preserve reported pre-existing local changes (Phase 4 LED material, three settings files, Build Profiles). Inspect exact diffs before acting. Never run destructive Git cleanup or blanket staging. Final smoke build may target macOS only if support is already installed; the instructor has not specified the final platform, file format or deadline. Source-project archive should be made only from reviewed committed files and exclude Unity caches, .git and unreviewed local-only files.
