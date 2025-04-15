using TMPro;
using UnityEngine;

public class MainManager : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI livesText;

    private float timer = 60.0f;
    private bool isCounting = true;

    protected static int score = 0;
    protected static int level = 9;
    protected static int lives = 3;

    private static int b_EnemiesToSpawn = level * 5;
    protected static int EnemiesToSpawn
    {
        get
        {
            return b_EnemiesToSpawn;
        }
        set
        {
            b_EnemiesToSpawn = value;
        }
    }

    void Start()
    {

    }

    void Update()
    {
        Timer();
        UpdateScoreText();
        UpdateLivesText();
    }

    private void Timer()
    {
        if (isCounting)
        {
            timer -= Time.deltaTime;
            timerText.text = "Timer: " + Mathf.CeilToInt(timer);

            if (timer <= 0.0f)
            {
                timer = 0.0f;
                isCounting = false;
            }
        }
    }

    private void UpdateScoreText()
    {
        scoreText.text = "Score: " + score;
    }

    private void UpdateLivesText()
    {
        livesText.text = "Lives: " + lives;
    }
}
