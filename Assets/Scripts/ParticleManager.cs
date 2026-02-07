using System.Collections.Generic;
using UnityEngine;

public class ParticleManager : MonoBehaviour
{
    [Header("Spawn Components")]
    [SerializeField]
    private GameObject particlePrefab;

    [Header("Spawn Properties")]
    [SerializeField]
    private int spawnValue = 10;

    private List<GameObject> _particles = new List<GameObject>();

    void Start()
    {
        for (int i = 0; i < spawnValue; i++)
        {
            GameObject particle = Instantiate(particlePrefab, transform);

            _particles.Add(particle);
            particle.SetActive(false);
        }
    }

    public ParticleBehaviour GetParticles()
    {
        ParticleBehaviour behaviour = null;

        foreach(GameObject obj in _particles)
        {
            if (!obj.activeInHierarchy)
            {
                behaviour = obj.GetComponent<ParticleBehaviour>();
                break;
            }
        }

        return behaviour;
    }
}
