using TMPro;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    public float gameTime = 30.0f;
    public float gameTimer = 0.0f;
    public bool isPlaying;

    public TextMeshProUGUI timerText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        isPlaying = true;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateGameTimer();
        UpdateTimerText();
    }

    public void UpdateGameTimer()
    {
        gameTimer += Time.deltaTime;
        if(gameTime < gameTimer)
        {
            gameTimer = gameTime;
            isPlaying = false;
            Debug.Log(" GameOver ");
        }
    }

    public void UpdateTimerText()
    {
        timerText.text = (gameTime - gameTimer).ToString("F2");
    }
}
