using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PowerSlider : MonoBehaviour, IIncreamentable
{
    [Header("Increment Properties")]
    [SerializeField]
    private float incrementDuration = 0.2f;

    [Header("Power Properties")]
    [SerializeField]
    private float powerValue = 30f;

    private Slider slider;

    void Start()
    {
        slider = GetComponent<Slider>();
        Init();
    }

    private void Init()
    {
        powerValue = GameManager.Instance.GamePhase.LevelConfig.MaxPowerBar;

        slider.maxValue = powerValue;
        slider.value = slider.maxValue;
    }

    public virtual void DecrementValue(int value)
    {
        //StartCoroutine(UpdateSliderValue(value, false));
        SliderValue(value, false);
    }

    public virtual void IncrementValue(int value)
    {
        //StartCoroutine(UpdateSliderValue(value, true));
        SliderValue(value, true);
    }

    public float GetPowerValue()
    {
        return slider.value;
    }

    private void SliderValue(float targetValue, bool isIncrement)
    {
        if (isIncrement)
        {
            slider.value += targetValue;
        }
        else
        {
            slider.value -= targetValue;
        }
    }

    private IEnumerator UpdateSliderValue(float targetValue, bool isIncrement)
    {
        float currentValue = slider.value;

        if (!isIncrement)
        {
            while (currentValue > targetValue)
            {
                slider.value -= Time.deltaTime * incrementDuration;
                yield return null;
            }
        }
        else
        {
            while (currentValue < targetValue)
            {
                slider.value += Time.deltaTime * incrementDuration;
                yield return null;
            }
        }

        yield break;
    }
}
