using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Hints : MonoBehaviour
{
    public TextMeshProUGUI hintText;
    private int currentHintIndex = 0;

    private List<string> hints = new List<string>()
    {
        "Hint 1",
        "Hint 2",
        "Hint 3",
        "Hint 4",
        "Hint 5",
        "Hint 6",
        "Hint 7"
    };

    void Start()
    {
        hintText.text = "";
    }

    public void ShowNextHint()
    {
        Debug.Log("Hint");
        if (currentHintIndex < hints.Count)
        {
            hintText.text = hints[currentHintIndex];
            currentHintIndex++;
        }
        else
        {
            hintText.text = "No Hints!";
        }
    }

    public void SetHintIndex(int index)
    {
        currentHintIndex = index;
    }
}
