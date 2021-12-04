using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MovementMae : MonoBehaviour
{
    private float gravity = 1.9f;
    private float movementSpeed = 7.5f;
    private float jumpPower = 700f;
    private int currentJumpsRemaining = 2;
    private float boostedJumpTimer;
    private bool justJumped;

    [SerializeField]
    private LayerMask groundMask;

    private BoxCollider2D boxCollider2D;
    private Rigidbody2D rb;

    void Start()
    {
        boxCollider2D = GetComponent<BoxCollider2D>();
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = (gravity * rb.mass);
    }

    void Update()
    {
        if (justJumped != true)
        {
            if (isGrounded() && Input.GetKeyDown(KeyCode.Space))
            {
                justJumped = true;
                rb.AddForce(transform.up * jumpPower);
            }
        }
        else
        {
            boostedJumpTimer -= Time.deltaTime;
            if (boostedJumpTimer < 1.5f)
            {
                if (isGrounded() && Input.GetKeyDown(KeyCode.Space))
                {
                    rb.AddForce(transform.up * jumpPower);
                    currentJumpsRemaining--;
                    if (currentJumpsRemaining == 1)
                    {
                        jumpPower += 200;
                    }

                    if (currentJumpsRemaining == 0)
                    {
                        jumpPower -= 200;
                        currentJumpsRemaining = 2;
                        boostedJumpTimer = 0;
                        justJumped = false;
                    }
                }
            }
            else
            {
                jumpPower = 700f;
                currentJumpsRemaining = 2;
                boostedJumpTimer = 0;
                justJumped = false;
            }
        }
    }

    public void FixedUpdate()
    {

        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        if (Input.GetKey(KeyCode.A))
        {
            rb.velocity = new Vector2(-movementSpeed, rb.velocity.y);
        }

        else
        {
            if (Input.GetKey(KeyCode.D))
            {
                rb.velocity = new Vector2(movementSpeed, rb.velocity.y);
            }

            else
            {
                rb.velocity = new Vector2(0, rb.velocity.y);
                rb.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
            }
        }
    }

    private bool isGrounded()
    {
        float extraHeight = 0.175f;
        RaycastHit2D rayCastHit = Physics2D.BoxCast(boxCollider2D.bounds.center, boxCollider2D.bounds.size, 0f, Vector2.down, extraHeight, groundMask);
        Color rayColor;
        if (rayCastHit.collider != null)
        {
            rayColor = Color.green;
        }
        else
        {
            rayColor = Color.red;
        }
        Debug.DrawRay(boxCollider2D.bounds.center + new Vector3(boxCollider2D.bounds.extents.x, 0), Vector2.down * (boxCollider2D.bounds.extents.y + extraHeight), rayColor);
        Debug.DrawRay(boxCollider2D.bounds.center - new Vector3(boxCollider2D.bounds.extents.x, 0), Vector2.down * (boxCollider2D.bounds.extents.y + extraHeight), rayColor);
        Debug.DrawRay(boxCollider2D.bounds.center - new Vector3(boxCollider2D.bounds.extents.x, 0), Vector2.down * (boxCollider2D.bounds.extents.y + extraHeight), rayColor);
        return rayCastHit.collider != null;
    }
}