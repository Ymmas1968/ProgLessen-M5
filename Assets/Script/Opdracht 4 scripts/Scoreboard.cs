using UnityEngine;
using TMPro;

public class Scoreboard : MonoBehaviour
{
    private int score = 0;
    private TMP_Text scoreText;

    void Start()
    {
        scoreText = GetComponent<TMP_Text>();
        UpdateScoreText();
    }

    private void UpdateScoreText()
    {
        scoreText.text = "Score : " + score;
    }

    // Dit is de functie die door Action Event wordt aangeroepen
    public void AddScore(int amount)
    {
        score += amount;
        UpdateScoreText();
    }
}
