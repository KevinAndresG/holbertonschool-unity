using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundController : MonoBehaviour
{
    public static SoundController Instance;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    void Start()
    {
        playMusic.loop = true;
    }
    [SerializeField] AudioSource playEffects;
    [SerializeField] AudioSource playMusic;
    [SerializeField] AudioClip menuMusic;
    [SerializeField] AudioClip[] inGameMusic;
    [SerializeField] AudioClip[] effects;
    [SerializeField] AudioClip winClip;
    public void PlayEffects(int effect)
    {
        // 0 is the hover effect
        // 1 is the click effect
        playEffects.clip = effects[effect];
        playEffects.Play();
    }
    public void PlaySongs()
    {
        if (GameManager.Instance.inGame == false)
        {
            playMusic.Stop();
            playMusic.clip = menuMusic;
            playMusic.Play();
            playMusic.loop = true;
        }
        else
        {
            Debug.Log(SceneManager.GetActiveScene().name);
            playMusic.Stop();
            if (PlayerPrefs.GetString("sceneLoaded") == "Level01")
            {
                playMusic.clip = inGameMusic[0];
            }
            if (PlayerPrefs.GetString("sceneLoaded") == "Level02")
            {
                playMusic.clip = inGameMusic[1];
            }
            if (PlayerPrefs.GetString("sceneLoaded") == "Level03")
            {
                playMusic.clip = inGameMusic[2];
            }
            playMusic.Play();
            playMusic.loop = true;
        }
    }
    public void WinMusic()
    {
        playMusic.Stop();
        playMusic.clip = winClip;
        playMusic.loop = false;
        playMusic.Play();
    }
}
