using UnityEngine;

/// <summary>
/// Manages health for an enemy and destroys the object when health reaches zero.
/// </summary>
public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private int _maxHealth = 100;
    private int _currentHealth;

    private void Start()
    {
        _currentHealth = _maxHealth;
    }

    /// <summary>
    /// Applies damage to the enemy.
    /// </summary>
    /// <param name="damage">Amount of damage to subtract.</param>
    public void TakeDamage(int damage)
    {
        _currentHealth -= damage;

        if (_currentHealth <= 0)
        {
            Die();
        }
    }

    /// <summary>
    /// Handles enemy death logic.
    /// </summary>
    private void Die()
    {
        Destroy(gameObject);
    }
}
