using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private Rigidbody2D rb;
    private BoxCollider2D col;
    private Animator anim;
    private float dirx=0f;
    private SpriteRenderer sprite;
    [SerializeField] private float movespeed = 8f;
    [SerializeField] private float jumpforce = 9f;
    [SerializeField] private LayerMask jumpableGround;
    private enum MovementState {idle,running,jumping,falling }
    [SerializeField] private AudioSource Jumpaffect;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<BoxCollider2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void Update()
    {
        dirx = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(dirx * movespeed,rb.velocity.y);
        if(Input.GetButtonDown("Jump") && isGrounded())
        {
            Jumpaffect.Play();
            GetComponent<Rigidbody2D>().velocity = new Vector3(rb.velocity.x, jumpforce);
        }
        UpdateAnimationState();
    }

    private void UpdateAnimationState() 
    {
        MovementState state;
        if (dirx > 0f)
        {
            state = MovementState.running;
            sprite.flipX = false;
        }
        else if (dirx < 0f)
        {
            state = MovementState.running;
            sprite.flipX = true;
        }
        else state = MovementState.idle;

        if(rb.velocity.y> .1f) state = MovementState.jumping;
        else if(rb.velocity.y< -.1f) state = MovementState.falling;
        anim.SetInteger("state", (int)state);
     
    }
    private bool isGrounded()
    {
        return Physics2D.BoxCast(col.bounds.center, col.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }
}
/*
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private Rigidbody2D rb;
    private BoxCollider2D col;
    private Animator anim;
    private float dirx = 0f;
    private SpriteRenderer sprite;
    [SerializeField] private float movespeed = 8f;
    [SerializeField] private float jumpforce = 9f;
    [SerializeField] private LayerMask jumpableGround;
    private enum MovementState { idle, running, jumping, falling }
    [SerializeField] private AudioSource Jumpaffect;
    private float lastTapTime = 0f;
    private const float doubleTapTime = 0.3f;
    private bool isMovingLeft = false;
    private bool isMovingRight = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<BoxCollider2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void Update()
    {
        HandleTouchInput();

        dirx = 0f;
        if (isMovingLeft)
        {
            dirx = -1f;
        }
        if (isMovingRight)
        {
            dirx = 1f;
        }

        rb.velocity = new Vector2(dirx * movespeed, rb.velocity.y);

        if (Input.GetButtonDown("Jump") && isGrounded())
        {
            Jump();
        }

        UpdateAnimationState();
    }

    private void HandleTouchInput()
    {
        if (Input.touchCount > 0)
        {
            for (int i = 0; i < Input.touchCount; i++)
            {
                Touch touch = Input.GetTouch(i);

                if (touch.phase == TouchPhase.Began)
                {
                    if (Time.time - lastTapTime < doubleTapTime)
                    {
                        Jump();
                    }
                    lastTapTime = Time.time;

                    if (touch.position.x > Screen.width / 2)
                    {
                        sprite.flipX = false; // Quay mặt sang phải
                        isMovingRight = true;
                    }
                    else if (touch.position.x < Screen.width / 2)
                    {
                        sprite.flipX = true; // Quay mặt sang trái
                        isMovingLeft = true;
                    }
                }
                else if (touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled)
                {
                    if (touch.position.x > Screen.width / 2)
                    {
                        isMovingRight = false;
                    }
                    else if (touch.position.x < Screen.width / 2)
                    {
                        isMovingLeft = false;
                    }
                }
            }
        }
        else
        {
            isMovingLeft = false;
            isMovingRight = false;
        }
    }

    private void Jump()
    {
        if (isGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpforce);
            Jumpaffect.Play();
        }
    }

    private void UpdateAnimationState()
    {
        MovementState state;

        if (rb.velocity.x > 0f)
        {
            state = MovementState.running;
        }
        else if (rb.velocity.x < 0f)
        {
            state = MovementState.running;
        }
        else
        {
            state = MovementState.idle;
        }

        if (rb.velocity.y > .1f)
        {
            state = MovementState.jumping;
        }
        else if (rb.velocity.y < -.1f)
        {
            state = MovementState.falling;
        }

        anim.SetInteger("state", (int)state);
    }

    private bool isGrounded()
    {
        return Physics2D.BoxCast(col.bounds.center, col.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }
}*/

