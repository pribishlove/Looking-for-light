using UnityEngine;
using TMPro; // �������� ������������ ���� ��� TextMeshPro
using UnityEngine.UI;

public class EndLevel : MonoBehaviour
{
    public TextMeshProUGUI countOfDeaths; // ����������� TextMeshProUGUI ������ Text
    public TextMeshProUGUI time; // ����������� TextMeshProUGUI ������ Text
    public TextMeshProUGUI additionalText1; // ����������� TextMeshProUGUI ������ Text
    public TextMeshProUGUI additionalText2; // ����������� TextMeshProUGUI ������ Text
    public Image additionalImage1;
    public Image additionalImage2;
    public GameObject player;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            LevelManager levelManager = FindObjectOfType<LevelManager>();

            if (levelManager != null)
            {
                var levelTime = time;
                var deathCount = countOfDeaths;

                // �������� ����� LevelComplete
                levelManager.LevelComplete(levelTime, deathCount);

                // ��������� �������������� ������ � ��������
                if (additionalText1 != null)
                {
                    additionalText1.gameObject.SetActive(false);
                }

                if (additionalText2 != null)
                {
                    additionalText2.gameObject.SetActive(false);
                }

                if (additionalImage1 != null)
                {
                    additionalImage1.gameObject.SetActive(false);
                }

                if (additionalImage2 != null)
                {
                    additionalImage2.gameObject.SetActive(false);
                }

                if (player != null)
                {
                    player.SetActive(false);
                }
            }
        }
    }
}
