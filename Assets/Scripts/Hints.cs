using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using TMPro;

/*
Handles the logic and order of hints to
provide appropriate hints based on game progress.

By Batsambuu Batbold
*/

public class Hints : MonoBehaviour
{
    public TextMeshProUGUI hintText;
    public TextMeshProUGUI hintButtonText;
    public float waitTime = 60f;
    
    public UnityEngine.UI.Image hintBackground;
    public Color normalColor = Color.gray;
    public Color highlightColor = new Color(1f, 0.85f, 0.3f);

    private int currentHintIndex = 0;
    private int usedCount = 0;
    private int allowedHints = 0;

    private Coroutine colorTransitionCoroutine = null;

    private List<string> hints = new List<string>()
    {
        "",

        "You might want to start by reading",
        "Numbers are everywhere. They could be telling you something",

        "Those numbers from the book might belong somewhere else",
        "The screen only listens to the right number",

        "Time's ticking! Or is it?",
        "Music videos aren't just for vibes",

        "Do the numbers on the notes feel familiar?",
    };

    private void Start()
    {
        hintText.text = "";
        hintButtonText.text = $"HINT\n{0} available";
    }

    private void Update()
    {
        float timeElapsed = Timer.instance.totalTime - Timer.instance.GetRemainingTime();
        allowedHints = Mathf.FloorToInt(timeElapsed / waitTime);
        hintButtonText.text = $"HINT\n{allowedHints - usedCount} available";
        if(allowedHints - usedCount > 0)
        {
            if (hintBackground.color != highlightColor)
            {
                if (colorTransitionCoroutine != null)
                    StopCoroutine(colorTransitionCoroutine);

                colorTransitionCoroutine = StartCoroutine(TransitionBackground(highlightColor));
            }
        }
        else
        {
            if (hintBackground.color != normalColor)
            {
                if (colorTransitionCoroutine != null)
                    StopCoroutine(colorTransitionCoroutine);

                colorTransitionCoroutine = StartCoroutine(TransitionBackground(normalColor));
            }
        }
    }

    public void ShowNextHint()
    {
        if (currentHintIndex < hints.Count)
        {
            if (usedCount < allowedHints)
            {
                // Adjust hint index based on current game progress
                if (ClueManager.instance.isBookUnlocked && currentHintIndex < 2)
                    currentHintIndex = 2;
                else if (!ClueManager.instance.isBookUnlocked && currentHintIndex > 1)
                {
                    currentHintIndex = 1;
                    usedCount--;
                }

                if (ClueManager.instance.isTVFound && currentHintIndex < 4)
                    currentHintIndex = 4;
                else if (!ClueManager.instance.isTVFound && currentHintIndex > 3)
                {
                    currentHintIndex = 3;
                    usedCount--;
                }

                if (ClueManager.instance.isPaintingUnlocked && currentHintIndex < 6)
                    currentHintIndex = 6;
                else if (!ClueManager.instance.isPaintingUnlocked && currentHintIndex > 5)
                {
                    currentHintIndex = 5;
                    usedCount--;
                }

                if (ClueManager.instance.isDrawerUnlocked && currentHintIndex < 7)
                    currentHintIndex = 7;
                else if (!ClueManager.instance.isDrawerUnlocked && currentHintIndex > 6)
                {
                    currentHintIndex = 6;
                    usedCount--;
                }

                currentHintIndex++;
                if (currentHintIndex == hints.Count)
                {
                    hintText.text = "Where are you?";
                    currentHintIndex--;
                }
                else
                {
                    hintText.text = hints[currentHintIndex];
                    usedCount++;
                }
            }
            else
            {
                hintText.text = "Wait a bit!";
                StartCoroutine(RestoreHintText(hints[currentHintIndex], 2f));
            }
        }
        else
        {
            hintText.text = "Where are you?";
        }

        Debug.Log(currentHintIndex + " " + usedCount + " " + allowedHints);
    }

    public void SetHintIndex(int index)
    {
        currentHintIndex = index;
    }

    private IEnumerator RestoreHintText(string text, float delay)
    {
        yield return new WaitForSeconds(delay);
        hintText.text = text;
    }

    private IEnumerator TransitionBackground(Color Color, float duration = 0.3f)
    {
        Color startColor = hintBackground.color;
        float t = 0f;

        while (t < 1f)
        {
            t += Time.deltaTime / duration;
            hintBackground.color = Color.Lerp(startColor, Color, t);
            yield return null;
        }

        hintBackground.color = Color;
    }
}
