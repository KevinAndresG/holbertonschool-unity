using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    private bool gamePaused;
    public Canvas pause;
    void Start()
    {
        gamePaused = false;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gamePaused)
            {
                Resume();
            }
            else
                Pause();
        }
    }
    public void Pause()
    {
        PlayerPrefs.SetInt("ActualScene", SceneManager.GetActiveScene().buildIndex);
        Cursor.lockState = CursorLockMode.None;
        gamePaused = true;
        pause.gameObject.SetActive(true);
        Time.timeScale = 0f;
    }
    public void Resume()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1f;
        gamePaused = false;
        pause.gameObject.SetActive(false);
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Locked;
    }
    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");

    }
    public void Options()
    {
        SceneManager.LoadScene("Options");

    }
}
