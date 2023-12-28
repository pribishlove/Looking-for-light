using UnityEngine;
using UnityEngine.SceneManagement;
using System.Runtime.InteropServices;
using YG;

public class SceneSwitcher : MonoBehaviour
{
    //[DllImport("__Internal")]
    //private static extern void ShowAdv();
    public void OnButtonClick()
    {
        //ShowAdv();
        YandexGame.FullscreenShow();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
