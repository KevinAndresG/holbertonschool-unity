using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    void Update()
    {

    }
    public void SceneSelect()
    {
        if (this.gameObject.name == "Level01")
        {
            LevelSelect(1);
        }
        if (this.gameObject.name == "Level02")
        {
            LevelSelect(2);
        }
        if (this.gameObject.name == "Level03")
        {
            LevelSelect(3);
        }

    }
    public void LevelSelect(int level)
    {
        switch (level)
        {
            case 1:
                Cursor.lockState = CursorLockMode.Locked;
                SceneManager.LoadScene("Level01");
                Time.timeScale = 1f;
                break;
            case 2:
                Cursor.lockState = CursorLockMode.Locked;
                SceneManager.LoadScene("Level02");
                Time.timeScale = 1f;
                break;
            case 3:
                Cursor.lockState = CursorLockMode.Locked;
                SceneManager.LoadScene("Level03");
                Time.timeScale = 1f;
                break;
        }

    }
    public void Options()
    {
        PlayerPrefs.SetInt("OptionScene", SceneManager.GetActiveScene().buildIndex);
        SceneManager.LoadScene("Options");
    }
    public void Quit()
    {
        Debug.Log("Quit Game");
        Application.Quit();
    }

}
