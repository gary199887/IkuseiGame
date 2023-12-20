using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TitleAudioManager : MonoBehaviour
{
    [SerializeField] AudioSource bgm;
    [SerializeField] AudioSource keyboardSE;
    [SerializeField] AudioSource confirmSE;
    [SerializeField] AudioSource cancelSE;

    public void playBGM() {
        if(!bgm.isPlaying)
            bgm.Play();
    }

    public void stopBGM() {
        if(bgm.isPlaying)
            bgm.Stop();
    }

    public void playKeyboardSE() {
        if(!keyboardSE.isPlaying)
            keyboardSE.Play();
    }
    public void stopKeyboardSE() {
        if(keyboardSE.isPlaying)
            keyboardSE.Stop();
    }

    public void playConfirmSE() {
        if (!confirmSE.isPlaying)
            confirmSE.Play();
        else {
            confirmSE.Stop();
            confirmSE.Play();
        }
    }

    public void playCancelSE() {
        if (!cancelSE.isPlaying)
            cancelSE.Play();
        else
        {
            cancelSE.Stop();
            cancelSE.Play();
        }
    }
}
