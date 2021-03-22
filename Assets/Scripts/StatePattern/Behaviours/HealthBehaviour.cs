using UnityEngine;

public class HealthBehaviour : MonoBehaviour, IHealth, IDamageable, IHealable
{
    public int CurrentHealth => currentHealth;

    [SerializeField] private int maxHealth = 100;

    private int currentHealth;

    private void Awake()
    {
        currentHealth = maxHealth;
    }

    public void Heal(int amount)
    {
        print($"{gameObject.name} heals for {amount}");
        currentHealth += amount;
    }

    public void TakeDamage(int amount)
    {
        print($"{gameObject.name} receives {amount} damage");
        currentHealth -= amount;
    }
}