using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using System.Collections;


public class CodePanel : MonoBehaviour
{
    private bool isUnlocked = false;
    [SerializeField]
    TextMeshProUGUI codeText;
    string codeTextValue = "";
    string correctCode = "5510";
    void Start()
    {
        gameObject.SetActive(true); 
    }
    void Update()
    {
       if (codeText != null)
    {
        codeText.text = string.IsNullOrEmpty(codeTextValue) ? "Enter Code" : codeTextValue;
    }

    if (!isUnlocked && codeTextValue.Length == 4)
    {
        StartCoroutine(HandleCodeEntry());
    }
    }

    IEnumerator HandleCodeEntry()
{
    //  lets the last digit appear

    if (codeTextValue == correctCode)
    {
        codeText.text = "CORRECT";
        codeText.color = Color.green;
        AudioManager.instance.PlayUnlocked();
        isUnlocked = true;
        ClueManager.instance.isDrawerUnlocked = true;
        SceneController.instance.ChangeScene("Scenes/OpenDrawerScene");
    }
    else
    {   
        yield return new WaitForSeconds(0.1f);
        AudioManager.instance.PlayNegative();
        codeText.color = Color.red;
        codeText.text = "INCORRECT";
        yield return new WaitForSeconds(1f);
        codeText.color = Color.white;
        codeTextValue = "";
        
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
