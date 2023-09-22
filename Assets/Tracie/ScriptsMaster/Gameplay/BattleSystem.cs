using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEditor.ShaderGraph.Internal;

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
    [SerializeField] private TextMeshProUGUI shitTalkinText;

    private float coroutineWaitTime = 4f;
    private float preventPlayerAction = 1f; 
    private int recoverAmount = 8;

    Combatant playerC; 
    Combatant bossC;

    public BattlePanel playerPanel; 
    public BattlePanel bossPanel;

    /// <summary>
    /// tt: set the state and initalize 
    /// </summary>
    private void Start()
    {
        state = BattleState.Start;
        StartCoroutine(InitializeBattle()); 
    }



    /// <summary>
    /// initializes battle and gets info on combatatants
    /// </summary>
    private IEnumerator InitializeBattle()
    {

        //player
       GameObject player =  Instantiate(playerPrefab, playerStation);
         playerC =     player.GetComponent<Combatant>(); 

        // boss
        GameObject boss = Instantiate(bossPrefab, bossStation);
        bossC = boss.GetComponent<Combatant>();
        Debug.Log("Battle initialized");

        //initializes dialogue during battle - boss first 
        shitTalkinText.text = "BEHOLD " +  bossC.combatantName  + " IS UPON YOU";

        // NEED: One shot audio for boss arrival // battle initalization 

        // DRAGANA 
        Debug.Log(" Dragana opening animationsss"); 



        // setup panels 
        playerPanel.SetBattleUI(playerC);
        bossPanel.SetBattleUI(bossC);

        // coroutine 
        yield return new WaitForSeconds(coroutineWaitTime); 

        // change state to player
        state = BattleState.PlayerTurn;
        PlayerTurn(); 
    }



    private void PlayerTurn()
    {
        shitTalkinText.text = " Shall you pick up your sword? Cower in fear for self preservation?"; 
    }

    /// <summary>
    ///  tt: handles fight selection
    /// </summary>
    public  void OnFightButton()
    {
        if (state != BattleState.PlayerTurn)
            return;

        StartCoroutine(PlayerAttackBasic()); 
    }

    public void OnRecoverButton()
    {
        if (state != BattleState.PlayerTurn)
            return;

        StartCoroutine(PlayerRecover()); 
    }

    public void OnStrongAttackButton()
    {

        if (state != BattleState.PlayerTurn)
            return;

        StartCoroutine(PlayerStrongAttack()); 
        // NEED : One shot audio for strong attack 


        // DRAGANA 
        Debug.Log(" Dragana  strong attack animationsss");
    }

    private IEnumerator PlayerRecover()
    {
        playerC.Recover(recoverAmount);
        playerPanel.TrackHP(playerC.currentHP);
        //update ui 
        shitTalkinText.text = " The heavens have blessed you. Go forth and conquer! ";

        //  NEED : Stylistic event 

        yield return new WaitForSeconds(preventPlayerAction);
       

        // next state 

        state = BattleState.EnemyTurn;
        StartCoroutine(EnemyTurn()); 
    }
    






    /// <summary>
    /// tt : handles attack
    /// </summary>
    /// <returns></returns>
    private IEnumerator PlayerAttackBasic()
    {
        // do basic damage 

      bool isDead =   bossC.TakeDamage(playerC.damage);
        //update ui 
        bossPanel.TrackHP(bossC.currentHP);
        shitTalkinText.text = bossC.combatantName + " has been Felled! "  ;



        // DRAGANA 
        Debug.Log(" Dragana player deals damage animationsss");

        yield return new WaitForSeconds(preventPlayerAction);


        // has died? 
        if (isDead)
        {
            // end battle through slaying boss 
            state = BattleState.Won;
            EndBattle(); 
        }
        else
        {
            //  if !isDead then  enemy turn 
            state = BattleState.EnemyTurn;
            StartCoroutine(EnemyTurn()); 
        }
    }



    private IEnumerator  PlayerStrongAttack()
    {
        // do strong attack damage 
        bool isDead = bossC.TakeStrongAttackDamage(playerC.strongAttackDamage); 

            //update ui 
        bossPanel.TrackHP(bossC.currentHP);
        shitTalkinText.text = bossC.combatantName + " has been gravely wounded!";

        // DRAGANA 
        Debug.Log(" Dragana player deals STRONG ATTACK  damage animationsss");

        yield return new WaitForSeconds(preventPlayerAction);

        // has died? 
        if (isDead)
        {
            // end battle through slaying boss 
            state = BattleState.Won;
            EndBattle();
        }
        else
        {
            //  if !isDead then  enemy turn 
            state = BattleState.EnemyTurn;
            StartCoroutine(EnemyTurn());
        }
    }






    private IEnumerator EnemyTurn()
    {
        // INCREASE  BUFF BASED ON BOSS IN PREFABS 

        shitTalkinText.text = bossC.combatantName + " strikes with a rageful glory! ";

        // DRAGANA 

        Debug.Log(" Dragana enemy strikes  animationsss");


        // deal damage 
        bool isDead =    playerC.TakeDamage(bossC.damage); 

        // update ui
        playerPanel.TrackHP(playerC.currentHP); 

        yield return new WaitForSeconds(coroutineWaitTime);

        if(isDead)
        {
            state = BattleState.Lost;
            EndBattle(); 
        }
        else
        {
            state = BattleState.PlayerTurn;
            PlayerTurn(); 

        }


    }












    /// <summary>
    ///  CHANGE SCENE FROM GM HERE!!!!! 
    /// </summary>
    private void EndBattle()
    {
        if(state == BattleState.Won)
        {
            shitTalkinText.text = " You have excorsized this terrible scourge... ";

            Debug.Log(" win theatrics"); 

        }
        else if( state == BattleState.Lost)
            {
             // SHOW PANEL (SETACTIVE) WITH BUTTON CLICK OPTIONS 
            shitTalkinText.text = " You have proven NO match for " + bossC.combatantName + " and have been pathetically deafeated. Will you seek vengeance? ";


            // DRAGANA 
            Debug.Log(" Dragana end battle animations"); 


        }
    }




}
