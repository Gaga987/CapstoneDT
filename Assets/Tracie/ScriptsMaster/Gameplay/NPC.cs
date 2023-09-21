using System.Collections;
using UnityEngine;

public class NPC : MonoBehaviour
{
    private static NPC instance;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        instance = this;
    }

    public static NPC GetInstance()
    {
        return instance;
    }

    [Header("NPC Configurations")]
    [SerializeField] private Transform player;
    [SerializeField] private float npcfollowSpeed;
    [SerializeField] private float npcstoppingDistance;
    public bool npcFollowing = false;

    private IEnumerator NPCFollowPlayer()
    {
        while (npcFollowing)
        {
            if (player == null)
            {
                yield break; // Exit the coroutine if the player is null
            }

            // Calculate distance between NPC and player
            float distanceToPlayer = Vector2.Distance(transform.position, player.position);

            // Check if NPC is outside of stopping distance
            if (distanceToPlayer >= npcstoppingDistance)
            {
                // Calculate direction from NPC to player
                Vector2 directionToPlayer = player.position - transform.position;
                directionToPlayer.Normalize();

                // Move NPC towards player at the specified speed
                transform.Translate(npcfollowSpeed * Time.deltaTime * directionToPlayer);
            }

            yield return new WaitForSeconds(0.1f);
        }
    }

    public void CallNPCCoroutine()
    {
        StartCoroutine(NPCFollowPlayer());
    }

    public void StopNPCCoroutine()
    {
        StopCoroutine(NPCFollowPlayer());   
    }
}