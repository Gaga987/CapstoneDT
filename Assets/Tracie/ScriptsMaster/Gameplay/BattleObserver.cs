using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BattleObserver : MonoBehaviour
{ 

public void FightA()
    {
  
            GameManager.GetInstance().LoadFightB(); 
        
    }

    public void FightB()
    {
        
            GameManager.GetInstance().EnterWinningMoment();
        
      
    }

}
