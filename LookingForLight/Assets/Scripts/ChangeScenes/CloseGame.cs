using UnityEngine;

public class CloseGame : MonoBehaviour
{
    // �����, ������� ����� ���������� ��� ����� �� ������
    public void OnButtonClick()
    {
        // ���� ��� ��������� ���������� ���������� (��������� ����)
        // �������� ��������, ��� ���� ��� �� ����� �������� � ��������� Unity
        // �� ����� �������� ������ � ��������� ������ ����.
        //UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
    }
}
