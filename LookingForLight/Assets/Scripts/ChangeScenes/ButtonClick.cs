using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonClick : MonoBehaviour
{
    // Метод, который будет вызываться при нажатии кнопки
    public void OnButtonClick()
    {
        // Здесь вы можете указать имя сцены, на которую вы хотите перейти
        string sceneToLoad = "Main-menu";

        // Загрузка сцены по имени
        SceneManager.LoadScene(sceneToLoad);
    }
}
