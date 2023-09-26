using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// tt : handles game over on click functionalities
/// </summary>
public class GameOverUI : MonoBehaviour
{
    [Header("Game Over Configurations")]
    [SerializeField] private Button quitButton;
    [SerializeField] private Button tryagainButton;
    private void Start()
    {
        quitButton.onClick.AddListener(OnClickQuitGame);
        tryagainButton.onClick.AddListener(OnClickRestartGame); 
    }

    public void OnClickQuitGame()
    {
        Application.Quit();
        quitButton.onClick.RemoveListener(OnClickQuitGame); 
    }

    public void OnClickRestartGame()
    {
        GameManager.GetInstance().LoadFightA();
        tryagainButton.onClick.RemoveListener(OnClickRestartGame); 

    }
}
