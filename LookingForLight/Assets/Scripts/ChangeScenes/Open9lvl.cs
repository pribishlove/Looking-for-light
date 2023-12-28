using UnityEngine;
using UnityEngine.SceneManagement;

public class Open9lvl : MonoBehaviour
{
    // Start is called before the first frame update
    public void OnButtonClick()
    {
        // Здесь вы можете указать имя сцены, на которую вы хотите перейти
        string sceneToLoad = "9 level";

        // Загрузка сцены по имени
        SceneManager.LoadScene(sceneToLoad);
    }
}
