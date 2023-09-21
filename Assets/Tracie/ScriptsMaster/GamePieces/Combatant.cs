using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combatant : MonoBehaviour
{
    [Header("CombatantConfigurations")]
   public string combatantName;
   public int combatantLevel;
   public  int damage;
   public int maxHP;
   public  int currentHP; 


    public bool TakeDamage(int damage)
    {
        currentHP -= damage; 

        // is dead?
        if(currentHP <= 0)
        {
            return true; 
        }
        else
        {
            return false;
        }
    }
}
