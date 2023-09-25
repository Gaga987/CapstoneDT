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
        controlsPanel.SetActive(true);
    }

    public void ExitControlPanel()
    {
        controlsPanel.SetActive(false);
    }

    private void Start()
    {
        exitGameButton.onClick.AddListener(OnClickEG); 
    }

    public void OnClickEG()
    {
        GameManager.GetInstance().LoadStartMenu(); 
        exitGameButton.onClick.RemoveListener(OnClickEG);
    }
}
