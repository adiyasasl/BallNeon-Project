using DG.Tweening;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [Header("Score Components")]
    [SerializeField]
    private TextMeshProUGUI scoreText;

    [Header("Objective Goal Components")]
    [SerializeField]
    private TextMeshProUGUI objectiveText;

    private int score = 0;
    private int currentObjective = -1;

    public void Init()
    {
        scoreText.text = score.ToString();
        UpdateObjective();
    }

    public void IncreaseScore(int scoreValue)
    {
        score += scoreValue;

        UpdateScore();
        UpdateObjective();
    }

    private void UpdateScore()
    {
        scoreText.text = score.ToString();

        DOTween.Complete(scoreText, false);

        scoreText.transform.DOScale(transform.localScale * 1.3f, 0.5f).SetEase(Ease.OutBack).SetId(scoreText).OnComplete(() =>
        scoreText.transform.DOScale(Vector3.one, 0.5f));
    }

    private void UpdateObjective()
    {
        if (currentObjective >= GameManager.Instance.LevelRule.ObjectiveGoal) return;

        currentObjective++;
        objectiveText.text = $"{currentObjective}/{GameManager.Instance.LevelRule.ObjectiveGoal}";
    }
}
