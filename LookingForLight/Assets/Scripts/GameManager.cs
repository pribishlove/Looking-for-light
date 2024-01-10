using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;

    public static GameManager Instance
    {
        get { return _instance; }
        set { _instance = value; }
    }

    public float increasedRadius = 10f;
    public float duration = 3f;
    public float remainingTime;

    public bool BonusCollected { get; set; }

    public TextMeshProUGUI timerText;

    private void Awake()
    {
        // Если экземпляр еще не установлен, установите его текущим объектом
        if (_instance == null)
        {
            _instance = this;
        }
        else
        {
            // Если экземпляр уже установлен и не совпадает с текущим объектом, уничтожьте текущий объект
            if (_instance != this)
            {
                Destroy(gameObject);
            }
        }
    }

    private void Start()
    {
        remainingTime = duration;
    }

    private void Update()
    {
        if (BonusCollected)
        {
            UpdateTimer();
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
