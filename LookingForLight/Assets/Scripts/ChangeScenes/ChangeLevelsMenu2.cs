using UnityEngine;
using UnityEngine.SceneManagement;
public class ChangeLevelsMenu2 : MonoBehaviour
{
    // Start is called before the first frame update
    public void OnButtonClick()
    {
        // ����� �� ������ ������� ��� �����, �� ������� �� ������ �������
        string sceneToLoad = "Levels-menu-1";

        // �������� ����� �� �����
        SceneManager.LoadScene(sceneToLoad);
    }
}
