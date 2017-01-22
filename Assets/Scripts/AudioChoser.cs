using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioChoser : MonoBehaviour
{

    public AudioClip song1;
    public AudioClip song2;
    public AudioClip song3;
    public AudioClip song4;
    public AudioClip song5;
    public AudioClip song6;
    public AudioSource audio;
    // Use this for initialization
    void Start()
    {

        AudioSource audio = GetComponent<AudioSource>();

        int randomNum = Random.Range(1, 6);

        switch (randomNum)
        {
            case 1:
                audio.PlayOneShot(song1);
                break;
            case 2:
                audio.PlayOneShot(song2);
                break;
            case 3:
                audio.PlayOneShot(song3);
                break;
            case 4:
                audio.PlayOneShot(song4);
                break;
            case 5:
                audio.PlayOneShot(song5);
                break;
            case 6:
                audio.PlayOneShot(song6);
                break;
        }
    }
}
