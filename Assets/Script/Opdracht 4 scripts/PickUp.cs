using UnityEngine;
using System;
using Unity.VisualScripting;

public class Pickup : MonoBehaviour
{
    // Action Event met int (hoeveel score erbij komt)
    [SerializeField] private Scoreboard scoreBoard;

    public int scoreValue = 50;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Pickup"))
        {
            scoreBoard.AddScore(scoreValue);
            Destroy(other.gameObject);  
        }
    }
}
