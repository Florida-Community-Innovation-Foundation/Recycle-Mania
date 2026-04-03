using UnityEngine;
using TMPro;

public class GameUI : MonoBehaviour
{
    public TMP_Text timerText;
    public TMP_Text counterText;
    public float timeLimit = 60f;
    private float timeRemaining;
    private int score = 0;
    private bool timesUp = false;

    private ItemSpawner spawner;

    void Start()
    {

        if (timerText == null)
        {
            timerText = GameObject.Find("Timer").GetComponent<TMP_Text>();
        }
        if (counterText == null)
        {
            counterText = GameObject.Find("Counter").GetComponent<TMP_Text>();
        }

        spawner = FindObjectOfType<ItemSpawner>();

        timeRemaining = timeLimit;
        UpdateTimerText();
        UpdateCounterText();
    }

    void Update()
    {
        if (timeRemaining > 0 && !timesUp)
        {
            timeRemaining -= Time.deltaTime;
            UpdateTimerText();

            if (timeRemaining <= 0)
            {
                timeRemaining = 0;
                UpdateTimerText();
                timesUp = true;
                if (spawner != null)
                    spawner.TimeUp();
            }
        }
    }

    public void IncrementScore()
    {
        score++;
        UpdateCounterText();
    }

    public void StopTimer()
    {
        timesUp = true;
    }

    private void UpdateTimerText()
    {
        timerText.text = Mathf.Ceil(timeRemaining).ToString();
    }

    private void UpdateCounterText()
    {
        counterText.text = "Score: " + score.ToString() + "/" + (spawner != null ? spawner.TotalItems.ToString() : "?");
    }
}