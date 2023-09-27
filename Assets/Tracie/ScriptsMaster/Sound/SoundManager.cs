using UnityEngine.Audio;
using System;
using UnityEngine;
using System.Collections.Generic;


public class SoundManager : MonoBehaviour
{

    [Header("Sound Configurations")]
    [SerializeField] private AudioSource songSource;
    [SerializeField] private AudioSource oneshotSource;

    [Header("Sound Collection")]
    public AudioClip intro; 
    public AudioClip backgroundAdventuring;
    public AudioClip fight; 
    public AudioClip happyEnding;
    public AudioClip gameOver; 
    //public AudioClip onplayerLose;
    //public AudioClip onplayerDamage; 
    //public AudioClip onplayerAttack;
    //public AudioClip onplayerStrongAttack; 
    //public AudioClip onplayerRecover;
    //public AudioClip onEnemyAttack;
    public AudioClip spearOfDivination;


    private void Awake()
    {
        DontDestroyOnLoad(gameObject); 
    }
    private void Start()
    {
        songSource.clip = intro;
        songSource.Play();
    }


    

    public void PlayOneShot(AudioClip clip)
    {
        oneshotSource.PlayOneShot(clip); 
    }




}























