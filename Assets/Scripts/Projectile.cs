using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.Events;

public class Projectile : MonoBehaviour
{
    [Header("Events")]
    [SerializeField]
    private UnityEvent onPressedAiming;
    [SerializeField]
    private UnityEvent onReleasedAiming;

    [Header("Audio Components")]
    [SerializeField]
    private AudioClip shootAudio;

    [Header("Projectile Properties")]
    public float BaseSpeed = 10f;
    public float MaxSpeed = 10f;

    [Header("Camera Components")]
    [SerializeField]
    private GameObject cameraFollow;
    [SerializeField]
    private GameObject cameraMovement;

    private RotationPlayer rotationPlayer;
    private Rigidbody2D rb;
    private TrajectoryPredictor tp;
    private PowerSlider powerSlider;
    private Vector2 currentVelocity = Vector2.zero;
    private bool canSlowmo = false;
    private bool canPredict = false;

    public Vector2 CurrentVelocity => currentVelocity;
    void Start()
    {
        rotationPlayer = FindFirstObjectByType<RotationPlayer>();
        rb = GetComponent<Rigidbody2D>();
        tp = GetComponent<TrajectoryPredictor>();
        powerSlider = FindFirstObjectByType<PowerSlider>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !canSlowmo && powerSlider.GetPowerValue() > 0)
        {
            canSlowmo = true;
            canPredict = true;
            Time.timeScale = 0.3f;
            Time.fixedDeltaTime = 0.02f * Time.timeScale;

            var cinemachineFollow = cameraFollow.GetComponent<CinemachineCamera>();
            var cinemachineMovement = cameraMovement.GetComponent<CinemachineCamera>();

            cinemachineFollow.Lens = cinemachineMovement.Lens;

            cameraFollow.SetActive(true);
            cameraMovement.SetActive(false);

            onPressedAiming?.Invoke();
        }

        if (Input.GetMouseButtonUp(0) && canSlowmo && powerSlider.GetPowerValue() > 0)
        {
            canSlowmo = false;
            canPredict = false;
            Time.timeScale = 1f;
            Time.fixedDeltaTime = 0.02f * Time.timeScale;

            var velocity = rotationPlayer.LookDir * BaseSpeed;

            // Using PowerSlide
            if (powerSlider.GetPowerValue() >= MaxSpeed)
                velocity = Vector2.ClampMagnitude(velocity, MaxSpeed);
            else
                velocity = Vector2.ClampMagnitude(velocity, powerSlider.GetPowerValue());

            velocity = Vector2.ClampMagnitude(velocity, MaxSpeed);

            rb.linearVelocity = velocity;

            //Debug.Log(rb.linearVelocity.magnitude);

            cameraMovement.SetActive(true);
            cameraFollow.SetActive(false);

            TriggerAudio.Instance.StartAudio(shootAudio);

            currentVelocity = velocity;

            // Powerslide Decrement
            powerSlider.DecrementValue((int)currentVelocity.magnitude);

            onReleasedAiming?.Invoke();
        }

        if (canPredict)
        {
            tp.drawDebugOnPrediction = true;

            var velocity = rotationPlayer.LookDir * BaseSpeed;

            if (powerSlider.GetPowerValue() > 0)
            {
                // Using PowerSlide
                if (powerSlider.GetPowerValue() >= MaxSpeed)
                    velocity = Vector2.ClampMagnitude(velocity, MaxSpeed);
                else
                    velocity = Vector2.ClampMagnitude(velocity, powerSlider.GetPowerValue());

                velocity = Vector2.ClampMagnitude(velocity, MaxSpeed);

                tp.Predict2D(transform.position, velocity, Physics2D.gravity);
            }


            //mainCamera.transform.position = transform.position;
        }
        else
        {
            tp.drawDebugOnPrediction = false;
        }
    }
}
