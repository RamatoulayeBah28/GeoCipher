using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;


public class CodePanel : MonoBehaviour
{
    private bool isUnlocked = false;
    [SerializeField]
    TextMeshProUGUI codeText;
    string codeTextValue = "";
    void Start()
    {
        gameObject.SetActive(true); 
    }
    void Update()
    {
       
        if (codeText != null)
        {
            // If codeTextValue is empty, show "Enter Code", otherwise, show the actual codeTextValue (the digits the player entered)
            codeText.text = string.IsNullOrEmpty(codeTextValue) ? "Enter Code" : codeTextValue;
        }

        if (!isUnlocked)
        {
            if (codeTextValue == "5510")
            {
                codeText.color = Color.green;
                AudioManager.instance.PlayUnlocked();
                isUnlocked = true;
                ClueManager.instance.isDrawerUnlocked = true;
                SceneController.instance.ChangeScene("Scenes/OpenDrawerScene");
            }

            if (codeTextValue.Length == 4)
            {
                codeTextValue = "";
            }
        }
    }

    public void AddDigit(string digit) {
        codeTextValue += digit;
    }

    public void PressClear()
    {
        codeTextValue = "";
        codeText.text = "Enter Code";
    }

    public void PressDelete()
    {
        if (codeTextValue.Length > 0)
        {
            codeTextValue = codeTextValue.Substring(0, codeTextValue.Length - 1);
            
        }
    }
}
