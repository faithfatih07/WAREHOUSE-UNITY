using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>Owns the small Phase 7B audio set and follows the Phase 7A conveyor's active state.</summary>
public sealed class WarehousePhase7BAudioController : MonoBehaviour
{
    [Header("Phase 7B sources")]
    public AudioSource ambienceSource;
    public AudioSource conveyorSource;
    public WarehousePhase7AAnimationController conveyorOperation;

    [Header("Level")]
    [Range(0f, 1f)] public float ambienceVolume = 0.12f;
    [Range(0f, 1f)] public float conveyorVolume = 0.18f;

    [SerializeField] private bool muted;
    private bool conveyorWasRunning;

    public bool IsMuted => muted;

    private void Awake()
    {
        ApplyLevelsAndMute();
        if (ambienceSource != null && ambienceSource.clip != null && !ambienceSource.isPlaying)
            ambienceSource.Play();
        UpdateConveyorPlayback(true);
    }

    private void Update()
    {
        Keyboard keyboard = Keyboard.current;
        if (keyboard != null && keyboard.mKey.wasPressedThisFrame)
            SetMuted(!muted);

        UpdateConveyorPlayback(false);
    }

    public void SetMuted(bool shouldMute)
    {
        if (muted == shouldMute) return;
        muted = shouldMute;
        ApplyLevelsAndMute();
        Debug.Log("Phase 7B audio " + (muted ? "muted" : "unmuted") + ". Press M to toggle.");
    }

    private void ApplyLevelsAndMute()
    {
        if (ambienceSource != null)
        {
            ambienceSource.volume = ambienceVolume;
            ambienceSource.mute = muted;
        }
        if (conveyorSource != null)
        {
            conveyorSource.volume = conveyorVolume;
            conveyorSource.mute = muted;
        }
    }

    private void UpdateConveyorPlayback(bool force)
    {
        bool shouldRun = conveyorOperation != null &&
                         conveyorOperation.isActiveAndEnabled &&
                         conveyorOperation.gameObject.activeInHierarchy;
        if (!force && shouldRun == conveyorWasRunning) return;

        conveyorWasRunning = shouldRun;
        if (conveyorSource == null || conveyorSource.clip == null) return;
        if (shouldRun)
        {
            if (!conveyorSource.isPlaying) conveyorSource.Play();
        }
        else if (conveyorSource.isPlaying)
        {
            conveyorSource.Stop();
        }
    }

    private void OnGUI()
    {
        GUI.Box(new Rect(18f, Screen.height - 52f, 156f, 32f), muted ? "M  Warehouse audio: Off" : "M  Warehouse audio: On");
    }
}
