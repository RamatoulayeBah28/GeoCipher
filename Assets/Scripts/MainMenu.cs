using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    private SceneFade sceneFade;

    private void Awake()
    {
        sceneFade = GetComponentInChildren<SceneFade>();
    }

    public void PlayGame()
    {
        StartCoroutine(ShowRulesThenLoad());
    }

    public void QuitGame()
    {
        Debug.Log("Quit!");
        Application.Quit();
    }

    private IEnumerator ShowRulesThenLoad()
    {
        yield return sceneFade.FadeOutCoroutine(1f);
        yield return SceneManager.LoadSceneAsync("Scenes/IntroScene");
    }
}
