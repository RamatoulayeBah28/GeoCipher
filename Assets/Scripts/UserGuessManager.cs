using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class UserGuessManager : MonoBehaviour
{
    [SerializeField] InputField inputField;
    [SerializeField] Text resultText;

    public GameObject winCanvas;
    public GameObject inputCanvas;

    public void ValidateInput() 
    {
        string input = inputField.text.Trim().ToLower();
        // Fix count
        int count = 0;

        if (input != "australia") {
            count++;
            resultText.color = Color.white;
            if (count > 2) {
                resultText.text = "Wrong guess, the correct country is Australia";
            }
            else {
                resultText.text = "Wrong country, try again";
            }
            
        }
        else
        {
            inputCanvas.SetActive(false);
            winCanvas.SetActive(true);
        }
    }

}

