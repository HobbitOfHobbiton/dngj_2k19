using System.Collections;
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
        float xDir = Input.GetAxisRaw("Horizontal"+playerNr.ToString());

        movementDirection.x = xDir * moveSpeed;

        movementDirection.y = rb.velocity.y;

        if (movementDirection.y < 0f)
        {
            rb.gravityScale = gravityScaleDown;
        }

        if (Input.GetAxisRaw("Vertical"+playerNr.ToString()) == 1f && isGrounded)
        {
            isGrounded = false;
            rb.gravityScale = gravityScaleUp;
            movementDirection.y = jumpForce;
            /// Zabieranie staminy przy skakaniu
            GetComponent<StaminaScript>().LoseStamina(JumpCost);
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
