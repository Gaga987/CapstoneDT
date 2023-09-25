using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UINavigation : MonoBehaviour
{
   public GameObject controlPanel;


    private void Awake()
    {
        controlPanel.SetActive(false);
    }

    public void OnClickSG()
    {
        GameManager.GetInstance().EnterGame("FreshStart");
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
