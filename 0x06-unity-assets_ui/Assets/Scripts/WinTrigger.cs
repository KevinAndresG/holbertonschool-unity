using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class WinTrigger : MonoBehaviour
{
    public Timer playerTimer;
    public Text TimerText;
    public Canvas winCanvas;
    private float time;
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            playerTimer.enabled = false;
            TimerText.enabled = false;
            // TimerText.color = Color.green;
            // TimerText.fontSize = 60;
            winCanvas.gameObject.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Time.timeScale = 0f;
        }
    }
    void Update()
    {
    }
}
