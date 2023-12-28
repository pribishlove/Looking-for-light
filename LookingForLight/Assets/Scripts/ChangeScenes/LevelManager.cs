using UnityEngine;
using TMPro; // �������� ������������ ���� ��� TextMeshPro

public class LevelManager : MonoBehaviour
{
    public GameObject resultPanel;
    public TextMeshProUGUI timeText; // ����������� TextMeshProUGUI ������ Text
    public TextMeshProUGUI deathCountText; // ����������� TextMeshProUGUI ������ Text

    private bool levelCompleted = false;

    // ����� ��� ������ ��� ���������� ������
    public void LevelComplete(TextMeshProUGUI levelTime, TextMeshProUGUI deathCount)
    {
        if (!levelCompleted)
        {
            levelCompleted = true;

            // ��������� ���������� ���������
            RenderSettings.ambientLight = Color.black;

            // ��������� ��������� �������� �� ������ �����������
            if (timeText != null)
            {
                timeText.text = levelTime.text;
            }

            if (deathCountText != null)
            {
                deathCountText.text = deathCount.text;
            }

            // ���������� ������ �����������
            if (resultPanel != null)
            {
                resultPanel.SetActive(true);
            }
        }
    }
}
