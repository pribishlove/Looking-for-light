using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeLevelsMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public void OnButtonClick()
    {
        // ����� �� ������ ������� ��� �����, �� ������� �� ������ �������
        string sceneToLoad = "Levels-menu-2";

        // �������� ����� �� �����
        SceneManager.LoadScene(sceneToLoad);
    }
}
