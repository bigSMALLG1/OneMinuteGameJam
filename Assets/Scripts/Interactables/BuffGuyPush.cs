using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffGuyPush : MonoBehaviour
{
    public float destroyDelay = 0f;
    public GameObject pushBuffGuyPopup;
    public Animator animator;
    public int pushCounter = 5;
    private int currentPushCount = 0;

    private bool playerInRange = false;
    private playerController player;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
            if (pushBuffGuyPopup != null)
            {
                pushBuffGuyPopup.SetActive(true);
            }

            if (animator != null)
            {
                animator.SetBool("isAngry", true);
            }

            player = other.GetComponent<playerController>();
            if (player != null)
            {
                player.rightBoundary = transform.position.x;
                player.rightBoundaryEnabled = true;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
            if (pushBuffGuyPopup != null)
            {
                pushBuffGuyPopup.SetActive(false);
            }

            if (animator != null)
            {
                animator.SetBool("isAngry", false);
            }
        }
    }

    private void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.E))
        {
            currentPushCount++;

            Debug.Log("Push count: " + currentPushCount + " / " + pushCounter);
            if (currentPushCount >= pushCounter)
            {
                if (pushBuffGuyPopup != null)
                {
                    pushBuffGuyPopup.SetActive(false);
                }

                if (player != null)
                {
                    player.rightBoundaryEnabled = false;
                }
                Destroy(gameObject, destroyDelay);
            }
          
        }
    }
}
