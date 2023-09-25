using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// tt : handles trigger related game events , observer pattern
/// </summary>
public class Triggers : MonoBehaviour
{
    [SerializeField] private NPC npcS; 
    
    
    /// <summary>
    ///  when trigger destroyed tell npc to follow player 
    /// </summary>
    /// <param name="collision"></param>

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
            {
            npcS.npcFollowing = true;
            npcS.CallNPCCoroutine();
            //NPC.GetInstance().npcFollowing = true;
            //NPC.GetInstance().CallNPCCoroutine();
            Destroy(this.gameObject);
            Debug.Log( "Trigger destroyed");
        }
       
    }
}
