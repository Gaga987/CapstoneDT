using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.CompareTag("Player"))
            {
            GameManager.GetInstance().LoadFightA();
            Debug.Log("Fight A Loaded"); 
        }
    }
}
