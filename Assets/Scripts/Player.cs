using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private float fallMultiplier;
    private Rigidbody2D palyerRb;
    private float speed = 5f;
    public float jumpForce = 5f;
    private Vector2 verGravity;


    private void Awake()
    {
        verGravity = new Vector2 (0, -Physics2D.gravity.y); 
        palyerRb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
       
        if (isGrounded())
        {
            if (Input.GetButtonDown("Jump"))
            {
               Jumping();
            }
            
        }
    }
    private void FixedUpdate()
    {
        if (palyerRb.velocity.y < 0)
        {
            palyerRb.velocity -= verGravity * fallMultiplier * Time.deltaTime;
        }
    }
    private void Jumping()
    {
        palyerRb.velocity = new Vector2(palyerRb.velocity.x, jumpForce);

    }
    private bool isGrounded()
        {
            return Physics2D.OverlapCapsule(groundCheck.position, new Vector2(0.44f, 0.05f), CapsuleDirection2D.Horizontal, 0, groundLayer);
        }

    }
