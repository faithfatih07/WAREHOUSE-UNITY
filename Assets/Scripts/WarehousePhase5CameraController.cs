using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering.Universal;

/// <summary>Switches the final warehouse's single camera between overview and first person.</summary>
[RequireComponent(typeof(Camera))]
public sealed class WarehousePhase5CameraController : MonoBehaviour
{
    public Transform roofPanels;
    public Transform playerRoot;
    public CharacterController playerController;
    public float walkSpeed = 4.5f;
    public float mouseSensitivity = 0.12f;
    public float eyeHeight = 1.62f;
    public float overviewSize = 43f;

    private Camera viewCamera;
    private bool firstPerson;
    private bool cursorCaptured;
    private bool transitioning;
    private float yaw;
    private float pitch;
    private float transitionStarted;
    private const float TransitionDuration = 0.35f;
    private Vector3 transitionFromPosition;
    private Quaternion transitionFromRotation;
    private Vector3 transitionToPosition;
    private Quaternion transitionToRotation;
    private Vector3 overviewPosition;
    private Quaternion overviewRotation;

    public bool IsFirstPerson => firstPerson;

    private void Awake()
    {
        viewCamera = GetComponent<Camera>();
        overviewPosition = new Vector3(83f, 83f, -44f);
        overviewRotation = Quaternion.LookRotation(new Vector3(32f, 2f, 8f) - overviewPosition, Vector3.up);
        viewCamera.orthographic = true;
        viewCamera.orthographicSize = overviewSize;
        viewCamera.transform.SetPositionAndRotation(overviewPosition, overviewRotation);
        if (roofPanels != null) roofPanels.gameObject.SetActive(false);
        if (playerController != null) playerController.enabled = false;
        firstPerson = false;
        SetCursorCaptured(false);
        ConfigureAntialiasing();
    }

    private void ConfigureAntialiasing()
    {
        UniversalAdditionalCameraData data = GetComponent<UniversalAdditionalCameraData>();
        if (data == null) data = gameObject.AddComponent<UniversalAdditionalCameraData>();
        data.antialiasing = AntialiasingMode.FastApproximateAntialiasing;
        data.antialiasingQuality = AntialiasingQuality.Medium;
        data.renderPostProcessing = true;
    }

    private void Update()
    {
        Keyboard keyboard = Keyboard.current;
        Mouse mouse = Mouse.current;
        if (keyboard != null && keyboard.vKey.wasPressedThisFrame) ToggleMode();
        if (keyboard != null && keyboard.escapeKey.wasPressedThisFrame) SetCursorCaptured(false);
        if (firstPerson && !cursorCaptured && mouse != null && mouse.leftButton.wasPressedThisFrame) SetCursorCaptured(true);
        if (transitioning) UpdateTransition();

        if (firstPerson)
        {
            if (cursorCaptured) UpdateFirstPerson(keyboard, mouse);
            return;
        }
        if (mouse != null) UpdateOverview(mouse);
    }

    private void ToggleMode()
    {
        if (playerRoot == null || playerController == null) return;
        firstPerson = !firstPerson;
        if (roofPanels != null) roofPanels.gameObject.SetActive(firstPerson);
        if (firstPerson)
        {
            playerRoot.position = new Vector3(1.7f, 0.05f, 4.5f);
            playerRoot.rotation = Quaternion.identity;
            yaw = 0f;
            pitch = 0f;
            playerController.enabled = true;
            SetCursorCaptured(true);
            transitionToPosition = playerRoot.position + Vector3.up * eyeHeight;
            transitionToRotation = Quaternion.identity;
        }
        else
        {
            playerController.enabled = false;
            SetCursorCaptured(false);
            transitionToPosition = overviewPosition;
            transitionToRotation = overviewRotation;
        }
        transitionFromPosition = transform.position;
        transitionFromRotation = transform.rotation;
        transitionStarted = Time.unscaledTime;
        transitioning = true;
        viewCamera.orthographic = !firstPerson;
        if (!firstPerson) viewCamera.orthographicSize = overviewSize;
    }

    private void UpdateTransition()
    {
        float t = Mathf.Clamp01((Time.unscaledTime - transitionStarted) / TransitionDuration);
        float eased = t * t * (3f - 2f * t);
        transform.SetPositionAndRotation(Vector3.Lerp(transitionFromPosition, transitionToPosition, eased), Quaternion.Slerp(transitionFromRotation, transitionToRotation, eased));
        if (t >= 1f) transitioning = false;
    }

    private void UpdateFirstPerson(Keyboard keyboard, Mouse mouse)
    {
        if (keyboard == null || mouse == null || playerController == null || !playerController.enabled) return;
        Vector2 look = mouse.delta.ReadValue() * mouseSensitivity;
        yaw += look.x;
        pitch = Mathf.Clamp(pitch - look.y, -82f, 82f);
        playerRoot.rotation = Quaternion.Euler(0f, yaw, 0f);
        transform.SetPositionAndRotation(playerRoot.position + Vector3.up * eyeHeight, Quaternion.Euler(pitch, yaw, 0f));

        Vector3 input = Vector3.zero;
        if (keyboard.wKey.isPressed) input.z += 1f;
        if (keyboard.sKey.isPressed) input.z -= 1f;
        if (keyboard.dKey.isPressed) input.x += 1f;
        if (keyboard.aKey.isPressed) input.x -= 1f;
        Vector3 move = playerRoot.TransformDirection(Vector3.ClampMagnitude(input, 1f)) * walkSpeed;
        playerController.Move(move * Time.deltaTime + Vector3.down * 9.81f * Time.deltaTime);
    }

    private void UpdateOverview(Mouse mouse)
    {
        if (mouse.scroll.ReadValue().y != 0f)
            overviewSize = Mathf.Clamp(overviewSize - mouse.scroll.ReadValue().y * 0.008f, 27f, 58f);
        viewCamera.orthographicSize = overviewSize;
        if (mouse.rightButton.isPressed)
        {
            Vector2 drag = mouse.delta.ReadValue();
            Vector3 shift = (-transform.right * drag.x + -transform.up * drag.y) * (overviewSize / Mathf.Max(300f, Screen.height));
            overviewPosition += shift;
            overviewPosition.x = Mathf.Clamp(overviewPosition.x, 45f, 112f);
            overviewPosition.z = Mathf.Clamp(overviewPosition.z, -74f, -10f);
            overviewRotation = Quaternion.LookRotation(new Vector3(32f, 2f, 8f) - overviewPosition, Vector3.up);
            transform.SetPositionAndRotation(overviewPosition, overviewRotation);
        }
    }

    private void SetCursorCaptured(bool captured)
    {
        cursorCaptured = captured;
        Cursor.lockState = captured ? CursorLockMode.Locked : CursorLockMode.None;
        Cursor.visible = !captured;
    }

    private void OnDisable() => SetCursorCaptured(false);

    private void OnGUI()
    {
        GUI.Box(new Rect(18f, 18f, 620f, 58f), firstPerson
            ? (cursorCaptured ? "FIRST PERSON  |  WASD move  •  Mouse look  •  Esc release  •  V overview" : "FIRST PERSON  |  Click to look  •  WASD move  •  V overview")
            : "WAREHOUSE OVERVIEW  |  V first person  •  Scroll zoom  •  Right-drag pan");
    }
}
