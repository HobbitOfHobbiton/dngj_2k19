﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControlls : MonoBehaviour
{
    [SerializeField]
    private int playerNr = 0;
    [SerializeField]
    private float moveSpeed = 10f;
    [SerializeField]
    private float jumpForce = 10f;
    [SerializeField]
    private float gravityScaleUp = 0.1f;
    [SerializeField]
    private float gravityScaleDown = 1f;
    [SerializeField]
    private int JumpCost = 30;
    [SerializeField]
    private int AttackCost = 10;

    private Vector2 movementDirection = Vector3.zero;

    private Rigidbody2D rb;

    private bool flag = true;

    private float LastVelocyti = 1;//bo patrzy w prawo

    private bool isGrounded = false;

    private CharacterAnimator characterAnimator;

    private StaminaScript staminaScript;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        characterAnimator = GetComponentInChildren<CharacterAnimator>();
        staminaScript = GetComponent<StaminaScript>();
    }

    // Update is called once per frame
    void Update()
    {
        GetDirection();
        MovePlayer();
        GetAttackInput();

        Rotate();

        characterAnimator.SetMoveVelocity(movementDirection.x / 1.5f);
    }

    void Rotate()
    {
        if((LastVelocyti * movementDirection.x) < 0)
        {
            transform.Rotate(new Vector3(0, 180, 0));
            LastVelocyti = movementDirection.x;
        }
    }

    void GetDirection()
    {
        float xDir = Input.GetAxisRaw("Horizontal"+playerNr.ToString());

        movementDirection.x = xDir * moveSpeed;

        movementDirection.y = rb.velocity.y;

        if (movementDirection.y < 0f)
        {
            rb.gravityScale = gravityScaleDown;
        }

        if (Input.GetAxisRaw("Vertical"+playerNr.ToString()) == 1f && isGrounded)
        {
            characterAnimator.Jump();
            isGrounded = false;
            rb.gravityScale = gravityScaleUp;
            movementDirection.y = jumpForce;
            /// Zabieranie staminy przy skakaniu
            if(gameObject.name == "Frodo")
                staminaScript.LoseStamina(JumpCost);
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
            characterAnimator.Land();
        }
    }

    public void TakeFrodo(Transform Frodo)
    {

    }

    void GetAttackInput()
    {
        if (Input.GetButtonDown("Attack"+playerNr.ToString()))
        {
            if (gameObject.name == "Frodo")
                staminaScript.LoseStamina(AttackCost);

            characterAnimator.Attack();
        }
    }
}
