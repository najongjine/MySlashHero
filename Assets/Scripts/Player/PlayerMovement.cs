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

    private void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        MovePlayer();
    }
    void MovePlayer()
    {
        myBody.velocity=new Vector2 (moveSpeed,myBody.velocity.y);
    }
}
