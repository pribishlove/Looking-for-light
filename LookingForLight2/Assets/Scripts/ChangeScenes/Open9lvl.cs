using UnityEngine;
using UnityEngine.SceneManagement;

public class Open9lvl : MonoBehaviour
{
    // Start is called before the first frame update
    public void OnButtonClick()
    {
        // ����� �� ������ ������� ��� �����, �� ������� �� ������ �������
        string sceneToLoad = "9 level";

        // �������� ����� �� �����
        SceneManager.LoadScene(sceneToLoad);
    }
}
