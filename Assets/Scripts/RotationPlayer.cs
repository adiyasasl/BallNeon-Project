using UnityEngine;

public class RotationPlayer : MonoBehaviour
{
    public float Distance {get; private set;}
    public Vector2 LookDir {get; private set;}

    void Update()
    {
        var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        LookDir = mousePos - transform.position;
        Distance = LookDir.magnitude;

        float angle = Mathf.Atan2(LookDir.y, LookDir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, angle);
    }
}
