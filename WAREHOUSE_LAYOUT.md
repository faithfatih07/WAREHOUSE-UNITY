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
- Exterior truck apron is south of the building, approximately Z = -15 to -1.
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
| External truck apron | X 34–60, Z -15–0 | Three truck/trailer positions aligned to loading doors |

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
