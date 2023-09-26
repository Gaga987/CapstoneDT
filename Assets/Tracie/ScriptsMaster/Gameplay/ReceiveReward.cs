using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReceiveReward : MonoBehaviour
{
    [SerializeField] private Button rewardButton;
    [SerializeField] private Button acceptButton; 
    [SerializeField] private GameObject rewardObject;

    private void Awake()
    {
        rewardObject.SetActive(false); 
    }

    public void ProcureReward()
    {
        rewardObject.SetActive(true); 
    }

    public void AcceptReward()
    {
        rewardObject.SetActive(false); 
    }
}
