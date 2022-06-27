using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text TimerText;
    private float time;
    public Canvas winCanvas;
    public Text winText;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        float minutes = ((int)time / 60);
        float seconds = (time % 60);
        float miliSeconds = (int)((time - (int)time) * 100);
        TimerText.text = string.Format("{0:00}:{1:00}.{2:00}", minutes, seconds, miliSeconds);

        if (winCanvas.enabled == true)
        {
            Win();
        }
    }
    public void Win()
    {
        winText.text = TimerText.text;
    }
}
