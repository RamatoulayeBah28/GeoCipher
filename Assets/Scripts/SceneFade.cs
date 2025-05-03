using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
Handles the fade-in effect for transitions between scenes.

By Batsambuu Batbold with the help of https://www.youtube.com/watch?v=vkOhefMbrFg
*/

public class SceneFade : MonoBehaviour
{
    public float duration = 0.5f;
    
    private Image fadeImage;

    private void Awake()
    {
        fadeImage = GetComponent<Image>();
    }

    public IEnumerator FadeInCoroutine()
    {
        Color startColor = new Color(fadeImage.color.r, fadeImage.color.g, fadeImage.color.b, 1);
        Color targetColor = new Color(fadeImage.color.r, fadeImage.color.g, fadeImage.color.b, 0);

        yield return FadeCoroutine(startColor, targetColor);

        gameObject.SetActive(false);
    }

    public IEnumerator FadeOutCoroutine()
    {
        Color startColor = new Color(fadeImage.color.r, fadeImage.color.g, fadeImage.color.b, 0);
        Color targetColor = new Color(fadeImage.color.r, fadeImage.color.g, fadeImage.color.b, 1);

        gameObject.SetActive(true);
        yield return FadeCoroutine(startColor, targetColor);
    }

    private IEnumerator FadeCoroutine(Color startColor, Color targetColor)
    {
        float elapsedTime = 0f;
        float progress = 0f;

        while (progress < 1f)
        {
            progress = elapsedTime / duration;
            fadeImage.color = Color.Lerp(startColor, targetColor, progress);

            yield return null;
            elapsedTime += Time.deltaTime;
        }
    }
}