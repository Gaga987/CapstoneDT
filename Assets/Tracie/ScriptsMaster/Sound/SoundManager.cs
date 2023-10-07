using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundManager : MonoBehaviour
{
    private static SoundManager instance;
    private void Awake()
    {
        if (instance != null && instance != this) { Destroy(this); return; }
        instance = this;
    }

    public static SoundManager GetInstance()
    {
        return instance;
    }

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

    public void StopSound(string name)
    {
        themeSource.Stop(); 
    }

}


























