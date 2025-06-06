using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitlescreenManager : MonoBehaviour
{
    public string nextScene;
    void Update()
    {
        if (Input.anyKeyDown)
        {
            LoadNextScene();
        }
    }

    void LoadNextScene()
    {
        SceneManager.LoadScene(nextScene);
    }
}
