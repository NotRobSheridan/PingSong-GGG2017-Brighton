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
    public Dropdown songPick;

    public void OnSongChosen()
    {

        AudioSource audio = GetComponent<AudioSource>();

        switch (songPick.value)
        {
            case 1:
                audio.Stop();
                audio.PlayOneShot(song1);
                break;
            case 2:
                audio.Stop();
                audio.PlayOneShot(song2);
                break;
            case 3:
                audio.Stop();
                audio.PlayOneShot(song3);
                break;
            case 4:
                audio.Stop();
                audio.PlayOneShot(song4);
                break;
            case 5:
                audio.Stop();
                audio.PlayOneShot(song5);
                break;
            case 6:
                audio.Stop();
                audio.PlayOneShot(song6);
                break;
        }
    }
}
