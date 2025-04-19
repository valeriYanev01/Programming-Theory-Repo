using TMPro;
using UnityEngine;

public class MainManager : MonoBehaviour
{
    public static MainManager Instance;

    [HideInInspector] public TextMeshProUGUI timerText;
    [HideInInspector] public TextMeshProUGUI scoreText;
    [HideInInspector] public TextMeshProUGUI livesText;

    private float timer = 60.0f;
    private bool isCounting = true;

    public int score = 0;
    public int lives = 3;
    public bool isBossLevel;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        isBossLevel = IsBossLevel();
    }

    void Update()
    {
        if (isBossLevel)
        {
            Timer();
        }

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
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score;
        }
    }

    private void UpdateLivesText()
    {
        if (livesText != null)
        {
            livesText.text = "Lives: " + lives;
        }
    }

    public void LoadUIData()
    {
        if (timerText != null) timerText.text = "Timer: " + Mathf.CeilToInt(timer);
        if (scoreText != null) scoreText.text = "Score: " + score;
        if (livesText != null) livesText.text = "Lives: " + lives;
    }

    public bool IsBossLevel()
    {
        int currentLevel = GameManager.Instance.playerData.level;

        if (currentLevel > 0)
        {
            if (currentLevel % 5 == 0)
            {
                timerText.gameObject.SetActive(true);
                return true;
            }
            else
            {
                timerText.gameObject.SetActive(false);
                return false;
            }
        }
        return false;
    }
}
