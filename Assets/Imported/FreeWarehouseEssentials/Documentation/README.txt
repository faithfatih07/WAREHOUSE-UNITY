WAREHOUSE ESSENTIALS v1.0
40 Stylized 3D Props
Creator: Akash Jikadra
License: CC0 1.0 Universal. Credit is optional; donations are voluntary.

START HERE
Unity: import Unity/WarehouseEssentials_Unity.unitypackage. Use Prefabs for interactive props; StaticPrefabs for scenery with LOD switching; AnimatedSamples for optional illustrative movement clips. Tested in Unity 6000.6.5f1, Built-in Render Pipeline / Standard shader. URP and HDRP are not verified.
Unreal: start with Models/Static_FBX_UCX for static meshes with named collision proxies. Models/Unreal_Parts contains individual mesh parts exported at their own pivots for Blueprint assembly. Unreal has NOT been run or validated for this pack; there is no native .uproject or Blueprint package.
Blender: open Source/WarehouseEssentials.blend. Use the scene selector for Warehouse_DAY, Warehouse_NIGHT, or ASSET_OVERVIEW. Day and night are Blender lighting demonstrations, not Unity/Unreal scenes.

CONTENTS
- 40 interactive FBX models and 40 interactive GLB models.
- 40 joined static FBX models with UCX collision boxes.
- 40 lower-detail static FBX models.
- 90 individual-part FBX files with own pivots and UCX boxes.
- 17 illustrative rigid-object animation FBX files.
- 40 Unity interactive prefabs, 40 Unity static LOD prefabs, 17 Unity animation sample prefabs.
- Shared palette textures and coordinated base-color variants.
- Latest editable Blender scenes and source hierarchies.
- Asset manifest, material map, validation results and setup guides.

USAGE
Everything in this original asset collection is dedicated under CC0 to the extent of rights held by Akash Jikadra. Personal and commercial use, modification and redistribution are permitted without required attribution. Donations are optional and do not change the license. See LICENSE.txt for the official legal text.

ANIMATION
The 40 prop roots support whole-object movement. Separate parts are provided where applicable for lids, doors, flaps, wheels, rollers, a fan rotor, drawer/jaw, gas valve, and folding ladder/sign frames. The ladder's paired spreader links use matching baked transforms. The 17 clips are demonstration motions, not gameplay controllers or physically simulated machinery. AnimatedSamples in Unity are visual examples without the interactive prefabs' colliders. To build gameplay, animate the corresponding child transforms on an interactive prefab and use an appropriate physics setup.
The packed standalone model rest pose is frame 1. Samples use frames 1-61. Shelf pull-out choreography belongs to the assembled Blender scene; the standalone tote clip lifts its lid and assumes surrounding clearance.
No cloth, hose deformation, character rigging, hydraulic coupling, destruction, or architectural shutter animation is included.

PERFORMANCE / QUALITY
Static LOD0 total: 59,484 triangles across 40 unique models. Optional LOD1 total: 37,512 triangles. Models use compact shared palette textures. Static versions are joined; interactive versions keep moving components separate. Colliders are approximate boxes rather than detailed render-mesh physics. Geometry, units, UV2, materials, collider construction, hierarchy and sampled animation import were checked in Unity. These are import checks, not runtime FPS benchmarks, device profiles, light-bake tests, or physics gameplay validation.

MATERIALS
Use each asset's base-color texture from Documentation/MaterialMap.json. Available coordinated variants include original, navy, rust, sage, cream and blue. Set base color to sRGB and metallic/roughness to linear data. Use point/nearest filtering and no palette mipmaps to avoid swatch bleeding. Unity uses metallic in red and smoothness in alpha of Warehouse_MetallicSmoothness.png. GLB embeds a PBR material. FBX material import may require manual assignment in other engines. The Blender tripod face uses additional emission logic; recreate that emission and add actual lights if desired in an engine.

CREATION
Created in Blender with AI-assisted procedural modeling, scripting, scene editing and copywriting. Promotional images are actual Blender renders. No third-party models or font files are distributed.
