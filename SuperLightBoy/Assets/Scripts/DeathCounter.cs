using UnityEngine;
using UnityEngine.UI;

public class DeathCounter : MonoBehaviour
{
    public int deathCount = 0;
    public Text deathText;

    // Вызывается при старте игры
    void Start()
    {
        // Получите компонент Text из дочернего объекта (если необходимо)
        if (deathText == null)
            deathText = GetComponentInChildren<Text>();

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
        deathText.text = "Deaths: " + deathCount;
    }
}
