using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneManager : MonoBehaviour
{
    public string sceneName;
    public float timeToWait = 60;

    void Start()
    {
        StartCoroutine(sceneChange());
    }

    
    void Update()
    {
        
    }

    private IEnumerator sceneChange()
    {
        yield return new WaitForSeconds(timeToWait);
        SceneManager.LoadScene(sceneName);
    }
}
