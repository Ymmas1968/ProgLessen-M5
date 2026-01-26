using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float health = 100f;
    public float speed = 2f;

    public virtual void TakeDamage(float damage)
    {
        health -= damage;
        Debug.Log($"{gameObject.name} valt en pakt damage {damage} damage HP: {health}");
        if (health <= 0)
        {
            Die();
        }
    }

    public virtual void Attack()
    {
        Debug.Log($"{gameObject.name} valt aan!");
    }

    public virtual void Die()
    {
        Debug.Log($"{gameObject.name} bro got vaporised");
        Destroy(gameObject);
    }
}