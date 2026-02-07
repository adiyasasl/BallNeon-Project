using Unity.Cinemachine;
using UnityEngine;

public class SpeedBasedZoom : MonoBehaviour
{
    [Header("Target & Speed Settings")]
    public Rigidbody2D targetRigidbody; // Drag the player/object here in the Inspector
    public float minSpeed = 0f;
    public float maxSpeed = 20f;

    [Header("Zoom Settings")]
    public float minZoomSize = 5f;   // Zoom in amount (smaller orthographic size)
    public float maxZoomSize = 10f;  // Zoom out amount (larger orthographic size)
    public float zoomSmoothTime = 0.5f; // How smooth the transition is

    private CinemachineCamera mainCamera;
    private float targetZoomSize;
    private float zoomVelocity; // Used by SmoothDamp

    void Start()
    {
        mainCamera = GetComponent<CinemachineCamera>();
        targetZoomSize = mainCamera.Lens.OrthographicSize;
    }

    void Update()
    {
        if (targetRigidbody != null)
        {
            // 1. Get the current speed (magnitude of velocity) of the target
            float currentSpeed = targetRigidbody.linearVelocity.magnitude;

            // 2. Calculate a speed fraction (0 to 1) using InverseLerp
            // 0 means minSpeed, 1 means maxSpeed
            float speedFraction = Mathf.InverseLerp(minSpeed, maxSpeed, currentSpeed);

            // 3. Determine the target orthographic size by interpolating (Lerp)
            // between minZoomSize and maxZoomSize based on the speed fraction
            targetZoomSize = Mathf.Lerp(minZoomSize, maxZoomSize, speedFraction);

            // 4. Smoothly change the camera's actual orthographic size
            mainCamera.Lens.OrthographicSize = Mathf.SmoothDamp(
                mainCamera.Lens.OrthographicSize,
                targetZoomSize,
                ref zoomVelocity,
                zoomSmoothTime
            );
        }
    }
}
