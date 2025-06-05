using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GregDialogue : MonoBehaviour
{
    [Header("Dialogue UI")]
    public TextMeshProUGUI textComponent;  
    public GameObject nextLinePrompt;      
    [Header("Dialogue Data")]
    public string[] lines;           
    public float textSpeed = 0.05f;         

    [Header("References")]
    public GameObject player;               
    public GameObject dialoguePanel;         
    public sceneManager sceneManagerScript;  

    private int lineIndex = 0;
    private bool isTyping = false;

    private void Start()
    {
    
        if (dialoguePanel != null)
            dialoguePanel.SetActive(true);

        textComponent.text = string.Empty;
        StartDialogue();
    }

    private void Update()
    {
        
        if (!dialoguePanel.activeSelf) return;

        if (Input.GetKeyDown(KeyCode.E))
        {
            
            if (isTyping)
            {
                StopAllCoroutines();
                textComponent.text = lines[lineIndex];
                isTyping = false;

                if (nextLinePrompt != null)
                    nextLinePrompt.SetActive(true);
            }
            else
            {
                if (lineIndex < lines.Length - 1)
                {
                    NextLine();
                }
                else
                {
                    CloseDialogueAndStartTimer();
                }
            }
        }
    }

    private void StartDialogue()
    {
        lineIndex = 0;
        StartCoroutine(TypeLine());
    }

    private IEnumerator TypeLine()
    {
        isTyping = true;
        textComponent.text = string.Empty;

        if (nextLinePrompt != null)
            nextLinePrompt.SetActive(false);

        foreach (char c in lines[lineIndex].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }

        isTyping = false;
        if (nextLinePrompt != null)
            nextLinePrompt.SetActive(true);
    }

    private void NextLine()
    {
        lineIndex++;
        textComponent.text = string.Empty;

        if (nextLinePrompt != null)
            nextLinePrompt.SetActive(false);

        StartCoroutine(TypeLine());
    }

    private void CloseDialogueAndStartTimer()
    {
      
        if (nextLinePrompt != null)
            nextLinePrompt.SetActive(false);

     
        textComponent.text = string.Empty;

     
        if (player != null)
        {
            var pc = player.GetComponent<playerController>();
            if (pc != null)
                pc.DisableRightBoundary();
        }

        // 4) Enable and start the timer
        if (sceneManagerScript != null)
        {
            // Ensure the timer text is visible:
            if (sceneManagerScript.timerText != null)
                sceneManagerScript.timerText.gameObject.SetActive(true);

            sceneManagerScript.StartTimer();
        }

        // 5) Finally, hide the entire dialogue panel
        if (dialoguePanel != null)
            dialoguePanel.SetActive(false);
        else
            gameObject.SetActive(false);
    }
}