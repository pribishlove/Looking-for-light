using UnityEngine;
using UnityEngine.SceneManagement;

public class Open2lvl : MonoBehaviour
{
    // Start is called before the first frame update
    public void OnButtonClick()
    {
        // ����� �� ������ ������� ��� �����, �� ������� �� ������ �������
        string sceneToLoad = "Second level";

        // �������� ����� �� �����
        SceneManager.LoadScene(sceneToLoad);
    }
}
