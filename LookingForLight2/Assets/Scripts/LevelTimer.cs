using UnityEngine;
using TMPro; // Добавьте пространство имен для TextMeshPro

public class LevelTimer : MonoBehaviour
{
    private float elapsedTime;
    public TextMeshProUGUI timerText; // Используйте TextMeshProUGUI вместо Text

    void Start()
    {
        if (timerText == null)
            timerText = GetComponentInChildren<TextMeshProUGUI>();

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
        timerText.text = $"{minutes:D2}:{seconds:D2}";
    }
}
