using UnityEngine;
using UnityEngine.SceneManagement;

public class Open4lvl : MonoBehaviour
{
    // Start is called before the first frame update
    public void OnButtonClick()
    {
        // ����� �� ������ ������� ��� �����, �� ������� �� ������ �������
        string sceneToLoad = "4 level";

        // �������� ����� �� �����
        SceneManager.LoadScene(sceneToLoad);
    }
}
