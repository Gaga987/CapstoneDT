using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
/// <summary>
/// tt : handles npc functionalities 
/// </summary>
public class NPC : MonoBehaviour
{
    private static NPC instance;
    private void Awake()
    {
        if (instance != null && instance != this) { Destroy(this); return; }
        instance = this;
    }

    public static NPC GetInstance()
    {
        return instance;
    }
    [Header(" NPC Configurations")]
    [SerializeField] private Transform player;
    [SerializeField] private float npcfollowSpeed;
    [SerializeField] private float npcstoppingDistance;
    public bool npcFollowing = false;

    private void Update()
    {
    //testing purposes    NPCFollowPlayer(); 
    }

    /// <summary>
    ///  npc goes from static to players location and stops when they are x proximity from the player 
    /// </summary>
  private  IEnumerator NPCFollowPlayer()
    {
        //      if (player == null) { return; }
        if(npcFollowing == true)
        { 
        // calc distance between npc and player 
        float distanceToPlayer = Vector2.Distance(transform.position, player.position);
            Debug.Log(" distance to player working " + distanceToPlayer); 
            // check if npc is outside of stopping distance 
            if (distanceToPlayer >= npcstoppingDistance)
            {
           
                //calc direction from npc to player 
                Vector2 directionToPlayer = player.position - transform.position;
                // normalize 
                directionToPlayer.Normalize();
                // move npc towards player at x speed 
             //   transform.Translate(npcfollowSpeed * Time.deltaTime * directionToPlayer * Vector2.left);
                Vector2.MoveTowards(transform.position, player.position, npcfollowSpeed * Time.deltaTime);
                Debug.Log("Npc on the move");
            }
            if (distanceToPlayer < npcstoppingDistance)
            {
                npcFollowing = false;
                StopAllCoroutines();
            }
        }
       
       yield return new WaitForSeconds(.1f); 
  
    }

    public void CallCoroutine()
    {
        StartCoroutine(NPCFollowPlayer());
    }

}
