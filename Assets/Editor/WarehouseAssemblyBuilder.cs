using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Phase 3 scene assembler. Regeneration is deliberately scoped to the single
/// WAREHOUSE_FINAL_ROOT object in Warehouse_Final.unity.
/// </summary>
public static class WarehouseAssemblyBuilder
{
    private const string FinalScenePath = "Assets/Scenes/Warehouse_Final.unity";
    private const string BaselineScenePath = "Assets/Scenes/Warehouse_Blockout.unity";
    private const string FinalRootName = "WAREHOUSE_FINAL_ROOT";
    private const string ReferenceRootName = "WAREHOUSE_BLOCKOUT_REFERENCE";
    private const string MaterialFolder = "Assets/Materials/WarehouseFinal";

    private static readonly Dictionary<string, Material> Mats = new Dictionary<string, Material>();
    private static readonly float[] RackXs = { 4.5f, 10f, 15.5f, 21f, 26.5f };

    [MenuItem("Warehouse/Phase 3/Regenerate Final Warehouse")]
    public static void RegenerateFinal()
    {
        EnsureFolder("Assets/Materials", "WarehouseFinal");
        CreateMaterials();
        if (!AssetDatabase.LoadAssetAtPath<SceneAsset>(FinalScenePath))
        {
            if (!AssetDatabase.CopyAsset(BaselineScenePath, FinalScenePath))
                throw new InvalidOperationException("Could not copy the preserved blockout scene to " + FinalScenePath);
            AssetDatabase.Refresh();
        }

        Scene scene = EditorSceneManager.OpenScene(FinalScenePath, OpenSceneMode.Single);
        GameObject reference = FindRoot(scene, "WAREHOUSE_ROOT");
        if (reference != null)
        {
            reference.name = ReferenceRootName;
            reference.SetActive(false);
        }
        else
        {
            reference = FindRoot(scene, ReferenceRootName);
            if (reference == null)
                throw new InvalidOperationException("Copied blockout reference root is missing; refusing to build over an unexpected scene.");
            reference.SetActive(false);
        }

        GameObject prior = FindRoot(scene, FinalRootName);
        if (prior != null) UnityEngine.Object.DestroyImmediate(prior);
        GameObject root = new GameObject(FinalRootName);
        SceneManager.MoveGameObjectToScene(root, scene);

        BuildEnvironment(root.transform);
        EditorSceneManager.MarkSceneDirty(scene);
        EditorSceneManager.SaveScene(scene);
        AssetDatabase.SaveAssets();
        Debug.Log("WarehouseAssemblyBuilder: assembled " + FinalScenePath + " with a preserved disabled blockout reference.");
    }

    private static GameObject FindRoot(Scene scene, string name)
    {
        foreach (GameObject go in scene.GetRootGameObjects()) if (go.name == name) return go;
        return null;
    }

    private static void EnsureFolder(string parent, string child)
    {
        string path = parent + "/" + child;
        if (!AssetDatabase.IsValidFolder(path)) AssetDatabase.CreateFolder(parent, child);
    }

    private static void CreateMaterials()
    {
        Mats.Clear();
        AddMat("Concrete", new Color(0.36f, 0.39f, 0.40f), 0.08f, 0.25f);
        AddMat("ConcreteLight", new Color(0.48f, 0.50f, 0.49f), 0.04f, 0.18f);
        AddMat("Steel", new Color(0.19f, 0.25f, 0.29f), 0.68f, 0.36f);
        AddMat("SteelLight", new Color(0.39f, 0.46f, 0.49f), 0.52f, 0.32f);
        AddMat("Roof", new Color(0.31f, 0.37f, 0.39f), 0.24f, 0.4f);
        AddMat("RoofLight", new Color(0.52f, 0.58f, 0.57f), 0.2f, 0.3f);
        AddMat("Glass", new Color(0.12f, 0.34f, 0.43f, 0.42f), 0.1f, 0.7f);
        AddMat("SafetyYellow", new Color(0.98f, 0.61f, 0.06f), 0.12f, 0.28f);
        AddMat("SafetyWhite", new Color(0.86f, 0.87f, 0.82f), 0.02f, 0.25f);
        AddMat("ZoneBlue", new Color(0.14f, 0.31f, 0.38f), 0.12f, 0.3f);
        AddMat("ZoneGreen", new Color(0.22f, 0.40f, 0.31f), 0.1f, 0.28f);
        AddMat("ZoneAmber", new Color(0.66f, 0.37f, 0.12f), 0.12f, 0.3f);
        AddMat("Wood", new Color(0.38f, 0.25f, 0.14f), 0.02f, 0.22f);
        AddMat("Rubber", new Color(0.08f, 0.09f, 0.09f), 0.02f, 0.08f);
        AddMat("Pale", new Color(0.74f, 0.73f, 0.67f), 0.04f, 0.3f);
    }

    private static void AddMat(string key, Color color, float metallic, float smoothness)
    {
        string path = MaterialFolder + "/WF_" + key + ".mat";
        Material mat = AssetDatabase.LoadAssetAtPath<Material>(path);
        if (mat == null)
        {
            Shader shader = Shader.Find("Universal Render Pipeline/Lit");
            if (shader == null) shader = Shader.Find("Standard");
            mat = new Material(shader);
            AssetDatabase.CreateAsset(mat, path);
        }
        mat.name = "WF_" + key;
        mat.color = color;
        if (mat.HasProperty("_Metallic")) mat.SetFloat("_Metallic", metallic);
        if (mat.HasProperty("_Smoothness")) mat.SetFloat("_Smoothness", smoothness);
        if (key == "Glass" && mat.HasProperty("_Surface"))
        {
            mat.SetFloat("_Surface", 1f);
            mat.SetFloat("_Blend", 0f);
            mat.renderQueue = 3000;
            mat.EnableKeyword("_SURFACE_TYPE_TRANSPARENT");
        }
        EditorUtility.SetDirty(mat);
        Mats[key] = mat;
    }

    private static Transform Group(Transform parent, string name)
    {
        GameObject go = new GameObject(name);
        go.transform.SetParent(parent, false);
        return go.transform;
    }

    private static GameObject Box(Transform parent, string name, Vector3 position, Vector3 size, Material material)
    {
        GameObject go = GameObject.CreatePrimitive(PrimitiveType.Cube);
        go.name = name;
        go.transform.SetParent(parent, false);
        go.transform.localPosition = position;
        go.transform.localScale = size;
        Renderer renderer = go.GetComponent<Renderer>();
        renderer.sharedMaterial = material;
        go.isStatic = true;
        return go;
    }

    private static GameObject Cyl(Transform parent, string name, Vector3 position, Vector3 size, Material material)
    {
        GameObject go = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
        go.name = name;
        go.transform.SetParent(parent, false);
        go.transform.localPosition = position;
        go.transform.localScale = size;
        go.GetComponent<Renderer>().sharedMaterial = material;
        go.isStatic = true;
        return go;
    }

    private static GameObject Model(Transform parent, string assetPath, string name, Vector3 position, float yaw, float scale)
    {
        GameObject prefab = AssetDatabase.LoadAssetAtPath<GameObject>(assetPath);
        if (prefab == null)
        {
            Debug.LogError("WarehouseAssemblyBuilder: missing imported model " + assetPath);
            return null;
        }
        GameObject instance = PrefabUtility.InstantiatePrefab(prefab) as GameObject;
        if (instance == null) instance = UnityEngine.Object.Instantiate(prefab);
        Vector3 importedRootScale = instance.transform.localScale;
        Quaternion importedRootRotation = instance.transform.localRotation;
        instance.name = name;
        instance.transform.SetParent(parent, false);
        instance.transform.localPosition = position;
        instance.transform.localRotation = Quaternion.Euler(0f, yaw, 0f) * importedRootRotation;
        // Imported FBX roots carry a 100x unit-conversion scale and the rack GLB
        // carries a 4.35x scale. Keep those verified importer transforms intact.
        instance.transform.localScale = importedRootScale * scale;
        return instance;
    }

    private static string Gap(string model) { return "Assets/Imported/FreeWarehouseGapAssets/Models/" + model + ".glb"; }
    private static string Essentials(string model) { return "Assets/Imported/FreeWarehouseEssentials/Models/" + model + ".fbx"; }

    private static void BuildEnvironment(Transform root)
    {
        Transform arch = Group(root, "ARCHITECTURE");
        Transform roof = Group(root, "ROOF_STRUCTURE");
        Transform roofPanels = Group(root, "ROOF_PANELS_AND_SKYLIGHTS");
        Transform marks = Group(root, "FLOOR_MARKINGS_AND_ZONE_SIGNS");
        Transform storage = Group(root, "STORAGE_RACKS_AND_STOCK");
        Transform ops = Group(root, "SORTING_AND_CONVEYOR");
        Transform office = Group(root, "OFFICE_CONTROL");
        Transform receive = Group(root, "RECEIVING_AND_INSPECTION");
        Transform pack = Group(root, "PACKING_AND_ASSEMBLY");
        Transform dispatch = Group(root, "DISPATCH_AND_OUTBOUND");
        Transform docks = Group(root, "LOADING_DOCKS_AND_VEHICLES");
        Transform exterior = Group(root, "EXTERIOR_APRON_AND_STAGING");
        Transform cameras = Group(root, "CAMERAS");
        Transform light = Group(root, "PROVISIONAL_INSPECTION_LIGHTING");

        BuildShell(arch, roof, roofPanels);
        BuildFloor(arch, marks);
        BuildStorage(storage);
        BuildConveyor(ops);
        BuildOffice(office);
        BuildReceiving(receive);
        BuildPacking(pack);
        BuildDispatch(dispatch);
        BuildDocks(docks, exterior);
        BuildSigns(marks);
        BuildCamera(cameras);
        BuildProvisionalLight(light);
    }

    private static void BuildShell(Transform arch, Transform roof, Transform panels)
    {
        Box(arch, "Floor_Slab_60x40m", new Vector3(30f, -0.2f, 20f), new Vector3(60f, 0.4f, 40f), Mats["Concrete"]);
        // Perimeter concrete upstand and metal cladding; south facade is split into three dock openings.
        Box(arch, "North_Concrete_Curb", new Vector3(30f, 0.45f, 39.65f), new Vector3(60f, 0.9f, 0.7f), Mats["ConcreteLight"]);
        Box(arch, "West_Concrete_Curb", new Vector3(0.35f, 0.45f, 20f), new Vector3(0.7f, 0.9f, 40f), Mats["ConcreteLight"]);
        Box(arch, "East_Concrete_Curb", new Vector3(59.65f, 0.45f, 20f), new Vector3(0.7f, 0.9f, 40f), Mats["ConcreteLight"]);
        WallPanel(arch, "North_Wall", new Vector3(30f, 4.9f, 39.8f), new Vector3(59.3f, 8.0f, 0.4f));
        WallPanel(arch, "West_Wall", new Vector3(0.2f, 4.9f, 20f), new Vector3(0.4f, 8.0f, 39.3f));
        WallPanel(arch, "East_Wall", new Vector3(59.8f, 4.9f, 20f), new Vector3(0.4f, 8.0f, 39.3f));

        float[] doorX = { 40f, 47f, 54f };
        float opening = 4.4f;
        float cursor = 0f;
        int seg = 0;
        foreach (float center in doorX)
        {
            float start = center - opening * 0.5f;
            float width = start - cursor;
            if (width > 0.05f) WallPanel(arch, "South_Wall_Segment_" + seg++, new Vector3(cursor + width * 0.5f, 4.9f, 0.2f), new Vector3(width, 8.0f, 0.4f));
            Box(arch, "Dock_Portal_Left_" + center, new Vector3(start, 4.65f, 0.05f), new Vector3(0.22f, 8.7f, 0.32f), Mats["Steel"]);
            Box(arch, "Dock_Portal_Right_" + center, new Vector3(center + opening * 0.5f, 4.65f, 0.05f), new Vector3(0.22f, 8.7f, 0.32f), Mats["Steel"]);
            Box(arch, "Dock_Head_" + center, new Vector3(center, 8.95f, 0.05f), new Vector3(opening + 0.4f, 0.3f, 0.45f), Mats["Steel"]);
            // Retractable overhead door is represented as visible horizontal slats above the dock bay.
            for (int i = 0; i < 8; i++) Box(arch, "Overhead_Door_" + center + "_Slat_" + i, new Vector3(center, 1.4f + i * 0.78f, 0.24f), new Vector3(opening - 0.35f, 0.07f, 0.12f), Mats["SteelLight"]);
            cursor = center + opening * 0.5f;
        }
        if (cursor < 60f) WallPanel(arch, "South_Wall_Segment_Last", new Vector3((cursor + 60f) * 0.5f, 4.9f, 0.2f), new Vector3(60f - cursor, 8f, 0.4f));

        // Structural portal frames every 10 m along the long facade; rafters span the 40 m depth.
        for (int x = 0; x <= 60; x += 10)
        {
            Box(roof, "Portal_Column_W_" + x, new Vector3(x, 4.5f, 0.55f), new Vector3(0.5f, 9f, 0.5f), Mats["Steel"]);
            Box(roof, "Portal_Column_E_" + x, new Vector3(x, 4.5f, 39.45f), new Vector3(0.5f, 9f, 0.5f), Mats["Steel"]);
            Box(roof, "Rafter_South_" + x, new Vector3(x, 9.15f, 10f), new Vector3(0.3f, 0.32f, 19.2f), Mats["Steel"]);
            Box(roof, "Rafter_North_" + x, new Vector3(x, 9.15f, 30f), new Vector3(0.3f, 0.32f, 19.2f), Mats["Steel"]);
            Box(roof, "Ridge_Girder_" + x, new Vector3(x, 9.5f, 20f), new Vector3(0.36f, 0.38f, 2.2f), Mats["SteelLight"]);
            if (x < 60)
            {
                for (int z = 5; z <= 35; z += 10)
                    Box(roof, "Purlin_" + x + "_" + z, new Vector3(x + 5f, 9.45f, z), new Vector3(9.9f, 0.18f, 0.2f), Mats["Steel"]);
                // Diagonal web members add legible truss depth without filling the interior with columns.
                Beam(roof, "Truss_Web_A_" + x, new Vector3(x, 8.55f, 10f), new Vector3(x, 9.45f, 20f), 0.16f, Mats["SteelLight"]);
                Beam(roof, "Truss_Web_B_" + x, new Vector3(x, 9.45f, 20f), new Vector3(x, 8.55f, 30f), 0.16f, Mats["SteelLight"]);
            }
        }

        // Real roof panels remain in the scene under their own root; hide the roof skin for cutaway review.
        for (int x = 0; x < 60; x += 10)
        {
            Box(panels, "Roof_Panel_South_" + x, new Vector3(x + 5f, 9.72f, 10f), new Vector3(9.9f, 0.18f, 19.6f), Mats["Roof"]);
            Box(panels, "Roof_Panel_North_" + x, new Vector3(x + 5f, 9.72f, 30f), new Vector3(9.9f, 0.18f, 19.6f), Mats["Roof"]);
            Box(panels, "Skylight_South_" + x, new Vector3(x + 5f, 9.83f, 10f), new Vector3(2.1f, 0.08f, 18.8f), Mats["Glass"]);
            Box(panels, "Skylight_North_" + x, new Vector3(x + 5f, 9.83f, 30f), new Vector3(2.1f, 0.08f, 18.8f), Mats["Glass"]);
        }
        panels.gameObject.SetActive(false);
    }

    private static void WallPanel(Transform parent, string name, Vector3 pos, Vector3 size)
    {
        Box(parent, name + "_Cladding", pos, size, Mats["RoofLight"]);
        // Narrow vertical ribs every 1.2m distinguish industrial metal skin from a flat blockout wall.
        bool northSouth = size.x > size.z;
        float length = northSouth ? size.x : size.z;
        int count = Mathf.Max(1, Mathf.FloorToInt(length / 1.2f));
        for (int i = 0; i <= count; i++)
        {
            float offset = -length * 0.5f + length * i / count;
            Vector3 ribPos = pos + (northSouth ? new Vector3(offset, 0f, -size.z * 0.55f) : new Vector3(-size.x * 0.55f, 0f, offset));
            Vector3 ribSize = northSouth ? new Vector3(0.06f, size.y, 0.07f) : new Vector3(0.07f, size.y, 0.06f);
            Box(parent, name + "_Rib_" + i, ribPos, ribSize, Mats["SteelLight"]);
        }
    }

    private static void Beam(Transform parent, string name, Vector3 a, Vector3 b, float thickness, Material mat)
    {
        Vector3 delta = b - a;
        GameObject go = Box(parent, name, (a + b) * 0.5f, new Vector3(thickness, delta.magnitude, thickness), mat);
        go.transform.rotation = Quaternion.FromToRotation(Vector3.up, delta.normalized);
    }

    private static void BuildFloor(Transform arch, Transform marks)
    {
        // Apron is 23.5 m clear south of the facade; its east edge aligns with the apron bounds.
        Box(arch, "Truck_Apron_23m", new Vector3(47f, -0.19f, -12f), new Vector3(26f, 0.38f, 24f), Mats["ConcreteLight"]);
        Box(arch, "Apron_Edge_Curb", new Vector3(47f, 0.02f, -24f), new Vector3(26f, 0.16f, 0.22f), Mats["Concrete"]);
        // Painted dock lanes and vehicle approach markings.
        for (int i = 0; i < 3; i++)
        {
            float x = 40f + i * 7f;
            Box(marks, "Apron_Lane_Left_" + i, new Vector3(x - 2.5f, 0.015f, -12f), new Vector3(0.12f, 0.02f, 21f), Mats["SafetyWhite"]);
            Box(marks, "Apron_Lane_Right_" + i, new Vector3(x + 2.5f, 0.015f, -12f), new Vector3(0.12f, 0.02f, 21f), Mats["SafetyWhite"]);
            Box(marks, "Dock_Safety_Line_" + i, new Vector3(x, 0.025f, -1.25f), new Vector3(5.2f, 0.025f, 0.18f), Mats["SafetyYellow"]);
            for (int d = 0; d < 4; d++) Box(marks, "Dock_Hatch_" + i + "_" + d, new Vector3(x - 2.15f + d * 1.43f, 0.028f, 1.6f), new Vector3(0.8f, 0.025f, 2.2f), Mats["SafetyYellow"]);
        }
        // Forklift spine and footpath are markings only; keep their travel surfaces unobstructed.
        Box(marks, "Forklift_Spine_West_Edge", new Vector3(32f, 0.018f, 20f), new Vector3(0.12f, 0.02f, 34f), Mats["SafetyYellow"]);
        Box(marks, "Forklift_Spine_East_Edge", new Vector3(36f, 0.018f, 20f), new Vector3(0.12f, 0.02f, 34f), Mats["SafetyYellow"]);
        Box(marks, "Pedestrian_Route_West", new Vector3(2.1f, 0.018f, 20f), new Vector3(1.8f, 0.02f, 35f), Mats["ZoneBlue"]);
        Box(marks, "Pedestrian_Route_Office", new Vector3(18f, 0.02f, 30.6f), new Vector3(28f, 0.025f, 0.16f), Mats["SafetyYellow"]);

        Zone(markers: marks, "STORAGE", new Vector3(17f, 0.025f, 5.1f), new Vector3(28f, 0.025f, 0.18f), Mats["ZoneBlue"]);
        Zone(marks, "RECEIVING", new Vector3(22f, 0.025f, 38.3f), new Vector3(16f, 0.025f, 0.18f), Mats["ZoneGreen"]);
        Zone(marks, "SORTING", new Vector3(47f, 0.025f, 30.8f), new Vector3(18f, 0.025f, 0.18f), Mats["ZoneAmber"]);
        Zone(marks, "PACKING", new Vector3(47f, 0.025f, 11.2f), new Vector3(18f, 0.025f, 0.18f), Mats["ZoneGreen"]);
        Zone(marks, "DISPATCH", new Vector3(47f, 0.025f, 2.2f), new Vector3(18f, 0.025f, 0.18f), Mats["ZoneAmber"]);
    }

    private static void Zone(Transform markers, string label, Vector3 pos, Vector3 size, Material mat)
    {
        Box(markers, "Zone_Band_" + label, pos, size, mat);
        GameObject text = new GameObject("Zone_Label_" + label);
        text.transform.SetParent(markers, false);
        text.transform.localPosition = pos + new Vector3(0f, 0.08f, 0.45f);
        text.transform.localRotation = Quaternion.Euler(90f, 0f, 0f);
        TextMesh tm = text.AddComponent<TextMesh>();
        tm.text = label;
        tm.anchor = TextAnchor.MiddleCenter;
        tm.alignment = TextAlignment.Center;
        tm.characterSize = 0.3f;
        tm.fontSize = 36;
        tm.color = new Color(0.91f, 0.9f, 0.83f);
        tm.font = Resources.GetBuiltinResource<Font>("LegacyRuntime.ttf");
    }

    private static void BuildStorage(Transform parent)
    {
        float[] zCenters = { 15.3f, 24.3f };
        int count = 0;
        for (int row = 0; row < RackXs.Length; row++)
        {
            foreach (float z in zCenters)
            {
                GameObject rack = Model(parent, Gap("Steel_Pallet_Rack_L0"), "Rack_Row_" + (row + 1) + "_Module_" + (z < 20 ? "South" : "North"), new Vector3(RackXs[row], 2.5f, z), 90f, 1f);
                if (rack != null) count++;
                // Match the rack module's three bays at two stocking tiers; keep aisle-facing ends open.
                for (int bay = 0; bay < 3; bay++)
                {
                    float stockZ = z + (bay - 1) * 2.65f;
                    for (int level = 0; level < 2; level++)
                    {
                        float stockY = level == 0 ? 0f : 2.55f;
                        GameObject pallet = Model(parent, Essentials("Pallet"), "Stock_Pallet_" + row + "_" + z + "_" + bay + "_" + level, new Vector3(RackXs[row], stockY, stockZ), 90f, 1f);
                        if (pallet != null)
                        {
                            string cargo = ((row + bay + level) % 3 == 0) ? "Crate_Large" : (((row + bay + level) % 2 == 0) ? "Box_Medium" : "Crate_Small");
                            string cpath = Essentials(cargo);
                            float cargoY = level == 0 ? 0.2f : 2.75f;
                            Model(parent, cpath, "Stock_" + row + "_" + z + "_" + bay + "_" + level, new Vector3(RackXs[row], cargoY, stockZ), 90f, 1f);
                        }
                    }
                }
            }
        }
        // End-of-row protection and compact aisle-end stock buffers, outside cross-aisle turning zones.
        for (int row = 0; row < RackXs.Length; row++)
        {
            Box(parent, "Rack_End_Guard_S_" + row, new Vector3(RackXs[row], 0.38f, 9.4f), new Vector3(1.5f, 0.76f, 0.18f), Mats["SafetyYellow"]);
            Box(parent, "Rack_End_Guard_N_" + row, new Vector3(RackXs[row], 0.38f, 30.2f), new Vector3(1.5f, 0.76f, 0.18f), Mats["SafetyYellow"]);
        }
        Debug.Log("WarehouseAssemblyBuilder: placed " + count + " rack modules (target 10).");
    }

    private static void BuildConveyor(Transform parent)
    {
        // Four straight modules form a 16 m east-west sorting run, with transfer and curved return.
        string straight = Gap("Conveyor_Roller_Straight_L0");
        Model(parent, straight, "Sort_Conveyor_Straight_A", new Vector3(43f, 0f, 24f), 90f, 1f);
        Model(parent, straight, "Sort_Conveyor_Straight_B", new Vector3(47f, 0f, 24f), 90f, 1f);
        Model(parent, straight, "Sort_Conveyor_Straight_C", new Vector3(51f, 0f, 24f), 90f, 1f);
        Model(parent, straight, "Sort_Conveyor_Straight_D", new Vector3(55f, 0f, 24f), 90f, 1f);
        Model(parent, Gap("Conveyor_Belt_Transfer_L0"), "Sort_Belt_Transfer", new Vector3(40.7f, 0f, 24f), 90f, 1f);
        Model(parent, Gap("Conveyor_Roller_Curve_L0"), "Sort_Conveyor_Curve", new Vector3(57f, 0f, 24.8f), 90f, 1f);
        // Inspection work surface, bins and operator access on the clear south side of the conveyor.
        WorkTable(parent, "Sort_Inspection_Table", new Vector3(44f, 0f, 20f), 3.0f, 0.9f);
        Model(parent, Essentials("Open_Carton"), "Sort_Open_Carton", new Vector3(44f, 0.95f, 20f), 0f, 1f);
        Model(parent, Essentials("Box_Small"), "Sort_Small_Box", new Vector3(46f, 0.95f, 20f), 0f, 1f);
        Model(parent, Essentials("Box_Medium"), "Conveyor_Load_01", new Vector3(43f, 1f, 24f), 90f, 1f);
        Model(parent, Essentials("Box_Small"), "Conveyor_Load_02", new Vector3(47f, 1f, 24f), 90f, 1f);
        Model(parent, Essentials("Crate_Small"), "Conveyor_Load_03", new Vector3(51f, 1f, 24f), 90f, 1f);
        Model(parent, Essentials("Open_Carton"), "Conveyor_Load_04", new Vector3(55f, 1f, 24f), 90f, 1f);
        Box(parent, "Sorting_Safety_Exclusion_South", new Vector3(48f, 0.025f, 18.6f), new Vector3(17f, 0.025f, 0.12f), Mats["SafetyYellow"]);
    }

    private static void BuildOffice(Transform parent)
    {
        // Enclosed south-west office (X 2–13, Z 31–38), with glazed upper panels and a clear doorway.
        Box(parent, "Office_West_Wall", new Vector3(2.15f, 1.65f, 34.5f), new Vector3(0.3f, 3.3f, 7.2f), Mats["Pale"]);
        Box(parent, "Office_North_Wall", new Vector3(7.5f, 1.65f, 38.05f), new Vector3(10.7f, 3.3f, 0.3f), Mats["Pale"]);
        Box(parent, "Office_East_Wall", new Vector3(12.85f, 1.65f, 34.5f), new Vector3(0.3f, 3.3f, 7.2f), Mats["Pale"]);
        Box(parent, "Office_South_Left", new Vector3(4.6f, 1.65f, 30.95f), new Vector3(5.2f, 3.3f, 0.3f), Mats["Pale"]);
        Box(parent, "Office_South_Right", new Vector3(11.15f, 1.65f, 30.95f), new Vector3(3.4f, 3.3f, 0.3f), Mats["Pale"]);
        Box(parent, "Office_Glazing_North", new Vector3(7.5f, 2.45f, 37.86f), new Vector3(9.9f, 1.55f, 0.06f), Mats["Glass"]);
        Box(parent, "Office_Glazing_East", new Vector3(12.65f, 2.45f, 34.5f), new Vector3(0.06f, 1.55f, 6.3f), Mats["Glass"]);
        Box(parent, "Office_Door", new Vector3(8.6f, 1.1f, 30.95f), new Vector3(1.3f, 2.2f, 0.08f), Mats["Steel"]);
        Box(parent, "Office_Counter", new Vector3(6.3f, 0.9f, 34.7f), new Vector3(2.2f, 0.18f, 0.85f), Mats["Wood"]);
        Box(parent, "Office_Counter_Base", new Vector3(6.3f, 0.44f, 34.7f), new Vector3(1.95f, 0.88f, 0.62f), Mats["Steel"]);
        Box(parent, "Office_Control_Desk", new Vector3(10.1f, 0.78f, 34.7f), new Vector3(2.1f, 0.15f, 0.85f), Mats["Wood"]);
        Box(parent, "Office_Monitor", new Vector3(10.1f, 1.34f, 34.98f), new Vector3(0.82f, 0.55f, 0.08f), Mats["Steel"]);
        Box(parent, "Office_Monitor_Screen", new Vector3(10.1f, 1.35f, 34.925f), new Vector3(0.7f, 0.42f, 0.025f), Mats["ZoneBlue"]);
        Model(parent, Essentials("Double_Locker"), "Office_Double_Locker", new Vector3(3.7f, 0f, 36.7f), 0f, 1f);
        Model(parent, Essentials("Electrical_Cabinet"), "Office_Control_Cabinet", new Vector3(11.5f, 0f, 36.8f), 180f, 1f);
        Zone(parent, "OFFICE / CONTROL", new Vector3(7.5f, 0.035f, 32f), new Vector3(8.8f, 0.03f, 0.14f), Mats["ZoneBlue"]);
    }

    private static void BuildReceiving(Transform parent)
    {
        for (int i = 0; i < 5; i++)
        {
            float x = 16.5f + i * 2.8f;
            Model(parent, Essentials("Pallet"), "Receiving_Pallet_" + i, new Vector3(x, 0f, 34.2f), 0f, 1f);
            Model(parent, Essentials(i % 2 == 0 ? "Crate_Large" : "Box_Medium"), "Receiving_Load_" + i, new Vector3(x, 0.2f, 34.2f), 0f, 1f);
        }
        WorkTable(parent, "Receiving_Inspection_Bench", new Vector3(22f, 0f, 31.8f), 3.4f, 0.95f);
        Model(parent, Essentials("Toolbox"), "Receiving_Toolbox", new Vector3(25f, 0f, 32.1f), 90f, 1f);
        Box(parent, "Receiving_Inspection_Bay", new Vector3(22f, 0.025f, 34.2f), new Vector3(16f, 0.025f, 5.8f), Mats["ZoneGreen"]);
        // Bring back the top paint over this translucent-looking bay using thin painted route borders.
        Box(parent, "Receiving_Border_S", new Vector3(22f, 0.035f, 31.25f), new Vector3(16f, 0.03f, 0.12f), Mats["SafetyYellow"]);
        Box(parent, "Receiving_Border_N", new Vector3(22f, 0.035f, 37.15f), new Vector3(16f, 0.03f, 0.12f), Mats["SafetyYellow"]);
    }

    private static void BuildPacking(Transform parent)
    {
        // Original detailed production tables: heavy laminated tops, apron, cross-braced legs, feet and tool rails.
        WorkTable(parent, "Assembly_Table_A", new Vector3(41f, 0f, 15.4f), 3.6f, 0.95f);
        WorkTable(parent, "Assembly_Table_B", new Vector3(47f, 0f, 15.4f), 3.6f, 0.95f);
        WorkTable(parent, "Packing_Table_C", new Vector3(53f, 0f, 15.4f), 3.6f, 0.95f);
        Model(parent, Essentials("Wooden_Spool_Table"), "Assembly_Spool_Table", new Vector3(40.5f, 0f, 12.8f), 0f, 1f);
        Model(parent, Essentials("Workbench_Vise"), "Assembly_Workbench_Vise", new Vector3(42f, 0.98f, 15.4f), 0f, 1f);
        Model(parent, Essentials("Toolbox"), "Assembly_Toolbox", new Vector3(48.8f, 0f, 16.2f), 0f, 1f);
        Model(parent, Essentials("Double_Locker"), "Packing_Locker", new Vector3(55f, 0f, 17.1f), 180f, 1f);
        Model(parent, Essentials("Electrical_Cabinet"), "Packing_Electrical_Cabinet", new Vector3(56.8f, 0f, 17.2f), 180f, 1f);
        Model(parent, Essentials("Open_Carton"), "Packing_Open_Carton_1", new Vector3(47f, 1f, 15.4f), 0f, 1f);
        Model(parent, Essentials("Box_Medium"), "Packing_Box_1", new Vector3(53f, 1f, 15.4f), 0f, 1f);
        // Approved original, detailed enclosed storage cabinet with framed doors, handles, venting and plinth.
        DetailedCabinet(parent, new Vector3(57.2f, 0f, 13.2f));
        Model(parent, Essentials("Pallet_Jack"), "Packing_Pallet_Jack", new Vector3(45f, 0f, 13.0f), 0f, 1f);
    }

    private static void WorkTable(Transform parent, string name, Vector3 basePos, float length, float depth)
    {
        float topY = 0.92f;
        Box(parent, name + "_Steel_Frame", basePos + new Vector3(0f, 0.74f, 0f), new Vector3(length - 0.08f, 0.25f, depth - 0.08f), Mats["Steel"]);
        Box(parent, name + "_Wood_Worktop", basePos + new Vector3(0f, topY, 0f), new Vector3(length, 0.12f, depth), Mats["Wood"]);
        float legOffset = length * 0.5f - 0.16f;
        for (int s = -1; s <= 1; s += 2)
        {
            for (int z = -1; z <= 1; z += 2)
            {
                Box(parent, name + "_Leg_" + s + "_" + z, basePos + new Vector3(s * legOffset, 0.42f, z * (depth * 0.5f - 0.14f)), new Vector3(0.12f, 0.84f, 0.12f), Mats["Steel"]);
                Box(parent, name + "_Foot_" + s + "_" + z, basePos + new Vector3(s * legOffset, 0.07f, z * (depth * 0.5f - 0.14f)), new Vector3(0.22f, 0.08f, 0.2f), Mats["Rubber"]);
            }
        }
        for (int i = 0; i < 3; i++) Box(parent, name + "_Tool_Rail_" + i, basePos + new Vector3(-length * 0.5f + 0.5f + i * 0.62f, 1.1f, -depth * 0.5f + 0.06f), new Vector3(0.06f, 0.34f, 0.07f), Mats["SteelLight"]);
        Box(parent, name + "_Lower_Shelf", basePos + new Vector3(0f, 0.32f, 0f), new Vector3(length - 0.38f, 0.08f, depth - 0.32f), Mats["SteelLight"]);
        Box(parent, name + "_Front_Apron", basePos + new Vector3(0f, 0.64f, -depth * 0.5f + 0.08f), new Vector3(length - 0.3f, 0.28f, 0.08f), Mats["SteelLight"]);
    }

    private static void DetailedCabinet(Transform parent, Vector3 basePos)
    {
        string n = "General_Storage_Cabinet_Original";
        Box(parent, n + "_Carcass", basePos + new Vector3(0f, 1.05f, 0f), new Vector3(1.6f, 2.1f, 0.65f), Mats["Steel"]);
        Box(parent, n + "_Top_Cap", basePos + new Vector3(0f, 2.12f, 0f), new Vector3(1.72f, 0.12f, 0.72f), Mats["SteelLight"]);
        Box(parent, n + "_Toe_Kick", basePos + new Vector3(0f, 0.12f, 0f), new Vector3(1.45f, 0.24f, 0.56f), Mats["Rubber"]);
        for (int d = 0; d < 2; d++)
        {
            float x = d == 0 ? -0.39f : 0.39f;
            Box(parent, n + "_Door_" + d, basePos + new Vector3(x, 1.1f, -0.336f), new Vector3(0.74f, 1.72f, 0.045f), Mats["SteelLight"]);
            Cyl(parent, n + "_Handle_" + d, basePos + new Vector3(x + 0.22f, 1.1f, -0.39f), new Vector3(0.035f, 0.2f, 0.035f), Mats["SafetyYellow"]);
            for (int v = 0; v < 5; v++) Box(parent, n + "_Vent_" + d + "_" + v, basePos + new Vector3(x, 1.7f + v * 0.075f, -0.365f), new Vector3(0.26f, 0.025f, 0.02f), Mats["Steel"]);
        }
        for (int shelf = 0; shelf < 4; shelf++)
        {
            float y = 0.58f + shelf * 0.42f;
            Box(parent, n + "_Interior_Shelf_" + shelf, basePos + new Vector3(0f, y, 0.02f), new Vector3(1.35f, 0.05f, 0.52f), Mats["Pale"]);
            if (shelf < 3) Box(parent, n + "_Shelf_Lip_" + shelf, basePos + new Vector3(0f, y + 0.05f, -0.235f), new Vector3(1.35f, 0.07f, 0.035f), Mats["SafetyYellow"]);
        }
        Box(parent, n + "_Asset_Plate", basePos + new Vector3(0f, 2.0f, -0.38f), new Vector3(0.32f, 0.12f, 0.025f), Mats["ZoneBlue"]);
    }

    private static void BuildDispatch(Transform parent)
    {
        float[] xs = { 40f, 45.5f, 51f, 56.5f };
        for (int i = 0; i < xs.Length; i++)
        {
            Model(parent, Essentials("Pallet"), "Dispatch_Pallet_" + i, new Vector3(xs[i], 0f, 7.4f), 0f, 1f);
            Model(parent, Essentials(i % 2 == 0 ? "Crate_Large" : "Box_Medium"), "Dispatch_Load_" + i, new Vector3(xs[i], 0.2f, 7.4f), 0f, 1f);
        }
        Model(parent, Essentials("Pallet_Jack"), "Dispatch_Pallet_Jack_1", new Vector3(43f, 0f, 5f), 90f, 1f);
        Model(parent, Essentials("Pallet_Jack"), "Dispatch_Pallet_Jack_2", new Vector3(55f, 0f, 5f), 90f, 1f);
        Model(parent, Gap("Forklift_L0"), "Dispatch_Parked_Forklift", new Vector3(37.5f, 0f, 8.2f), 0f, 1f);
        // Staging lanes are painted as thin borders; central aisle remains open for turns.
        for (int i = 0; i < 4; i++)
        {
            float x = 39f + i * 5.5f;
            Box(parent, "Dispatch_Staging_Line_" + i, new Vector3(x, 0.025f, 4f), new Vector3(0.1f, 0.025f, 5.2f), Mats["SafetyYellow"]);
        }
    }

    private static void BuildDocks(Transform docks, Transform exterior)
    {
        float[] xs = { 40f, 47f, 54f };
        for (int i = 0; i < xs.Length; i++)
        {
            Model(docks, Gap("Loading_Dock_L0"), "South_Facing_Loading_Dock_" + (i + 1), new Vector3(xs[i], 0f, 0.1f), 180f, 1f);
            // Parked, full-scale vehicles retain their measured source size and face out to apron.
            Model(docks, Gap("Semi_Truck_L0"), "Outbound_Semi_Truck_" + (i + 1), new Vector3(xs[i], 0f, -10f), 180f, 1f);
        }
        // One forklift is stationed inside receiving; one is parked at dispatch but outside the main spine.
        Model(docks, Gap("Forklift_L0"), "Receiving_Forklift", new Vector3(28.6f, 0f, 34.2f), 90f, 1f);
        Model(exterior, Gap("Shipping_Container"), "East_Yard_Staging_Container", new Vector3(62.7f, 0f, 30.5f), 90f, 1f);
        Box(exterior, "Container_Staging_Pad", new Vector3(62.7f, -0.12f, 30.5f), new Vector3(8.2f, 0.24f, 4.2f), Mats["Concrete"]);
    }

    private static void BuildSigns(Transform parent)
    {
        Sign(parent, "OFFICE / CONTROL", new Vector3(7.5f, 4.2f, 30.65f), 0f, Mats["ZoneBlue"]);
        Sign(parent, "RECEIVING & INSPECTION", new Vector3(22f, 5.2f, 38.9f), 180f, Mats["ZoneGreen"]);
        Sign(parent, "SORTING / CONVEYOR", new Vector3(47f, 5.2f, 38.9f), 180f, Mats["ZoneAmber"]);
        Sign(parent, "PACKING / ASSEMBLY", new Vector3(47f, 4.2f, 18.95f), 180f, Mats["ZoneGreen"]);
        Sign(parent, "DISPATCH / OUTBOUND", new Vector3(47f, 4.2f, 10.95f), 180f, Mats["ZoneAmber"]);
    }

    private static void Sign(Transform parent, string label, Vector3 pos, float yaw, Material back)
    {
        Box(parent, "Sign_Board_" + label, pos, new Vector3(5.8f, 0.8f, 0.12f), back);
        GameObject go = new GameObject("Sign_Text_" + label);
        go.transform.SetParent(parent, false);
        go.transform.localPosition = pos + new Vector3(0f, 0f, yaw == 180f ? -0.08f : 0.08f);
        go.transform.localRotation = Quaternion.Euler(0f, yaw, 0f);
        go.transform.localScale = new Vector3(yaw == 180f ? -1f : 1f, 1f, 1f);
        TextMesh tm = go.AddComponent<TextMesh>();
        tm.text = label;
        tm.font = Resources.GetBuiltinResource<Font>("LegacyRuntime.ttf");
        tm.anchor = TextAnchor.MiddleCenter;
        tm.alignment = TextAlignment.Center;
        tm.characterSize = 0.19f;
        tm.fontSize = 36;
        tm.color = Color.white;
    }

    private static void BuildCamera(Transform parent)
    {
        GameObject go = new GameObject("Warehouse_Overview_Camera_Phase3");
        go.transform.SetParent(parent, false);
        go.transform.position = new Vector3(74f, 49f, -38f);
        go.transform.rotation = Quaternion.LookRotation(new Vector3(31f, 2.5f, 8f) - go.transform.position, Vector3.up);
        Camera camera = go.AddComponent<Camera>();
        camera.orthographic = false;
        camera.fieldOfView = 48f;
        camera.nearClipPlane = 0.1f;
        camera.farClipPlane = 250f;
        camera.clearFlags = CameraClearFlags.SolidColor;
        camera.backgroundColor = new Color(0.76f, 0.80f, 0.80f);
        camera.tag = "MainCamera";
        go.AddComponent<AudioListener>();
    }

    private static void BuildProvisionalLight(Transform parent)
    {
        RenderSettings.ambientMode = UnityEngine.Rendering.AmbientMode.Flat;
        RenderSettings.ambientLight = new Color(0.47f, 0.51f, 0.52f);
        GameObject go = new GameObject("Provisional_Directional_Inspection_Light");
        go.transform.SetParent(parent, false);
        go.transform.rotation = Quaternion.Euler(50f, -35f, 0f);
        Light l = go.AddComponent<Light>();
        l.type = LightType.Directional;
        l.intensity = 1.1f;
        l.color = new Color(1f, 0.92f, 0.78f);
        l.shadows = LightShadows.Soft;
    }
}
