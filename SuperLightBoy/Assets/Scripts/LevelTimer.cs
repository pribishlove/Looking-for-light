using UnityEngine;
using UnityEngine.UI;

public class LevelTimer : MonoBehaviour
{
    private float elapsedTime;
    public Text timerText;

    void Start()
    {
        if (timerText == null)
            timerText = GetComponentInChildren<Text>();

        elapsedTime = 0f;
        UpdateTimerText();
    }

    void Update()
    {
        elapsedTime += Time.deltaTime;
        UpdateTimerText();
    }

    void UpdateTimerText()
    {
        int minutes = Mathf.FloorToInt(elapsedTime / 60f);
        int seconds = Mathf.RoundToInt(elapsedTime % 60f);
        timerText.text = $"Time: {minutes:D2}:{seconds:D2}";
    }
}
