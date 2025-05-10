using UnityEngine;
using UnityEngine.UI;

public class UserGuessManager : MonoBehaviour
{
    [SerializeField] InputField inputField;
    [SerializeField] Text resultText;

    public GameObject winCanvas;
    public GameObject inputCanvas;

    public GameObject exitButton;

    // make sure it stops the time
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
            exitButton.SetActive(false);
            winCanvas.SetActive(true);
            Timer.instance.StopTimer();

        }
    }

    // destoy time on load
    public void ResetGame()
    {
        SceneController.instance.ChangeScene("Scenes/WelcomeScene");
    }

    public void QuitGame()
    {
        Debug.Log("Quit game");
        Application.Quit();
    }

}

