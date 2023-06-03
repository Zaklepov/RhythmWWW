using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButtons : MonoBehaviour
{
    public int nextScene;
    public void SceneSelect()
    {
        SceneManager.LoadSceneAsync(nextScene);
    }

    public void ExitGame()
    {
        PlayerPrefs.SetInt("Save", 0);
        Application.Quit();
    }
}