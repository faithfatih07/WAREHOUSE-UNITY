using UnityEngine;

/// <summary>
/// Serialized configuration for the editor driven Phase 6 stock generator.
/// Generated scene objects are owned by WAREHOUSE_GENERATED_STOCK_ROOT.
/// </summary>
public sealed class WarehouseStockGenerator : MonoBehaviour
{
    [Header("Rack capacity")]
    [Range(1, 5)] public int rackRows = 5;
    [Range(1, 6)] public int baysPerRow = 6;
    [Range(1, 2)] public int shelfLevels = 2;
    [Range(0f, 100f)] public float fillDensityPercent = 50f;
    public int randomSeed = 12345;

    [Header("Load distribution (relative weights)")]
    [Min(0f)] public float palletOnlyWeight = 15f;
    [Min(0f)] public float boxesWeight = 45f;
    [Min(0f)] public float cratesWeight = 40f;

    [Header("Existing scene references")]
    public Transform storageRackRoot;
    public Transform generatedStockRoot;

    [Header("Verified source models")]
    public GameObject palletModel;
    public GameObject smallBoxModel;
    public GameObject mediumBoxModel;
    public GameObject smallCrateModel;
    public GameObject largeCrateModel;

    [HideInInspector] public int lastGeneratedLoadCount;
    [HideInInspector] public string lastGenerationSummary = "Not generated yet";
}
