using UnityEngine;
using UnityEngine.SceneManagement;

public class Open6lvl : MonoBehaviour
{
    // Start is called before the first frame update
    public void OnButtonClick()
    {
        // ����� �� ������ ������� ��� �����, �� ������� �� ������ �������
        string sceneToLoad = "6 level";

        // �������� ����� �� �����
        SceneManager.LoadScene(sceneToLoad);
    }
}
