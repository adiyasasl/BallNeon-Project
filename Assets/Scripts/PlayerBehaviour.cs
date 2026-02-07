using DG.Tweening;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    [Header("Audio Properties")]
    [SerializeField]
    private AudioClip hitAudio;

    private Rigidbody2D rb;
    private Projectile projectile;
    private bool isPlay = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0;
        projectile = GetComponent<Projectile>();

        projectile.enabled = false;
        transform.localScale = Vector3.zero;
    }
    void Update()
    {
        if (Input.GetMouseButtonUp(0) && !isPlay)
        {
            transform.DOScale(1f, 0.6f).SetEase(Ease.OutBack).OnComplete(() => {rb.gravityScale = 1; projectile.enabled = true;});
            isPlay = true;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.collider.CompareTag("Enemy"))
            TriggerAudio.Instance.StartAudio(hitAudio);
    }
}
