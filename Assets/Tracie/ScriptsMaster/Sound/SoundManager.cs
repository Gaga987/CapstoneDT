using UnityEngine.Audio;
using System;
using UnityEngine;
using System.Collections.Generic;


public class SoundManager : MonoBehaviour
{// enable enum selection ? 
    // retrieval functionality :
         
    //private static SoundManager instance;
    private void Awake()
    {
        //if (instance != null && instance != this) { Destroy(this); return; }
        //instance = this;
        InitalizeSoundClips(); 
    }
    //public static SoundManager GetInstance()
    //{
    //    return instance;
    //}

    [Header("Sound Configurations")]
public Dictionary<string, AudioClip> soundClips = new Dictionary<string, AudioClip>();

    public  AudioSource soundSource; 

    private void Start()
    {
        soundSource = gameObject.GetComponent<AudioSource>();
    }

    private void InitalizeSoundClips()
    {
        foreach (SoundClips soundclipEnum in Enum.GetValues(typeof(SoundClips)))
        {
            string clipName = soundclipEnum.ToString(); 
            AudioClip clip = Resources.Load<AudioClip>("TimorousTheme" + clipName);
            if( clip != null)
            {
                soundClips.Add(clipName, clip);
            }
            else
            {
                Debug.Log("Failed to load sound" + clipName); 
            }
        }
    }
       
    public void PlaySound(SoundClips soundClipEnum)
    {
        string clipName = soundClipEnum.ToString();
        {
            if(soundClips.ContainsKey(clipName))
                {
                soundSource.PlayOneShot(soundClips[clipName]);
            }
        }
    }

}
public enum SoundClips
{
    TimorousTheme, 
    BrazenTheme, 
    JourneyTheme, 
    ChoiceOneShot, 
    EndOneShot, 

}


























