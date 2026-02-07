using DG.Tweening;
using TMPro;
using UnityEngine;

public class EnemyScore : MonoBehaviour
{
    [Header("Score Properties")]
    [SerializeField]
    private int scoreValue = 100;

    [Header("Text Components")]
    [SerializeField]
    private TextMeshPro scoreText;

    [Header("Text Animation Properties")]
    [SerializeField]
    private float offsetPosY = 3f;

    private EnemyBehaviour enemyBehaviour;

    void Start()
    {
        enemyBehaviour = transform.parent.GetComponent<EnemyBehaviour>();

        scoreText.text = scoreValue.ToString();
        scoreText.color = enemyBehaviour.SpriteRenderer.color;

        GameManager.Instance.UI.IncreaseScore(scoreValue);

        transform.DOScale(Vector3.one, 0.3f).SetEase(Ease.OutElastic);
        transform.DOMoveY(transform.position.y + offsetPosY, 0.5f).SetEase(Ease.OutBack).OnComplete(() => 
        transform.DOScale(Vector3.zero, 0.3f).SetEase(Ease.OutElastic).OnComplete(() => Destroy(gameObject)));
    }
}
