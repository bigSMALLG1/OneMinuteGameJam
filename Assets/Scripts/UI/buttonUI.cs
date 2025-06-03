using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class buttonUI : MonoBehaviour
{
    public string sceneName;
    public GameObject MainMenu;
    public GameObject SettingsMenu;
    
    public void PlayGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(sceneName);
    }

    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }

    public void Settings()
    {
        MainMenu.SetActive(false);
        SettingsMenu.SetActive(true);
    }

    public void Back()
    {
        MainMenu.SetActive(true);
        SettingsMenu.SetActive(false);
    }
}
