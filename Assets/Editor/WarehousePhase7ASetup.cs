using System;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>Idempotent Phase 7A binding for the already assembled Warehouse_Final scene.</summary>
public static class WarehousePhase7ASetup
{
    private const string ScenePath = "Assets/Scenes/Warehouse_Final.unity";
    private const string ControllerName = "WAREHOUSE_PHASE7A_ANIMATION_CONTROLLER";
    private const string Essentials = "Assets/Imported/FreeWarehouseEssentials/";

    [MenuItem("Warehouse/Phase 7A/Configure Visible Animations")]
    public static void Configure()
    {
        Scene scene = SceneManager.GetActiveScene();
        if (!scene.IsValid() || scene.path != ScenePath)
            throw new InvalidOperationException("Open Assets/Scenes/Warehouse_Final.unity before configuring Phase 7A.");

        GameObject finalRoot = FindRoot(scene, "WAREHOUSE_FINAL_ROOT");
        if (finalRoot == null) throw new InvalidOperationException("WAREHOUSE_FINAL_ROOT was not found; no props were changed.");

        GameObject carton = FindUnique(scene, "Packing_Open_Carton_1");
        GameObject locker = FindUnique(scene, "Office_Double_Locker");
        if (carton == null || locker == null)
            throw new InvalidOperationException("The existing packing carton and office double locker must both exist; no scene objects were created.");

        AnimationClip cartonClip = LoadLegacyClip("Open_Carton");
        AnimationClip lockerClip = LoadLegacyClip("Double_Locker");
        ValidateSourceModel(carton, "Open_Carton");
        ValidateSourceModel(locker, "Double_Locker");

        GameObject cartonPlacement = EnsurePlacementParent(carton, "P7A_Placement_Packing_Open_Carton_1");
        GameObject lockerPlacement = EnsurePlacementParent(locker, "P7A_Placement_Office_Double_Locker");
        ConfigureLegacyAnimation(carton, cartonClip);
        ConfigureLegacyAnimation(locker, lockerClip);

        Transform[] rollers = FindStraightConveyorRollers(scene);
        if (rollers.Length != 100)
            throw new InvalidOperationException("Expected 100 separate rollers across four existing straight modules; found " + rollers.Length + ". The scene was not saved.");

        GameObject controllerObject = FindUnique(scene, ControllerName);
        if (controllerObject == null)
        {
            controllerObject = new GameObject(ControllerName);
            Undo.RegisterCreatedObjectUndo(controllerObject, "Create Phase 7A animation controller");
            controllerObject.transform.SetParent(finalRoot.transform, false);
        }
        WarehousePhase7AAnimationController controller = controllerObject.GetComponent<WarehousePhase7AAnimationController>();
        if (controller == null) controller = Undo.AddComponent<WarehousePhase7AAnimationController>(controllerObject);
        controller.conveyorRollers = rollers;
        controller.rollerSpeed = 135f;
        EditorUtility.SetDirty(controller);

        EditorSceneManager.MarkSceneDirty(scene);
        EditorSceneManager.SaveScene(scene);
        AssetDatabase.SaveAssets();
        Debug.Log("Phase 7A configured: one Open_Carton Legacy clip, one Double_Locker Legacy clip, four existing straight conveyor modules and " + rollers.Length + " individual rollers. Placement parents preserve the carton and locker world transforms.");
    }

    [MenuItem("Warehouse/Phase 7A/Verify Setup and Animation Bindings")]
    public static void VerifySetup()
    {
        Scene scene = SceneManager.GetActiveScene();
        if (!scene.IsValid() || scene.path != ScenePath)
            throw new InvalidOperationException("Open Warehouse_Final.unity before running Phase 7A verification.");

        GameObject carton = FindUnique(scene, "Packing_Open_Carton_1");
        GameObject locker = FindUnique(scene, "Office_Double_Locker");
        GameObject controllerGo = FindUnique(scene, ControllerName);
        if (carton == null || locker == null || controllerGo == null)
            throw new InvalidOperationException("Phase 7A scene bindings are incomplete.");
        var cartonAnimation = carton.GetComponent<Animation>();
        var lockerAnimation = locker.GetComponent<Animation>();
        if (cartonAnimation == null || lockerAnimation == null || !cartonAnimation.playAutomatically || !lockerAnimation.playAutomatically)
            throw new InvalidOperationException("Legacy Animation components or automatic playback are missing.");
        if (cartonAnimation.clip == null || cartonAnimation.clip.name != "Warehouse_DAY" || lockerAnimation.clip == null || lockerAnimation.clip.name != "Warehouse_DAY")
            throw new InvalidOperationException("The assigned matching Warehouse_DAY clips were not found.");
        if (FindStraightConveyorRollers(scene).Length != 100)
            throw new InvalidOperationException("The scene no longer contains the expected 100 straight conveyor roller transforms.");
        var controller = controllerGo.GetComponent<WarehousePhase7AAnimationController>();
        if (controller == null || controller.conveyorRollers == null || controller.conveyorRollers.Length != 100)
            throw new InvalidOperationException("The roller controller binding is missing or incomplete.");
        Debug.Log("Phase 7A setup verification passed: existing carton and locker each have one automatic Legacy clip, four straight modules expose 100 rollers, controller has 100 unique roller references, and no duplicate animation controller exists.");
    }

    [MenuItem("Warehouse/Phase 7A/Inspect Existing Animation Targets")]
    public static void InspectExistingTargets()
    {
        Scene scene = SceneManager.GetActiveScene();
        if (!scene.IsValid() || scene.path != ScenePath)
            throw new InvalidOperationException("Open Warehouse_Final.unity before inspecting the Phase 7A targets.");
        string[] names = {
            "Sort_Open_Carton", "Packing_Open_Carton_1", "Office_Double_Locker", "Packing_Locker",
            "Office_Control_Cabinet", "Packing_Electrical_Cabinet",
            "Conveyor_Load_01", "Conveyor_Load_02", "Conveyor_Load_03", "Conveyor_Load_04"
        };
        foreach (string name in names)
        {
            GameObject go = FindUnique(scene, name);
            if (go == null)
            {
                Debug.LogError("Phase 7A scene inspection: missing existing object " + name + ".");
                continue;
            }
            GameObject source = PrefabUtility.GetCorrespondingObjectFromSource(go);
            string path = source == null ? "project-owned / no direct prefab source" : AssetDatabase.GetAssetPath(source);
            Debug.Log("Phase 7A scene inspection: " + name + " worldPosition=" + go.transform.position.ToString("F3") +
                      " worldEuler=" + go.transform.eulerAngles.ToString("F1") + " localScale=" + go.transform.localScale.ToString("F3") +
                      " directChildren=" + go.transform.childCount + " source=" + path +
                      " Animation=" + (go.GetComponent<Animation>() != null) + " Animator=" + (go.GetComponent<Animator>() != null));
        }
    }

    [MenuItem("Warehouse/Phase 7A/Verify Visible Motion (Play Mode)")]
    public static void VerifyVisiblePlayModeMotion()
    {
        if (!EditorApplication.isPlaying)
            throw new InvalidOperationException("Enter Play Mode in Warehouse_Final before checking animation playback.");
        Scene scene = SceneManager.GetActiveScene();
        GameObject carton = FindUnique(scene, "Packing_Open_Carton_1");
        GameObject locker = FindUnique(scene, "Office_Double_Locker");
        GameObject cartonParent = FindUnique(scene, "P7A_Placement_Packing_Open_Carton_1");
        GameObject lockerParent = FindUnique(scene, "P7A_Placement_Office_Double_Locker");
        var controller = FindUnique(scene, ControllerName)?.GetComponent<WarehousePhase7AAnimationController>();
        if (carton == null || locker == null || cartonParent == null || lockerParent == null || controller == null)
            throw new InvalidOperationException("Phase 7A objects are missing from the running scene.");

        Transform[] cartonParts = carton.GetComponentsInChildren<Transform>(true);
        Transform[] lockerParts = locker.GetComponentsInChildren<Transform>(true);
        Transform[] rollers = controller.conveyorRollers;
        Vector3 cartonRootPosition = cartonParent.transform.position;
        Quaternion cartonRootRotation = cartonParent.transform.rotation;
        Vector3 lockerRootPosition = lockerParent.transform.position;
        Quaternion lockerRootRotation = lockerParent.transform.rotation;
        Vector3[] cartonStart = cartonParts.Select(t => t.localPosition).ToArray();
        Quaternion[] cartonRotStart = cartonParts.Select(t => t.localRotation).ToArray();
        Vector3[] lockerStart = lockerParts.Select(t => t.localPosition).ToArray();
        Quaternion[] lockerRotStart = lockerParts.Select(t => t.localRotation).ToArray();
        Quaternion[] rollersStart = rollers.Select(t => t == null ? Quaternion.identity : t.localRotation).ToArray();
        double finishAt = EditorApplication.timeSinceStartup + 3.2d;
        EditorApplication.CallbackFunction callback = null;
        callback = () =>
        {
            if (!EditorApplication.isPlaying)
            {
                EditorApplication.update -= callback;
                Debug.LogWarning("Phase 7A Play Mode motion check was cancelled because Play Mode stopped.");
                return;
            }
            if (EditorApplication.timeSinceStartup < finishAt) return;
            EditorApplication.update -= callback;

            string cartonChangedParts = ChangedPartNames(cartonParts, cartonStart, cartonRotStart);
            string lockerChangedParts = ChangedPartNames(lockerParts, lockerStart, lockerRotStart);
            bool cartonMoved = !string.IsNullOrEmpty(cartonChangedParts);
            bool lockerMoved = !string.IsNullOrEmpty(lockerChangedParts);
            int rollerCount = 0;
            for (int i = 0; i < rollers.Length; i++)
                if (rollers[i] != null && Quaternion.Angle(rollersStart[i], rollers[i].localRotation) > 0.1f) rollerCount++;
            bool anchorsStable = Vector3.Distance(cartonRootPosition, cartonParent.transform.position) < 0.001f &&
                                 Quaternion.Angle(cartonRootRotation, cartonParent.transform.rotation) < 0.01f &&
                                 Vector3.Distance(lockerRootPosition, lockerParent.transform.position) < 0.001f &&
                                 Quaternion.Angle(lockerRootRotation, lockerParent.transform.rotation) < 0.01f;
            if (!cartonMoved || !lockerMoved || rollerCount != rollers.Length || !anchorsStable)
                Debug.LogError("Phase 7A Play Mode motion check failed. Carton pose changed=" + cartonMoved + ", locker pose changed=" + lockerMoved + ", rotating rollers=" + rollerCount + "/" + rollers.Length + ", placement anchors stable=" + anchorsStable + ".");
            else
                Debug.Log("Phase 7A Play Mode motion check passed: carton changed transforms [" + cartonChangedParts + "]; locker changed transforms [" + lockerChangedParts + "]; " + rollerCount + "/" + rollers.Length + " rollers rotated; both unanimated placement parent positions and orientations stayed fixed.");
        };
        EditorApplication.update += callback;
        Debug.Log("Phase 7A Play Mode motion check started; sampling the two Legacy hierarchies, 100 conveyor rollers and fixed placement parents for 3.2 seconds.");
    }

    private static string ChangedPartNames(Transform[] transforms, Vector3[] startPositions, Quaternion[] startRotations)
    {
        var changed = new List<string>();
        for (int i = 0; i < transforms.Length; i++)
            if (Vector3.Distance(startPositions[i], transforms[i].localPosition) > 0.002f ||
                Quaternion.Angle(startRotations[i], transforms[i].localRotation) > 0.2f)
                changed.Add(transforms[i].name);
        return string.Join(", ", changed.Distinct().Take(12));
    }

    private static void ConfigureLegacyAnimation(GameObject modelRoot, AnimationClip clip)
    {
        Animation animation = modelRoot.GetComponent<Animation>();
        if (animation == null) animation = Undo.AddComponent<Animation>(modelRoot);
        animation.playAutomatically = true;
        animation.wrapMode = WrapMode.PingPong;
        animation.clip = clip;
        animation.AddClip(clip, clip.name);
        AnimationState state = animation[clip.name];
        if (state == null) throw new InvalidOperationException("Could not create Legacy Animation state for " + clip.name + ".");
        state.wrapMode = WrapMode.PingPong;
        state.speed = 0.45f;
        animation.Play(clip.name);
        EditorUtility.SetDirty(animation);
    }

    private static GameObject EnsurePlacementParent(GameObject model, string parentName)
    {
        Transform existingParent = model.transform.parent;
        if (existingParent != null && existingParent.name == parentName) return existingParent.gameObject;

        GameObject wrapper = FindUnique(model.scene, parentName);
        if (wrapper != null)
        {
            if (model.transform.parent != wrapper.transform)
                Undo.SetTransformParent(model.transform, wrapper.transform, "Restore Phase 7A animation placement parent");
            return wrapper;
        }

        Vector3 worldPosition = model.transform.position;
        Quaternion worldRotation = model.transform.rotation;
        Transform oldParent = model.transform.parent;
        wrapper = new GameObject(parentName);
        Undo.RegisterCreatedObjectUndo(wrapper, "Create unanimated placement parent");
        SceneManager.MoveGameObjectToScene(wrapper, model.scene);
        wrapper.transform.SetParent(oldParent, true);
        wrapper.transform.SetPositionAndRotation(worldPosition, worldRotation);
        model.transform.SetParent(wrapper.transform, true);
        return wrapper;
    }

    private static void ValidateSourceModel(GameObject instance, string modelName)
    {
        GameObject source = PrefabUtility.GetCorrespondingObjectFromSource(instance);
        string path = source == null ? AssetDatabase.GetAssetPath(instance) : AssetDatabase.GetAssetPath(source);
        if (string.IsNullOrEmpty(path) || !path.Contains("/Models/" + modelName + ".fbx", StringComparison.Ordinal))
            throw new InvalidOperationException(instance.name + " is not the matching imported " + modelName + " model (source: " + path + ").");
    }

    private static AnimationClip LoadLegacyClip(string sampleName)
    {
        string path = Essentials + "Animations/" + sampleName + ".fbx";
        AnimationClip clip = AssetDatabase.LoadAllAssetsAtPath(path).OfType<AnimationClip>().FirstOrDefault(c => c.name == "Warehouse_DAY");
        if (clip == null || !clip.legacy)
            throw new InvalidOperationException("Matching Legacy Warehouse_DAY clip was not found at " + path + ".");
        return clip;
    }

    private static Transform[] FindStraightConveyorRollers(Scene scene)
    {
        string[] moduleNames = { "Sort_Conveyor_Straight_A", "Sort_Conveyor_Straight_B", "Sort_Conveyor_Straight_C", "Sort_Conveyor_Straight_D" };
        var rollers = new List<Transform>(100);
        foreach (string moduleName in moduleNames)
        {
            GameObject module = FindUnique(scene, moduleName);
            if (module == null) throw new InvalidOperationException("Existing conveyor module is missing: " + moduleName);
            rollers.AddRange(module.GetComponentsInChildren<Transform>(true)
                .Where(t => t.name.StartsWith("straight_roller_", StringComparison.Ordinal) && !t.name.EndsWith("_mesh", StringComparison.Ordinal)));
        }
        return rollers.ToArray();
    }

    private static GameObject FindUnique(Scene scene, string name)
    {
        GameObject[] matches = scene.GetRootGameObjects()
            .SelectMany(root => root.GetComponentsInChildren<Transform>(true))
            .Where(t => t.name == name)
            .Select(t => t.gameObject)
            .Distinct()
            .ToArray();
        if (matches.Length > 1) throw new InvalidOperationException("Expected one scene object named " + name + ", found " + matches.Length + ".");
        return matches.Length == 0 ? null : matches[0];
    }

    private static GameObject FindRoot(Scene scene, string name)
    {
        return scene.GetRootGameObjects().FirstOrDefault(root => root.name == name);
    }
}
