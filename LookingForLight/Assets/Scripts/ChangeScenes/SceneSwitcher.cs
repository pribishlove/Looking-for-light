using UnityEngine;
using UnityEngine.SceneManagement;
using System.Runtime.InteropServices;

public class SceneSwitcher : MonoBehaviour
{
    [DllImport("__Internal")]
    private static extern void ShowAdv();
    public void OnButtonClick()
    {
        ShowAdv();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
