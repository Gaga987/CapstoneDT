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


    ///// <summary>
    /////  RETURNS to StartMenu for exit game on button click during gameplay AND During Game Lost. 
    ///// </summary>
    //public void ExitGame()
    //{
    //    Debug.Log("Returning to start menu"); 
    //    SceneManager.LoadScene("StartMenu"); 
    //}
    ///// <summary>
    /////  From  ONTRIGGERENTER from FreshStart
    ///// </summary>
    //public void EnterFirstBattleScene()
    //{
    //    Debug.Log(" Round 1 - fight!");
    //    SceneManager.LoadScene("SceneTwo");
    //}

    //public void EnterNextFight()
    //{
    //    Debug.Log(" Round 2 - fight!");
    //    SceneManager.LoadScene("SceneThree");
    //}
    
    //public void EnterWinningMoment()
    //{
    //    Debug.Log(" You've proven valorant and won");
    //    SceneManager.LoadScene("AHappyEnding");
    //}

    public void LoadScene( Scene scene)
    {
        SceneManager.LoadScene(scene.ToString());
    }
    /// <summary>
    ///  on click - loads quest begins FROM  StartMenu 
    /// </summary>
    public void LoadNewGame()
    {
        SceneManager.LoadScene(SceneCollection.QuestBegins.ToString());
        Debug.Log("Entering the game, the story begins.");
    }

    /// <summary>
    ///  Loads StartMenu from any onclick
    /// </summary>
    public void LoadStartMenu()
    {
        SceneManager.LoadScene(SceneCollection.StartMenu.ToString());
    }



    /// <summary>
    ///  loads fight sequence from OTE in QuestBegins 
    /// </summary>
    public void LoadFight()
    {
        SceneManager.LoadScene(SceneCollection.FightA.ToString());
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
    FightB,  //3
    AHappyEnding //4 
}
