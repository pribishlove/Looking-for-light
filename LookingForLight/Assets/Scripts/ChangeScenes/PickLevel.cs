using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelMenu : MonoBehaviour
{
    // ������ ����/�������. ���������, ��� ������� ���� ������������� ������� ������ � ����.
    public string[] levelNames;

    // �����, ���������� ��� ������� ������ ������
    public void LoadLevel(int levelIndex)
    {
        // ���������, ��� ������ �� ������� �� ������� �������
        if (levelIndex >= 0 && levelIndex < levelNames.Length)
        {
            // ��������� ����� � ��������������� ������
            SceneManager.LoadScene(levelNames[levelIndex]);
        }
        else
        {
            Debug.LogError("������������ ������ ������");
        }
    }
}
