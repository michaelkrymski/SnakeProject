using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinLoseAudioManager : MonoBehaviour
{
    [SerializeField] AudioSource winSound;
    [SerializeField] AudioSource loseSound;

    public void PlayWinSound()
    {
        transform.parent.GetComponent<AudioSource>().Stop();
        winSound.Play();
    }

    public void PlayLoseSound()
    {
        transform.parent.GetComponent<AudioSource>().Stop();
        loseSound.Play();
    }
}
