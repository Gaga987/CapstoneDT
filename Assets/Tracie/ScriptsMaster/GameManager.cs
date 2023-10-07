using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
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
    ///  Loads StartMenu from any onclick
    /// </summary>
    public void LoadStartMenu()
    {
        SoundManager.GetInstance().PlayTheme("StartingSound");
        Debug.Log("Audio Manager :  " + SoundManager.GetInstance().themeSound.ToString() + "Playing Confirmed");
        SceneManager.LoadScene(SceneCollection.StartMenu.ToString());
   
    }

    /// <summary>
    ///  on click - loads quest begins FROM  StartMenu 
    /// </summary>
    public void LoadNewGame()
    {
        SceneManager.LoadScene(SceneCollection.QuestBegins.ToString());
      //  SoundManager.GetInstance().StopSound("StartingSound");
        //Debug.Log(" start sound has stopped"); 
       SoundManager.GetInstance().PlayTheme("QuestSound");
        Debug.Log("playing QUEST  sound, Entering the game, the story begins.");
    }


    public void EnterWinningMoment()
    {
        SceneManager.LoadScene(SceneCollection.AHappyEnding.ToString());
        Debug.Log("You've proven valorant and won");
    }

    public void LosingLost()
    {
        SceneManager.LoadScene(SceneCollection.Loser.ToString()); 
    }

    public void LoadScene( Scene scene)
    {
        SceneManager.LoadScene(scene.ToString());
    }







    /// <summary>
    ///  loads fight sequence from OTE in QuestBegins 
    /// </summary>
    public void LoadFightA()
    {
        SceneManager.LoadScene(SceneCollection.FightA.ToString());
    }


    public void LoadFightB()
    {
        SceneManager.LoadScene(SceneCollection.SecondFight.ToString());  
    }



    public void LoadNextScene()
    {
        // taking running scene in game , grab the index number and add 1 to it for going to level two 
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); 
    }




    }

// enum names need to be the same order as build settings!!! 
public enum SceneCollection
{
    StartMenu,  //0
    QuestBegins,  //1
    FightA,   //2
    SecondFight,  //3
    AHappyEnding,  //4 
    Loser  //5 
}
