using UnityEngine;
using UnityEngine.SceneManagement;

public class Open1lvl : MonoBehaviour
{
    // Start is called before the first frame update
    public void OnButtonClick()
    {
        // ����� �� ������ ������� ��� �����, �� ������� �� ������ �������
        string sceneToLoad = "First level";

        // �������� ����� �� �����
        SceneManager.LoadScene(sceneToLoad);
    }
}
