using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class CodePanel : MonoBehaviour
{
    [SerializeField]
    Text codeText;
    string codeTextValue = "";
     void Start()
    {
        gameObject.SetActive(true); 
    }
    void Update()
    {
        codeText.text = codeTextValue;
        if (codeTextValue == "5510") {
            SceneController.instance.ChangeScene("Scenes/OpenDrawerScene");
        }

        if (codeTextValue.Length >= 4) {
            codeTextValue = "";
        }
    }

    public void AddDigit(string digit) {
        codeTextValue += digit;
    }
}
