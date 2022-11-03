using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSteps : MonoBehaviour
{
    [SerializeField] AudioClip steps;
    [SerializeField] AudioClip fallInGrass;
    [SerializeField] AudioClip fallInRock;
    [SerializeField] AudioSource aud;
    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            other.GetComponent<AudioSource>().clip = steps;
            other.GetComponent<AudioSource>().Play();
        }
        if (other.tag == "Player")
        {
            if (gameObject.tag == "Grass")
            {
                aud.PlayOneShot(fallInGrass);
            }
            if (gameObject.tag == "Rock")
            {
                aud.PlayOneShot(fallInRock);
            }
        }
    }
}
