using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelMenu : MonoBehaviour
{
    // Массив сцен/уровней. Убедитесь, что порядок сцен соответствует порядку кнопок в меню.
    public string[] levelNames;

    // Метод, вызываемый при нажатии кнопки уровня
    public void LoadLevel(int levelIndex)
    {
        // Проверяем, что индекс не выходит за границы массива
        if (levelIndex >= 0 && levelIndex < levelNames.Length)
        {
            // Загружаем сцену с соответствующим именем
            SceneManager.LoadScene(levelNames[levelIndex]);
        }
        else
        {
            Debug.LogError("Недопустимый индекс уровня");
        }
    }
}
