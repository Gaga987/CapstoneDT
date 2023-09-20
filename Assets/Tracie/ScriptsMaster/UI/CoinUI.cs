using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using TMPro; 
public class CoinUI : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private TextMeshProUGUI coinText;
    private void OnEnable()
    {
        GameEventsMaster.instance.coinEvents.onCoinChange += CoinChange; 
    }

    private void OnDisable()
    {
        GameEventsMaster.instance.coinEvents.onCoinChange -= CoinChange;
    }

    private void CoinChange(int coin)
    {
        coinText.text = coin.ToString(); 
    }
}
