using UnityEngine;
using UnityEngine.SceneManagement;

public class Open8lvl : MonoBehaviour
{
    // Start is called before the first frame update
    public void OnButtonClick()
    {
        // ����� �� ������ ������� ��� �����, �� ������� �� ������ �������
        string sceneToLoad = "8 level";

        // �������� ����� �� �����
        SceneManager.LoadScene(sceneToLoad);
    }
}
