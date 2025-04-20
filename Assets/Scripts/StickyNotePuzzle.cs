using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class StickyNotePuzzle : MonoBehaviour
{
    public TextMeshProUGUI[] inputSlots; 
    public GameObject inputPanel;
    public AudioSource staticAudio;

    private string correctCode = "17";
    private string userInput = "";
    private bool isInputActive = false;
    private static bool StickyNoteSolved = false;

    void Start()
    {

        if (StickyNoteSolved) 
        {
            inputPanel.SetActive(true);
            inputSlots[0].text = "<b>1</b>";
            inputSlots[1].text = "<b>7</b>";
            inputSlots[0].color = Color.green;
            inputSlots[1].color = Color.green;
            isInputActive = false;

        }
        else
        {
            inputPanel.SetActive(false);
            ResetInputs();
        }
    }

    private void OnMouseDown()
    {
        isInputActive = true;
        inputPanel.SetActive(true);
        ResetInputs();
    }

    void Update()
    {
       if (!isInputActive || userInput.Length >= 2) return;

    if (Input.anyKeyDown && Input.inputString.Length > 0)
    {
        char inputChar = Input.inputString[0];

        // without non-printable characters like Shift, Enter
        if (!char.IsControl(inputChar))
        {
            AddInput(inputChar);
        }
    }
    }

    void AddInput(char c)
    {
        userInput += c;
        inputSlots[userInput.Length - 1].text = $"<b>{c}</b>";

        if (userInput.Length == 2)
        {
            CheckCode();
        }
    }

    void CheckCode()
    {
        Color[] slotColors = new Color[2];
        bool[] matched = new bool[2];

       // checking for correct position
        for (int i = 0; i < 2; i++)
        {
            if (userInput[i] == correctCode[i])
            {
                slotColors[i] = Color.green;
                matched[i] = true;
            }
        }

        // checking for wrong position
        for (int i = 0; i < 2; i++)
        {
            if (!matched[i])
            {
                if ((userInput[i] == correctCode[0] && i != 0 && !matched[0]) ||
                    (userInput[i] == correctCode[1] && i != 1 && !matched[1]))
                {
                    slotColors[i] = new Color(1f, 0.5f, 0f); // orange color for right number wrong position
                }
                else
                {
                    slotColors[i] = Color.red; // red for wrong character
                }
            }
        }

        // applying colors
        for (int i = 0; i < 2; i++)
        {
            inputSlots[i].color = slotColors[i];
        }

        StartCoroutine(ResetAfterDelay());
    }

    IEnumerator ResetAfterDelay()
    {
        yield return new WaitForSeconds(1f);

        if (userInput == correctCode)
        {
            staticAudio.Play(); // tv static sound so the user gets a hint that the tv channel is next
            ClueManager.instance.isBookUnlocked = true;
            yield return new WaitForSeconds(2f);
            staticAudio.Stop();
            StickyNoteSolved = true;
            isInputActive = false;
        }
        else 
        {
            ResetInputs();
        }

    }

    void ResetInputs()
    {
        userInput = "";
        foreach (var slot in inputSlots)
        {
            slot.text = "_";
            slot.color = Color.black;
        }
    }

}
