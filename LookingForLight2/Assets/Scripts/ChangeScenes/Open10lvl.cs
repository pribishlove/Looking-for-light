using UnityEngine;
using UnityEngine.SceneManagement;

public class Open10lvl : MonoBehaviour
{
    // Start is called before the first frame update
    public void OnButtonClick()
    {
        // ����� �� ������ ������� ��� �����, �� ������� �� ������ �������
        string sceneToLoad = "10 level";

        // �������� ����� �� �����
        SceneManager.LoadScene(sceneToLoad);
    }
}
