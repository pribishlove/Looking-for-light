using UnityEngine;
using TMPro; // Добавьте пространство имен для TextMeshPro

public class LevelManager : MonoBehaviour
{
    public GameObject resultPanel;
    public TextMeshProUGUI timeText; // Используйте TextMeshProUGUI вместо Text
    public TextMeshProUGUI deathCountText; // Используйте TextMeshProUGUI вместо Text

    private bool levelCompleted = false;

    // Метод для вызова при завершении уровня
    public void LevelComplete(TextMeshProUGUI levelTime, TextMeshProUGUI deathCount)
    {
        if (!levelCompleted)
        {
            levelCompleted = true;

            // Отключаем глобальное освещение
            RenderSettings.ambientLight = Color.black;

            // Обновляем текстовые элементы на панели результатов
            if (timeText != null)
            {
                timeText.text = levelTime.text;
            }

            if (deathCountText != null)
            {
                deathCountText.text = deathCount.text;
            }

            // Активируем панель результатов
            if (resultPanel != null)
            {
                resultPanel.SetActive(true);
            }
        }
    }
}
