using UnityEngine;
using UnityEngine.SceneManagement;

public class Open3lvl : MonoBehaviour
{
    // Start is called before the first frame update
    public void OnButtonClick()
    {
        // ����� �� ������ ������� ��� �����, �� ������� �� ������ �������
        string sceneToLoad = "Third level";

        // �������� ����� �� �����
        SceneManager.LoadScene(sceneToLoad);
    }
}
