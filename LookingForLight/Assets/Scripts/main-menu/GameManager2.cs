using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager2 : MonoBehaviour
{
    private const string SceneKey = "LastScene";

    public void SaveScene()
    {
        PlayerPrefs.SetInt(SceneKey, SceneManager.GetActiveScene().buildIndex + 1);
        PlayerPrefs.Save();
    }

    public int LoadLastScene()
    {
        return PlayerPrefs.GetInt(SceneKey, 0);
    }
}
