using DG.Tweening;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [Header("Score Components")]
    [SerializeField]
    private TextMeshProUGUI scoreText;

    private int score = 0;
    void Awake()
    {
        scoreText.text = score.ToString();
    }

    public void IncreaseScore(int scoreValue)
    {
        score += scoreValue;

        UpdateScore();
    }

    private void UpdateScore()
    {
        scoreText.text = score.ToString();

        DOTween.Complete(scoreText, false);

        scoreText.transform.DOScale(transform.localScale * 1.3f, 0.5f).SetEase(Ease.OutBack).SetId(scoreText).OnComplete(() =>
        scoreText.transform.DOScale(Vector3.one, 0.5f));
    }
}
