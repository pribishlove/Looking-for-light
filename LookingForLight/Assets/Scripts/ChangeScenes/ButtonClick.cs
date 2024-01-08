using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonClick : MonoBehaviour
{
    // Метод, который будет вызываться при нажатии кнопки

    private GameManager2 gameManager;

    void Start()
    {
        gameManager = FindObjectOfType<GameManager2>();
    }

    public void OnButtonClick()
    {
        gameManager.SaveScene();
        // Здесь вы можете указать имя сцены, на которую вы хотите перейти
        string sceneToLoad = "Main-menu";

        // Загрузка сцены по имени
        SceneManager.LoadScene(sceneToLoad);
    }
}
