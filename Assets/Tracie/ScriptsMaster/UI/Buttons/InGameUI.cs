using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class InGameUI : MonoBehaviour
{
    [Header(" Current UI Configurations")]
    [SerializeField] private GameObject controlsPanel;
    [SerializeField] private Button exitGameButton;

    private void Awake()
    {
        controlsPanel.SetActive(false);
    }

    public void ShowControlPanel()
    {
        SoundManager.GetInstance().PlaySingleSounds("OnClick");
        Debug.Log("Sound : On Click registered"); 
        controlsPanel.SetActive(true);
    }

    public void ExitControlPanel()
    {
        SoundManager.GetInstance().PlaySingleSounds("OnClick");
        Debug.Log("Sound : On Click registered");
        controlsPanel.SetActive(false);
    }

    private void Start()
    {
        exitGameButton.onClick.AddListener(OnClickEG); 
    }

    public void OnClickEG()
    {
        SoundManager.GetInstance().PlaySingleSounds("OnClick");
        Debug.Log("Sound : On Click registered");
        GameManager.GetInstance().LoadStartMenu(); 
        exitGameButton.onClick.RemoveListener(OnClickEG);
    }
}
