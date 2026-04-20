using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highscoreText;

    private int score = 0;
    private int highscore = 0;

    private void Awake(){instance = this;}

    void Start()
    {
        // PlayerPrefs.DeleteKey("Highscore"); //reset
        highscore = PlayerPrefs.GetInt("Highscore", 0);
        UpdateUI();
    }

    public void AddPoint()
    {
        score++;
        if (score > highscore)
        {
            highscore = score;
            PlayerPrefs.SetInt("Highscore", highscore);
            PlayerPrefs.Save();
        }

        UpdateUI();
    }

    private void UpdateUI()
    {
        scoreText.text = score + " Points";
        highscoreText.text = "HIGHSCORE: " + highscore;
    }
}