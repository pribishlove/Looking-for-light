using UnityEngine;

public class GameController : MonoBehaviour
{
    // ����� ��� ���������� ������
    public static void TogglePause()
    {
        Time.timeScale = 1f; // �������������
    }
}
