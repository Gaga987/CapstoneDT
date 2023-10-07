using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// tt: handles player movement for our 2d participant
/// </summary>
public class PlayerMovement : MonoBehaviour
{
    [Header("Player Movement Configurations")]
    [SerializeField] private float horizontalInput;
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private Rigidbody2D playerRB;
    [SerializeField] private bool isFacingRight = false;
    [SerializeField] private float jumpPower = 4f;
    [SerializeField] private bool isGrounded = false;

    Animator animator;


    void Start()
    {
        playerRB = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        FlipSprite();
        
        if(Input.GetButtonDown("Jump")&& isGrounded)
        {
            playerRB.velocity = new Vector2(playerRB.velocity.x, jumpPower);
            isGrounded = false;
            animator.SetBool("isJumping", !isGrounded);
        }
     
    }

    private void FixedUpdate()
    {
        
 
        playerRB.velocity = new Vector2(horizontalInput * moveSpeed, playerRB.velocity.y);
        animator.SetFloat("xVelocity", Mathf.Abs(playerRB.velocity.x));
      
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        isGrounded = false; 
    }
    /// <summary>
    ///  checks our bool to our horizontal input to flip based on whichever direction 
    /// </summary>
    void FlipSprite()
    {
        if(isFacingRight && horizontalInput <0f || !isFacingRight && horizontalInput >0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 ls = transform.localScale;
            ls.x *= -1f;
            transform.localScale = ls; 
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        isGrounded = true;
    }
    /// <summary>
    ///  not working atm, called in U || FU
    /// </summary>
    void FreezePlayerMovementDuringDialogue()
    {
        if (DialogueManager.GetInstance().dialogueIsPlaying)
        {
            return;
        }
    }
    
}
