using System;
using System.IO;
using System.Text;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>Generates original loopable WAV clips and idempotently binds Phase 7B audio in Warehouse_Final.</summary>
public static class WarehousePhase7BAudioSetup
{
    private const string ScenePath = "Assets/Scenes/Warehouse_Final.unity";
    private const string OutputFolder = "Assets/Audio/Generated";
    private const string AmbiencePath = OutputFolder + "/Warehouse_Ambience_Original.wav";
    private const string ConveyorPath = OutputFolder + "/Conveyor_Operation_Original.wav";
    private const string RootName = "WAREHOUSE_PHASE7B_AUDIO_ROOT";
    private const string ControllerName = "Warehouse_Phase7B_Audio_Controller";
    private static WarehousePhase7BAudioController gateTestController;
    private static bool gateTestInitialEnabled;
    private static int gateTestStage;
    private static int gateTestFrame;

    [MenuItem("Warehouse/Phase 7B/Generate Original WAV Clips")]
    public static void GenerateOriginalWavs()
    {
        Directory.CreateDirectory(Path.GetFullPath(Path.Combine(Application.dataPath, "Audio/Generated")));
        WriteWav(AmbiencePath, BuildAmbience(), 22050, 2);
        WriteWav(ConveyorPath, BuildConveyor(), 22050, 1);
        AssetDatabase.ImportAsset(AmbiencePath, ImportAssetOptions.ForceUpdate);
        AssetDatabase.ImportAsset(ConveyorPath, ImportAssetOptions.ForceUpdate);
        AssetDatabase.Refresh();
        Debug.Log("Phase 7B generated original PCM WAV loops: 20 s stereo warehouse ambience and 8 s mono conveyor mechanism. No external audio was used.");
    }

    [MenuItem("Warehouse/Phase 7B/Configure Audio in Warehouse_Final")]
    public static void ConfigureScene()
    {
        Scene scene = SceneManager.GetActiveScene();
        if (!scene.IsValid() || scene.path != ScenePath)
            throw new InvalidOperationException("Open Assets/Scenes/Warehouse_Final.unity before configuring Phase 7B.");

        AudioClip ambienceClip = AssetDatabase.LoadAssetAtPath<AudioClip>(AmbiencePath);
        AudioClip conveyorClip = AssetDatabase.LoadAssetAtPath<AudioClip>(ConveyorPath);
        if (ambienceClip == null || conveyorClip == null)
            throw new InvalidOperationException("Generate the two Phase 7B WAV clips before scene setup.");

        GameObject finalRoot = FindUnique(scene, "WAREHOUSE_FINAL_ROOT");
        if (finalRoot == null) throw new InvalidOperationException("WAREHOUSE_FINAL_ROOT is missing.");
        WarehousePhase7AAnimationController operation = FindUnique(scene, "WAREHOUSE_PHASE7A_ANIMATION_CONTROLLER")?.GetComponent<WarehousePhase7AAnimationController>();
        if (operation == null) throw new InvalidOperationException("The Phase 7A conveyor operation controller is missing.");

        GameObject root = FindUnique(scene, RootName);
        if (root == null)
        {
            root = new GameObject(RootName);
            Undo.RegisterCreatedObjectUndo(root, "Create Phase 7B audio root");
            root.transform.SetParent(finalRoot.transform, false);
        }
        if (root.transform.parent != finalRoot.transform)
            Undo.SetTransformParent(root.transform, finalRoot.transform, "Group Phase 7B audio under warehouse root");

        Transform ambienceTransform = EnsureChild(root.transform, "Warehouse_Ambience_Audio");
        ambienceTransform.localPosition = new Vector3(30f, 4f, 20f);
        AudioSource ambience = EnsureSingleAudioSource(ambienceTransform.gameObject);
        ConfigureSource(ambience, ambienceClip, true, 0f, 0.12f, 1f, 28f);

        Transform conveyorTransform = EnsureChild(root.transform, "Conveyor_Operation_Audio");
        conveyorTransform.localPosition = new Vector3(49f, 1.35f, 24f);
        AudioSource conveyor = EnsureSingleAudioSource(conveyorTransform.gameObject);
        ConfigureSource(conveyor, conveyorClip, true, 1f, 0.18f, 2.5f, 24f);

        WarehousePhase7BAudioController controller = root.GetComponent<WarehousePhase7BAudioController>();
        if (controller == null) controller = Undo.AddComponent<WarehousePhase7BAudioController>(root);
        controller.ambienceSource = ambience;
        controller.conveyorSource = conveyor;
        controller.conveyorOperation = operation;
        controller.ambienceVolume = 0.12f;
        controller.conveyorVolume = 0.18f;
        EditorUtility.SetDirty(controller);

        EditorSceneManager.MarkSceneDirty(scene);
        EditorSceneManager.SaveScene(scene);
        AssetDatabase.SaveAssets();
        Debug.Log("Phase 7B configured idempotently: one 2D ambience source, one spatial conveyor source at (49, 1.35, 24), and M mute control. Conveyor playback follows the active Phase 7A roller controller. No packing one-shot was added because there is no genuine package-completion event.");
    }

    [MenuItem("Warehouse/Phase 7B/Verify Setup")]
    public static void VerifySetup()
    {
        Scene scene = SceneManager.GetActiveScene();
        if (!scene.IsValid() || scene.path != ScenePath)
            throw new InvalidOperationException("Open Warehouse_Final.unity before verifying Phase 7B.");
        GameObject root = FindUnique(scene, RootName);
        if (root == null) throw new InvalidOperationException("The Phase 7B audio root is missing.");
        var controller = root.GetComponent<WarehousePhase7BAudioController>();
        AudioSource[] sources = root.GetComponentsInChildren<AudioSource>(true);
        if (controller == null || sources.Length != 2 || controller.ambienceSource == null || controller.conveyorSource == null || controller.conveyorOperation == null)
            throw new InvalidOperationException("Expected one controller, exactly two assigned audio sources and the Phase 7A operation binding.");
        if (controller.ambienceSource.clip == null || controller.conveyorSource.clip == null || !controller.ambienceSource.loop || !controller.conveyorSource.loop)
            throw new InvalidOperationException("A loop clip is missing or not configured to loop.");
        if (controller.ambienceSource.spatialBlend != 0f || controller.conveyorSource.spatialBlend < 0.99f)
            throw new InvalidOperationException("Ambience and conveyor spatial blend settings are incorrect.");
        int listeners = UnityEngine.Object.FindObjectsByType<AudioListener>().Length;
        if (listeners != 1)
            throw new InvalidOperationException("Expected exactly one active AudioListener in Warehouse_Final; found " + listeners + ". No camera/listener settings were changed.");
        Debug.Log("Phase 7B setup verification passed: one owned root, one ambience source, one spatial conveyor source, assigned looping WAV clips, one active listener and a live Phase 7A operation-state reference.");
    }

    [MenuItem("Warehouse/Phase 7B/Verify Play Mode Playback")]
    public static void VerifyPlayModePlayback()
    {
        if (!EditorApplication.isPlaying)
            throw new InvalidOperationException("Enter Play Mode before checking Phase 7B playback.");
        GameObject root = FindUnique(SceneManager.GetActiveScene(), RootName);
        var controller = root == null ? null : root.GetComponent<WarehousePhase7BAudioController>();
        if (controller == null) throw new InvalidOperationException("Phase 7B audio controller is missing in the running scene.");

        bool ambiencePlaying = controller.ambienceSource != null && controller.ambienceSource.isPlaying && controller.ambienceSource.clip != null;
        bool operationRunning = controller.conveyorOperation != null && controller.conveyorOperation.isActiveAndEnabled && controller.conveyorOperation.gameObject.activeInHierarchy;
        bool conveyorPlaying = controller.conveyorSource != null && controller.conveyorSource.isPlaying && controller.conveyorSource.clip != null;
        bool expectedConveyor = operationRunning == conveyorPlaying;
        if (!ambiencePlaying || !expectedConveyor)
            Debug.LogError("Phase 7B playback check failed: ambience isPlaying=" + ambiencePlaying + "; conveyor isPlaying=" + conveyorPlaying + "; Phase 7A operating=" + operationRunning + ".");
        else
            Debug.Log("Phase 7B playback state passed: ambience clip loaded/playing; spatial conveyor clip loaded/" + (conveyorPlaying ? "playing" : "stopped") + " matches Phase 7A operating=" + operationRunning + ". This check does not verify audible output; use the manual listening checklist.");
    }

    [MenuItem("Warehouse/Phase 7B/Verify Conveyor Operation Gate (Play Mode)")]
    public static void VerifyConveyorOperationGate()
    {
        if (!EditorApplication.isPlaying)
            throw new InvalidOperationException("Enter Play Mode before testing the conveyor audio operation gate.");

        GameObject root = FindUnique(SceneManager.GetActiveScene(), RootName);
        gateTestController = root == null ? null : root.GetComponent<WarehousePhase7BAudioController>();
        if (gateTestController == null || gateTestController.conveyorOperation == null || gateTestController.conveyorSource == null)
            throw new InvalidOperationException("The Phase 7B conveyor source or Phase 7A operation binding is missing.");
        if (!gateTestController.conveyorOperation.isActiveAndEnabled || !gateTestController.conveyorOperation.gameObject.activeInHierarchy)
            throw new InvalidOperationException("The conveyor operation must be active before this state-gate check.");

        gateTestInitialEnabled = gateTestController.conveyorOperation.enabled;
        gateTestStage = 0;
        gateTestFrame = Time.frameCount;
        gateTestController.conveyorOperation.enabled = false;
        EditorApplication.update -= CheckConveyorOperationGate;
        EditorApplication.update += CheckConveyorOperationGate;
        Debug.Log("Phase 7B conveyor gate test started: temporarily pausing the Phase 7A operation, then restoring it.");
    }

    private static void CheckConveyorOperationGate()
    {
        if (!EditorApplication.isPlaying || gateTestController == null)
        {
            EditorApplication.update -= CheckConveyorOperationGate;
            gateTestController = null;
            return;
        }
        if (Time.frameCount <= gateTestFrame) return;

        if (gateTestStage == 0)
        {
            bool stopped = !gateTestController.conveyorSource.isPlaying;
            gateTestController.conveyorOperation.enabled = gateTestInitialEnabled;
            gateTestStage = 1;
            gateTestFrame = Time.frameCount;
            if (!stopped)
                Debug.LogError("Phase 7B conveyor gate test failed: spatial conveyor audio continued after the Phase 7A operation was disabled.");
            return;
        }

        bool expectedPlaying = gateTestInitialEnabled;
        bool restored = gateTestController.conveyorOperation.enabled == gateTestInitialEnabled &&
                        gateTestController.conveyorSource.isPlaying == expectedPlaying;
        if (restored)
            Debug.Log("Phase 7B conveyor gate test passed: audio stopped while Phase 7A operation was disabled and resumed after it was restored.");
        else
            Debug.LogError("Phase 7B conveyor gate test failed after restoring operation: enabled=" + gateTestController.conveyorOperation.enabled + "; audio playing=" + gateTestController.conveyorSource.isPlaying + ".");

        EditorApplication.update -= CheckConveyorOperationGate;
        gateTestController = null;
    }

    private static void ConfigureSource(AudioSource source, AudioClip clip, bool loop, float spatialBlend, float volume, float minDistance, float maxDistance)
    {
        source.clip = clip;
        source.playOnAwake = false;
        source.loop = loop;
        source.spatialBlend = spatialBlend;
        source.volume = volume;
        source.priority = 128;
        source.pitch = 1f;
        source.dopplerLevel = 0f;
        source.panStereo = 0f;
        source.spread = spatialBlend > 0.5f ? 35f : 0f;
        source.rolloffMode = AudioRolloffMode.Logarithmic;
        source.minDistance = minDistance;
        source.maxDistance = maxDistance;
        source.bypassEffects = false;
        source.bypassListenerEffects = false;
        source.bypassReverbZones = false;
        source.reverbZoneMix = 1f;
        EditorUtility.SetDirty(source);
    }

    private static AudioSource EnsureSingleAudioSource(GameObject go)
    {
        AudioSource[] found = go.GetComponents<AudioSource>();
        if (found.Length > 1)
            throw new InvalidOperationException(go.name + " already has duplicate AudioSources; setup will not delete components.");
        return found.Length == 1 ? found[0] : Undo.AddComponent<AudioSource>(go);
    }

    private static Transform EnsureChild(Transform parent, string childName)
    {
        Transform found = null;
        for (int i = 0; i < parent.childCount; i++)
        {
            Transform child = parent.GetChild(i);
            if (child.name != childName) continue;
            if (found != null) throw new InvalidOperationException("Duplicate Phase 7B child " + childName + " detected; no objects were removed.");
            found = child;
        }
        if (found != null) return found;
        GameObject created = new GameObject(childName);
        Undo.RegisterCreatedObjectUndo(created, "Create Phase 7B audio source object");
        created.transform.SetParent(parent, false);
        return created.transform;
    }

    private static GameObject FindUnique(Scene scene, string objectName)
    {
        GameObject found = null;
        foreach (GameObject sceneRoot in scene.GetRootGameObjects())
        {
            Transform[] transforms = sceneRoot.GetComponentsInChildren<Transform>(true);
            foreach (Transform transform in transforms)
            {
                if (transform.name != objectName) continue;
                if (found != null) throw new InvalidOperationException("Multiple scene objects named " + objectName + " exist; setup did not change the scene.");
                found = transform.gameObject;
            }
        }
        return found;
    }

    private static float[] BuildAmbience()
    {
        const int sampleRate = 22050;
        const int seconds = 20;
        int frames = sampleRate * seconds;
        var samples = new float[frames * 2];
        var random = new System.Random(74021);
        float lowL = 0f;
        float lowR = 0f;
        for (int frame = 0; frame < frames; frame++)
        {
            double t = frame / (double)sampleRate;
            float whiteL = (float)(random.NextDouble() * 2.0 - 1.0);
            float whiteR = (float)(random.NextDouble() * 2.0 - 1.0);
            lowL += 0.045f * (whiteL - lowL);
            lowR += 0.045f * (whiteR - lowR);

            float edgeSeconds = (float)Math.Min(t, seconds - t);
            float noiseFade = SmoothStep(Mathf.Clamp01(edgeSeconds / 0.3f));
            float slowAir = 0.58f * Mathf.Sin((float)(2.0 * Math.PI * 0.65 * t + 0.3)) +
                            0.27f * Mathf.Sin((float)(2.0 * Math.PI * 1.85 * t + 1.1)) +
                            0.15f * Mathf.Sin((float)(2.0 * Math.PI * 3.45 * t + 2.0));
            float motorBed = 0.012f * Mathf.Sin((float)(2.0 * Math.PI * 50.0 * t)) +
                             0.006f * Mathf.Sin((float)(2.0 * Math.PI * 100.0 * t + 0.4));
            float airL = 0.026f * slowAir + motorBed + noiseFade * (0.055f * lowL + 0.012f * (whiteL - lowL));
            float airR = 0.025f * slowAir + motorBed + noiseFade * (0.052f * lowR + 0.013f * (whiteR - lowR));
            float width = 0.94f + 0.06f * Mathf.Sin((float)(2.0 * Math.PI * 0.1 * t));
            samples[frame * 2] = Mathf.Clamp(airL * width, -0.4f, 0.4f);
            samples[frame * 2 + 1] = Mathf.Clamp(airR / width, -0.4f, 0.4f);
        }
        return samples;
    }

    private static float[] BuildConveyor()
    {
        const int sampleRate = 22050;
        const int frames = sampleRate * 8; // 8 s = 3 rotations at the Phase 7A 135 degrees/second rate.
        var samples = new float[frames];
        var random = new System.Random(55193);
        float lowNoise = 0f;
        const int rotationsPerLoop = 3;
        const int rollerContactTicksPerLoop = 75; // 25 rollers × 3 rotations per loop.
        for (int frame = 0; frame < frames; frame++)
        {
            double t = frame / (double)sampleRate;
            double phase = frame / (double)frames;
            float white = (float)(random.NextDouble() * 2.0 - 1.0);
            lowNoise += 0.035f * (white - lowNoise);
            float rotationPhase = (float)((phase * rollerContactTicksPerLoop) % 1.0);
            float distanceFromRollerTick = Mathf.Abs(rotationPhase - 0.5f);
            float tickEnvelope = distanceFromRollerTick < 0.19f
                ? Mathf.Exp(-distanceFromRollerTick * 45f) * Mathf.Clamp01((0.19f - distanceFromRollerTick) * 40f)
                : 0f;
            float seamFade = SmoothStep(Mathf.Clamp01((float)Math.Min(t, 8.0 - t) / 0.16f));
            float motor = 0.018f * Mathf.Sin((float)(2.0 * Math.PI * rotationsPerLoop * t / 8.0)) +
                          0.011f * Mathf.Sin((float)(2.0 * Math.PI * 2.0 * rotationsPerLoop * t / 8.0 + 0.7)) +
                          0.006f * Mathf.Sin((float)(2.0 * Math.PI * 5.0 * rotationsPerLoop * t / 8.0 + 1.8));
            float bearing = 0.007f * Mathf.Sin((float)(2.0 * Math.PI * 60.0 * t)) +
                            0.0035f * Mathf.Sin((float)(2.0 * Math.PI * 120.0 * t + 0.2));
            float rollerTexture = seamFade * (0.012f * lowNoise + 0.012f * (white - lowNoise) + tickEnvelope * (0.045f * lowNoise + 0.025f * white));
            samples[frame] = Mathf.Clamp(motor + bearing + rollerTexture, -0.35f, 0.35f);
        }
        return samples;
    }

    private static float SmoothStep(float value) => value * value * (3f - 2f * value);

    private static void WriteWav(string assetPath, float[] samples, int sampleRate, short channels)
    {
        string fullPath = Path.GetFullPath(Path.Combine(Application.dataPath, assetPath.Substring("Assets/".Length)));
        int bytesPerSample = 2;
        int dataLength = samples.Length * bytesPerSample;
        using (var stream = new FileStream(fullPath, FileMode.Create, FileAccess.Write))
        using (var writer = new BinaryWriter(stream, Encoding.ASCII))
        {
            writer.Write(Encoding.ASCII.GetBytes("RIFF"));
            writer.Write(36 + dataLength);
            writer.Write(Encoding.ASCII.GetBytes("WAVE"));
            writer.Write(Encoding.ASCII.GetBytes("fmt "));
            writer.Write(16);
            writer.Write((short)1);
            writer.Write(channels);
            writer.Write(sampleRate);
            writer.Write(sampleRate * channels * bytesPerSample);
            writer.Write((short)(channels * bytesPerSample));
            writer.Write((short)16);
            writer.Write(Encoding.ASCII.GetBytes("data"));
            writer.Write(dataLength);
            foreach (float sample in samples)
                writer.Write((short)Mathf.RoundToInt(Mathf.Clamp(sample, -1f, 1f) * short.MaxValue));
        }
    }
}
