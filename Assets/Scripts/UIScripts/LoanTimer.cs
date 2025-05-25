using System.Collections;
using UnityEngine;
using UnityEngine.UI;
public class LoanTimer : MonoBehaviour
{
    public float loanTimeSeconds = 300f;
    public Text loanTimerText;

    private float loanStartTime;
    private float remainingTime;
    private bool isTimerRunning = true;
    private LoadScene loadScene;

    private void Start()
    {
        loadScene = gameObject.GetComponent<LoadScene>();

        loanTimerText = gameObject.GetComponent<Text>();
        remainingTime = loanTimeSeconds;
        loanStartTime = Time.time;
        isTimerRunning = true;
    }

    private void Update()
    {
        if (isTimerRunning)
        {
            updateTimer();
        }
    }
    private void updateTimer()
    {
        remainingTime = loanTimeSeconds - (Time.time - loanStartTime);
        loanTimerText.text = FormatTime(remainingTime);
        if (remainingTime <= 0)
        {
            remainingTime = 0;
            loanTimerText.text = FormatTime(remainingTime);
            finishTimer();
        }
    }

    private string FormatTime(float time)
    {
        int minutes = Mathf.FloorToInt(time / 60);
        int seconds = Mathf.FloorToInt(time % 60);

        return string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    private void finishTimer()
    {
        isTimerRunning = false;
        loadScene.LoadGivenScene("GameOverLoan");
    }

    private void paidInFull()
    {
        isTimerRunning = false;
    }
}
