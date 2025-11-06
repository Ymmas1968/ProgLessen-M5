using UnityEngine;

public class Brute : EnemyParent
{
    private void Start()
    {
        moveSpeed = 1f;  // Langzaam
        health = 10;     // Veel levens
    }
}