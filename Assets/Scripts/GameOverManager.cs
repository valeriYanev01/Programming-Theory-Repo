using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;

    private void Start()
    {
        scoreText.text = "Score: " + MainManager.Instance.score;
        MainManager.Instance.isGameOverTriggerred = true;

        if (MainManager.Instance)
        {
            Destroy(MainManager.Instance.gameObject);
        }
    }

    public void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit(); // Quit application if it's a build
#endif
    }

    public void GoToMenu()
    {
        MainManager.Instance.isGameOverTriggerred = false;
        SceneManager.LoadScene(0);
    }
}
