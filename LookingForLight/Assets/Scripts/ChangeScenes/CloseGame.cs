using UnityEngine;

public class CloseGame : MonoBehaviour
{
    // ћетод, который будет вызыватьс€ при клике на кнопку
    public void OnButtonClick()
    {
        // Ётот код завершает выполнение приложени€ (закрывает игру)
        // ќбратите внимание, что этот код не будет работать в редакторе Unity
        // ќн будет работать только в собранной версии игры.
        //UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
    }
}
