using UnityEngine;
using TMPro; // Добавьте пространство имен для TextMeshPro
using UnityEngine.UI;

public class EndLevel : MonoBehaviour
{
    public TextMeshProUGUI countOfDeaths; // Используйте TextMeshProUGUI вместо Text
    public TextMeshProUGUI time; // Используйте TextMeshProUGUI вместо Text
    public TextMeshProUGUI additionalText1; // Используйте TextMeshProUGUI вместо Text
    public TextMeshProUGUI additionalText2; // Используйте TextMeshProUGUI вместо Text
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

                // Вызываем метод LevelComplete
                levelManager.LevelComplete(levelTime, deathCount);

                // Выключаем дополнительные тексты и картинки
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
