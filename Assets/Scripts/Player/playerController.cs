using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class playerController : MonoBehaviour
{
    [Header ("Movement")]
    [SerializeField] float moveSpeed = 100f;
   

    private float verticalInput;
    private float horizontalInput;
    public Rigidbody2D rb;
    public GameObject Player;
    public Camera playerCamera;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        verticalInput = Input.GetAxis("Vertical");
        horizontalInput = Input.GetAxis("Horizontal");

        float horizontalMovement = horizontalInput * moveSpeed;
        float verticalMovement = verticalInput * moveSpeed;
        Vector2 moveDirection = new Vector2(horizontalMovement, verticalMovement);
        
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    private void MovePlayer()
    {
        float horizontalMovement = horizontalInput * moveSpeed;
        float verticalMovement = verticalInput * moveSpeed;
        Vector2 moveDirection = new Vector2(horizontalMovement, verticalMovement);
        rb.velocity = moveDirection * Time.fixedDeltaTime;
    }
}
