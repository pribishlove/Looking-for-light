using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private GameManager2 gameManager;

    void Start()
    {
        gameManager = FindObjectOfType<GameManager2>();
    }

    public void ContinueGame()
    {
        int lastSceneIndex = gameManager.LoadLastScene();
        SceneManager.LoadScene(lastSceneIndex);
    }
}
