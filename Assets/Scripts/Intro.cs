using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

/*
Handles the intro texts - rules and countdown.

by Batsambuu Batbold with the help of https://stackoverflow.com/questions/27885201/fade-out-unity-ui-text
*/

public class Intro : MonoBehaviour
{
    private SceneFade sceneFade;

    public GameObject ruleCanvas;

    public TMP_Text text1;
    public TMP_Text text2;
    public TMP_Text text3;
    public TMP_Text countdown;

    private void Awake()
    {
        sceneFade = GetComponentInChildren<SceneFade>();
    }

    public void Start()
    {   
        if(SceneController.instance != null)
        {
            SceneManager.LoadSceneAsync("Scenes/RoomScene");
        }
        else
        {
            StartCoroutine(ShowRulesThenLoad());
        }
    }

    private IEnumerator ShowRulesThenLoad()
    {
        ruleCanvas.SetActive(true);

        TMP_Text[] rules = new TMP_Text[] { text1, text2, text3 };

        yield return new WaitForSeconds(0.75f);

        foreach (TMP_Text rule in rules)
        {
            yield return FadeIn(rule, 1f);
            yield return new WaitForSeconds(2.25f);
            yield return FadeOut(rule, 1f);
            yield return new WaitForSeconds(0.3f);
        }

        for (int i = 3; i > 0; i--)
        {
            countdown.text = $"Your time starts in {i}...";
            yield return FadeIn(countdown, 0.5f);
            yield return new WaitForSeconds(0.5f);
            yield return FadeOut(countdown, 0.25f);
        }

        countdown.text = "Go!";
        yield return FadeIn(countdown, 0.5f);
        yield return new WaitForSeconds(1f);
        yield return FadeOut(countdown, 0.5f);

        yield return SceneManager.LoadSceneAsync("Scenes/RoomScene");
        yield return sceneFade.FadeInCoroutine(1f);
    }


    private IEnumerator FadeIn(TMP_Text text, float duration)
    {
        float t = 0f;
        while (t < duration)
        {
            t += Time.deltaTime;
            text.alpha = Mathf.Clamp01(t / duration);
            yield return null;
        }
    }

    private IEnumerator FadeOut(TMP_Text text, float duration)
    {
        float t = 0f;
        float startAlpha = text.alpha;
        while (t < duration)
        {
            t += Time.deltaTime;
            text.alpha = Mathf.Lerp(startAlpha, 0f, t / duration);
            yield return null;
        }
    }
}
