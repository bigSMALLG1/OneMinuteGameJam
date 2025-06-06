using UnityEngine;

public class TicketInspectorInteraction : MonoBehaviour
{
    public GameObject showTicketPopup;
    private bool playerInRange = false;
    private playerController player;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
            player = other.GetComponent<playerController>();

            if (showTicketPopup != null)
            {
                showTicketPopup.SetActive(true);
            }
        }

        if (player != null)
        {
            player.rightBoundary = transform.position.x;
            player.rightBoundaryEnabled = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
            player = null;

            if (showTicketPopup != null)
            {
                showTicketPopup.SetActive(false);
            }
        }
    }

    private void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.E))
        {
            if (player != null && player.hasTicket)
            {
                player.hasTicket = false;

                if (showTicketPopup != null)
                {
                    showTicketPopup.SetActive(false);
                }

                player.rightBoundary = 113f;
                player.rightBoundaryEnabled = true;
                
                this.enabled = false;
            }
            else
            {
                Debug.Log("Player has no ticket!");
            }
        }
        
         if (showTicketPopup != null)
        {
            Vector3 scale = showTicketPopup.transform.localScale;
            scale.x = Mathf.Abs(scale.x) * Mathf.Sign(transform.localScale.x) * -1f;
            showTicketPopup.transform.localScale = scale;
        }
    
    }
}