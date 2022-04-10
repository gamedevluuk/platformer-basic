using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public SpriteRenderer playerSprite;
    public Animator animator;
    public LayerMask groundMask;

    public int playerID = 1;

    public float verticalVelocityMax = 20;
    public float movementSpeed = 15f;
    public float airSpeedFactor = 2f;
    public float jumpStrength = 8f;
    public float airJumpStrength = 5f;
    public float maximumVelocity = 4f;

    Rigidbody2D rigidBody;
    bool isJumping = false;
    bool isWalking = false;
    bool hasDoubleJumped = false;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerID == 1)
        {
            if (Input.GetKey(KeyCode.A))
            {
                Move(-1);
                playerSprite.flipX = true;
            }
            else if (Input.GetKey(KeyCode.D))
            {
                Move(1);
                playerSprite.flipX = false;

            }
            else if (isWalking)
            {
                isWalking = false;
                animator.SetBool("IsWalking", false);
            }

            if (Input.GetKeyDown(KeyCode.W))
                if (!isJumping)
                    Jump();
                else
                    DoubleJump();
        }
        else if (playerID == 2)
        {
            if (Input.GetKey(KeyCode.J))
            {
                Move(-1);
                playerSprite.flipX = true;
            }
            else if (Input.GetKey(KeyCode.L))
            {
                Move(1);
                playerSprite.flipX = false;

            }

            else if (isWalking)
            {
                isWalking = false;
                animator.SetBool("IsWalking", false);
            }


            if (Input.GetKeyDown(KeyCode.I))
                if(!isJumping)
                    Jump();
                else
                    DoubleJump();
        }

        if (!IsStandingOnObject())
        {
            isJumping = true;
            animator.SetBool("IsJumping", true);

        }

        else if (IsStandingOnObject())
        {
            PlayerLanded();
        }
    }

    public void Move(float horizontalInput)
    {
        isWalking = true;
        
        Vector2 er = Vector2.right * horizontalInput;
        float vel = Vector2.Dot(rigidBody.velocity, er);

        if (vel < maximumVelocity)
        {
            rigidBody.AddForce(
                (isJumping ? 1 / airSpeedFactor : 1) *
                movementSpeed * Time.deltaTime * er, ForceMode2D.Impulse);
        }

        animator.SetBool("IsWalking", true);

    }

    public void Jump()
    {
        if (IsStandingOnObject())
        {
            rigidBody.AddForce(new Vector2(0, jumpStrength), ForceMode2D.Impulse);
            isJumping = true;
            animator.SetBool("IsJumping", true);
        }
    }

    public void DoubleJump()
    {
         if (!IsStandingOnObject() && !hasDoubleJumped)
        {
            rigidBody.AddForce(new Vector2(0, airJumpStrength), ForceMode2D.Impulse);
            hasDoubleJumped = true;
        }
    }
    private void LateUpdate()
    {
        if (rigidBody.velocity.y > verticalVelocityMax)
        {
            rigidBody.velocity = new Vector2(rigidBody.velocity.x, verticalVelocityMax);
        }
    }

    void PlayerLanded()
    {
        animator.SetBool("IsJumping", false);
        isJumping = false;
        hasDoubleJumped = false;
     
    }

    private bool IsStandingOnObject()
    {
        var direction = -Vector2.up;
        return DoRaycastTowardsDirectionOnLayermasks(groundMask, direction, 0.5f);
    }
    private bool DoRaycastTowardsDirectionOnLayermasks(LayerMask layerMask, Vector2 direction, float length)
    {
        RaycastHit2D hit;
        hit = Physics2D.Raycast(transform.position, direction, length, layerMask);

        if (hit.collider != null)
        {
            Debug.DrawLine(transform.position, hit.point, Color.red);
            return true;
        }
        else
        {
            return false;
        }
    }

}
