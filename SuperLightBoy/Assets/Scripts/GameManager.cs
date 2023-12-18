using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public float increasedRadius = 10f;
    public float duration = 3f;
    public float remainingTime; // Добавлено: оставшееся время бонуса

    public bool BonusCollected { get; set; }

    public Text timerText; // Добавлено: текстовый элемент для отображения времени

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
            timerText.text = $"Time left: {Mathf.Ceil(remainingTime)}s";
        }
    }

}
