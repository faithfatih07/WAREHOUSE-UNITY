# Warehouse Essentials animation playback validation

Date: 2026-11-26  
Unity Editor: 6000.6.10f1  
Render pipeline: URP 17.6.0  
Source: original Warehouse Essentials archive; CC0 1.0 `LICENSE.txt` retained beside this report

## Unity setup and method

All 17 separate animation FBXs were imported from the reviewed archive without importing its nested Unity package or opening its Blender project. Each FBX contains one `Warehouse_DAY` clip of 2.50 seconds. The `ModelImporter` animation type was changed from Generic to Legacy so Unity exposed Legacy clips. For playback, each sample model had an `Animation` component with the imported clip assigned and `Play` called in Play Mode.

The Editor was set to run in the background for the test because the unfocused Editor otherwise stopped advancing frames. In Play Mode the Editor advanced from frame 139 to frame 262 and the `AnimationState.time` advanced from 15.76 to 28.28 seconds. The sample models were parented under separate preview slots because their clips key root transforms; this kept their scene placement while preserving the clip hierarchy. For each model, the local position and rotation of every transform were compared at the two runtime snapshots.

## Results

`Clip playing` means Unity reported the clip as active on its Legacy `Animation` component during Play Mode. `Pose changed` means at least one descendant transform's local position or rotation differed between the two runtime snapshots.

| Animation sample | Clip | Length | Curve bindings | Clip playing | Pose changed |
|---|---|---:|---:|---|---|
| `Caution_Sign` | `Warehouse_DAY` | 2.50 s | 30 | Yes | Yes |
| `Double_Locker` | `Warehouse_DAY` | 2.50 s | 40 | Yes | Yes |
| `Electrical_Cabinet` | `Warehouse_DAY` | 2.50 s | 30 | Yes | Yes |
| `Floor_Fan` | `Warehouse_DAY` | 2.50 s | 30 | Yes | Yes |
| `Furniture_Dolly` | `Warehouse_DAY` | 2.50 s | 60 | Yes | Yes |
| `Gas_Cylinder` | `Warehouse_DAY` | 2.50 s | 30 | Yes | Yes |
| `Hand_Trolley` | `Warehouse_DAY` | 2.50 s | 40 | Yes | Yes |
| `Industrial_Trash_Can` | `Warehouse_DAY` | 2.50 s | 30 | Yes | No change observed |
| `Lidded_Transit_Tote` | `Warehouse_DAY` | 2.50 s | 30 | Yes | No change observed |
| `Open_Carton` | `Warehouse_DAY` | 2.50 s | 60 | Yes | Yes |
| `Pallet_Jack` | `Warehouse_DAY` | 2.50 s | 70 | Yes | Yes |
| `Plastic_Barrel` | `Warehouse_DAY` | 2.50 s | 30 | Yes | No change observed |
| `Roller_Conveyor` | `Warehouse_DAY` | 2.50 s | 160 | Yes | Yes |
| `Step_Ladder` | `Warehouse_DAY` | 2.50 s | 70 | Yes | Yes |
| `Toolbox` | `Warehouse_DAY` | 2.50 s | 30 | Yes | Yes |
| `Utility_Cart` | `Warehouse_DAY` | 2.50 s | 60 | Yes | Yes |
| `Workbench_Vise` | `Warehouse_DAY` | 2.50 s | 40 | Yes | No change observed |

Thirteen clips changed one or more transforms in the sampled interval. Four clips (`Industrial_Trash_Can`, `Lidded_Transit_Tote`, `Plastic_Barrel` and `Workbench_Vise`) played but showed no transform change in that interval; no visible motion is claimed for those four.

## Reuse with imported models

Unity animation curve paths were checked against the static imported FBX hierarchy for `Double_Locker`, `Electrical_Cabinet`, `Open_Carton`, `Pallet_Jack`, `Roller_Conveyor`, `Toolbox` and `Workbench_Vise`. All 7 target hierarchies resolved every non-root transform binding (zero missing paths). The five animated priority clips, plus `Toolbox`, can be reused as Legacy clips on their matching Warehouse Essentials models. `Workbench_Vise` has matching paths but did not show visible motion in the Play Mode interval, so it is not a demonstrated visible animation candidate.

These clips are specific to the Warehouse Essentials FBX hierarchy. In particular, the `Roller_Conveyor` clip was not retargeted to the separate tevy GLB conveyor straight, curve or transfer module; those GLBs have no imported animation clips. Their separate nodes alone are not proof of animation.

For future integration, retain the imported FBX sample and its clip, set the model's import type to Legacy, add an `Animation` component, assign the clip and call `Play` (or enable automatic playback). Choose a deliberate wrap mode for each use. Since root transform curves are present, place animated models under an unanimated parent slot/root so world placement is not overwritten by the clip.

## Visual evidence

- `AnimationSamples_All17_PlayMode.png` — all 17 sample models rendered by the temporary Unity Game camera while in Play Mode.
- `AnimationPriority_PlayMode.png` — focused view of the six requested priority samples in Play Mode.

The preview scene lived in `Assets/__Phase2FinalPreview/` and was deleted after testing. No animation assets were modified beyond the Legacy import configuration. No downloaded code was executed, and no antivirus scan was performed.
