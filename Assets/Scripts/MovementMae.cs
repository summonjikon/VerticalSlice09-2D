using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MovementMae : MonoBehaviour
{
    private float gravity = 4.5f;
    [SerializeField]
    private float movementSpeed = 7.5f;
    [SerializeField]
    private float jumpPower = 1000f;
    private int currentJumpsRemaining = 2;
    private float boostedJumpTimer = 0f;
    private bool justJumped;

    [SerializeField]
    private LayerMask groundMask;

    private BoxCollider2D boxCollider2D;
    private Rigidbody2D rb;

    private Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
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
                anim.SetTrigger("Jumped");
                justJumped = true;
                currentJumpsRemaining = 2;
                boostedJumpTimer = 0f;
                rb.AddForce(transform.up * jumpPower);
            }
        }
        else
        {
            boostedJumpTimer += Time.deltaTime;
            if (boostedJumpTimer < 1.75f)
            {
                if (isGrounded() && Input.GetKeyDown(KeyCode.Space))
                {
                    if (currentJumpsRemaining == 1)
                    {
                        jumpPower += 300;
                    }

                    //anim.SetTrigger("Jumped2");
                    boostedJumpTimer = 0f;
                    rb.AddForce(transform.up * jumpPower);
                    currentJumpsRemaining--;

                    if (currentJumpsRemaining == 0)
                    {
                        anim.SetTrigger("Jumped3");
                        jumpPower -= 300;
                        currentJumpsRemaining = 2;
                        boostedJumpTimer = 0;
                        justJumped = false;
                    }
                }
            }
            else
            {
                currentJumpsRemaining = 2;
                boostedJumpTimer = 0;
                justJumped = false;
            }
        }
        Vector3 characterScale = transform.localScale;
        if (Input.GetAxis("Horizontal") < 0)
        {
            //anim.SetTrigger("Turning");
            characterScale.x = -0.4002f;
        }
        if (Input.GetAxis("Horizontal") > 0)
        {
           // anim.SetTrigger("Turning");
            characterScale.x = 0.4002f;
        }
        transform.localScale = characterScale;
    }

    public void FixedUpdate()
    {

        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        if (Input.GetKey(KeyCode.A))
        {
            anim.SetBool("IsRunning", true);
            rb.velocity = new Vector2(-movementSpeed, rb.velocity.y);
        }

        else
        {
            if (Input.GetKey(KeyCode.D))
            {
                anim.SetBool("IsRunning", true);
                rb.velocity = new Vector2(movementSpeed, rb.velocity.y);
            }

            else
            {
                anim.SetBool("IsRunning", false);
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
