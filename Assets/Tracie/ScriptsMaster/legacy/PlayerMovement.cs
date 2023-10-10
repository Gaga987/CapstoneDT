using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// tt: handles player run for our 2d participant
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
    [SerializeField] private bool slash = false;
   


    Animator animator;
    public CharacterController character;
    public Transform groundCheck;
    public LayerMask groundLayer;


    void Start()
    {
        playerRB = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }
    void Update()
    {
        Debug.Log("isGrounded: " + isGrounded);
        Debug.Log("horizontalInput: " + horizontalInput);

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.1f, groundLayer);

        //horizontalInput = Input.GetAxis("Horizontal");
        
        // Vector2 run = new Vector2(horizontalInput * moveSpeed, playerRB.velocity.y);
        FlipSprite();

        if (Input.GetButtonDown("jump") && isGrounded)
        {
            playerRB.velocity = new Vector2(playerRB.velocity.x, jumpPower);
            
            animator.SetBool("jump", true);
        }

        if (Input.GetButtonDown("slash"))
        {
            slash = true;
        }

        

    }
    private bool ShouldStopMoving()
    {
        return Mathf.Approximately(horizontalInput, 0f);
    }

    private void FixedUpdate()
    {

        horizontalInput = Input.GetAxis("Horizontal");
        if (ShouldStopMoving())
        {
            // Set horizontalInput to 0 to stop movement
            horizontalInput = 0f;
      
        }
        animator.SetBool("slash", slash);
       

        playerRB.velocity = new Vector2(horizontalInput * moveSpeed, playerRB.velocity.y);
        animator.SetFloat("xVelocity", Mathf.Abs(playerRB.velocity.x));
        animator.SetBool("run", true);
        animator.SetFloat("speed", 1);

        slash = false;
       


    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {
            isGrounded = false;
            animator.SetBool("jump", false);
            animator.SetBool("inAir", false);
        }
       

    }
    /// <summary>
    ///  checks our bool to our horizontal input to flip based on whichever direction 
    /// </summary>
    void FlipSprite()
    {
        if (isFacingRight && horizontalInput < 0f || !isFacingRight && horizontalInput > 0f)
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
        // if (DialogueManager.GetInstance().dialogueIsPlaying)
        // {
        //      return;
        //  }
    }

}