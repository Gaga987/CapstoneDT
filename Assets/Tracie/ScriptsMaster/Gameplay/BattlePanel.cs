using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI; 
/// <summary>
/// tt : displays battle info to the ui panels 
/// </summary>
public class BattlePanel : MonoBehaviour
{
    [Header(" Battle UI Configuragtions")]
    [SerializeField] private TextMeshProUGUI nameText;
    [SerializeField] private TextMeshProUGUI levelText;
    [SerializeField] private Slider hpSlider; 



    public void SetBattleUI(Combatant combatant)
    {
        nameText.text = combatant.combatantName;
        levelText.text = "Lvl" + combatant.combatantLevel;
        hpSlider.maxValue = combatant.maxHP;
        hpSlider.value = combatant.currentHP; 

    }

    /// <summary>
    /// tt: tracks hp 
    /// </summary>
    /// <param name="hp"></param>
    public void TrackHP(int hp)
    {
        hpSlider.value = hp;    
    }
}
