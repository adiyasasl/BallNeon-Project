using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour, IDestroyable, IIncreamentable
{
    [Header("Events")]
    [SerializeField]
    private UnityEvent onHealthEmpty;
    [SerializeField]
    private UnityEvent onHealthIncrease;
    [SerializeField]
    private UnityEvent onHealthDecrease;

    [Header("Health Properties")]
    [SerializeField]
    private int maxHealth;

    private int _currentHealth;

    void Awake()
    {
        _currentHealth = maxHealth;
    }

    public virtual void Destroy()
    {
        if (_currentHealth <= 0)
            onHealthEmpty?.Invoke();
    }

    public virtual void IncrementValue(int value)
    {
        _currentHealth += value;

        onHealthIncrease?.Invoke();
    }

    public virtual void DecrementValue(int value)
    {
        _currentHealth -= value;
        Destroy();

        onHealthDecrease?.Invoke();
    }
}
