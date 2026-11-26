using UnityEngine;

/// <summary>
/// Moves the four existing conveyor loads along the straight belt and resets
/// them at its endpoint. The endpoint reset is a visual demo, not a physical loop.
/// </summary>
[DisallowMultipleComponent]
public sealed class WarehouseConveyorPackageFlow : MonoBehaviour
{
    [SerializeField] private Transform[] packages = new Transform[0];
    [SerializeField, Min(0f)] private float speedMetersPerSecond = 1f;
    [SerializeField] private float routeStartX = 41f;
    [SerializeField] private float routeEndX = 57f;

    private float[] startingX;
    private double startedAt;

    private void Start()
    {
        if (packages == null || packages.Length != 4 || routeEndX <= routeStartX)
        {
            Debug.LogError("WarehouseConveyorPackageFlow requires four package references and a valid X route.", this);
            enabled = false;
            return;
        }

        startingX = new float[packages.Length];
        for (int i = 0; i < packages.Length; i++)
        {
            if (packages[i] == null)
            {
                Debug.LogError("WarehouseConveyorPackageFlow has a missing package reference at index " + i + ".", this);
                enabled = false;
                startingX = null;
                return;
            }

            startingX[i] = packages[i].position.x;
        }

        startedAt = Time.timeAsDouble;
    }

    private void Update()
    {
        if (startingX == null) return;

        double routeLength = routeEndX - routeStartX;
        double distance = Mathf.Max(0f, speedMetersPerSecond) * (Time.timeAsDouble - startedAt);

        for (int i = 0; i < packages.Length; i++)
        {
            Transform package = packages[i];
            if (package == null) continue;

            double offset = PositiveModulo(startingX[i] - routeStartX + distance, routeLength);
            Vector3 position = package.position;
            position.x = routeStartX + (float)offset;
            package.position = position;
        }
    }

    private static double PositiveModulo(double value, double modulus)
    {
        double remainder = value % modulus;
        return remainder < 0d ? remainder + modulus : remainder;
    }
}
