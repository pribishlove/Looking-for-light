using UnityEngine;
using TMPro; // Добавьте пространство имен для TextMeshPro

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public float increasedRadius = 10f;
    public float duration = 3f;
    public float remainingTime; // Добавлено: оставшееся время бонуса

    public bool BonusCollected { get; set; }

    public TextMeshProUGUI timerText; // Используйте TextMeshProUGUI вместо Text

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        // Инициализируем таймер
        remainingTime = duration;
    }

    private void Update()
    {
        // Проверяем, был ли подобран бонус
        if (BonusCollected)
        {
            UpdateTimer(); // Добавлено: обновление таймера
        }
    }

    private void UpdateTimer()
    {
        remainingTime -= Time.deltaTime;

        if (remainingTime <= 0f)
        {
            BonusCollected = false;
            remainingTime = 0f;
        }

        if (timerText != null)
        {
            timerText.text = $"{Mathf.Ceil(remainingTime)}s";
        }
    }
}
