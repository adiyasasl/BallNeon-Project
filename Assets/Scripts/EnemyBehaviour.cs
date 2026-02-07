using FirstGearGames.SmoothCameraShaker;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class EnemyBehaviour : Health
{
    [Header("Audio Properties")]
    [SerializeField]
    private AudioClip deadAudio;

    [Header("Camera Shaker Properties")]
    [SerializeField]
    private ShakeData shakeData;

    [Header("Color Properties")]
    [SerializeField]
    private Color[] colors;

    private SpawnArea spawnArea;
    private PowerSlider powerSlider;
    private ParticleManager particleManager;
    private SpriteRenderer spriteRenderer;
    private Light2D light2D;

    public SpriteRenderer SpriteRenderer => spriteRenderer;

    void Start()
    {
        spawnArea = FindFirstObjectByType<SpawnArea>();
        powerSlider = FindFirstObjectByType<PowerSlider>();
        particleManager = FindFirstObjectByType<ParticleManager>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        light2D = GetComponentInChildren<Light2D>();

        int randomColorIndex = Random.Range(0, colors.Length);

        Color color = colors[randomColorIndex];
        spriteRenderer.color = new Color(color.r, color.g, color.b, color.a);

        light2D.color = color;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            ParticleBehaviour behaviour = particleManager.GetParticles();
            behaviour.ChangeColor(spriteRenderer.color);
            behaviour.gameObject.transform.position = transform.position;
            behaviour.gameObject.SetActive(true);
            
            DecrementValue(1);
            powerSlider.IncrementValue(20);
            
            CameraShakerHandler.Shake(shakeData);

            TriggerAudio.Instance.StartAudio(deadAudio);
        }

        if (collision.gameObject.CompareTag("Enemy"))
        {
            transform.position = spawnArea.GetRandomPosition();
        }
    }
}
