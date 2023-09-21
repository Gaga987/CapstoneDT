using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BattleState
{
    Start, 
    PlayerTurn, 
    EnemyTurn, 
    Won, 
    Lost
}


public class BattleSystem : MonoBehaviour
{
    [Header("Battle System Configurations")]
   [SerializeField] private BattleState state;
    [SerializeField] private GameObject playerPrefab;
    [SerializeField] private GameObject bossPrefab;
    [SerializeField] private Transform playerStation;
    [SerializeField] private Transform bossStation; 

    private void Start()
    {
        state = BattleState.Start;
        InitializeBattle(); 
    }

    private void InitializeBattle()
    {
        Instantiate(playerPrefab, playerStation);
        Instantiate(bossPrefab, bossStation);
        Debug.Log("Battle initialized"); 
    }
}
