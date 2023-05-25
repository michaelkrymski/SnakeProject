using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinLoseAudioManager : MonoBehaviour
{
    [SerializeField] AudioSource winSound;
    [SerializeField] AudioSource loseSound;

    public void PlayWinSound()
    {
        winSound.Play();
    }

    public void PlayLoseSound()
    {
        loseSound.Play();
    }
}
