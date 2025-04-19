using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SettingsManager : MonoBehaviour
{
    public TMP_InputField newName;
    public TextMeshProUGUI errorText;

    public void GoToMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void SaveData()
    {
        if (newName.text.Length < 2)
        {
            errorText.gameObject.SetActive(true);
            return;
        }

        PlayerData data = new PlayerData
        {
            level = GameManager.Instance.playerData.level,
            playerName = newName.text
        };

        SaveSystem.SavePlayer(data);
        newName.text = "";
        SceneManager.LoadScene(0);
        errorText.gameObject.SetActive(false);
    }

    public void Cancel()
    {
        newName.text = "";
    }
}
