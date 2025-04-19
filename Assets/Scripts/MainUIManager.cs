using TMPro;
using UnityEngine;

public class MainUIManager : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI livesText;

    void Start()
    {
        MainManager.Instance.timerText = timerText;
        MainManager.Instance.scoreText = scoreText;
        MainManager.Instance.livesText = livesText;

        MainManager.Instance.LoadUIData();
    }
}
