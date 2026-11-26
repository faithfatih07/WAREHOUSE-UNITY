using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Rendering.Universal;

/// <summary>Idempotent Phase 5 setup scoped to Warehouse_Final and its named roots.</summary>
public static class WarehousePhase5Setup
{
    private const string ScenePath = "Assets/Scenes/Warehouse_Final.unity";
    private const string SystemRootName = "WAREHOUSE_PHASE5_CAMERA_AND_COLLISION_SYSTEM";

    [MenuItem("Warehouse/Phase 5/Setup Camera Modes and Collisions")]
    public static void Setup()
    {
        Scene scene = SceneManager.GetActiveScene();
        if (scene.path != ScenePath) throw new System.InvalidOperationException("Open Warehouse_Final.unity before running Phase 5 setup.");
        GameObject final = FindRoot(scene, "WAREHOUSE_FINAL_ROOT");
        GameObject detail = FindRoot(scene, "WAREHOUSE_PHASE4_DETAIL_ROOT");
        if (final == null || detail == null) throw new System.InvalidOperationException("Phase 3/4 roots are missing; refusing to create camera setup.");
        Transform cameraParent = final.transform.Find("CAMERAS");
        Camera cam = cameraParent != null ? cameraParent.GetComponentInChildren<Camera>(true) : null;
        if (cam == null) throw new System.InvalidOperationException("Existing overview camera not found; refusing to create a duplicate.");

        Transform existingSystem = scene.GetRootGameObjects().Length == 0 ? null : FindRoot(scene, SystemRootName)?.transform;
        if (existingSystem == null)
        {
            GameObject system = new GameObject(SystemRootName);
            SceneManager.MoveGameObjectToScene(system, scene);
            existingSystem = system.transform;
        }
        for (int i = existingSystem.childCount - 1; i >= 0; i--) Object.DestroyImmediate(existingSystem.GetChild(i).gameObject);
        Transform player = new GameObject("WAREHOUSE_PHASE5_PLAYER").transform;
        player.SetParent(existingSystem, false);
        player.position = new Vector3(1.7f, 0.05f, 4.5f);
        CharacterController controller = player.gameObject.AddComponent<CharacterController>();
        controller.height = 1.8f; controller.radius = 0.32f; controller.center = new Vector3(0f, 0.9f, 0f);
        controller.stepOffset = 0.3f; controller.slopeLimit = 45f; controller.skinWidth = 0.04f; controller.minMoveDistance = 0f;

        Transform collisionRoot = new GameObject("INVISIBLE_COLLISION_PROXIES").transform;
        collisionRoot.SetParent(existingSystem, false);
        AddBox(collisionRoot, "West_Wall", new Vector3(0f, 4.5f, 20f), new Vector3(0.35f, 9f, 40f));
        AddBox(collisionRoot, "East_Wall", new Vector3(60f, 4.5f, 20f), new Vector3(0.35f, 9f, 40f));
        AddBox(collisionRoot, "North_Wall", new Vector3(30f, 4.5f, 40f), new Vector3(60f, 9f, 0.35f));
        AddBox(collisionRoot, "South_Wall_West", new Vector3(18.5f, 4.5f, 0f), new Vector3(37f, 9f, 0.35f));
        AddBox(collisionRoot, "South_Wall_East", new Vector3(58.5f, 4.5f, 0f), new Vector3(3f, 9f, 0.35f));
        AddBox(collisionRoot, "South_Pier_1", new Vector3(43f, 4.5f, 0f), new Vector3(0.4f, 9f, 0.4f));
        AddBox(collisionRoot, "South_Pier_2", new Vector3(50.5f, 4.5f, 0f), new Vector3(0.4f, 9f, 0.4f));
        float[] rackX = { 4.5f, 10f, 15.5f, 21f, 26.5f };
        for (int i = 0; i < rackX.Length; i++) AddBox(collisionRoot, "Rack_Row_" + (i + 1), new Vector3(rackX[i], 2.5f, 19.8f), new Vector3(1.55f, 5f, 19.2f));
        Transform structure = final.transform.Find("ROOF_STRUCTURE");
        if (structure != null) foreach (Transform t in structure)
        {
            if (!t.name.StartsWith("Portal_Column_")) continue;
            Vector3 p = t.position;
            AddBox(collisionRoot, "Proxy_" + t.name, p, new Vector3(0.62f, 9f, 0.62f));
        }
        // A narrow proxy follows the fixed roller line; adjoining working aisles stay open.
        AddBox(collisionRoot, "Fixed_Conveyor_Line", new Vector3(48f, 0.55f, 24f), new Vector3(15.5f, 1.1f, 1.15f));
        // Worktops and stationary packing equipment, with clearance around each operating face.
        for (int i = 0; i < 3; i++) AddBox(collisionRoot, "Packing_Station_" + i, new Vector3(41f + i * 6f, 0.72f, 15.4f), new Vector3(3.6f, 1.45f, 1.25f));

        Transform roof = final.transform.Find("ROOF_PANELS_AND_SKYLIGHTS");
        if (roof == null) throw new System.InvalidOperationException("Complete roof root not found.");
        WarehousePhase5CameraController modes = cam.GetComponent<WarehousePhase5CameraController>();
        if (modes == null) modes = cam.gameObject.AddComponent<WarehousePhase5CameraController>();
        modes.roofPanels = roof;
        modes.playerRoot = player;
        modes.playerController = controller;
        modes.overviewSize = 43f;
        cam.transform.position = new Vector3(83f, 83f, -44f);
        cam.transform.rotation = Quaternion.LookRotation(new Vector3(32f, 2f, 8f) - cam.transform.position, Vector3.up);
        cam.orthographic = true;
        cam.orthographicSize = 43f;
        cam.farClipPlane = 300f;
        UniversalAdditionalCameraData cameraData = cam.GetComponent<UniversalAdditionalCameraData>();
        if (cameraData == null) cameraData = cam.gameObject.AddComponent<UniversalAdditionalCameraData>();
        cameraData.antialiasing = AntialiasingMode.FastApproximateAntialiasing;
        cameraData.antialiasingQuality = AntialiasingQuality.Medium;
        cameraData.renderPostProcessing = true;
        roof.gameObject.SetActive(false);

        EditorSceneManager.MarkSceneDirty(scene);
        EditorSceneManager.SaveScene(scene);
        AssetDatabase.SaveAssets();
        Debug.Log("WarehousePhase5Setup: configured one existing camera, one controller/player, one proxy set and overview cutaway in Warehouse_Final.");
    }

    private static GameObject FindRoot(Scene scene, string name)
    {
        foreach (GameObject go in scene.GetRootGameObjects()) if (go.name == name) return go;
        return null;
    }

    private static void AddBox(Transform parent, string name, Vector3 center, Vector3 size)
    {
        GameObject go = new GameObject(name);
        go.transform.SetParent(parent, true);
        go.transform.position = center;
        BoxCollider box = go.AddComponent<BoxCollider>();
        box.size = size;
    }
}
