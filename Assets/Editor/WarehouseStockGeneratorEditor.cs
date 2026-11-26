using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;

[CustomEditor(typeof(WarehouseStockGenerator))]
public sealed class WarehouseStockGeneratorEditor : Editor
{
    private const string GeneratedRootName = "WAREHOUSE_GENERATED_STOCK_ROOT";
    private static readonly float[] BayOffsets = { -2.65f, 0f, 2.65f };
    private static readonly float[] LevelOffsets = { 0f, 2.55f };

    public override void OnInspectorGUI()
    {
        serializedObject.Update();
        DrawDefaultInspector();
        serializedObject.ApplyModifiedProperties();

        var generator = (WarehouseStockGenerator)target;
        EditorGUILayout.Space();
        EditorGUILayout.HelpBox("Generation and clearing are scoped to " + GeneratedRootName + ". Existing rack modules and all non-stock objects are left in place. Density is applied to the configured rack capacity.", MessageType.Info);
        EditorGUILayout.LabelField("Last result", generator.lastGenerationSummary);
        using (new EditorGUILayout.HorizontalScope())
        {
            if (GUILayout.Button("Generate")) Generate(generator);
            if (GUILayout.Button("Clear Generated Stock")) Clear(generator);
        }
        if (GUILayout.Button("Regenerate")) Generate(generator);
    }

    [MenuItem("Warehouse/Phase 6/Configure Stock Generator in Warehouse_Final")]
    private static void ConfigureInFinalScene()
    {
        Scene scene = SceneManager.GetActiveScene();
        if (!scene.IsValid() || !scene.path.EndsWith("Warehouse_Final.unity", StringComparison.Ordinal))
        {
            EditorUtility.DisplayDialog("Warehouse Stock Generator", "Open Assets/Scenes/Warehouse_Final.unity before configuring the generator.", "OK");
            return;
        }

        GameObject finalRoot = FindRoot(scene, "WAREHOUSE_FINAL_ROOT");
        Transform storage = finalRoot == null ? null : finalRoot.transform.Find("STORAGE_RACKS_AND_STOCK");
        if (storage == null)
        {
            Debug.LogError("WarehouseStockGenerator: could not find WAREHOUSE_FINAL_ROOT/STORAGE_RACKS_AND_STOCK; no scene changes were made.");
            return;
        }

        Transform generated = storage.Find(GeneratedRootName);
        if (generated == null)
        {
            GameObject root = new GameObject(GeneratedRootName);
            Undo.RegisterCreatedObjectUndo(root, "Create generated stock root");
            root.transform.SetParent(storage, false);
            generated = root.transform;
        }

        GameObject config = FindChild(finalRoot.transform, "WAREHOUSE_STOCK_GENERATOR_CONFIG");
        if (config == null)
        {
            config = new GameObject("WAREHOUSE_STOCK_GENERATOR_CONFIG");
            Undo.RegisterCreatedObjectUndo(config, "Create stock generator configuration");
            config.transform.SetParent(finalRoot.transform, false);
        }
        var component = config.GetComponent<WarehouseStockGenerator>();
        if (component == null) component = Undo.AddComponent<WarehouseStockGenerator>(config);
        component.storageRackRoot = storage;
        component.generatedStockRoot = generated;
        component.palletModel = Load("Assets/Imported/FreeWarehouseEssentials/Models/Pallet.fbx");
        component.smallBoxModel = Load("Assets/Imported/FreeWarehouseEssentials/Models/Box_Small.fbx");
        component.mediumBoxModel = Load("Assets/Imported/FreeWarehouseEssentials/Models/Box_Medium.fbx");
        component.smallCrateModel = Load("Assets/Imported/FreeWarehouseEssentials/Models/Crate_Small.fbx");
        component.largeCrateModel = Load("Assets/Imported/FreeWarehouseEssentials/Models/Crate_Large.fbx");

        // The original assembly placed stock beside the rack instances. Adopt only the
        // explicitly named stock instances, retaining those exact objects and transforms.
        var legacyStock = storage.Cast<Transform>()
            .Where(t => t != generated && (t.name.StartsWith("Stock_Pallet_", StringComparison.Ordinal) || t.name.StartsWith("Stock_", StringComparison.Ordinal)))
            .ToArray();
        foreach (Transform item in legacyStock)
        {
            Undo.SetTransformParent(item, generated, "Move existing rack stock into generated stock ownership");
        }

        EditorUtility.SetDirty(component);
        EditorSceneManager.MarkSceneDirty(scene);
        Selection.activeGameObject = config;
        Debug.Log("WarehouseStockGenerator: configured against " + CountRackModules(storage) + " existing rack modules; preserved and adopted " + legacyStock.Length + " existing stock objects.");
    }

    [MenuItem("Warehouse/Phase 6/Run Generator Validation")]
    private static void RunGeneratorValidation()
    {
        WarehouseStockGenerator g = FindAnyObjectByType<WarehouseStockGenerator>();
        if (g == null || g.gameObject.scene != SceneManager.GetActiveScene())
        {
            Debug.LogError("WarehouseStockGenerator validation: open Warehouse_Final and configure the generator first.");
            return;
        }
        int priorSeed = g.randomSeed;
        float priorDensity = g.fillDensityPercent;
        int priorRows = g.rackRows, priorBays = g.baysPerRow, priorLevels = g.shelfLevels;
        try
        {
            g.rackRows = 5; g.baysPerRow = 6; g.shelfLevels = 2;
            g.randomSeed = 12345; g.fillDensityPercent = 50f;
            Generate(g);
            string seedA = BuildSignature(g.generatedStockRoot);
            int firstCount = g.generatedStockRoot.childCount;
            Generate(g);
            string seedARepeat = BuildSignature(g.generatedStockRoot);
            if (firstCount != 30 || seedA != seedARepeat)
                throw new InvalidOperationException("Seed 12345 did not regenerate the same 30 distinct rack positions.");

            g.randomSeed = 67890;
            Generate(g);
            if (BuildSignature(g.generatedStockRoot) == seedA)
                throw new InvalidOperationException("Changing the seed did not change the arrangement.");

            int[] expected = { 15, 30, 45, 60 };
            int[] densities = { 25, 50, 75, 100 };
            for (int i = 0; i < densities.Length; i++)
            {
                g.fillDensityPercent = densities[i];
                Generate(g);
                if (g.generatedStockRoot.childCount != expected[i])
                    throw new InvalidOperationException("Density " + densities[i] + "% produced " + g.generatedStockRoot.childCount + " loads; expected " + expected[i] + ".");
                VerifySlotsAreUniqueAndInsideRackZone(g.generatedStockRoot);
            }

            Clear(g);
            if (g.generatedStockRoot.childCount != 0)
                throw new InvalidOperationException("Clear left objects under the generated stock root.");
            g.randomSeed = 12345; g.fillDensityPercent = 50f;
            Generate(g);
            if (g.generatedStockRoot.childCount != 30)
                throw new InvalidOperationException("Regeneration after clear did not restore 30 loads.");
            Debug.Log("WarehouseStockGenerator validation passed: seed 12345 stable; changed seed differs; densities 25/50/75/100 produced 15/30/45/60 unique rack loads; clear and regenerate produced no duplicates.");
        }
        catch (Exception e)
        {
            Debug.LogException(e);
        }
        finally
        {
            g.rackRows = priorRows; g.baysPerRow = priorBays; g.shelfLevels = priorLevels;
            g.randomSeed = priorSeed; g.fillDensityPercent = priorDensity;
            EditorUtility.SetDirty(g);
            EditorSceneManager.MarkSceneDirty(g.gameObject.scene);
        }
    }

    private static string BuildSignature(Transform root)
    {
        return string.Join("|", root.Cast<Transform>().OrderBy(t => t.name, StringComparer.Ordinal).Select(t =>
            t.name + "@" + t.localPosition.x.ToString("R", CultureInfo.InvariantCulture) + "," +
            t.localPosition.y.ToString("R", CultureInfo.InvariantCulture) + "," +
            t.localPosition.z.ToString("R", CultureInfo.InvariantCulture)));
    }

    private static void VerifySlotsAreUniqueAndInsideRackZone(Transform root)
    {
        var occupied = new HashSet<string>(StringComparer.Ordinal);
        foreach (Transform load in root)
        {
            Vector3 p = load.position;
            string key = p.x.ToString("0.00", CultureInfo.InvariantCulture) + ":" + p.y.ToString("0.00", CultureInfo.InvariantCulture) + ":" + p.z.ToString("0.00", CultureInfo.InvariantCulture);
            if (!occupied.Add(key)) throw new InvalidOperationException("Duplicate generated rack slot: " + key);
            if (p.x < 4f || p.x > 27f || p.z < 9f || p.z > 30f)
                throw new InvalidOperationException("Generated load is outside the rack structure: " + key);
        }
    }

    private static void Generate(WarehouseStockGenerator g)
    {
        if (!Validate(g)) return;
        var slots = GetSlots(g).ToList();
        if (slots.Count == 0)
        {
            Debug.LogError("WarehouseStockGenerator: no rack modules named Rack_Row_*_Module_* were found; generated stock was not changed.");
            return;
        }

        // Validate all source model assignments before clearing any previous result.
        var missing = new List<string>();
        if (g.palletModel == null) missing.Add(nameof(g.palletModel));
        if (g.smallBoxModel == null) missing.Add(nameof(g.smallBoxModel));
        if (g.mediumBoxModel == null) missing.Add(nameof(g.mediumBoxModel));
        if (g.smallCrateModel == null) missing.Add(nameof(g.smallCrateModel));
        if (g.largeCrateModel == null) missing.Add(nameof(g.largeCrateModel));
        if (missing.Count > 0)
        {
            Debug.LogError("WarehouseStockGenerator: missing model references: " + string.Join(", ", missing) + ". No generated objects were changed.");
            return;
        }

        ClearContents(g.generatedStockRoot);
        System.Random random = new System.Random(g.randomSeed);
        Shuffle(slots, random);
        int desired = Mathf.Clamp(Mathf.RoundToInt(slots.Count * Mathf.Clamp(g.fillDensityPercent, 0f, 100f) / 100f), 0, slots.Count);
        Scene scene = g.gameObject.scene;
        for (int i = 0; i < desired; i++)
        {
            Slot slot = slots[i];
            string slotName = "Row_" + slot.row.ToString("00", CultureInfo.InvariantCulture) + "_Bay_" + slot.bay.ToString("00", CultureInfo.InvariantCulture) + "_Level_" + slot.level.ToString("00", CultureInfo.InvariantCulture);
            GameObject load = new GameObject("Generated_Load_" + slotName);
            Undo.RegisterCreatedObjectUndo(load, "Generate warehouse stock");
            load.transform.SetParent(g.generatedStockRoot, false);
            load.transform.position = new Vector3(slot.x, slot.y, slot.z);
            SpawnModel(g.palletModel, load.transform, "Pallet", slot.y, 90f, scene);

            int category = ChooseCategory(g, random);
            GameObject cargo = null;
            string cargoName = "PalletOnly";
            float cargoOffset = slot.level == 0 ? 0.2f : 2.75f;
            if (category == 1)
            {
                cargo = random.Next(2) == 0 ? g.smallBoxModel : g.mediumBoxModel;
                cargoName = cargo == g.smallBoxModel ? "BoxSmall" : "BoxMedium";
            }
            else if (category == 2)
            {
                cargo = random.Next(2) == 0 ? g.smallCrateModel : g.largeCrateModel;
                cargoName = cargo == g.smallCrateModel ? "CrateSmall" : "CrateLarge";
            }
            if (cargo != null) SpawnModel(cargo, load.transform, cargoName, cargoOffset, 90f, scene);
            load.name += "_" + cargoName;
        }

        g.lastGeneratedLoadCount = desired;
        g.lastGenerationSummary = desired.ToString(CultureInfo.InvariantCulture) + " loads / " + slots.Count.ToString(CultureInfo.InvariantCulture) + " configured positions; seed " + g.randomSeed.ToString(CultureInfo.InvariantCulture) + "; " + g.fillDensityPercent.ToString("0.#", CultureInfo.InvariantCulture) + "% density";
        EditorUtility.SetDirty(g);
        EditorSceneManager.MarkSceneDirty(scene);
        Debug.Log("WarehouseStockGenerator: generated " + g.lastGenerationSummary + ".");
    }

    private static void Clear(WarehouseStockGenerator g)
    {
        if (g == null || g.generatedStockRoot == null)
        {
            Debug.LogError("WarehouseStockGenerator: generated root is unassigned; nothing was cleared.");
            return;
        }
        ClearContents(g.generatedStockRoot);
        g.lastGeneratedLoadCount = 0;
        g.lastGenerationSummary = "Generated stock cleared";
        EditorUtility.SetDirty(g);
        EditorSceneManager.MarkSceneDirty(g.gameObject.scene);
        Debug.Log("WarehouseStockGenerator: cleared only children of " + GeneratedRootName + ".");
    }

    private static void ClearContents(Transform root)
    {
        for (int i = root.childCount - 1; i >= 0; i--) Undo.DestroyObjectImmediate(root.GetChild(i).gameObject);
    }

    private static void SpawnModel(GameObject source, Transform parent, string label, float yOffset, float yaw, Scene scene)
    {
        GameObject instance = PrefabUtility.InstantiatePrefab(source, scene) as GameObject;
        if (instance == null) instance = Instantiate(source);
        Undo.RegisterCreatedObjectUndo(instance, "Generate warehouse stock model");
        instance.name = label;
        Vector3 sourceScale = source.transform.localScale;
        Quaternion sourceRotation = source.transform.localRotation;
        instance.transform.SetParent(parent, false);
        instance.transform.localPosition = new Vector3(0f, yOffset - parent.localPosition.y, 0f);
        instance.transform.localRotation = Quaternion.Euler(0f, yaw, 0f) * sourceRotation;
        instance.transform.localScale = sourceScale;
    }

    private static IEnumerable<Slot> GetSlots(WarehouseStockGenerator g)
    {
        var racks = g.storageRackRoot.Cast<Transform>()
            .Where(t => t.name.StartsWith("Rack_Row_", StringComparison.Ordinal) && t.name.Contains("_Module_"))
            .Select(t => new { Transform = t, Row = ParseRow(t.name) })
            .Where(x => x.Row >= 1 && x.Row <= g.rackRows)
            .OrderBy(x => x.Row).ThenBy(x => x.Transform.position.z).ToArray();
        foreach (var rack in racks)
        {
            int rowIndex = rack.Row;
            int moduleIndex = rack.Transform.position.z < 20f ? 0 : 1;
            for (int bay = 0; bay < 3; bay++)
            {
                int rowBay = moduleIndex * 3 + bay + 1;
                if (rowBay > g.baysPerRow) continue;
                for (int level = 0; level < g.shelfLevels; level++)
                    yield return new Slot(rowIndex, rowBay, level + 1, rack.Transform.position.x,
                        LevelOffsets[level], rack.Transform.position.z + BayOffsets[bay]);
            }
        }
    }

    private static int ParseRow(string name)
    {
        const string prefix = "Rack_Row_";
        int end = name.IndexOf('_', prefix.Length);
        return end < 0 || !int.TryParse(name.Substring(prefix.Length, end - prefix.Length), out int row) ? -1 : row;
    }

    private static int ChooseCategory(WarehouseStockGenerator g, System.Random random)
    {
        double a = Math.Max(0, g.palletOnlyWeight), b = Math.Max(0, g.boxesWeight), c = Math.Max(0, g.cratesWeight);
        double total = a + b + c;
        if (total <= 0) return 1;
        double pick = random.NextDouble() * total;
        return pick < a ? 0 : pick < a + b ? 1 : 2;
    }

    private static void Shuffle<T>(IList<T> values, System.Random random)
    {
        for (int i = values.Count - 1; i > 0; i--)
        {
            int j = random.Next(i + 1);
            T tmp = values[i]; values[i] = values[j]; values[j] = tmp;
        }
    }

    private static bool Validate(WarehouseStockGenerator g)
    {
        if (g.storageRackRoot == null || g.generatedStockRoot == null || g.generatedStockRoot.parent != g.storageRackRoot)
        {
            Debug.LogError("WarehouseStockGenerator: assign the existing rack storage root and its child WAREHOUSE_GENERATED_STOCK_ROOT. No scene objects were changed.");
            return false;
        }
        return true;
    }

    private static int CountRackModules(Transform storage) => storage.Cast<Transform>().Count(t => t.name.StartsWith("Rack_Row_", StringComparison.Ordinal) && t.name.Contains("_Module_"));
    private static GameObject Load(string path) => AssetDatabase.LoadAssetAtPath<GameObject>(path);
    private static GameObject FindRoot(Scene scene, string name) => scene.GetRootGameObjects().FirstOrDefault(go => go.name == name);
    private static GameObject FindChild(Transform root, string name)
    {
        foreach (Transform child in root) { if (child.name == name) return child.gameObject; GameObject nested = FindChild(child, name); if (nested != null) return nested; }
        return null;
    }

    private struct Slot
    {
        public int row, bay, level;
        public float x, y, z;
        public Slot(int row, int bay, int level, float x, float y, float z) { this.row = row; this.bay = bay; this.level = level; this.x = x; this.y = y; this.z = z; }
    }
}
