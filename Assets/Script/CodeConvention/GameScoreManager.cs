using UnityEngine;

/// <summary>
/// Keeps track of the player's score and provides access through a singleton.
/// </summary>
public class GameScoreManager : MonoBehaviour
{
    public static GameScoreManager Instance { get; private set; }

    public int Score { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }

    /// <summary>
    /// Adds points to the player's total score.
    /// </summary>
    /// <param name="points">Number of points to add.</param>
    public void AddScore(int points)
    {
        Score += points;
    }
}
