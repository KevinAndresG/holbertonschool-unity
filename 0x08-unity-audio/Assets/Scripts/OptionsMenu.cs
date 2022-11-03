using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OptionsMenu : MonoBehaviour
{
    public Toggle invertYaxis;
    public bool yesOrNot;
    // Start is called before the first frame update
    void Start()
    {
    }
    public void Back()
    {
        SceneManager.LoadScene(PlayerPrefs.GetInt("ActualScene"));
        Time.timeScale = 1f;
    }
    public void Apply()
    {
        if (invertYaxis.isOn)
        {
            yesOrNot = true;
            SceneManager.LoadScene(PlayerPrefs.GetInt("ActualScene"));
            Time.timeScale = 1f;
            Cursor.lockState = CursorLockMode.Locked;
        }
        else
        {
            SceneManager.LoadScene(PlayerPrefs.GetInt("ActualScene"));
            yesOrNot = false;
            Time.timeScale = 1f;
            Cursor.lockState = CursorLockMode.Locked;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
