using UnityEngine;
using TMPro; // Добавьте пространство имен для TextMeshPro

public class DeathCounter : MonoBehaviour
{
    public int deathCount = 0;
    public TextMeshProUGUI deathText; // Используйте TextMeshProUGUI вместо Text

    // Вызывается при старте игры
    void Start()
    {
        // Получите компонент TextMeshProUGUI из дочернего объекта (если необходимо)
        if (deathText == null)
            deathText = GetComponentInChildren<TextMeshProUGUI>();

        // Обновите текст при старте
        UpdateDeathText();
    }

    // Вызывается при смерти игрока
    public void PlayerDied()
    {
        deathCount++;
        UpdateDeathText();
    }

    // Обновить отображение текста
    void UpdateDeathText()
    {
        // Установите новый текст с количеством смертей
        if (deathText != null)
        {
            deathText.text = deathCount.ToString();
        }
    }
}
