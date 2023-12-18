using UnityEngine;
using UnityEngine.UI;

public class DeathCounter : MonoBehaviour
{
    public int deathCount = 0;
    public Text deathText;

    // ���������� ��� ������ ����
    void Start()
    {
        // �������� ��������� Text �� ��������� ������� (���� ����������)
        if (deathText == null)
            deathText = GetComponentInChildren<Text>();

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
        deathText.text = "Deaths: " + deathCount;
    }
}
