using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

/*
Handles scene loading.

By Ramatoulaye Bah, edited by Batsambuu Batbold for the effect
*/

public class SceneController : MonoBehaviour
{
    public static SceneController instance;

    private SceneFade sceneFade;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            sceneFade = GetComponentInChildren<SceneFade>();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private IEnumerator Start()
    {
        yield return sceneFade.FadeInCoroutine(0.3f);
    }

    public void ChangeScene(string sceneName)
    {
        StartCoroutine(LoadSceneCoroutine(sceneName));
    }

    private IEnumerator LoadSceneCoroutine(string sceneName)
    {
        yield return sceneFade.FadeOutCoroutine(0.3f);
        yield return SceneManager.LoadSceneAsync(sceneName);
        yield return sceneFade.FadeInCoroutine(0.3f);
    }
}
