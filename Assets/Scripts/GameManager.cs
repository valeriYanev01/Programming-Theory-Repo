using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public PlayerData playerData;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);

            // Load existing player data, or if there isn't, create new
            playerData = SaveSystem.LoadPlayer() ?? new PlayerData();
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
