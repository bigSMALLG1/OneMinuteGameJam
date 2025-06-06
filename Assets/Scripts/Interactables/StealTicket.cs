using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StealTicket : MonoBehaviour
{
    public GameObject StealTicketPopup;
    private bool playerInRange = false;
    private playerController player;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
            player = other.GetComponent<playerController>();
             if (StealTicketPopup != null)
            {
                StealTicketPopup.SetActive(true);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
         if (other.CompareTag("Player"))
        {
            playerInRange = false;
            player = null;
             if (StealTicketPopup != null)
            {
                StealTicketPopup.SetActive(false);
            }
        }
    }

    void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.E))
        {
            if (StealTicketPopup != null)
            {
                StealTicketPopup.SetActive(false);
                Destroy(StealTicketPopup);
            }

            if (player != null)
            {
                player.hasTicket = true;
            }
            this.enabled = false;
        }
    }
}
