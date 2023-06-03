using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    public VideoPlayer player;
    public AudioSource audioSource;
    public GameObject fin;
    void Update()
    {
        if (Time.timeScale == 0)
        {
            fin.SetActive(false);
        }
    }
    public void Resume()
    {
        Time.timeScale = 1;
        player.Play();
        audioSource.Play();
        pauseMenu.SetActive(false);
    }
    public void Restart()
    {
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().name);
        Time.timeScale = 1;
    }

    // Update is called once per frame
    public void Exit()
    {
        Time.timeScale = 1;
        SceneManager.LoadSceneAsync(0);
    }
}
