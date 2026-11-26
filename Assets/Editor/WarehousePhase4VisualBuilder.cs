using System.IO;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Rendering;

/// <summary>
/// Phase 4 procedural material and visual-detail pass. It is scoped to the
/// Warehouse_Final scene and replaces only WAREHOUSE_PHASE4_DETAIL_ROOT.
/// </summary>
public static class WarehousePhase4VisualBuilder
{
    private const string ScenePath = "Assets/Scenes/Warehouse_Final.unity";
    private const string RootName = "WAREHOUSE_PHASE4_DETAIL_ROOT";
    private const string AssetFolder = "Assets/Materials/WarehousePhase4";
    private const string TextureFolder = AssetFolder + "/Textures";
    private static Material concrete, cladding, steel, wood, joint, yellow, white, fixture, diffuser, skylight;

    [MenuItem("Warehouse/Phase 4/Regenerate Source Textures Only")]
    public static void RegenerateSourceTexturesOnly()
    {
        EnsureFolder("Assets/Materials", "WarehousePhase4");
        EnsureFolder(AssetFolder, "Textures");
        EnsureTextures(true);
        AssetDatabase.SaveAssets();
        Debug.Log("WarehousePhase4VisualBuilder: deterministically regenerated six named source PNGs in place; existing Unity GUIDs were preserved.");
    }

    [MenuItem("Warehouse/Phase 4/Regenerate Visual Transformation")]
    public static void Regenerate()
    {
        Scene scene = SceneManager.GetActiveScene();
        if (scene.path != ScenePath) throw new System.InvalidOperationException("Open Warehouse_Final.unity before running the Phase 4 builder.");
        EnsureFolder("Assets/Materials", "WarehousePhase4");
        EnsureFolder(AssetFolder, "Textures");
        EnsureTextures(false);
        CreateMaterials();
        Transform final = FindRoot(scene, "WAREHOUSE_FINAL_ROOT");
        if (final == null) throw new System.InvalidOperationException("WAREHOUSE_FINAL_ROOT was not found; refusing to modify the scene.");
        ApplyMaterials(final);
        GameObject old = FindRoot(scene, RootName)?.gameObject;
        if (old != null) Object.DestroyImmediate(old);
        GameObject root = new GameObject(RootName);
        SceneManager.MoveGameObjectToScene(root, scene);
        BuildFloorDetail(root.transform);
        BuildRackDetail(root.transform);
        BuildStructureDetail(root.transform);
        BuildLighting(root.transform);
        BuildWorkAreaDetail(root.transform);
        TunePresentation(final);
        EditorSceneManager.MarkSceneDirty(scene);
        EditorSceneManager.SaveScene(scene);
        AssetDatabase.SaveAssets();
        Debug.Log("WarehousePhase4VisualBuilder: regenerated scoped details and industrial material pass in " + ScenePath);
    }

    private static Transform FindRoot(Scene scene, string name)
    {
        foreach (GameObject go in scene.GetRootGameObjects()) if (go.name == name) return go.transform;
        return null;
    }

    private static void EnsureFolder(string parent, string child)
    {
        string path = parent + "/" + child;
        if (!AssetDatabase.IsValidFolder(path)) AssetDatabase.CreateFolder(parent, child);
    }

    private static void EnsureTextures(bool forceRegenerate)
    {
        MakeTexture("Concrete_Albedo", 2048, 2048, 1, false, forceRegenerate);
        MakeTexture("Cladding_Albedo", 1024, 1024, 2, false, forceRegenerate);
        MakeTexture("Timber_Albedo", 1024, 1024, 3, false, forceRegenerate);
        MakeTexture("Steel_Normal", 1024, 1024, 4, true, forceRegenerate);
        MakeTexture("Concrete_Normal", 1024, 1024, 5, true, forceRegenerate);
        MakeTexture("Steel_MetallicSmoothness", 1024, 1024, 6, false, forceRegenerate);
        AssetDatabase.Refresh();
    }

    private static void MakeTexture(string name, int width, int height, int kind, bool normal, bool forceRegenerate)
    {
        string path = TextureFolder + "/" + name + ".png";
        if (File.Exists(path) && !forceRegenerate)
        {
            TextureImporter existing = AssetImporter.GetAtPath(path) as TextureImporter;
            if (existing != null)
            {
                ConfigureTextureImporter(existing, width, normal, kind);
            }
            return;
        }
        Texture2D tex = new Texture2D(width, height, TextureFormat.RGBA32, false, false);
        tex.wrapMode = TextureWrapMode.Repeat;
        Color[] pixels = new Color[width * height];
        for (int y = 0; y < height; y++) for (int x = 0; x < width; x++)
        {
            float u = (float)x / width, v = (float)y / height;
            float n = Mathf.PerlinNoise(u * 31f + 3.7f, v * 31f + 8.1f) * 0.55f + Mathf.PerlinNoise(u * 113f, v * 113f) * 0.24f + Mathf.PerlinNoise(u * 7f, v * 7f) * 0.13f + Mathf.PerlinNoise(u * 317f + 19f, v * 317f + 41f) * 0.08f;
            if (normal)
            {
                float du = (Mathf.PerlinNoise((u + 0.001f) * 31f, v * 31f) - Mathf.PerlinNoise((u - 0.001f) * 31f, v * 31f)) * (kind == 4 ? 2.8f : 0.9f);
                float dv = (Mathf.PerlinNoise(u * 31f, (v + 0.001f) * 31f) - Mathf.PerlinNoise(u * 31f, (v - 0.001f) * 31f)) * 1.8f;
                du += (Mathf.PerlinNoise(u * 251f + 5f, v * 251f + 7f) - Mathf.PerlinNoise(u * 251f - 5f, v * 251f - 7f)) * 0.18f;
                dv += (Mathf.PerlinNoise(u * 251f + 7f, v * 251f + 5f) - Mathf.PerlinNoise(u * 251f - 7f, v * 251f - 5f)) * 0.18f;
                Vector3 nrm = new Vector3(-du, -dv, 1f).normalized;
                pixels[y * width + x] = new Color(nrm.x * 0.5f + 0.5f, nrm.y * 0.5f + 0.5f, nrm.z * 0.5f + 0.5f, 1f);
            }
            else if (kind == 6)
            {
                float ridge = Mathf.Abs(Mathf.Sin(u * Mathf.PI * 58f));
                float metal = 0.72f + n * 0.16f;
                float smooth = 0.32f + (1f - ridge) * 0.24f + n * 0.08f;
                pixels[y * width + x] = new Color(metal, 0f, 0f, smooth);
            }
            else if (kind == 1)
            {
                float fleck = (n - 0.5f) * 0.16f;
                float aggregate = (Mathf.PerlinNoise(u * 137f, v * 137f) - 0.5f) * 0.065f + (Mathf.PerlinNoise(u * 521f, v * 521f) - 0.5f) * 0.022f;
                float c = 0.57f + fleck + aggregate;
                pixels[y * width + x] = new Color(c * 0.98f, c, c * 1.01f, 1f);
            }
            else if (kind == 2)
            {
                float corrugation = Mathf.Pow(Mathf.Abs(Mathf.Sin(u * Mathf.PI * 50f)), 8f) * 0.14f;
                float c = 0.42f + (n - 0.5f) * 0.12f + corrugation;
                pixels[y * width + x] = new Color(c * 0.82f, c * 0.89f, c * 0.9f, 1f);
            }
            else
            {
                float grain = (Mathf.PerlinNoise(u * 17f, v * 186f) - 0.5f) * 0.18f + (n - 0.5f) * 0.1f;
                pixels[y * width + x] = new Color(0.46f + grain, 0.31f + grain * 0.77f, 0.18f + grain * 0.52f, 1f);
            }
        }
        tex.SetPixels(pixels); tex.Apply(false, false);
        File.WriteAllBytes(path, tex.EncodeToPNG());
        Object.DestroyImmediate(tex);
        AssetDatabase.ImportAsset(path, ImportAssetOptions.ForceSynchronousImport);
        TextureImporter importer = AssetImporter.GetAtPath(path) as TextureImporter;
        if (importer != null) ConfigureTextureImporter(importer, width, normal, kind);
    }

    private static void ConfigureTextureImporter(TextureImporter importer, int width, bool normal, int kind)
    {
        importer.textureType = normal ? TextureImporterType.NormalMap : TextureImporterType.Default;
        importer.sRGBTexture = !normal && kind != 6;
        importer.wrapMode = TextureWrapMode.Repeat;
        importer.mipmapEnabled = true;
        importer.filterMode = FilterMode.Trilinear;
        importer.anisoLevel = kind == 1 || kind == 5 ? 4 : 2;
        importer.maxTextureSize = width;
        importer.textureCompression = TextureImporterCompression.CompressedHQ;
        importer.SaveAndReimport();
    }

    private static Texture2D Tex(string name) => AssetDatabase.LoadAssetAtPath<Texture2D>(TextureFolder + "/" + name + ".png");

    private static Material Mat(string name, Color tint, float metal, float smooth, Texture2D albedo, Texture2D normalMap = null, Texture2D metalMap = null)
    {
        string path = AssetFolder + "/" + name + ".mat";
        Material m = AssetDatabase.LoadAssetAtPath<Material>(path);
        Shader shader = Shader.Find("Universal Render Pipeline/Lit");
        if (shader == null) throw new System.InvalidOperationException("URP/Lit shader was not found.");
        if (m == null) { m = new Material(shader); AssetDatabase.CreateAsset(m, path); }
        m.shader = shader; m.color = tint; m.SetFloat("_Metallic", metal); m.SetFloat("_Smoothness", smooth);
        if (albedo != null) { m.SetTexture("_BaseMap", albedo); m.SetTextureScale("_BaseMap", name.Contains("Concrete") ? new Vector2(9f, 7f) : new Vector2(5f, 5f)); }
        if (normalMap != null) { m.SetTexture("_BumpMap", normalMap); m.SetFloat("_BumpScale", name.Contains("Concrete") ? 0.28f : 0.42f); m.EnableKeyword("_NORMALMAP"); }
        if (metalMap != null) { m.SetTexture("_MetallicGlossMap", metalMap); m.EnableKeyword("_METALLICSPECGLOSSMAP"); }
        EditorUtility.SetDirty(m); return m;
    }

    private static void CreateMaterials()
    {
        concrete = Mat("P4_Concrete_PBR", Color.white, 0.04f, 0.23f, Tex("Concrete_Albedo"), Tex("Concrete_Normal"));
        cladding = Mat("P4_Cladding_Corrugated", new Color(0.83f, 0.88f, 0.88f), 0.52f, 0.38f, Tex("Cladding_Albedo"), Tex("Steel_Normal"), Tex("Steel_MetallicSmoothness"));
        steel = Mat("P4_Structural_Steel", new Color(0.45f, 0.52f, 0.55f), 0.7f, 0.42f, Tex("Cladding_Albedo"), Tex("Steel_Normal"), Tex("Steel_MetallicSmoothness"));
        wood = Mat("P4_Sealed_Timber", Color.white, 0.02f, 0.27f, Tex("Timber_Albedo"));
        joint = Mat("P4_Expansion_Joint", new Color(0.16f, 0.18f, 0.18f), 0.02f, 0.12f, null);
        yellow = Mat("P4_Safety_Amber", new Color(0.95f, 0.49f, 0.08f), 0.12f, 0.33f, null);
        white = Mat("P4_Marking_OffWhite", new Color(0.87f, 0.86f, 0.76f), 0.04f, 0.28f, null);
        fixture = Mat("P4_Highbay_Housing", new Color(0.15f, 0.2f, 0.21f), 0.64f, 0.45f, null);
        diffuser = Mat("P4_LED_Diffuser", new Color(0.88f, 0.94f, 1f), 0f, 0.12f, null);
        diffuser.EnableKeyword("_EMISSION"); diffuser.SetColor("_EmissionColor", new Color(1.1f, 1.2f, 1.35f));
        skylight = Mat("P4_Skylight_Polycarbonate", new Color(0.53f, 0.72f, 0.79f, 0.24f), 0.03f, 0.2f, null);
        skylight.SetFloat("_Surface", 1f); skylight.SetFloat("_Blend", 0f); skylight.renderQueue = 3000;
        skylight.SetOverrideTag("RenderType", "Transparent"); skylight.SetFloat("_SrcBlend", 1f); skylight.SetFloat("_DstBlend", 10f); skylight.SetFloat("_SrcBlendAlpha", 1f); skylight.SetFloat("_DstBlendAlpha", 10f); skylight.SetFloat("_ZWrite", 0f);
        skylight.EnableKeyword("_SURFACE_TYPE_TRANSPARENT"); skylight.EnableKeyword("_ALPHAPREMULTIPLY_ON"); skylight.DisableKeyword("_EMISSION");
    }

    private static void ApplyMaterials(Transform final)
    {
        Transform architecture = final.Find("ARCHITECTURE");
        Transform roof = final.Find("ROOF_STRUCTURE");
        Transform panels = final.Find("ROOF_PANELS_AND_SKYLIGHTS");
        if (architecture != null) foreach (Renderer r in architecture.GetComponentsInChildren<Renderer>(true))
        {
            string n = r.gameObject.name;
            if (n == "Floor_Slab_60x40m" || n == "Truck_Apron_23m") r.sharedMaterial = concrete;
            else if (n.Contains("_Cladding")) r.sharedMaterial = cladding;
            else if (n.Contains("_Rib") || n.Contains("Concrete_Curb")) r.sharedMaterial = steel;
        }
        if (roof != null) foreach (Renderer r in roof.GetComponentsInChildren<Renderer>(true)) r.sharedMaterial = steel;
        if (panels != null) foreach (Renderer r in panels.GetComponentsInChildren<Renderer>(true)) r.sharedMaterial = r.gameObject.name.Contains("Skylight") ? skylight : cladding;
        foreach (Renderer r in final.GetComponentsInChildren<Renderer>(true)) if (r.gameObject.name.Contains("Wood_Worktop")) r.sharedMaterial = wood;
    }

    private static GameObject Box(Transform parent, string name, Vector3 pos, Vector3 size, Material mat, float yaw = 0f)
    {
        GameObject go = GameObject.CreatePrimitive(PrimitiveType.Cube); go.name = name; go.transform.SetParent(parent, false); go.transform.localPosition = pos; go.transform.localScale = size; go.transform.localRotation = Quaternion.Euler(0f, yaw, 0f);
        Collider c = go.GetComponent<Collider>(); if (c != null) Object.DestroyImmediate(c);
        go.GetComponent<Renderer>().sharedMaterial = mat; go.isStatic = true; return go;
    }

    private static GameObject Cylinder(Transform parent, string name, Vector3 pos, Vector3 size, Material mat)
    {
        GameObject go = GameObject.CreatePrimitive(PrimitiveType.Cylinder); go.name = name; go.transform.SetParent(parent, false); go.transform.localPosition = pos; go.transform.localScale = size;
        Collider c = go.GetComponent<Collider>(); if (c != null) Object.DestroyImmediate(c); go.GetComponent<Renderer>().sharedMaterial = mat; go.isStatic = true; return go;
    }

    private static void BuildFloorDetail(Transform root)
    {
        Transform g = new GameObject("FLOOR_JOINTS_AND_TRAFFIC_PAINT").transform; g.SetParent(root, false);
        // Saw-cut construction joints, kept very fine and low contrast.
        for (int x = 6; x < 60; x += 6) Box(g, "Expansion_Joint_X_" + x, new Vector3(x, 0.006f, 20f), new Vector3(0.02f, 0.006f, 39.8f), joint);
        for (int z = 6; z < 40; z += 6) Box(g, "Expansion_Joint_Z_" + z, new Vector3(30f, 0.006f, z), new Vector3(59.8f, 0.006f, 0.02f), joint);
        // Forklift aisle directional chevrons and marked pedestrian crossings.
        for (int z = 9; z <= 33; z += 8)
        {
            Box(g, "Spine_Arrow_Left_" + z, new Vector3(33.1f, 0.033f, z), new Vector3(0.09f, 0.022f, 0.56f), white, 42f);
            Box(g, "Spine_Arrow_Right_" + z, new Vector3(34.9f, 0.033f, z), new Vector3(0.09f, 0.022f, 0.56f), white, -42f);
        }
        for (int i = 0; i < 11; i++) Box(g, "West_Crossing_Bar_" + i, new Vector3(1.7f, 0.036f, 17.2f + i * 0.52f), new Vector3(1.55f, 0.02f, 0.24f), white);
        // Loading dock threshold warning stripes.
        for (int bay = 0; bay < 3; bay++) for (int k = 0; k < 6; k++)
            Box(g, "Dock_Threshold_Chevron_" + bay + "_" + k, new Vector3(37.3f + bay * 7f + k * 0.88f, 0.042f, 0.78f), new Vector3(0.11f, 0.018f, 0.9f), yellow, 28f);
    }

    private static void BuildRackDetail(Transform root)
    {
        Transform g = new GameObject("RACK_FOOTPLATES_AND_BAY_ID").transform; g.SetParent(root, false);
        float[] xs = { 4.5f, 10f, 15.5f, 21f, 26.5f }; float[] zs = { 15.3f, 24.3f };
        for (int row = 0; row < xs.Length; row++) for (int mod = 0; mod < zs.Length; mod++)
        {
            float x = xs[row], z = zs[mod];
            for (int end = -1; end <= 1; end += 2) for (int side = -1; side <= 1; side += 2)
            {
                Vector3 p = new Vector3(x + side * 0.58f, 0.035f, z + end * 4.15f);
                Box(g, "Rack_Foot_Plate_" + row + "_" + mod + "_" + side + "_" + end, p, new Vector3(0.38f, 0.06f, 0.34f), steel);
                Cylinder(g, "Rack_Anchor_Bolt_A_" + row + "_" + mod + "_" + side + "_" + end, p + new Vector3(-0.12f, 0.043f, 0f), new Vector3(0.065f, 0.018f, 0.065f), yellow);
                Cylinder(g, "Rack_Anchor_Bolt_B_" + row + "_" + mod + "_" + side + "_" + end, p + new Vector3(0.12f, 0.043f, 0f), new Vector3(0.065f, 0.018f, 0.065f), yellow);
            }
            // Readable aisle-side location card; the rack itself and all stocked props remain unchanged.
            Box(g, "Rack_Bay_ID_Plate_" + row + "_" + mod, new Vector3(x - 0.83f, 4.18f, z), new Vector3(0.035f, 0.38f, 0.62f), yellow);
            TextMesh tm = new GameObject("Rack_Bay_ID_" + (row + 1) + "_" + (mod + 1)).AddComponent<TextMesh>();
            tm.transform.SetParent(g, false); tm.transform.localPosition = new Vector3(x - 0.86f, 4.18f, z); tm.transform.localRotation = Quaternion.Euler(0f, -90f, 0f);
            tm.text = "R" + (row + 1) + "-" + (mod + 1); tm.anchor = TextAnchor.MiddleCenter; tm.alignment = TextAlignment.Center; tm.characterSize = 0.14f; tm.fontSize = 42; tm.color = new Color(0.11f, 0.15f, 0.17f); tm.font = Resources.GetBuiltinResource<Font>("LegacyRuntime.ttf");
        }
    }

    private static void BuildStructureDetail(Transform root)
    {
        Transform g = new GameObject("STEEL_COLUMN_BASES_AND_ROOF_SERVICE").transform; g.SetParent(root, false);
        for (int x = 0; x <= 60; x += 10) for (int side = 0; side < 2; side++)
        {
            float z = side == 0 ? 0.55f : 39.45f;
            Box(g, "Portal_Base_Plate_" + x + "_" + side, new Vector3(x, 0.06f, z), new Vector3(0.82f, 0.12f, 0.82f), steel);
            for (int bx = -1; bx <= 1; bx += 2) for (int bz = -1; bz <= 1; bz += 2)
                Cylinder(g, "Portal_Anchor_" + x + "_" + side + "_" + bx + "_" + bz, new Vector3(x + bx * 0.27f, 0.14f, z + bz * 0.27f), new Vector3(0.09f, 0.035f, 0.09f), yellow);
        }
    }

    private static void BuildLighting(Transform root)
    {
        Transform g = new GameObject("LED_HIGHBAYS_AND_DOCK_WALLPACKS").transform; g.SetParent(root, false);
        float[] xs = { 8f, 20f, 32f, 44f, 56f }; float[] zs = { 8f, 20f, 32f };
        int index = 0;
        foreach (float x in xs) foreach (float z in zs)
        {
            Vector3 p = new Vector3(x, 9.1f, z);
            Box(g, "Highbay_Housing_" + index, p, new Vector3(1.45f, 0.12f, 0.48f), fixture);
            Box(g, "Highbay_LED_Lens_" + index, p + Vector3.down * 0.071f, new Vector3(1.1f, 0.025f, 0.31f), diffuser);
            GameObject lightGo = new GameObject("Highbay_LED_Spot_" + index++); lightGo.transform.SetParent(g, false); lightGo.transform.position = p + Vector3.down * 0.14f;
            Light l = lightGo.AddComponent<Light>(); l.type = LightType.Spot; l.color = new Color(0.84f, 0.9f, 1f); l.intensity = 900f; l.range = 18f; l.spotAngle = 100f; l.shadows = LightShadows.None; l.renderMode = LightRenderMode.Auto;
        }
        for (int i = 0; i < 3; i++)
        {
            float x = 40f + i * 7f; Vector3 p = new Vector3(x, 6.8f, 0.04f);
            Box(g, "Dock_Wallpack_Housing_" + i, p, new Vector3(0.58f, 0.72f, 0.22f), fixture);
            Box(g, "Dock_Wallpack_Lens_" + i, p + new Vector3(0f, -0.05f, -0.12f), new Vector3(0.35f, 0.48f, 0.025f), diffuser);
            GameObject go = new GameObject("Dock_Wallpack_Spot_" + i); go.transform.SetParent(g, false); go.transform.position = p; go.transform.rotation = Quaternion.Euler(48f, 180f, 0f);
            Light l = go.AddComponent<Light>(); l.type = LightType.Spot; l.color = new Color(1f, 0.78f, 0.5f); l.intensity = 480f; l.range = 13f; l.spotAngle = 105f; l.shadows = LightShadows.None;
        }
        Light key = Object.FindAnyObjectByType<Light>();
        if (key != null && key.type == LightType.Directional) { key.intensity = 0.78f; key.color = new Color(1f, 0.96f, 0.88f); key.shadows = LightShadows.Soft; }
        RenderSettings.ambientMode = AmbientMode.Flat; RenderSettings.ambientLight = new Color(0.31f, 0.34f, 0.37f);
    }

    private static void BuildWorkAreaDetail(Transform root)
    {
        Transform g = new GameObject("WORKSTATION_EQUIPMENT_AND_SAFETY_POSTS").transform; g.SetParent(root, false);
        // Small, legible accessories enrich existing modeled worktops without blocking the work surface.
        float[] stations = { 41f, 47f, 53f };
        for (int i = 0; i < stations.Length; i++)
        {
            float x = stations[i], z = 15.4f;
            Box(g, "Packing_Parts_Bin_" + i, new Vector3(x - 1.15f, 1.08f, z - 0.17f), new Vector3(0.42f, 0.25f, 0.42f), i == 1 ? yellow : steel);
            Box(g, "Packing_Scale_Base_" + i, new Vector3(x + 0.72f, 1.03f, z + 0.12f), new Vector3(0.44f, 0.09f, 0.34f), fixture);
            Box(g, "Packing_Scale_Display_" + i, new Vector3(x + 0.72f, 1.21f, z + 0.18f), new Vector3(0.26f, 0.11f, 0.04f), diffuser);
        }
    }

    private static void TunePresentation(Transform final)
    {
        Transform cams = final.Find("CAMERAS");
        if (cams == null) return;
        Camera cam = cams.GetComponentInChildren<Camera>(true);
        if (cam == null) return;
        cam.transform.position = new Vector3(78f, 58f, -53f);
        cam.transform.rotation = Quaternion.LookRotation(new Vector3(31f, 3f, 7f) - cam.transform.position, Vector3.up);
        cam.fieldOfView = 47f; cam.farClipPlane = 300f;
    }
}
