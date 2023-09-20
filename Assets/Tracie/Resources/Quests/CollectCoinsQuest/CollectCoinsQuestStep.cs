using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.XR;

public class CollectCoinsQuestStep : QuestStep
{
    // goal collect 5 coins 

    private int coinsCollected = 0; 
    private int coinsToComplete = 5;

    private void OnEnable()
    {
        GameEventsMaster.instance.miscEvents.onCoinCollected += CoinCollected; 
    }


    private void OnDisable()
    {
        GameEventsMaster.instance.miscEvents.onCoinCollected -= CoinCollected; 
    }

    private void CoinCollected()
    {
        if(coinsCollected < coinsToComplete)
        {
            coinsCollected++;
            //UpdateState(); 
        }
        if(coinsCollected >= coinsToComplete)
        {
            FinishQuestStep(); 
        }
    }

    private void UpdateState()
    {
      
   
    }

}
