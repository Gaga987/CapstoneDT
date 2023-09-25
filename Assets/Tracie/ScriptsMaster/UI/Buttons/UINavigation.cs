using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 


public class UINavigation : MonoBehaviour
{
    [SerializeField] private Button startGame; 
   public GameObject controlPanel;


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
        GameManager.GetInstance().LoadNewGame();
        //GameManager.GetInstance().LoadScene(GameManager.SceneCollection.QuestBegins) 
  startGame.onClick.RemoveListener(OnClickSG);
    }

    public void ShowControlPanel()
    {
        controlPanel.SetActive(true);
    }
    /// <summary>
    ///  On button click for Exit Controls
    /// </summary>
    public void ExitControlPanel()
    {
        controlPanel.SetActive(false); 
    }
}
