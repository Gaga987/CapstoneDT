using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combatant : MonoBehaviour
{
    [Header("CombatantConfigurations")]
    [SerializeField] private string combatantName;
    [SerializeField] private int combatantLevel;
    [SerializeField] private int damage;
    [SerializeField] private int maxHP;
    [SerializeField] private int currentHP; 
}
