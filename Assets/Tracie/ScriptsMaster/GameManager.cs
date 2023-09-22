using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 
/// <summary>
/// tt :  loads scenes 
/// </summary>
public class GameManager : MonoBehaviour
{ private static GameManager instance;
    private void Awake()
    {
        if (instance != null && instance != this) { Destroy(this); return; }
        instance = this;
    } 

    public static GameManager GetInstance()
    {
        return instance; 
    }

        /// <summary>
        ///  ENTERS game for on button click from StartMenu
        /// </summary>
        public void EnterGame()
    {
        Debug.Log("Entering the game, the story begins.");
        SceneManager.LoadScene("FreshStart"); 
    }
    /// <summary>
    ///  RETURNS to StartMenu for exit game on button click during gameplay AND During Game Lost. 
    /// </summary>
    public void ExitGame()
    {
        Debug.Log("Returning to start menu"); 
        SceneManager.LoadScene("StartMenu"); 
    }
    /// <summary>
    ///  From  ONTRIGGERENTER from FreshStart
    /// </summary>
    public void EnterFirstBattleScene()
    {
        Debug.Log(" Round 1 - fight!");
        SceneManager.LoadScene("SceneTwo");
    }

    public void EnterNextFight()
    {
        Debug.Log(" Round 2 - fight!");
        SceneManager.LoadScene("SceneThree");
    }
    
    public void EnterWinningMoment()
    {
        Debug.Log(" You've proven valorant and won");
        SceneManager.LoadScene("AHappyEnding");
    }


    }
