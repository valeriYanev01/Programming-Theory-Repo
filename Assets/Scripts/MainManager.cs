using TMPro;
using UnityEngine;

public class MainManager : MonoBehaviour
{
    public TextMeshProUGUI timerText;

    //private int level;
    private float timer = 60.0f;
    private bool isCounting = true;

    protected static int level = 1;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Timer();
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
}
