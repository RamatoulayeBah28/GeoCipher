using UnityEngine;
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
            codeText.text = string.IsNullOrEmpty(codeTextValue) ? "_ _ _ _" : codeTextValue;
        }

        if (!isUnlocked && codeTextValue.Length == 4)
        {
            StartCoroutine(HandleCodeEntry());
        }
    }

    IEnumerator HandleCodeEntry()
    {

        if (codeTextValue == correctCode)
        {
            codeText.text = "CORRECT";
            codeText.color = Color.green;
            AudioManager.instance.PlayUnlocked();
            isUnlocked = true;
            ClueManager.instance.UnlockObject("Drawer");
            SceneController.instance.ChangeScene("Scenes/DrawerOpenScene");
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

    public void AddDigit(string digit)
    {
        codeTextValue += digit;
    }

    public void PressClear()
    {
        codeTextValue = "";
        codeText.text = "_ _ _ _";
    }

    public void PressDelete()
    {
        if (codeTextValue.Length > 0)
        {
            codeTextValue = codeTextValue.Substring(0, codeTextValue.Length - 1);

        }
    }
}
