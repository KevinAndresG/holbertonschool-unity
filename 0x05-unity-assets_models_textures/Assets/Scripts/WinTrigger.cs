using UnityEngine;
using UnityEngine.UI;

public class WinTrigger : MonoBehaviour
{
    public Timer playerTimer;
    public Text TimerText;
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            playerTimer.enabled = false;
            TimerText.color = Color.green;
            TimerText.fontSize = 60;
        }
    }
}
