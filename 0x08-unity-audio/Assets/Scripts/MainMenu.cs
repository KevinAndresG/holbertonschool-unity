using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    void Start()
    {
        GameManager.Instance.inGame = false;
        SoundController.Instance.PlaySongs();
    }
    public void Hover()
    {
        SoundController.Instance.PlayEffects(0);
    }

    public void LevelSelect(int level)
    {
        switch (level)
        {
            case 1:
                PlayerPrefs.SetString("sceneLoaded", "Level01");
                Cursor.lockState = CursorLockMode.Locked;
                SceneManager.LoadScene("Level01");
                Time.timeScale = 1f;
                SoundController.Instance.PlayEffects(1);
                GameManager.Instance.inGame = true;
                SoundController.Instance.PlaySongs();
                break;
            case 2:
                PlayerPrefs.SetString("sceneLoaded", "Level02");
                Cursor.lockState = CursorLockMode.Locked;
                SceneManager.LoadScene("Level02");
                Time.timeScale = 1f;
                SoundController.Instance.PlayEffects(1);
                GameManager.Instance.inGame = true;
                SoundController.Instance.PlaySongs();
                break;
            case 3:
                PlayerPrefs.SetString("sceneLoaded", "Level03");
                Cursor.lockState = CursorLockMode.Locked;
                SceneManager.LoadScene("Level03");
                Time.timeScale = 1f;
                SoundController.Instance.PlayEffects(1);
                GameManager.Instance.inGame = true;
                SoundController.Instance.PlaySongs();
                break;
        }

    }
    public void Options()
    {
        PlayerPrefs.SetInt("OptionScene", SceneManager.GetActiveScene().buildIndex);
        SceneManager.LoadScene("Options");
        SoundController.Instance.PlayEffects(1);
    }
    public void Quit()
    {
        Debug.Log("Quit Game");
        Application.Quit();
        SoundController.Instance.PlayEffects(1);
    }

}
