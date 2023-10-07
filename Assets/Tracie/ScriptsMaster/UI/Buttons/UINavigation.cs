using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 


public class UINavigation : MonoBehaviour
{
    [Header("StartMenuUI Configurations")]
    [SerializeField] private Button startGame; 
   [SerializeField]   private GameObject controlPanel;


    private void Awake()
    {
        controlPanel.SetActive(false);
    }
    private void Start()
    {
        startGame.onClick.AddListener(OnClickSG); 
    }

    public void OnClickSG()
    {
        SoundManager.GetInstance().PlaySingleSounds("OnClick");
        Debug.Log("Sound on click registered"); 
        GameManager.GetInstance().LoadNewGame();
  startGame.onClick.RemoveListener(OnClickSG);
    }

    public void ShowControlPanel()
    {
        SoundManager.GetInstance().PlaySingleSounds("OnClick");
        Debug.Log("Sound on click registered");
        controlPanel.SetActive(true);

    }
    /// <summary>
    ///  On button click for Exit Controls
    /// </summary>
    public void ExitControlPanel()
    {
        SoundManager.GetInstance().PlaySingleSounds("OnClick");
        Debug.Log("Sound on click registered");
        controlPanel.SetActive(false); 
    }
}
