using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class UserGuessManager : MonoBehaviour
{
    [SerializeField] InputField inputField;
    [SerializeField] Text resultText;

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
            resultText.text = "Congrats, you guessed the right country!";
            resultText.color = Color.green;
        }
    }

}

