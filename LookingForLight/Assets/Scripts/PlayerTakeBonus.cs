using System.Collections;
using UnityEngine;
using TMPro; // �������� ������������ ���� ��� TextMeshPro
using UnityEngine.UI;

public class PlayerTakeBonus : MonoBehaviour
{
    private bool isCountingDown = false;
    public float countdownDuration = 10f;
    public Image bonusImage;
    public Image bonusTimeImage;
    private float countdownTimer;
    public TextMeshProUGUI countdownText; // ����������� TextMeshProUGUI ������ Text

    private void Start()
    {
        if (countdownText == null)
            countdownText = GetComponentInChildren<TextMeshProUGUI>();

        HideText(); // ������ ����� ��� ������
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bonus") && !isCountingDown)
        {
            StartCountdown();
        }
    }

    private void StartCountdown()
    {
        isCountingDown = true;
        countdownTimer = countdownDuration;
        StartCoroutine(CountdownRoutine());
        ShowText(); // �������� ����� ��� ������ ��������� �������
    }

    private IEnumerator CountdownRoutine()
    {
        while (countdownTimer > 0f)
        {
            UpdateCountdownText();
            countdownTimer -= Time.deltaTime;
            yield return null;
        }

        EndCountdown();
    }

    private void UpdateCountdownText()
    {
        int roundedTimer = Mathf.RoundToInt(countdownTimer);
        countdownText.text = roundedTimer.ToString();
    }

    private void EndCountdown()
    {
        countdownText.text = "";
        isCountingDown = false;
        HideText(); // ������ ����� �� ���������� ��������� �������
    }

    private void ShowText()
    {
        countdownText.enabled = true;
        bonusImage.enabled = true;
        bonusTimeImage.enabled = true;
    }

    private void HideText()
    {
        countdownText.enabled = false;
        bonusImage.enabled = false;
        bonusTimeImage.enabled = false;
    }
}
