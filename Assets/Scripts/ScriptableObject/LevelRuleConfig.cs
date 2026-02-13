using UnityEngine;

[CreateAssetMenu(fileName = "Level Rule", menuName = "Level/Level Rule", order = 0)]
public class LevelRuleConfig : ScriptableObject
{
    [Header("Setup Level")]
    public int ObjectiveGoal = 10;

    [Header("Player")]
    public float MaxPowerBar = 60f;
    public float BaseSpeed = 6f;
    public float MaxSpeed = 20f;
}
