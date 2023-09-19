using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCMovement : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private float followSpeed;
    [SerializeField] private float stoppingDistance;



    // Update is called once per frame
    void Update()
    {
        NPCFollowPlayer(); 

    }
    /// <summary>
    ///  npc goes from static to players location and stops when they are x proximity from the player 
    /// </summary>
    private void NPCFollowPlayer()
    {
        if (player == null) { return; }
        // calc distance between npc and player 
        float distanceToPlayer = Vector2.Distance(transform.position, player.position);
        // check if npc is outside of stopping distance 
        if (distanceToPlayer >= stoppingDistance)
        {
            //calc direction from npc to player 
            Vector2 directionToPlayer = player.position - transform.position;
            // normalize 
            directionToPlayer.Normalize();
            // move npc towards player at x speed 
            transform.Translate(Vector2.left * followSpeed * Time.deltaTime * directionToPlayer); 
        }
        Debug.Log("Npc on the move"); 
    }
}
