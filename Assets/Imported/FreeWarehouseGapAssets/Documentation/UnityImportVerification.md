# Unity Import Verification — Free Warehouse Gap Models

Date: 2026-11-26  
Unity Editor: 6000.6.10f1  
Render pipeline: URP 17.6.0  
Importer packages: glTFast 6.21.0, KTX 3.8.0, Meshopt Decompressor 0.3.0-exp.1

All six GLBs were loaded from the project asset paths, instantiated in a separate temporary preview scene through the live Unity Editor, and rendered by a camera screenshot. The temporary scene was saved as `Assets/AssetPreview_TEMP.unity` only for inspection and removed afterwards. The scene used imported model materials; no project-specific material conversion was applied. Each renderer material used `Shader Graphs/glTF-pbrMetallicRoughness`. The live inspection found no null material references and texture properties were populated for every model. The imported GLB renderers and metre-scale bounds confirmed geometry decoding; the selected tevy models use meshopt compression and BasisU/KTX2 textures, which rendered in the prior validated GLB preview and in this import.

| Imported GLB | Unity bounds (X × Y × Z, m) | Renderers | Materials | Textured material slots | Direct child nodes | Colliders | LODGroups | Animation / Animator |
|---|---:|---:|---:|---:|---:|---:|---:|---:|
| `Steel_Pallet_Rack_L0.glb` | 8.700 × 5.000 × 1.500 | 1 | 1 | 3 | 0 | 0 | 0 | 0 / 0 |
| `Forklift_L0.glb` | 1.410 × 2.397 × 4.120 | 27 | 36 | 46 | 9 | 0 | 0 | 0 / 0 |
| `Loading_Dock_L0.glb` | 6.600 × 6.220 × 6.000 | 9 | 11 | 18 | 5 | 0 | 0 | 0 / 0 |
| `Semi_Truck_L0.glb` | 3.270 × 4.207 × 20.026 | 36 | 56 | 36 | 11 | 0 | 0 | 0 / 0 |
| `Shipping_Container.glb` | 6.128 × 2.591 × 2.440 | 1 | 1 | 3 | 1 | 0 | 0 | 0 / 0 |
| `Conveyor_Roller_Straight_L0.glb` | 0.876 × 0.995 × 4.000 | 27 | 27 | 78 | 27 | 0 | 0 | 0 / 0 |

Renderer bounds are Unity world bounds with imported root scales preserved. The rack's root pivot is vertically centered: translate it +2.5 m on Y for floor placement. The truck is Y-up, with width on X and length on Z; its rear doors are toward negative Z and cab toward positive Z. To reverse from the south apron into a south-facing dock, rotate the truck 180° around Y. Rotate the loading-dock model 180° around Y to orient its facade south.

The separate child nodes on the forklift, loading dock, semi-truck and conveyor are model hierarchy only. No animation clips or animation components were found on these imported assets; animation is not claimed. The tevy source pages advertise LOD variants, but these imported LOD0 files produced no Unity LODGroup; the shipping container has no LODGroup. No colliders were present.

Visual capture: `GLB_ImportPreview.png`. This asset-only preview is not the final warehouse assembly. The separate temporary preview scene was used only for verification and is not part of the retained model folder.

## Console note

The attempted initial save to `Assets/__GLBPreviewTemp/AssetPreview.unity` produced one Unity error because that parent directory did not yet exist. The scene was then saved as the exact temporary file `Assets/AssetPreview_TEMP.unity`, the screenshot was captured, and that scene and its metadata were deleted after inspection. The Editor log contained repeated MCP WebSocket transport warnings after the MCP connection closed. It showed no GLB/model-specific import error. A final live `read_console` call was unavailable because the Unity Editor/MCP session stopped responding; this note is based on the visible Editor error and `Logs/Editor.log`, not a claim of a clean final Console.

## Additional conveyor modules and props (2026-11-26)

Two more models from the official tevy creator pages were copied from the previously reviewed folder. Both pages identify the files as free CC0 1.0 assets; their project copies match the downloaded review files by SHA-256. Source URLs are recorded in `SOURCES.md`.

| Model | File size | SHA-256 | Unity bounds X × Y × Z (m) | Renderers | Texture slots | Colliders | LODGroups |
|---|---:|---|---:|---:|---:|---:|---:|
| `Conveyor_Roller_Curve_L0.glb` | 2,334,236 B | `058c44ac485dffb66531d37c7504cfae73016cb5aaeca45a590a13bb9c90373a` | 1.47 × 0.99 × 1.47 | 13 | 3/3 | 0 | 0 |
| `Conveyor_Belt_Transfer_L0.glb` | 925,636 B | `f0adec5772bfdb4076c9fd2299c51527e390ab667f0dcf438d8c8b75ef367ae8` | 0.97 × 0.99 × 1.52 | 3 | 3/3 | 0 | 0 |

Both modules rendered in the actual Unity 6000.6.10f1 URP 17.6.0 Editor using `Shader Graphs/glTF-pbrMetallicRoughness`. All three inspected texture properties (base colour, normal and metallic/roughness) were populated; no material reference was null. The imports contain separate hierarchy nodes but no animation clips, colliders or `LODGroup` components. Although tevy lists three LOD downloads on each creator page, only LOD0 was imported here. No LOD was fabricated. `Phase2_AddedAssets_Preview.png` is a live Unity Editor screenshot of both modules with the eight newly selected Warehouse Essentials FBXs.

The eight additional interactive Warehouse Essentials FBXs were instantiated in the same temporary Editor preview. Their renderer bounds (X × Y × Z, metres), URP materials and reference status were:

| Model | Bounds (m) | Renderers | Material / texture check | Colliders | LODGroups |
|---|---:|---:|---|---:|---:|
| `Box_Medium.fbx` | 0.56 × 0.48 × 0.48 | 1 | URP Lit; texture assigned | 0 | 0 |
| `Box_Small.fbx` | 0.38 × 0.32 × 0.36 | 1 | URP Lit; texture assigned | 0 | 0 |
| `Crate_Small.fbx` | 0.71 × 0.60 × 0.71 | 1 | URP Lit; texture assigned | 0 | 0 |
| `Double_Locker.fbx` | 0.80 × 1.83 × 0.53 | 3 | URP Lit; texture assigned | 0 | 0 |
| `Electrical_Cabinet.fbx` | 0.52 × 0.81 × 0.26 | 2 | URP Lit; texture assigned | 0 | 0 |
| `Open_Carton.fbx` | 0.89 × 0.42 × 0.75 | 5 | URP Lit; texture assigned | 0 | 0 |
| `Toolbox.fbx` | 0.57 × 0.45 × 0.31 | 2 | URP Lit; texture assigned | 0 | 0 |
| `Wooden_Spool_Table.fbx` | 0.86 × 0.74 × 0.86 | 1 | URP Lit; texture assigned | 0 | 0 |

All imported materials resolved and showed populated atlas texture slots in the preview. These raw FBX imports produced no Unity colliders or `LODGroup` components. The collection's separately supplied collider meshes and static LOD assets were not imported.
