using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneManager : MonoBehaviour
{
    public string sceneName;
    public float timeToWait = 60f;

    private bool timerIsOn = false;
    private float currentTime;

    [Header("UI")]
    public TextMeshProUGUI timerText;         // drag your countdown TextMeshProUGUI here

    [Header("Player")]
    public playerController playerController; // drag your Player GameObject (with playerController) here

    public void Start()
    {
        // Make sure the timerText is hidden at the very start:
        if (timerText != null)
            timerText.gameObject.SetActive(false);
    }

    public void StartTimer()
    {
        // Only run this block once
        if (!timerIsOn)
        {
            timerIsOn = true;
            currentTime = timeToWait;

            // 1) Immediately disable the right boundary
            if (playerController != null)
            {
                playerController.DisableRightBoundary();
            }

            // 2) Show the timerText so the player can see the countdown
            if (timerText != null)
            {
                timerText.gameObject.SetActive(true);
                timerText.text = "Time remaining: " + Mathf.CeilToInt(currentTime).ToString();
            }

            // 3) Begin the countdown coroutine
            StartCoroutine(SceneChangeCoroutine());
        }
    }

    private void Update()
    {
        if (!timerIsOn) return;

        currentTime -= Time.deltaTime;
        if (timerText != null)
        {
            timerText.text = "Time remaining: " + Mathf.CeilToInt(currentTime).ToString();
        }

        if (currentTime <= 0f)
        {
            ResetScene();
        }
    }

    private IEnumerator SceneChangeCoroutine()
    {
        yield return new WaitForSeconds(timeToWait);
        ResetScene();
    }

    private void ResetScene()
    {
        SceneManager.LoadScene(sceneName);
    }
}