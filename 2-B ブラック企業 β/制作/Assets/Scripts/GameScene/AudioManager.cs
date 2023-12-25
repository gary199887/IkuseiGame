using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioSource bgm;
    [SerializeField] AudioSource confirmSE;

    public void playBGM() {
        if(!bgm.isPlaying)
            bgm.Play();
    }

    public void stopBGM() {
        if(bgm.isPlaying)
            bgm.Stop();
    }

    public void playConfirmSE() {
        if (!confirmSE.isPlaying)
            confirmSE.Play();
    }
}
