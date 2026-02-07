using UnityEngine;

public class ParticleBehaviour : MonoBehaviour
{
    [Header("Particle Components")]
    [SerializeField]
    private ParticleSystem particle;

    void Start()
    {
        particle = GetComponent<ParticleSystem>();
    }

    public void ChangeColor(Color color)
    {
        var main = particle.main;
        main.startColor = color;
    }
}
