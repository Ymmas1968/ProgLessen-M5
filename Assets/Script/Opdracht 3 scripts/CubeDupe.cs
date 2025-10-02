using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;          // Sleep hier je Enemy prefab (rood kubusje) in Unity
    public List<GameObject> enemies = new List<GameObject>();

    void Update()
    {
        // Spawn 3 enemies als je op W drukt
        if (Input.GetKeyDown(KeyCode.W))
        {
            for (int i = 0; i < 3; i++)
            {
                SpawnEnemy();
            }
        }

        // Clear alle enemies als je op Q drukt
        if (Input.GetKeyDown(KeyCode.Q))
        {
            ClearEnemies();
        }

        // Bonus: verwijder 1 enemy per keer met X
        if (Input.GetKeyDown(KeyCode.X))
        {
            StartCoroutine(RemoveEnemiesOneByOne());
        }
    }

    void SpawnEnemy()
    {
        Vector3 spawnPos = transform.position + new Vector3(Random.Range(-5f, 5f), 0, Random.Range(-5f, 5f));
        GameObject newEnemy = Instantiate(enemyPrefab, spawnPos, Quaternion.identity);
        enemies.Add(newEnemy);
    }

    void ClearEnemies()
    {
        foreach (GameObject enemy in enemies)
        {
            Destroy(enemy);
        }
        enemies.Clear();
    }

    // Bonus: Coroutine die 1 voor 1 verwijdert
    System.Collections.IEnumerator RemoveEnemiesOneByOne()
    {
        while (enemies.Count > 0)
        {
            GameObject enemy = enemies[0];
            enemies.RemoveAt(0);
            Destroy(enemy);
            yield return new WaitForSeconds(0.2f); // wacht 0.2 seconden
        }
    }
}
