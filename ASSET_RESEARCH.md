# WAREHOUSE-UNITY — Phase 2 Asset Research

Research date: 2026-11-25  
Current Unity project: Unity 6.6.10f1 (6000.6.10f1), URP  
Current scene: Assets/Scenes/Warehouse_Blockout.unity  
Status: Shortlist only — no assets from these listings are imported or purchased yet.

## Selection rules

- Preserve the existing URP project and Phase 1 blockout.
- Prefer one coherent asset family over mixing unrelated visual styles.
- The instructor's reference is a detailed stylized/isometric warehouse visualization. "Reference quality" means comparable scene completeness, composition and detail density; photorealism is not mandatory.
- Prioritize the instructor's explicit categories: racks, crates, container, cabinets, "lizards" (term unclear in PDF; do not guess), assembly tables, conveyor and pallet truck.
- Also source forklift/truck, pallets, boxes, dock equipment, building shell and lighting as useful.
- Before importing, verify actual package contents, license, scale, URP/Unity compatibility, materials, pivots and colliders in the Unity Editor.
- Do not commit paid asset source files to a public repository or redistribute them separately. Follow the asset's actual license/EULA and check whether the lecturer's required submission method is compatible.
- Never claim an asset has been imported or tested until verified in the local Unity project.

## Recommended candidate A — best time/value fit to evaluate first

**Low Poly Warehouse Modular Kit — TWELF Creative Studio**

Official Unity Asset Store listing:  
https://assetstore.unity.com/packages/3d/environments/industrial/low-poly-warehouse-modular-kit-428136

Published listing details (checked 2026-11-25):
- Listed price: USD 9.99, taxes/VAT calculated at checkout.
- 154 assets: 45 modular building pieces, 86 props and 23 pickup/loot items.
- Includes modular walls, windows, doors, roller doors, floors, roof, stairs, catwalks, facade, foundation and loading dock platforms.
- Major props include pallet racks, forklift, pallet jack, conveyor, shipping container, semi truck, trailer, delivery van, security booth, barrier gate and street lights.
- 4 demo scenes; two are walkable first-person scenes.
- Prefabs include colliders; pickup objects have rigidbodies; lights are included.
- Two visual looks: clean low-poly and retro PSX texture variant.
- One shared 512 px colour atlas plus emission atlas and glass material.
- Geometry is lightweight: approximately 10–1,500 triangles per mesh, average approximately 216.
- URP compatible and listed as tested in Unity 6000.6.7f1. Current project is 6000.6.10f1, a nearby patch in the same Unity 6000.6 line; still verify package import in the actual Editor.
- 3.0 MB listing size; latest release 2026-11-16.
- Rating/review evidence: listing says "not enough ratings"; treat as a new, not yet community-validated package.
- Listing notes doors have animated parts via demo scripts; it does not establish that conveyor animation is included.

It appears to cover most physical categories needed and is close to the instructor's isometric warehouse style. The first-person demos may also provide reusable reference for the agreed second camera mode. Its low-poly art style is not photorealistic; judge the sample against the professor's actual reference, not against a photorealistic ideal.

**Recommended evaluation path:** inspect/download the creator's 18-asset free sample from their itch.io page before purchase, then compare it with the current blockout and instructor reference.  
Sample / creator page: https://twelfstudio.itch.io/low-poly-warehouse-modular-kit  
The creator states the sample is free; the complete pack is sold separately. The itch.io page states personal/commercial use is allowed but the assets themselves must not be resold or redistributed. Check the exact current terms before using that route. The Unity Asset Store listing uses the Standard Unity Asset Store EULA.

## Candidate B — lower-cost alternate

**Warehouse Pack (Full) — FromQCWithGameDev**

Official Unity Asset Store listing:  
https://assetstore.unity.com/packages/3d/environments/warehouse-pack-full-complete-low-poly-warehouse-collection-407034

Published listing details:
- Listed price: USD 5, taxes/VAT at checkout.
- 147 custom low-poly props; flat-colour style.
- Includes pallet racking, dock doors, packing assets, forklifts, conveyors, cold storage, hazmat storage and other warehouse assets.
- URP compatible; Unity 6000.3.13f1 listed as the original version.
- 4.0 MB; includes two sample scenes.
- Listing says "not enough ratings".
- Listing describes AI-assisted procedural generation for models and supporting code/docs. This is not by itself a compatibility or quality verdict; actual sample quality must be inspected.

This is a cheap alternative but its flat-colour visual style and limited external validation mean it should be evaluated against the instructor reference before choosing it.

## Candidate C — higher visual fidelity, higher cost

**Warehouse Distribution Centre — Clean and Abandoned — AK Atlas Kits**

Official Unity Asset Store listing:  
https://assetstore.unity.com/packages/3d/environments/industrial/warehouse-distribution-centre-clean-and-abandoned-427890

Published listing details:
- Listed price: USD 39.99, taxes/VAT calculated at checkout.
- URP compatible (Unity 2022.3+).
- Complete 9-area logistics distribution centre, clean and abandoned states.
- 152 game-ready FBX assets (127 props/modules + 25 building-shell parts).
- 381 PBR texture files, maps up to 2048 px; real-world scale (1 unit = 1 m); colliders on prefabs.
- File size 363.3 MB; latest release 2026-11-11.
- Listing says "not enough ratings"; the asset is new.
- Documented lightmap UV limitation: 14/127 props and 16/25 shell parts fall below a 4 px padding check at 128 px. Use higher lightmap resolution (512+) or generate lightmap UVs / realtime lighting.
- GPU instancing is recommended for the many separate rack-load props.

This is the strongest listed option if a more realistic PBR result is prioritized and the budget permits, but it costs substantially more and has limited public review history. It is not automatically selected.

## Candidate D — free but not a base solution

**Warehouse Pack (Free) — Low-Poly Warehouse Essentials — FromQCWithGameDev**

Official Unity Asset Store listing:  
https://assetstore.unity.com/packages/3d/environments/warehouse-pack-free-low-poly-warehouse-essentials-407032

Published listing details:
- Free; 15 props; URP only; Unity 6000.3.13f1; 612.2 KB.
- Includes rack start/add-on bays, overhead door, dock bumper, pallet, hand pallet jack, packing table, boxes, floor-line kit and high-bay light.
- Flat-colour low-poly style, no texture maps; listing says it was made with AI assistance.
- Useful as a small sample / supplementary prop set, but insufficient by itself for the requested full warehouse.

## Options explicitly not selected as the main solution

- **Unity Warehouse (free, Unity Japan):** listing describes a photorealistic warehouse, but marks it HDRP compatible and URP not compatible. Do not import it as-is into the existing URP project or change render pipeline to use it.
  https://assetstore.unity.com/packages/3d/environments/industrial/unity-warehouse-276394
- **Free3D forklift model 977987:** page labels it "Personal Use License"; it has no textures, UVs, rigging or animation. Do not use in the submitted/shared project unless the licence is explicitly confirmed.
  https://free3d.com/3d-model/forklift-977987.html
- **TurboSquid Warehouse Storage Rack (free):** a PBR game-ready FBX/OBJ rack with 2048 textures and a Standard License, but a single model is not a coherent warehouse set. It may be a backup for one missing prop after checking its license.
  https://www.turbosquid.com/3d-models/warehouse-storage-rack-game-ready-props-3d-model-2036965

## Current recommendation

Evaluate Candidate A's free sample first. It provides the best balance of:
- coverage of the required physical items,
- existing first-person demo scenes,
- URP / Unity 6 compatibility,
- small download size,
- and low purchase cost.

Do not buy it automatically: it is new and has insufficient ratings. If its free sample visually fits the instructor's reference, the full pack is the preferred time-saving route. If it looks too simplistic, compare Candidate C's asset previews and decide whether the additional USD 30 cost over Candidate A is justified. Candidate B is the low-cost fallback, not the preferred visual-quality choice.

## Next actions

1. Compare Candidate A's free sample visually with the PDF reference image and the Phase 1 blockout.
2. Inspect its Unity folder structure, demo scenes, prefabs, materials and any scripts before deciding.
3. Record exactly which required instructor categories it covers and which remain missing (particularly cabinets, "lizards" as written in the PDF, assembly tables, conveyor, pallet truck, sounds and animation).
4. Confirm the asset license and lecturer submission constraints.
5. Only after the user authorizes/purchases the chosen package, import it into a separate temporary/test path first; do not overwrite the Phase 1 blockout.
6. Verify assets in Unity URP, then map selected prefabs into the Phase 1 layout.
