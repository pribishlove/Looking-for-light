using UnityEngine;
using TMPro; // �������� ������������ ���� ��� TextMeshPro

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public float increasedRadius = 10f;
    public float duration = 3f;
    public float remainingTime; // ���������: ���������� ����� ������

    public bool BonusCollected { get; set; }

    public TextMeshProUGUI timerText; // ����������� TextMeshProUGUI ������ Text

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
        // �������������� ������
        remainingTime = duration;
    }

    private void Update()
    {
        // ���������, ��� �� �������� �����
        if (BonusCollected)
        {
            UpdateTimer(); // ���������: ���������� �������
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
