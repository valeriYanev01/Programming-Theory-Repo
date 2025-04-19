using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevelManager : MonoBehaviour
{
    public TextMeshProUGUI textCongratulations;
    public TextMeshProUGUI textScore;
    string playerName;

    private void Start()
    {
        LoadPlayerName();
        DisplayText();
        SaveGameProgress();
    }

    public void ResetLevel()
    {
        GameManager.Instance.playerData.level--;

        SaveSystem.SavePlayer(new PlayerData
        {
            level = GameManager.Instance.playerData.level,
            playerName = playerName
        });

        SceneManager.LoadScene(1);
        MainManager.Instance.score = 0;
    }

    public void NextLevel()
    {
        SceneManager.LoadScene(1);
        MainManager.Instance.score = 0;
    }

    public void GoToMenu()
    {
        SceneManager.LoadScene(0);
    }

    private void LoadPlayerName()
    {
        playerName = SaveSystem.LoadPlayer().playerName;

        if (playerName.Length < 2)
        {
            playerName = "Player";
        }
    }

    private void SaveGameProgress()
    {
        SaveSystem.SavePlayer(new PlayerData
        {
            level = GameManager.Instance.playerData.level,
            playerName = playerName
        });
    }

    private void DisplayText()
    {
        textCongratulations.text = "Congratulations, " + playerName;
        textScore.text = "Score: " + MainManager.Instance.score;
    }
}
