using UnityEngine;
using UnityEngine.SceneManagement;

public class Open5lvl : MonoBehaviour
{
    // Start is called before the first frame update
    public void OnButtonClick()
    {
        // ����� �� ������ ������� ��� �����, �� ������� �� ������ �������
        string sceneToLoad = "5 level";

        // �������� ����� �� �����
        SceneManager.LoadScene(sceneToLoad);
    }
}
