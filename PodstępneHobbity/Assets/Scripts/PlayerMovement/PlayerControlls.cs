﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControlls : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 10f;
    [SerializeField]
    private float jumpForce = 10f;
    [SerializeField]
    private float gravityScaleUp = 0.1f;
    [SerializeField]
    private float gravityScaleDown = 1f;

    private Vector2 movementDirection = Vector3.zero;

    private Rigidbody2D rb;

    private bool flag = true;

    private bool isGrounded = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        GetDirection();
        MovePlayer();
    }

    void GetDirection()
    {
        float xDir = Input.GetAxisRaw("Horizontal");

        movementDirection.x = xDir * moveSpeed;

        movementDirection.y = rb.velocity.y;

        if (movementDirection.y < 0f)
        {
            rb.gravityScale = gravityScaleDown;
        }

        if (Input.GetAxisRaw("Vertical") == 1f && isGrounded)
        {
            isGrounded = false;
            rb.gravityScale = gravityScaleUp;
            movementDirection.y = jumpForce;
        }
    }

    void MovePlayer()
    {
        rb.velocity = movementDirection;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Ground")
        {
            isGrounded = true;
            rb.gravityScale = 1f;
        }
    }
}
