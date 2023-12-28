using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeLevelsMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public void OnButtonClick()
    {
        // Здесь вы можете указать имя сцены, на которую вы хотите перейти
        string sceneToLoad = "Levels-menu-2";

        // Загрузка сцены по имени
        SceneManager.LoadScene(sceneToLoad);
    }
}
