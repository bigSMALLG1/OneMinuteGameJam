using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GregInteraction : MonoBehaviour
{
    public GameObject GregPopup;
    public GameObject gregDialogue;
    private bool playerInRange = false;
    void Start()
    {
        GregPopup.SetActive(false);
        gregDialogue.SetActive(false);
    }


    void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.E))
        {
            GregPopup.SetActive(false);
            gregDialogue.SetActive(true);
            GetComponent<Collider2D>().enabled = false;

            if (GregPopup.activeSelf)
            {
                GregPopup.SetActive(false);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (!gregDialogue.activeSelf) 
            {
                GregPopup.SetActive(true);
            }
            playerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GregPopup.SetActive(false);
            playerInRange = false;
        }
    }
}
