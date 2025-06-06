using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TicketInspectorPatrol : MonoBehaviour
{
    public float leftBoundary = 65f;
    public float rightBoundary = 75f;
    public float moveSpeed = 2f;
    public float idle = 2f;
    private bool isMovingRight = true;
    private bool isIdle = false;
    private Animator animator;
    private Rigidbody2D rb;
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        if (!isIdle)
        {
            Patrol();
        }
    }

    private void Patrol()
    {
        animator.SetBool("isWalking", true);

        if (isMovingRight)
        {
            rb.velocity = new Vector2(moveSpeed, rb.velocity.y);

            if (transform.position.x >= rightBoundary)
            {
                StartCoroutine(IdleAndTurnAround());
            }
        }
        else
        {
            rb.velocity = new Vector2(-moveSpeed, rb.velocity.y);

            if (transform.position.x <= leftBoundary)
            {
                StartCoroutine(IdleAndTurnAround());
            }
        }
    }

    private IEnumerator IdleAndTurnAround()
    {
        isIdle = true;
        rb.velocity = Vector2.zero;
        animator.SetBool("isWalking", false);

        yield return new WaitForSeconds(idle);

        isMovingRight = !isMovingRight;
        Flip();
        isIdle = false;
    }

    private void Flip()
    {
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
}
    
