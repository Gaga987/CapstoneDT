using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Combatant : MonoBehaviour
{
    [Header("CombatantConfigurations")]
   public string combatantName;
   public int combatantLevel;
   public  int damage;
    public int strongAttackDamage; 
   public int maxHP;
   public  int currentHP;
    


    public bool TakeDamage(int damage)
    {
       
        currentHP -= damage;
       
        // is dead?
        if (currentHP <= 0)
        {
            return true; 
        }
        else
        {
            return false;
        }
    }


    public bool TakeStrongAttackDamage( int strongAttackDamage)
    {
       
        currentHP -= strongAttackDamage;
     //   intText.text = strongAttackDamage.ToString();
        // is dead?
        if (currentHP <= 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }


    public void Recover(int healAmount)
    {
        // heald and cap if not 
        currentHP += healAmount; 
     //   intText.text = healAmount.ToString();
        if(currentHP > maxHP)
        {
            currentHP = maxHP; 
        }
    }

    }




