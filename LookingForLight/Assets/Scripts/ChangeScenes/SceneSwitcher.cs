using UnityEngine;
using UnityEngine.SceneManagement;
using System.Runtime.InteropServices;
using YG;

public class SceneSwitcher : MonoBehaviour
{
    //[DllImport("__Internal")]
    //private static extern void ShowAdv();

    private GameManager2 gameManager;

    void Start()
    {
        gameManager = FindObjectOfType<GameManager2>();
    }

    public void OnButtonClick()
    {
        //ShowAdv();
        
        gameManager.SaveScene();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

        YandexGame.FullscreenShow();

    }
}
