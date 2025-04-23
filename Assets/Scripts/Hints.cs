using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using TMPro;

public class Hints : MonoBehaviour
{
    public TextMeshProUGUI hintText;

    public float waitingTime = 60f;
    private int currentHintIndex = 0;
    private int hintsUsed = 0;

    private List<string> hints = new List<string>()
    {
        "",

        "You might want to start by reading",
        "Books have more than just stories",
        "Numbers are everywhere. They could be telling you something",
        "Is something missing in the pages?",
        "Which page number is shown… and which isn't?",

        "Those numbers from the book might belong somewhere else",
        "The screen only listens to the right number",

        "Time's ticking! Or is it?",
        "Music videos aren't just for vibes",
        "Where did you see time?",

        "Do the numbers on the notes feel familiar?",
    };

    void Start()
    {
        hintText.text = "";
    }

    public void ShowNextHint()
    {
        float timeElapsed = Timer.instance.totalTime - Timer.instance.GetRemainingTime();
        int allowedHints = Mathf.FloorToInt(timeElapsed / waitingTime);

        if (currentHintIndex < hints.Count)
        {
            if(hintsUsed < allowedHints){
                if(ClueManager.instance.isBookUnlocked && currentHintIndex < 5){
                    currentHintIndex = 5;
                } else {
                    if(!ClueManager.instance.isBookUnlocked && currentHintIndex > 4){
                        currentHintIndex = 4;
                        hintsUsed--;
                    }
                }

                if(ClueManager.instance.isTVFound && currentHintIndex < 7){
                    currentHintIndex = 7;
                } else {
                    if(!ClueManager.instance.isTVFound && currentHintIndex > 6){
                        currentHintIndex = 6;
                        hintsUsed--;
                    }
                }

                if(ClueManager.instance.isPaintingUnlocked && currentHintIndex < 10){
                    currentHintIndex = 10;
                } else {
                    if(!ClueManager.instance.isPaintingUnlocked && currentHintIndex > 9){
                        currentHintIndex = 9;
                        hintsUsed--;
                    }
                }

                if(ClueManager.instance.isDrawerUnlocked && currentHintIndex < 11){
                    currentHintIndex = 11;
                } else {
                    if(!ClueManager.instance.isDrawerUnlocked && currentHintIndex > 10){
                        currentHintIndex = 10;
                        hintsUsed--;
                    }
                }

                
                currentHintIndex++;
                if(currentHintIndex == hints.Count){
                    hintText.text = "Where are you?";
                    currentHintIndex--;
                }else{
                    hintText.text = hints[currentHintIndex];
                    hintsUsed++;
                }
                
            }
            else
            {
                hintText.text = "Wait a bit!";
                StartCoroutine(ResetHint(hints[currentHintIndex], 2f));
            }
        }
        else
        {
            hintText.text = "Where are you?";
        }
        Debug.Log(currentHintIndex + " " + hintsUsed + " " + allowedHints);
    }

    public void SetHintIndex(int index)
    {
        currentHintIndex = index;
    }

    private IEnumerator ResetHint(string text, float delay)
    {
        yield return new WaitForSeconds(delay);
        hintText.text = text;
    }
}
