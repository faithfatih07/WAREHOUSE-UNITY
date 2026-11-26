using UnityEngine;

/// <summary>
/// Small runtime controller for the verified Phase 7A warehouse animations.
/// Matching Warehouse Essentials clips are kept on Legacy Animation components;
/// this component only drives the separately named rollers in the tevy GLBs.
/// </summary>
public sealed class WarehousePhase7AAnimationController : MonoBehaviour
{
    [Tooltip("The 25 individually imported rollers from each existing straight GLB module.")]
    public Transform[] conveyorRollers;

    [Tooltip("Roller rotation speed in degrees per second around each roller's local X axis.")]
    [Range(30f, 360f)] public float rollerSpeed = 135f;

    private Quaternion[] startingLocalRotations;
    private float elapsedRotationTime;
    private float initializedAt;

    private void Awake()
    {
        initializedAt = Time.time;
        startingLocalRotations = new Quaternion[conveyorRollers == null ? 0 : conveyorRollers.Length];
        for (int i = 0; i < startingLocalRotations.Length; i++)
            if (conveyorRollers[i] != null)
                startingLocalRotations[i] = conveyorRollers[i].localRotation;
    }

    private void Update()
    {
        if (conveyorRollers == null || startingLocalRotations == null) return;
        elapsedRotationTime = Time.time - initializedAt;
        float angle = elapsedRotationTime * rollerSpeed;
        for (int i = 0; i < conveyorRollers.Length; i++)
        {
            Transform roller = conveyorRollers[i];
            if (roller == null) continue;
            roller.localRotation = startingLocalRotations[i] * Quaternion.AngleAxis(angle, Vector3.right);
        }
    }
}
