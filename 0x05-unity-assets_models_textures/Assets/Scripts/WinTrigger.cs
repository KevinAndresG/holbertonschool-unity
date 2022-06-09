using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class WinTrigger : MonoBehaviour
{
    public Timer playerTimer;
    public Text TimerText;
    public Text countDownText;
    private float time;
    private float restarTime = 3f;
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            playerTimer.enabled = false;
            countDownText.gameObject.SetActive(true);
            TimerText.color = Color.green;
            TimerText.fontSize = 60;
            StartCoroutine(winLoadScene(3));
        }
    }
    public void countDown(float sec)
    {
        countDownText.text = string.Format("Next Map In {0:0}", sec);
    }
    void Update()
    {
        if (countDownText.isActiveAndEnabled)
        {
            time += Time.deltaTime;
            float seconds = restarTime - (time % 60);
            countDown(seconds);
        }
    }
    IEnumerator winLoadScene(float sec)
    {
        yield return new WaitForSeconds(sec);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
