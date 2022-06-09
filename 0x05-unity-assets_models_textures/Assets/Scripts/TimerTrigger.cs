using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerTrigger : MonoBehaviour
{
    public Timer playerTimer;
    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            playerTimer.enabled = true;
        }
    }
}
