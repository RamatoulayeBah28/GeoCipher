using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneFade : MonoBehaviour
{
    public float duration = 0.5f;
    private Image _sceneFadeImage;

    private void Awake()
    {
        _sceneFadeImage = GetComponent<Image>();
    }

    public IEnumerator FadeInCoroutine()
    {
        Color startColor = new Color(_sceneFadeImage.color.r, _sceneFadeImage.color.g, _sceneFadeImage.color.b, 1);
        Color targetColor = new Color(_sceneFadeImage.color.r, _sceneFadeImage.color.g, _sceneFadeImage.color.b, 0);

        yield return FadeCoroutine(startColor, targetColor);

        gameObject.SetActive(false);
    }

    public IEnumerator FadeOutCoroutine()
    {
        Color startColor = new Color(_sceneFadeImage.color.r, _sceneFadeImage.color.g, _sceneFadeImage.color.b, 0);
        Color targetColor = new Color(_sceneFadeImage.color.r, _sceneFadeImage.color.g, _sceneFadeImage.color.b, 1);
        gameObject.SetActive(true);
        yield return FadeCoroutine(startColor, targetColor);
    }

    private IEnumerator FadeCoroutine(Color startColor, Color targetColor)
    {
        float elapsedTime = 0;
        float elapsedPercentage = 0;

        while (elapsedPercentage < 1)
        {
            elapsedPercentage = elapsedTime / duration;
            _sceneFadeImage.color = Color.Lerp(startColor, targetColor, elapsedPercentage);

            yield return null;
            elapsedTime += Time.deltaTime;
        }
    }
}