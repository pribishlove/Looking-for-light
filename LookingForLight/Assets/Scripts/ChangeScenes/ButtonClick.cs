using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonClick : MonoBehaviour
{
    // �����, ������� ����� ���������� ��� ������� ������
    public void OnButtonClick()
    {
        // ����� �� ������ ������� ��� �����, �� ������� �� ������ �������
        string sceneToLoad = "Main-menu";

        // �������� ����� �� �����
        SceneManager.LoadScene(sceneToLoad);
    }
}
