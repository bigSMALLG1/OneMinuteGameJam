using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class playerController : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] float moveSpeed = 100f;



    private float verticalInput;
    private float horizontalInput;
    public Rigidbody2D rb;
    public GameObject Player;
    private bool isMoving;
    private Vector3 origPos, targetPos;
    private float timeToMove = 0.4f;
    bool lookingRight = true;
    public float leftBoundary = 0f;
    public float rightBoundary = 3f;
    public bool rightBoundaryEnabled = true;

    public Animator animator;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float horizontalMovement = horizontalInput * moveSpeed;
        float verticalMovement = verticalInput * moveSpeed;

        animator.SetBool("isMoving", isMoving);

        if (Input.GetKey(KeyCode.A) && !isMoving)
        {
            if (transform.position.x - 1f >= leftBoundary)
            {
                StartCoroutine(GridMovement(Vector3.left));
            }
        }

        if (Input.GetKey(KeyCode.D) && !isMoving)
        {
            if (!rightBoundaryEnabled || transform.position.x + 1f <= rightBoundary)
                {
                StartCoroutine(GridMovement(Vector3.right));
                }
        }
    }

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.D) && !lookingRight)
        {
            Flip();
        }
        else if (Input.GetKey(KeyCode.A) && lookingRight)
        {
            Flip();
        }
    }


    private IEnumerator GridMovement(Vector3 direction)
    {
        Vector2 rayOrigin = transform.position;
        float rayDistance = 1f;

        RaycastHit2D hit = Physics2D.Raycast(rayOrigin, direction, rayDistance);

        if (hit.collider != null)
        {
            isMoving = true;
            float elapsedTime = 0f;
            origPos = transform.position;
            targetPos = origPos + direction * 1f;

            while (elapsedTime < timeToMove)
            {
                transform.position = Vector3.Lerp(origPos, targetPos, elapsedTime / timeToMove);
                elapsedTime += Time.deltaTime;
                yield return null;
            }

            transform.position = targetPos;
            isMoving = false;
        }
    }

    void Flip()
    {
        Vector3 currentScale = gameObject.transform.localScale;
        currentScale.x *= -1;
        gameObject.transform.localScale = currentScale;

        lookingRight = !lookingRight;
    }

    public void DisableRightBoundary()
    {
        rightBoundaryEnabled = false;
    }
}
