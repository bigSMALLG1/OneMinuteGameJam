using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BackGroundManager : MonoBehaviour
{
    public SpriteRenderer[] backgroundRenderer;
    public Sprite[] backgroundSprites;
    public float scrollingSpeed = 1f;
    private Material[] backgroundMaterials;
    public bool changeBackground = true;
    public float changeInterval = 5f;
    void Start()
    {
        backgroundMaterials = new Material[backgroundRenderer.Length];
        for (int i = 0; i < backgroundRenderer.Length; i++)
        {
            backgroundMaterials[i] = backgroundRenderer[i].material;
        }

        RandomiseBackground();

        if (changeBackground)
        {
            StartCoroutine(ChangeBackground());
        }
    }
    void Update()
    {
        for (int i = 0; i < backgroundMaterials.Length; i++)
        {
            float offset = Time.time * scrollingSpeed;
            backgroundMaterials[i].mainTextureOffset = new Vector2(offset, 0);
        }
    }

    public void RandomiseBackground()
    {
        if (backgroundSprites.Length == 0)
        {
            Debug.LogWarning("Nothing assigned");
            return;
        }

        int index = Random.Range(0, backgroundSprites.Length);

        foreach (SpriteRenderer sr in backgroundRenderer)
        {
            sr.sprite = backgroundSprites[index];
        }
    }

    private IEnumerator ChangeBackground()
    {
        while (true)
        {
            yield return new WaitForSeconds(changeInterval);
            RandomiseBackground();
        }
    }

}
