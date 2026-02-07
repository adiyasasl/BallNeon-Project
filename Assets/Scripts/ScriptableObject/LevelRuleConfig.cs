using UnityEngine;

[CreateAssetMenu(fileName = "Level Rule", menuName = "Level/Level Rule", order = 0)]
public class LevelRuleConfig : ScriptableObject
{
    [Header("Setup Level")]
    public float MaxPowerBar = 60f;

    [Header("Player")]
    public float BaseSpeed = 6f;
    public float MaxSpeed = 20f;
}
