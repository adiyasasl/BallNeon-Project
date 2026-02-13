using DG.Tweening;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("Level Rule")]
    [SerializeField]
    private LevelRuleConfig levelRuleConfig;

    [Header("Managers")]
    [SerializeField]
    private GamePhaseManager gamePhaseManager;
    [SerializeField]
    private UIManager uIManager;

    public LevelRuleConfig LevelRule => levelRuleConfig;
    public GamePhaseManager GamePhase => gamePhaseManager;
    public UIManager UI => uIManager;
    void Awake()
    {
        if (Instance != null && Instance == this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    void Start() 
    {
        Initialize();
    }

    private void Initialize()
    {
        gamePhaseManager.Init();
        uIManager.Init();
    }
}
