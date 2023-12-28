using UnityEngine;

public class GameController : MonoBehaviour
{
    // Метод для управления паузой
    public static void TogglePause()
    {
        Time.timeScale = 1f; // Возобновление
    }
}
