using UnityEngine;

public class OrbitBehaviour : MonoBehaviour
{
    [Header("Orbit Properties")]
    [SerializeField]
    private float speed = 2f;
    void Update()
    {
        transform.Rotate(Vector3.forward * speed * Time.deltaTime);
    }
}
