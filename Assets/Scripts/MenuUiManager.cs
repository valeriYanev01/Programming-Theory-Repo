using TMPro;
using UnityEngine;

public class MenuUiManager : MonoBehaviour
{
    public TextMeshProUGUI greetingsText;

    private string playerName;

    void Start()
    {
        UpdatePlayerName();
    }

    private void Awake()
    {
        playerName = SaveSystem.LoadPlayer().playerName;
    }

    public void UpdatePlayerName()
    {
        if (greetingsText != null)
        {
            if (playerName.Length > 1)
            {
                greetingsText.text = "Hello, " + playerName;
            }
            else
            {
                greetingsText.text = "Hello, player";
            }
        }
    }
}
