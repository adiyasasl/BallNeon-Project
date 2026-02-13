using UnityEngine;
using UnityEngine.UI;

public class GamePhaseManager : MonoBehaviour
{
    [Header("Phase Setting")]
    [SerializeField]
    private Slider powerSlider;
    [SerializeField]
    private Projectile projectile;

    public void Init()
    {
        powerSlider.maxValue = GameManager.Instance.LevelRule.MaxPowerBar;
        powerSlider.value = powerSlider.maxValue;

        projectile.BaseSpeed = GameManager.Instance.LevelRule.BaseSpeed;
        projectile.MaxSpeed = GameManager.Instance.LevelRule.MaxSpeed;
    }
}
