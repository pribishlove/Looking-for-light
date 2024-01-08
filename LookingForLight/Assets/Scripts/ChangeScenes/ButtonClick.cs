using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonClick : MonoBehaviour
{
    // �����, ������� ����� ���������� ��� ������� ������

    private GameManager2 gameManager;

    void Start()
    {
        gameManager = FindObjectOfType<GameManager2>();
    }

    public void OnButtonClick()
    {
        gameManager.SaveScene();
        // ����� �� ������ ������� ��� �����, �� ������� �� ������ �������
        string sceneToLoad = "Main-menu";

        // �������� ����� �� �����
        SceneManager.LoadScene(sceneToLoad);
    }
}
