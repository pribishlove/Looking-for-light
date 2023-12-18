using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlayerTakeBonus : MonoBehaviour
{
    private bool isCountingDown = false;
    public float countdownDuration = 10f;
    private float countdownTimer;
    public Text countdownText;

    private void Start()
    {
        if (countdownText == null)
            countdownText = GetComponentInChildren<Text>();

        HideText(); // —крыть текст при старте
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
        ShowText(); // ѕоказать текст при старте обратного отсчета
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
        countdownText.text = "Bonus time left: " + roundedTimer + "s";
    }

    private void EndCountdown()
    {
        countdownText.text = "";
        isCountingDown = false;
        HideText(); // —крыть текст по завершению обратного отсчета
    }

    private void ShowText()
    {
        countdownText.enabled = true;
    }

    private void HideText()
    {
        countdownText.enabled = false;
    }
}
