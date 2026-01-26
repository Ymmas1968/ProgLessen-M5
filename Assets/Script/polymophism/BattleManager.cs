using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    public List<Enemy> enemies = new List<Enemy>();

    public int playerHealth = 100;

    void Start()
    {
        enemies.Add(new Zombie());
        enemies.Add(new Goblin());
        enemies.Add(new Dragon());
        enemies.Add(new Enemy());


        Debug.Log("Battle gestart!");
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            foreach (Enemy enemy in enemies)
            {
                enemy.Attack();
                playerHealth -= 10;
            }

            Debug.Log("Player HP: " + playerHealth);
            CheckGameOver();
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            foreach (Enemy enemy in enemies)
            {
                enemy.TakeDamage(20);
            }

            CheckVictory();
        }
    }

    void CheckVictory()
    {
        bool allDead = true;

        foreach (Enemy enemy in enemies)
        {
            if (enemy.health > 0)
            {
                allDead = false;
            }
        }

        if (allDead)
        {
            Debug.Log("All dead");
        }
    }

    void CheckGameOver()
    {
        if (playerHealth <= 0)
        {
            Debug.Log("Game Over");
        }
    }
}