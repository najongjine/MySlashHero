using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    float moveSpeed = 7f, jumpForce = 20f;

    Rigidbody2D myBody;

    Transform groundCheckPos;

    [SerializeField]
    LayerMask groundLayer;

    bool canDoubleJump;

    PlayerAnimationsWithTransitions playerAnim;

    [SerializeField]
    float attackWaitTime = 0.5f;
    float attackTimer;
    bool canAttack;

    private void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
        groundCheckPos = transform.GetChild(0).transform;
        playerAnim=GetComponent<PlayerAnimationsWithTransitions>();
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        PlayerJump();
        AnimatePlayer();
        GetAttackInput();
        HandleAttackAction();
    }
    private void FixedUpdate()
    {
        MovePlayer();
    }
    void MovePlayer()
    {
        myBody.velocity=new Vector2 (moveSpeed,myBody.velocity.y);
    }
    bool isGrounded()
    {
        //return Physics2D.Raycast(groundCheckPos.position,Vector2.down,0.1f,groundLayer);
        return Physics2D.OverlapCircle(groundCheckPos.position,  0.1f, groundLayer);
    }
    void PlayerJump()
    {
        if (Input.GetButtonDown(TagManager.JUMP_BUTTON))
        {
            if (!isGrounded() && canDoubleJump)
            {
                canDoubleJump = false;
                myBody.velocity = new Vector2(myBody.velocity.x,0f);
                myBody.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
                playerAnim.PlayDoubleJump();
            }
            if (isGrounded())
            {
                canDoubleJump = true;
                myBody.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            }
        }
    }
    void AnimatePlayer()
    {
        playerAnim.PlayJump(myBody.velocity.y);
        playerAnim.PlayFromJumpToRunning(isGrounded());
    }
    void GetAttackInput()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            if (Time.time > attackTimer)
            {
                attackTimer = Time.time+attackWaitTime;
                canAttack = true;
                //MySoundManager.instance.fxSource.PlayOneShot(MySoundManager.instance.slashClip);
                SoundManager.instance.Play_PlayerAttack_Sound();
            }
        }
    }
    void HandleAttackAction()
    {
        if (canAttack && isGrounded())
        {
            canAttack = false;
            playerAnim.PlayAttack();
        }
        else if (canAttack && !isGrounded())
        {
            canAttack = false;
            playerAnim.PlayJumpAttack();
        }
    }

}
