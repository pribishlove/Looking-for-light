using UnityEngine;
using UnityEngine.SceneManagement;

public class Open7lvl : MonoBehaviour
{
    // Start is called before the first frame update
    public void OnButtonClick()
    {
        // ����� �� ������ ������� ��� �����, �� ������� �� ������ �������
        string sceneToLoad = "7 level";

        // �������� ����� �� �����
        SceneManager.LoadScene(sceneToLoad);
    }
}
