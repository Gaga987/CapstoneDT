using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundManager : MonoBehaviour
{
    public AudioArray[] themeSound, gameplaySounds;
    public AudioSource themeSource, gameplaysoundsSource;

    public void PlayTheme(string name)
    {
        AudioArray audioArray = Array.Find(themeSound, theme => theme.name == name);

        if (audioArray == null)
        {
            Debug.Log(" Audio name not found");
        }
        else
        {
            themeSource.clip = audioArray.clip;
            themeSource.Play();
        }
    }

    public void PlaySingleSounds(string name)
    {
        AudioArray audioArray = Array.Find(gameplaySounds, gS => gS.name == name);

        if (audioArray == null)
        {
            Debug.Log(" Audio name not found");
        }
        else
        {
            gameplaysoundsSource.clip = audioArray.clip;
            gameplaysoundsSource.PlayOneShot(audioArray.clip);
        }
    }

    void Start()
    {
        PlayTheme("StartingSound");
        Debug.Log("Audio Manager :  " +   themeSound  +  "Playing Confirmed");

    }
}


























