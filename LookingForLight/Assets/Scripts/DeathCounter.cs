using UnityEngine;
using TMPro; // �������� ������������ ���� ��� TextMeshPro

public class DeathCounter : MonoBehaviour
{
    public int deathCount = 0;
    public TextMeshProUGUI deathText; // ����������� TextMeshProUGUI ������ Text

    // ���������� ��� ������ ����
    void Start()
    {
        // �������� ��������� TextMeshProUGUI �� ��������� ������� (���� ����������)
        if (deathText == null)
            deathText = GetComponentInChildren<TextMeshProUGUI>();

        // �������� ����� ��� ������
        UpdateDeathText();
    }

    // ���������� ��� ������ ������
    public void PlayerDied()
    {
        deathCount++;
        UpdateDeathText();
    }

    // �������� ����������� ������
    void UpdateDeathText()
    {
        // ���������� ����� ����� � ����������� �������
        if (deathText != null)
        {
            deathText.text = deathCount.ToString();
        }
    }
}
