using UnityEngine;
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

        if (input != "australia")
        {

            resultText.color = Color.white;
            resultText.text = "Wrong country, try again";

        }
        else
        {
            inputCanvas.SetActive(false);
            winCanvas.SetActive(true);
        }
    }

}

